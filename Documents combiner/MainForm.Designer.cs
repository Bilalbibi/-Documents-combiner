
namespace Documents_combiner
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.HeadersRowsNbr = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MatchFormatting = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CombineOptionsI = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MaxSheetPerDocumentTxt = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MaxLinesPerSheetTxt = new MetroFramework.Controls.MetroTextBox();
            this.ProgressB = new System.Windows.Forms.ProgressBar();
            this.displayT = new System.Windows.Forms.Label();
            this.startB = new MetroFramework.Controls.MetroButton();
            this.loadOutputB = new MetroFramework.Controls.MetroButton();
            this.loadInputB = new MetroFramework.Controls.MetroButton();
            this.outputI = new MetroFramework.Controls.MetroTextBox();
            this.inputI = new MetroFramework.Controls.MetroTextBox();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.DebugT = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(941, 554);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroTabControl1.TabIndex = 16;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabControl1.UseSelectable = true;
            this.metroTabControl1.UseStyleColors = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.metroTabPage1.Controls.Add(this.panel2);
            this.metroTabPage1.ForeColor = System.Drawing.Color.Black;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 0;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(933, 509);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Options";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.HeadersRowsNbr);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.MatchFormatting);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.CombineOptionsI);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.MaxSheetPerDocumentTxt);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.MaxLinesPerSheetTxt);
            this.panel2.Controls.Add(this.ProgressB);
            this.panel2.Controls.Add(this.displayT);
            this.panel2.Controls.Add(this.startB);
            this.panel2.Controls.Add(this.loadOutputB);
            this.panel2.Controls.Add(this.loadInputB);
            this.panel2.Controls.Add(this.outputI);
            this.panel2.Controls.Add(this.inputI);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(933, 509);
            this.panel2.TabIndex = 14;
            // 
            // HeadersRowsNbr
            // 
            this.HeadersRowsNbr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeadersRowsNbr.FormattingEnabled = true;
            this.HeadersRowsNbr.Location = new System.Drawing.Point(341, 234);
            this.HeadersRowsNbr.Name = "HeadersRowsNbr";
            this.HeadersRowsNbr.Size = new System.Drawing.Size(87, 23);
            this.HeadersRowsNbr.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(144, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "Match Formatting:";
            // 
            // MatchFormatting
            // 
            this.MatchFormatting.AutoSize = true;
            this.MatchFormatting.Location = new System.Drawing.Point(341, 276);
            this.MatchFormatting.Name = "MatchFormatting";
            this.MatchFormatting.Size = new System.Drawing.Size(15, 14);
            this.MatchFormatting.TabIndex = 34;
            this.MatchFormatting.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(144, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "Number of header rows:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(144, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "Combine document by:";
            // 
            // CombineOptionsI
            // 
            this.CombineOptionsI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CombineOptionsI.FormattingEnabled = true;
            this.CombineOptionsI.Location = new System.Drawing.Point(341, 143);
            this.CombineOptionsI.Name = "CombineOptionsI";
            this.CombineOptionsI.Size = new System.Drawing.Size(118, 23);
            this.CombineOptionsI.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(144, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "Max sheets per document:";
            // 
            // MaxSheetPerDocumentTxt
            // 
            // 
            // 
            // 
            this.MaxSheetPerDocumentTxt.CustomButton.Image = null;
            this.MaxSheetPerDocumentTxt.CustomButton.Location = new System.Drawing.Point(96, 1);
            this.MaxSheetPerDocumentTxt.CustomButton.Name = "";
            this.MaxSheetPerDocumentTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.MaxSheetPerDocumentTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.MaxSheetPerDocumentTxt.CustomButton.TabIndex = 1;
            this.MaxSheetPerDocumentTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.MaxSheetPerDocumentTxt.CustomButton.UseSelectable = true;
            this.MaxSheetPerDocumentTxt.CustomButton.Visible = false;
            this.MaxSheetPerDocumentTxt.Lines = new string[] {
        "10"};
            this.MaxSheetPerDocumentTxt.Location = new System.Drawing.Point(341, 205);
            this.MaxSheetPerDocumentTxt.MaxLength = 32767;
            this.MaxSheetPerDocumentTxt.Name = "MaxSheetPerDocumentTxt";
            this.MaxSheetPerDocumentTxt.PasswordChar = '\0';
            this.MaxSheetPerDocumentTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.MaxSheetPerDocumentTxt.SelectedText = "";
            this.MaxSheetPerDocumentTxt.SelectionLength = 0;
            this.MaxSheetPerDocumentTxt.SelectionStart = 0;
            this.MaxSheetPerDocumentTxt.ShortcutsEnabled = true;
            this.MaxSheetPerDocumentTxt.Size = new System.Drawing.Size(118, 23);
            this.MaxSheetPerDocumentTxt.Style = MetroFramework.MetroColorStyle.Orange;
            this.MaxSheetPerDocumentTxt.TabIndex = 28;
            this.MaxSheetPerDocumentTxt.Text = "10";
            this.MaxSheetPerDocumentTxt.UseSelectable = true;
            this.MaxSheetPerDocumentTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.MaxSheetPerDocumentTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(144, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Max lines per sheet:";
            // 
            // MaxLinesPerSheetTxt
            // 
            // 
            // 
            // 
            this.MaxLinesPerSheetTxt.CustomButton.Image = null;
            this.MaxLinesPerSheetTxt.CustomButton.Location = new System.Drawing.Point(96, 1);
            this.MaxLinesPerSheetTxt.CustomButton.Name = "";
            this.MaxLinesPerSheetTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.MaxLinesPerSheetTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.MaxLinesPerSheetTxt.CustomButton.TabIndex = 1;
            this.MaxLinesPerSheetTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.MaxLinesPerSheetTxt.CustomButton.UseSelectable = true;
            this.MaxLinesPerSheetTxt.CustomButton.Visible = false;
            this.MaxLinesPerSheetTxt.Lines = new string[] {
        "300000"};
            this.MaxLinesPerSheetTxt.Location = new System.Drawing.Point(341, 172);
            this.MaxLinesPerSheetTxt.MaxLength = 32767;
            this.MaxLinesPerSheetTxt.Name = "MaxLinesPerSheetTxt";
            this.MaxLinesPerSheetTxt.PasswordChar = '\0';
            this.MaxLinesPerSheetTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.MaxLinesPerSheetTxt.SelectedText = "";
            this.MaxLinesPerSheetTxt.SelectionLength = 0;
            this.MaxLinesPerSheetTxt.SelectionStart = 0;
            this.MaxLinesPerSheetTxt.ShortcutsEnabled = true;
            this.MaxLinesPerSheetTxt.Size = new System.Drawing.Size(118, 23);
            this.MaxLinesPerSheetTxt.Style = MetroFramework.MetroColorStyle.Orange;
            this.MaxLinesPerSheetTxt.TabIndex = 26;
            this.MaxLinesPerSheetTxt.Text = "300000";
            this.MaxLinesPerSheetTxt.UseSelectable = true;
            this.MaxLinesPerSheetTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.MaxLinesPerSheetTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ProgressB
            // 
            this.ProgressB.Location = new System.Drawing.Point(3, 482);
            this.ProgressB.Name = "ProgressB";
            this.ProgressB.Size = new System.Drawing.Size(920, 14);
            this.ProgressB.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressB.TabIndex = 25;
            // 
            // displayT
            // 
            this.displayT.AutoSize = true;
            this.displayT.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayT.ForeColor = System.Drawing.Color.Black;
            this.displayT.Location = new System.Drawing.Point(13, 453);
            this.displayT.Name = "displayT";
            this.displayT.Size = new System.Drawing.Size(91, 16);
            this.displayT.TabIndex = 24;
            this.displayT.Text = "Bot Started";
            // 
            // startB
            // 
            this.startB.Location = new System.Drawing.Point(366, 380);
            this.startB.Name = "startB";
            this.startB.Size = new System.Drawing.Size(111, 43);
            this.startB.Style = MetroFramework.MetroColorStyle.Orange;
            this.startB.TabIndex = 23;
            this.startB.Text = "Start";
            this.startB.UseSelectable = true;
            this.startB.UseStyleColors = true;
            this.startB.Click += new System.EventHandler(this.startB_Click_1);
            // 
            // loadOutputB
            // 
            this.loadOutputB.Location = new System.Drawing.Point(147, 110);
            this.loadOutputB.Name = "loadOutputB";
            this.loadOutputB.Size = new System.Drawing.Size(111, 23);
            this.loadOutputB.Style = MetroFramework.MetroColorStyle.Orange;
            this.loadOutputB.TabIndex = 23;
            this.loadOutputB.Text = "Output File";
            this.loadOutputB.UseSelectable = true;
            this.loadOutputB.UseStyleColors = true;
            this.loadOutputB.Click += new System.EventHandler(this.loadOutputB_Click_1);
            // 
            // loadInputB
            // 
            this.loadInputB.Location = new System.Drawing.Point(147, 70);
            this.loadInputB.Name = "loadInputB";
            this.loadInputB.Size = new System.Drawing.Size(111, 23);
            this.loadInputB.Style = MetroFramework.MetroColorStyle.Orange;
            this.loadInputB.TabIndex = 22;
            this.loadInputB.Text = "Input File";
            this.loadInputB.UseSelectable = true;
            this.loadInputB.UseStyleColors = true;
            this.loadInputB.Click += new System.EventHandler(this.loadInputB_Click_1);
            // 
            // outputI
            // 
            // 
            // 
            // 
            this.outputI.CustomButton.Image = null;
            this.outputI.CustomButton.Location = new System.Drawing.Point(399, 1);
            this.outputI.CustomButton.Name = "";
            this.outputI.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.outputI.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.outputI.CustomButton.TabIndex = 1;
            this.outputI.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.outputI.CustomButton.UseSelectable = true;
            this.outputI.CustomButton.Visible = false;
            this.outputI.Lines = new string[0];
            this.outputI.Location = new System.Drawing.Point(341, 110);
            this.outputI.MaxLength = 32767;
            this.outputI.Name = "outputI";
            this.outputI.PasswordChar = '\0';
            this.outputI.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.outputI.SelectedText = "";
            this.outputI.SelectionLength = 0;
            this.outputI.SelectionStart = 0;
            this.outputI.ShortcutsEnabled = true;
            this.outputI.Size = new System.Drawing.Size(421, 23);
            this.outputI.Style = MetroFramework.MetroColorStyle.Orange;
            this.outputI.TabIndex = 21;
            this.outputI.UseSelectable = true;
            this.outputI.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.outputI.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.outputI.Click += new System.EventHandler(this.outputI_Click);
            // 
            // inputI
            // 
            // 
            // 
            // 
            this.inputI.CustomButton.Image = null;
            this.inputI.CustomButton.Location = new System.Drawing.Point(399, 1);
            this.inputI.CustomButton.Name = "";
            this.inputI.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.inputI.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputI.CustomButton.TabIndex = 1;
            this.inputI.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputI.CustomButton.UseSelectable = true;
            this.inputI.CustomButton.Visible = false;
            this.inputI.Lines = new string[0];
            this.inputI.Location = new System.Drawing.Point(341, 70);
            this.inputI.MaxLength = 32767;
            this.inputI.Name = "inputI";
            this.inputI.PasswordChar = '\0';
            this.inputI.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputI.SelectedText = "";
            this.inputI.SelectionLength = 0;
            this.inputI.SelectionStart = 0;
            this.inputI.ShortcutsEnabled = true;
            this.inputI.Size = new System.Drawing.Size(421, 23);
            this.inputI.Style = MetroFramework.MetroColorStyle.Orange;
            this.inputI.TabIndex = 20;
            this.inputI.UseSelectable = true;
            this.inputI.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputI.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroPanel2);
            this.metroTabPage2.HorizontalScrollbarBarColor = false;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 0;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(933, 509);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Logs";
            this.metroTabPage2.VerticalScrollbarBarColor = false;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 0;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.DebugT);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(933, 509);
            this.metroPanel2.TabIndex = 2;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // DebugT
            // 
            this.DebugT.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DebugT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DebugT.Cursor = System.Windows.Forms.Cursors.Default;
            this.DebugT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DebugT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DebugT.Location = new System.Drawing.Point(0, 0);
            this.DebugT.Margin = new System.Windows.Forms.Padding(4);
            this.DebugT.Name = "DebugT";
            this.DebugT.ReadOnly = true;
            this.DebugT.Size = new System.Drawing.Size(933, 509);
            this.DebugT.TabIndex = 1;
            this.DebugT.Text = "";
            this.DebugT.WordWrap = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::Documents_combiner.Properties.Resources.clipart196740;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(20, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 634);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "       Doc Squasher 1.06";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        internal System.Windows.Forms.RichTextBox DebugT;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox inputI;
        private MetroFramework.Controls.MetroTextBox outputI;
        private MetroFramework.Controls.MetroButton loadInputB;
        private MetroFramework.Controls.MetroButton loadOutputB;
        private MetroFramework.Controls.MetroButton startB;
        private System.Windows.Forms.ProgressBar ProgressB;
        private System.Windows.Forms.Label displayT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        //private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private MetroFramework.Controls.MetroTextBox MaxSheetPerDocumentTxt;
        private MetroFramework.Controls.MetroTextBox MaxLinesPerSheetTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CombineOptionsI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox MatchFormatting;
        private System.Windows.Forms.ComboBox HeadersRowsNbr;
    }
}

