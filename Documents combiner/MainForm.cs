using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Documents_combiner.Models;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using OfficeOpenXml;
using scrapingTemplateV51.Models;
using Action = System.Action;
using Application = System.Windows.Forms.Application;
using CheckBox = System.Windows.Forms.CheckBox;
using TextBox = System.Windows.Forms.TextBox;

namespace Documents_combiner
{
    public partial class MainForm : MetroForm
    {
        public bool LogToUi = true;
        public bool LogToFile = true;

        private readonly string _path = Application.StartupPath;
        private Dictionary<string, string> _config;
        //public HttpCaller HttpCaller = new HttpCaller();
        public List<List<CellProp>> AllRows = new List<List<CellProp>>();
        public List<List<CellProp>> HeaderRows = new List<List<CellProp>>();
        string _firstInputFilesName;
        int _maxSheetPerDoc;
        private bool _EmptyFileIsFounded;
        private int _maxLinesPerSheet;
        int _columnsNbr;
        private int _headerLines;
        private int _emptyInputsDocsCount;

        public MainForm()
        {
            InitializeComponent();
        }


        private async Task MainWork()
        {
            var toBeContinued = CheckEntries();
            if (!toBeContinued)
            {
                return;
            }
            var inputFiles = Directory.GetFiles(inputI.Text, "*").Select(fn => new FileInfo(fn)).
                OrderBy(f => f.Name).ToList();
            if (inputFiles.Count.Equals(0))
            {
                //Invoke(new Action(() => MessageBox.Show(@"There are no populated documents in the input folder selected ")));
                MessageBox.Show(@"There are no populated documents in the input folder selected");
                return;
            }

            if (CombineOptionsI.SelectedIndex == 0)
            {
                inputFiles = Directory.GetFiles(inputI.Text, "*").Select(fn => new FileInfo(fn))
                    .OrderByDescending(f => f.LastWriteTime).ToList();
            }
            if (CombineOptionsI.SelectedIndex == 1)
            {
                inputFiles = Directory.GetFiles(inputI.Text, "*").Select(fn => new FileInfo(fn)).
                    OrderBy(f => f.LastWriteTime).ToList();
            }
            if (CombineOptionsI.SelectedIndex == 3)
            {
                inputFiles = Directory.GetFiles(inputI.Text, "*").Select(fn => new FileInfo(fn)).
                    OrderByDescending(f => f.Name).ToList();
            }
            _firstInputFilesName = inputFiles[0].FullName;
            if (HeadersRowsNbr.Text != @"0")
            {
                var areHeadersCorrect = AddHeaders(inputFiles);
                if (!areHeadersCorrect)
                {
                    return;
                }
            }
            Display(@"reading first file...");
            await Task.Run(() => CheckTheFirstDocFirstRow(inputFiles[0]));
            await Task.Run(() => StartProcessing(inputFiles)).ConfigureAwait(false);


        }

        private async Task CheckTheFirstDocFirstRow(FileInfo file
        )
        {
            if (file.Name.EndsWith(".csv"))
                await CheckCsvHeaders(file.FullName);
            else
                await CheckExcelHeaders(file.FullName);
        }

        private async Task CheckExcelHeaders(string fileName)
        {
            //fileName = "C:\\Users\\BILEL\\Desktop\\files\\x.xlsx";
            ExcelPackage package;
            if (fileName.EndsWith(".xlsx"))
            {
                package = GetExcelPackage(fileName, true);
            }
            else
            {
                ConvertXLS_XLSX(fileName);
                FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                //file.Dispose();
                const int MAX_BUFFER = 1048576;
                int read = 0;
                byte[] buffer = new byte[MAX_BUFFER];
                int bytesRead;
                BufferedStream bs = new BufferedStream(file);
                while ((bytesRead = bs.Read(buffer, 0, MAX_BUFFER)) != 0)
                {
                    read = read + bytesRead;
                    SetProgress((read * 1.0 / file.Length) * 100);
                }
                package = new ExcelPackage(bs);
            }

            ExcelWorksheets workSheets;
            try
            {
                workSheets = package.Workbook.Worksheets;
            }
            catch (Exception)
            {
                try
                {

                    package.Dispose();
                    var app = new Microsoft.Office.Interop.Excel.Application { DisplayAlerts = false };
                    var wb = app.Workbooks.Open(fileName);
                    wb.SaveAs(fileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                    wb.Close();
                    app.Quit();
                    package = new ExcelPackage(new FileInfo(fileName));
                    workSheets = package.Workbook.Worksheets;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Can not Convert file {fileName.Substring(fileName.LastIndexOf('\\') + 1)} It appears the Input file is formatted in a format that is different from its .extension");
                }

            }
            var rows = new List<List<CellProp>>();
            foreach (var workSheet in workSheets)
            {
                if (workSheet.Dimension == null)
                {
                    Invoke(new Action(() => MessageBox.Show(@"Warning: The First document's First Row(s) >Header(s)< are empty")));
                    return;
                }
                for (int row = 1; row <= workSheet.Dimension.End.Row; row++)
                {
                    var line = new List<CellProp>();
                    for (var column = 1; column <= workSheet.Dimension.End.Column; column++)
                    {
                        var cell = new CellProp
                        {
                            Value = workSheet.Cells[row, column].Value?.ToString().Trim(),
                        };

                        line.Add(cell);
                    }
                    rows.Add(line);
                    break;
                }
                break;
            }
            package.Dispose();
            var headersIsEmpty = rows.Any(x => x.Any(y => y.Value != null));
            if (!headersIsEmpty)
            {
                Invoke(new Action(() => MessageBox.Show(@"Warning: The First document's First Row(s) >Header(s)< are empty")));
            }
            File.Delete(fileName + "x");
        }

        private async Task CheckCsvHeaders(string fileName)
        {
            char[] separators = { '\t', ';', ',' };
            var lines = File.ReadAllLines(fileName).ToList();
            if (lines.Count == 0)
            {
                Invoke(new Action(() => MessageBox.Show(@"Warning: The First document's First Row(s) >Header(s)< are empty")));
                return;
            }
            var separator = ' ';
            var separatorIsFound = false;
            foreach (var line in lines)
            {
                foreach (var ch in separators)
                {
                    if (line.Contains(ch))
                    {
                        separator = ch;
                        separatorIsFound = true;
                        break;
                    }
                }

                if (separatorIsFound)
                {
                    break;
                }
            }

            var chars = lines[0].Split(separator).ToList();
            var headersIsMissed = chars.Any(string.IsNullOrEmpty);
            if (headersIsMissed)
            {
                Invoke(new Action(() => MessageBox.Show(@"Warning: The First document's First Row(s) >Header(s)< are empty")));
            }

        }

        private async void StartProcessing(List<FileInfo> inputFiles)
        {
            SetProgress(0);
            var fileNbr = 1;
            foreach (var file in inputFiles)
            {
                Display($@"we are working on {file.FullName} file");
                if (file.Name.EndsWith(".csv"))
                    CsvHandler(file.FullName);
                if (file.Name.EndsWith(".xlsx") || file.Name.EndsWith(".xls"))
                    ExcelHandler(file.FullName);
                SetProgress((fileNbr * 100) / inputFiles.Count);
                fileNbr++;
            }
            await Task.Run(MainWriter).ConfigureAwait(false);
            Display("Work done");
        }

        private bool CheckEntries()
        {
            try
            {
                int.Parse(MaxSheetPerDocumentTxt.Text);
            }
            catch (Exception)
            {
                //Invoke(new Action(() => MessageBox.Show(@"Please enter a digit characters in ""Max sheets per document"" field")));
                MessageBox.Show(@"Please enter a digit characters in ""Max sheets per document"" field");
                return false;
            }

            var maxSheetNbr = int.Parse(MaxSheetPerDocumentTxt.Text);
            if (maxSheetNbr > 50)
            {
                //Invoke(new Action(() => MessageBox.Show(@"The maximum number of sheets per document is 50")));
                MessageBox.Show(@"The maximum number of sheets per document is 50");
                return false;
            }


            if (_maxLinesPerSheet >= 1000000)
            {
                Invoke(new Action(() => MessageBox.Show(@"The maximum number of lines per sheet is less than 1 million")));
                //MessageBox.Show(@"The maximum number of lines per sheet is less than 1 million");
                return false;
            }

            return true;
        }

        private void CsvHandler(string fileName)
        {
            char[] separators = { '\t', ';', ',' };
            var lines = File.ReadAllLines(fileName).ToList();
            if (_headerLines > 0)
            {
                var removeAt = _headerLines - 1;
                lines.RemoveAt(removeAt);
            }
            var separatorIsFound = false;
            var separator = ' ';
            foreach (var newLine in lines)
            {
                foreach (var ch in separators)
                {
                    if (newLine.Contains(ch))
                    {
                        separator = ch;
                        separatorIsFound = true;
                        break;
                    }

                    if (separatorIsFound)
                    {
                        break;
                    }
                }

                var values = newLine.Split(separator).ToList();
                var row = new List<CellProp>();
                foreach (var ch in values)
                {
                    row.Add(new CellProp { Value = ch });
                }

                var checkIfEmptyFile = row.Any(x => x.Value != null);
                if (!checkIfEmptyFile || row.Count == 1)
                {
                    if (!_EmptyFileIsFounded)
                    {
                        _EmptyFileIsFounded = true;
                        Invoke(new Action(() => MessageBox.Show(@"/Warning: One or more Input documents contain NO Data Rows")));
                    }
                }
                else
                {
                    AllRows.Add(row);
                }
            }

        }
        private void ExcelHandler(string fileName)
        {
            ExcelPackage package;
            if (fileName.EndsWith(".xlsx"))
            {
                package = GetExcelPackage(fileName, false);
            }
            else
            {
                ConvertXLS_XLSX(fileName);
                package = new ExcelPackage(new FileInfo(fileName + "x"));
            }

            ExcelWorksheets workSheets;
            try
            {
                workSheets = package.Workbook.Worksheets;
            }
            catch (Exception)
            {
                throw new ApplicationException($"Can not Convert file {fileName.Substring(fileName.LastIndexOf('\\') + 1)} It appears the Input file is formatted in a format that is different from its .extension");

            }

            var rows = new List<List<CellProp>>();
            foreach (var workSheet in workSheets)
            {
                if (workSheet.Dimension == null)
                {
                    continue;
                }
                for (int row = _headerLines + 1; row <= workSheet.Dimension.End.Row; row++)
                {
                    var line = new List<CellProp>();
                    for (var column = 1; column <= workSheet.Dimension.End.Column; column++)
                    {
                        var cell = new CellProp
                        {
                            Value = workSheet.Cells[row, column].Value?.ToString().Trim(),
                            ExcelStyle = workSheet.Cells[row, column].Style
                        };
                        var x = workSheet.Cells[row, column].Style.Fill.BackgroundColor.Rgb;

                        line.Add(cell);
                    }
                    rows.Add(line);
                }
            }

            var checkIfEmptyFile = rows.Any(x => x.Any(y => y.Value != null));
            if (!checkIfEmptyFile || (checkIfEmptyFile && rows.Count == 1))
            {
                if (!_EmptyFileIsFounded)
                {
                    _EmptyFileIsFounded = true;
                    Invoke(new Action(() => MessageBox.Show(@"Warning: One or more Input documents contain NO Data Rows")));
                }
            }
            else
                AllRows.AddRange(rows);
            File.Delete(fileName + "x");

            //SaveExcel();
        }

        private ExcelPackage GetExcelPackage(string fileName, bool forHeaders)
        {
            ExcelPackage package;
            do
            {
                var checkIfFileOpen = IsFileOpen(fileName);
                if (!checkIfFileOpen)
                {
                    break;
                }
                Invoke(new Action(() => MessageBox.Show($@"Please close this file ""{fileName}"" for processing it")));
            } while (true);


            FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //file.Dispose();
            const int MAX_BUFFER = 1048576; //1MB 
            int read = 0;
            byte[] buffer = new byte[MAX_BUFFER];
            int bytesRead;
            BufferedStream bs = new BufferedStream(file);
            if (forHeaders)
            {
                while ((bytesRead = bs.Read(buffer, 0, MAX_BUFFER)) != 0)
                {
                    read = read + bytesRead;
                    SetProgress((read * 1.0 / file.Length) * 100);
                }
            }
            package = new ExcelPackage(bs);
            return package;
        }
        bool IsFileOpen(string filePath)
        {
            bool isOpen = false;
            try
            {
                using (var fs = File.OpenWrite(filePath))
                {

                }
            }
            catch (IOException)
            {
                isOpen = true;
            }
            return isOpen;
        }
        //private async Task SaveExcel()
        //{
        //    Display($@"Saving Output document(s)...");
        //    await MainWriter();
        //}

        private async Task MainWriter()
        {
            SetProgress(0);
            var docsCount = AllRows.Count / (_maxSheetPerDoc * _maxLinesPerSheet);
            if (AllRows.Count % (_maxSheetPerDoc * _maxLinesPerSheet) != 0)
                docsCount++;
            var fileNbr = 1;
            for (int i = 0; i < docsCount; i++)
            {
                Display($"Writing file {i + 1} / {docsCount}");
                var docName = "" + (i + 1);
                var temp = AllRows.Take((_maxSheetPerDoc * _maxLinesPerSheet)).ToList();
                AllRows.RemoveRange(0, temp.Count);
                temp.InsertRange(0, HeaderRows);
                await WriteDoc(temp, docName).ConfigureAwait(false);
                // Invoke(new Action(() => SetProgress((fileNbr * 100 / docsCount))));
                SetProgress((fileNbr * 100 / docsCount));
                fileNbr++;
            }
        }
        private async Task WriteDoc(List<List<CellProp>> values, string docName)
        {
            var unixTimestamp = DateTime.Now.TimeOfDay.TotalSeconds.ToString(CultureInfo.InvariantCulture);
            var outPutPath = _firstInputFilesName.Replace(inputI.Text, outputI.Text).Replace(".xlsx", "").Replace("xls", "");
            var excelPackage = new ExcelPackage(new FileInfo(outPutPath + " " + unixTimestamp + " " + docName + ".xlsx"));

            for (var i = 0; i < _maxSheetPerDoc; i++)
            {
                if (values.Count == 0)
                {
                    return;
                }
                var sheet = excelPackage.Workbook.Worksheets.Add(@"Sheet " + (i + 1));
                var temp = values.Take(int.Parse(MaxLinesPerSheetTxt.Text)).ToList();
                if (i + 1 == 1)
                {
                    temp = values.Take(int.Parse(MaxLinesPerSheetTxt.Text) + HeaderRows.Count).ToList();
                }
                values.RemoveRange(0, temp.Count);
                if (i + 1 > 1 && _headerLines > 0)
                {
                    temp.InsertRange(0, HeaderRows);
                }
                WriteSheet(temp, sheet); //nothing IO on this
                await excelPackage.SaveAsync(); //sab resharper bil isim
            }
            if (values.Count % _maxSheetPerDoc != 0)
            {
                var sheet = excelPackage.Workbook.Worksheets.Add(@"Sheet " + (_maxSheetPerDoc + 1));
                values.InsertRange(0, HeaderRows);
                WriteSheet(values, sheet);
                await excelPackage.SaveAsync(); //this instruction only can be called saving file and its IO , this is why we put async
            }
        }

        private void WriteSheet(List<List<CellProp>> values, ExcelWorksheet sheet)
        {
            var indexRow = 1;

            for (var row = 0; row < values.Count; row++)
            {
                for (var column = 1; column <= values[row].Count; column++)
                {
                    sheet.Cells[indexRow, column].Value = values[row][column - 1].Value;
                    try
                    {
                        if (values[row][column - 1].ExcelStyle != null)
                        {
                            sheet.Cells[indexRow, column].Style.Font.Italic = values[row][column - 1].ExcelStyle.Font.Italic;
                            sheet.Cells[indexRow, column].Style.Font.Bold = values[row][column - 1].ExcelStyle.Font.Bold;
                            sheet.Cells[indexRow, column].Style.Font.Strike = values[row][column - 1].ExcelStyle.Font.Strike;
                            sheet.Cells[indexRow, column].Style.Font.UnderLine = values[row][column - 1].ExcelStyle.Font.UnderLine;
                        }
                    }
                    catch (Exception)
                    {

                    }

                    if (MatchFormatting.Checked)
                    {
                        if (!string.IsNullOrEmpty(values[row][column - 1].ExcelStyle.Fill.BackgroundColor.Rgb))
                        {
                            sheet.Cells[indexRow, column].Style.Fill.PatternType = values[row][column - 1].ExcelStyle.Fill.PatternType;
                            sheet.Cells[indexRow, column].Style.Fill.BackgroundColor
                                .SetColor(ColorTranslator.FromHtml("#" + values[row][column - 1]
                                    .ExcelStyle.Fill.BackgroundColor.Rgb));
                            sheet.Cells[indexRow, column].Style.Fill.BackgroundColor.Tint = 0;
                        }
                    }
                }

                indexRow++;
            }
        }
        public static void ConvertXLSX_XLS(string fileName)
        {
            var file = new FileInfo(fileName);
            var app = new Microsoft.Office.Interop.Excel.Application();
            var xlsFile = file.FullName;
            var wb = app.Workbooks.Open(xlsFile);
            var xlsxFile = xlsFile.Replace("xlsx", "xls");
            wb.SaveAs(xlsxFile, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
            wb.Close();
            File.Delete(fileName);
        }
        public static string ConvertXLS_XLSX(string fileName)
        {
            var file = new FileInfo(fileName);
            var app = new Microsoft.Office.Interop.Excel.Application();
            var xlsFile = file.FullName;
            var wb = app.Workbooks.Open(xlsFile);
            var xlsxFile = xlsFile + "x";
            wb.SaveAs(xlsxFile, XlFileFormat.xlOpenXMLWorkbook);
            wb.Close();
            return xlsxFile;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ServicePointManager.DefaultConnectionLimit = 65000;
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            inputI.Text = _path + @"\input.txt";
            outputI.Text = _path + @"\output.csv";
            LoadConfig();

            var combineOptions = new List<string>
            {
                "Date: New to Old",
                "Date: Old to New",
                "Name: A to Z",
                "Name: Z to A",
            };
            foreach (var combineOption in combineOptions)
            {
                CombineOptionsI.Items.Add(combineOption);
            }
            var headersRows = new List<string>
            {
                "0",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10"
            };
            foreach (var headersRow in headersRows)
            {
                HeadersRowsNbr.Items.Add(headersRow);
            }

            HeadersRowsNbr.SelectedIndex = 0;
            CombineOptionsI.SelectedIndex = 2;
        }

        void InitControls(Control parent)
        {
            try
            {
                foreach (Control x in parent.Controls)
                {
                    try
                    {
                        if (x.Name.EndsWith("I"))
                        {
                            switch (x)
                            {
                                case MetroCheckBox _:
                                case CheckBox _:
                                    ((CheckBox)x).Checked = bool.Parse(_config[((CheckBox)x).Name]);
                                    break;
                                case RadioButton radioButton:
                                    radioButton.Checked = bool.Parse(_config[radioButton.Name]);
                                    break;
                                case TextBox _:
                                case RichTextBox _:
                                case MetroTextBox _:
                                    x.Text = _config[x.Name];
                                    break;
                                case NumericUpDown numericUpDown:
                                    numericUpDown.Value = int.Parse(_config[numericUpDown.Name]);
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                    InitControls(x);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void SaveControls(Control parent)
        {
            try
            {
                foreach (Control x in parent.Controls)
                {
                    #region Add key value to disctionarry

                    if (x.Name.EndsWith("I"))
                    {
                        switch (x)
                        {
                            case MetroCheckBox _:
                            case RadioButton _:
                            case CheckBox _:
                                _config.Add(x.Name, ((CheckBox)x).Checked + "");
                                break;
                            case TextBox _:
                            case RichTextBox _:
                            case MetroTextBox _:
                                _config.Add(x.Name, x.Text);
                                break;
                            case NumericUpDown _:
                                _config.Add(x.Name, ((NumericUpDown)x).Value + "");
                                break;
                            default:
                                Console.WriteLine(@"could not find a type for " + x.Name);
                                break;
                        }
                    }
                    #endregion
                    SaveControls(x);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void SaveConfig()
        {
            _config = new Dictionary<string, string>();
            SaveControls(this);
            try
            {
                File.WriteAllText("config.txt", JsonConvert.SerializeObject(_config, Formatting.Indented));
            }
            catch (Exception e)
            {
                ErrorLog(e.ToString());
            }
        }
        private void LoadConfig()
        {
            try
            {
                _config = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("config.txt"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
            InitControls(this);
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(), @"Unhandled Thread Exception");
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show((e.ExceptionObject as Exception)?.ToString(), @"Unhandled UI Exception");
        }
        #region UIFunctions
        public delegate void WriteToLogD(string s, Color c);
        public void WriteToLog(string s, Color c)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new WriteToLogD(WriteToLog), s, c);
                    return;
                }
                if (LogToUi)
                {
                    if (DebugT.Lines.Length > 5000)
                    {
                        DebugT.Text = "";
                    }
                    DebugT.SelectionStart = DebugT.Text.Length;
                    DebugT.SelectionColor = c;
                    DebugT.AppendText(DateTime.Now.ToString(Utility.SimpleDateFormat) + " : " + s + Environment.NewLine);
                }
                Console.WriteLine(DateTime.Now.ToString(Utility.SimpleDateFormat) + @" : " + s);
                if (LogToFile)
                {
                    File.AppendAllText(_path + "/data/log.txt", DateTime.Now.ToString(Utility.SimpleDateFormat) + @" : " + s + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void NormalLog(string s)
        {
            WriteToLog(s, Color.Black);
        }
        public void ErrorLog(string s)
        {
            WriteToLog(s, Color.Red);
        }
        public void SuccessLog(string s)
        {
            WriteToLog(s, Color.Green);
        }
        public void CommandLog(string s)
        {
            WriteToLog(s, Color.Blue);
        }

        //this take care of multithreading access to controls
        public delegate void SetProgressD(double x);
        public void SetProgress(double x)
        {
            if (InvokeRequired)
            {
                Invoke(new SetProgressD(SetProgress), x);
                return;
            }
            if ((x <= 100))
            {
                ProgressB.Value = Convert.ToInt32(x);
            }

        }
        public delegate void DisplayD(string s);
        public void Display(string s)
        {
            if (InvokeRequired)
            {
                Invoke(new DisplayD(Display), s);
                return;
            }
            displayT.Text = s;
        }

        #endregion
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }
        private void loadInputB_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog o = new FolderBrowserDialog { SelectedPath = _path };
            if (o.ShowDialog() == DialogResult.OK)
            {
                inputI.Text = o.SelectedPath;
            }
        }
        private void openInputB_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process.Start(inputI.Text);
            }
            catch (Exception ex)
            {
                ErrorLog(ex.ToString());
            }
        }
        private void openOutputB_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process.Start(outputI.Text);
            }
            catch (Exception ex)
            {
                ErrorLog(ex.ToString());
            }
        }
        private void loadOutputB_Click_1(object sender, EventArgs e)
        {


            FolderBrowserDialog o = new FolderBrowserDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                outputI.Text = o.SelectedPath;
            }
        }

        private async void startB_Click_1(object sender, EventArgs e)
        {
            AllRows = new List<List<CellProp>>();
            HeaderRows = new List<List<CellProp>>();
            _EmptyFileIsFounded = false;
            if (!Directory.Exists(inputI.Text))
            {
                MessageBox.Show(@"Can not find the input file selected");
                return;
            }
            if (!Directory.Exists(outputI.Text))
            {
                MessageBox.Show(@"Can not find the Output folder selected");
                return;
            }
            if (inputI.Text == outputI.Text)
            {
                MessageBox.Show(@"You can not select the same folder to be both the Input and Output");
                return;
            }
            try
            {
                _maxSheetPerDoc = int.Parse(MaxSheetPerDocumentTxt.Text);
            }
            catch (Exception)
            {

                MessageBox.Show(@"Please put a digit character in ""Max sheets per document"" field");
                return;
            }

            try
            {
                _maxLinesPerSheet = int.Parse(MaxLinesPerSheetTxt.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Please put a digit character in ""Max lines per sheet"" field");
                return;
            }
            _headerLines = int.Parse(HeadersRowsNbr.Text);
            AllRows = new List<List<CellProp>>();
            try
            {
                await MainWork();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool AddHeaders(List<FileInfo> inputFiles)
        {
            var path = _firstInputFilesName.Substring(_firstInputFilesName.LastIndexOf('\\') + 1);
            ExcelPackage package;
            if (_firstInputFilesName.EndsWith(".xlsx"))
            {
                package = new ExcelPackage(new FileInfo(_firstInputFilesName));
            }
            else
            {
                ConvertXLS_XLSX(_firstInputFilesName);
                package = new ExcelPackage(new FileInfo(_firstInputFilesName + "x"));
            }
            ExcelWorksheet workSheet;
            try
            {
                workSheet = package.Workbook.Worksheets.First();
            }
            catch (Exception)
            {
                try
                {

                    package.Dispose();
                    var app = new Microsoft.Office.Interop.Excel.Application { DisplayAlerts = false };
                    var wb = app.Workbooks.Open(_firstInputFilesName);
                    wb.SaveAs(_firstInputFilesName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                    wb.Close();
                    app.Quit();
                    package = new ExcelPackage(new FileInfo(_firstInputFilesName));
                    workSheet = package.Workbook.Worksheets.First();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Can not Convert file {_firstInputFilesName.Substring(_firstInputFilesName.LastIndexOf('\\') + 1)} the first file is wit unexpected format");
                }

            }

            if (workSheet.Dimension != null)
            {
                if (_headerLines > workSheet.Dimension.End.Row)
                {
                    MessageBox.Show(@"You have selected  more header rows, than total rows in existence");
                    return false;
                }
                _columnsNbr = workSheet.Dimension.End.Column;
                if (_columnsNbr > 10000)
                {
                    MessageBox.Show(@"Please select a file with less than 10,000 columns");
                    return false;
                }
                for (int i = 1; i <= _headerLines; i++)
                {
                    var row = new List<CellProp>();
                    for (var j = 1; j <= workSheet.Dimension.End.Column; j++)
                    {
                        var cellProp = new CellProp
                        {
                            Value = workSheet.Cells[i, j].Value?.ToString().Trim(),
                            ExcelStyle = workSheet.Cells[i, j].Style
                        };
                        row.Add(cellProp);
                    }
                    HeaderRows.Add(row);
                }

                var checkIfNull = HeaderRows.Any(x => x.Any(y => y.Value != null));
                if (!checkIfNull)
                {
                    Invoke(new Action(() =>
                        MessageBox.Show(@"Warning: The First document's First Row(s) Header(s) are empty")));
                }
            }
            package.Dispose();
            File.Delete(_firstInputFilesName + "x");

            return true;
        }

        private void outputI_Click(object sender, EventArgs e)
        {

        }
    }
}