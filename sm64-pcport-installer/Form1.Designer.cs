namespace sm64_pcport_installer
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.outputText = new System.Windows.Forms.RichTextBox();
            this.repoSource = new System.Windows.Forms.GroupBox();
            this.sourceButton3 = new System.Windows.Forms.RadioButton();
            this.sourceButton2 = new System.Windows.Forms.RadioButton();
            this.sourceButton1 = new System.Windows.Forms.RadioButton();
            this.jobLabel = new System.Windows.Forms.Label();
            this.updateCheck = new System.Windows.Forms.CheckBox();
            this.jobNumber = new System.Windows.Forms.NumericUpDown();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.backupText = new System.Windows.Forms.TextBox();
            this.labelBackup = new System.Windows.Forms.Label();
            this.backupBrowse = new System.Windows.Forms.Button();
            this.checkDepend = new System.Windows.Forms.CheckBox();
            this.sm64PortLogo = new System.Windows.Forms.PictureBox();
            this.buttonCompile = new System.Windows.Forms.Button();
            this.labelMSYS2 = new System.Windows.Forms.Label();
            this.textMSYS2 = new System.Windows.Forms.TextBox();
            this.buttonMSYS2 = new System.Windows.Forms.Button();
            this.checkLog = new System.Windows.Forms.CheckBox();
            this.buttonROM = new System.Windows.Forms.Button();
            this.textROM = new System.Windows.Forms.TextBox();
            this.labelRepo = new System.Windows.Forms.Label();
            this.labelLog = new System.Windows.Forms.Label();
            this.checkTerm = new System.Windows.Forms.CheckBox();
            this.checkShortcut = new System.Windows.Forms.CheckBox();
            this.compileProgress = new System.Windows.Forms.ProgressBar();
            this.repoSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sm64PortLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // outputText
            // 
            resources.ApplyResources(this.outputText, "outputText");
            this.outputText.Name = "outputText";
            this.outputText.TextChanged += new System.EventHandler(this.outputText_TextChanged);
            // 
            // repoSource
            // 
            this.repoSource.Controls.Add(this.sourceButton3);
            this.repoSource.Controls.Add(this.sourceButton2);
            this.repoSource.Controls.Add(this.sourceButton1);
            resources.ApplyResources(this.repoSource, "repoSource");
            this.repoSource.Name = "repoSource";
            this.repoSource.TabStop = false;
            // 
            // sourceButton3
            // 
            resources.ApplyResources(this.sourceButton3, "sourceButton3");
            this.sourceButton3.Name = "sourceButton3";
            this.sourceButton3.UseVisualStyleBackColor = true;
            this.sourceButton3.CheckedChanged += new System.EventHandler(this.sourceButton3_CheckedChanged);
            // 
            // sourceButton2
            // 
            resources.ApplyResources(this.sourceButton2, "sourceButton2");
            this.sourceButton2.Name = "sourceButton2";
            this.sourceButton2.UseVisualStyleBackColor = true;
            this.sourceButton2.CheckedChanged += new System.EventHandler(this.sourceButton2_CheckedChanged);
            // 
            // sourceButton1
            // 
            resources.ApplyResources(this.sourceButton1, "sourceButton1");
            this.sourceButton1.Checked = true;
            this.sourceButton1.Name = "sourceButton1";
            this.sourceButton1.TabStop = true;
            this.sourceButton1.UseVisualStyleBackColor = true;
            this.sourceButton1.CheckedChanged += new System.EventHandler(this.sourceButton1_CheckedChanged);
            // 
            // jobLabel
            // 
            resources.ApplyResources(this.jobLabel, "jobLabel");
            this.jobLabel.Name = "jobLabel";
            // 
            // updateCheck
            // 
            resources.ApplyResources(this.updateCheck, "updateCheck");
            this.updateCheck.Checked = true;
            this.updateCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.updateCheck.Name = "updateCheck";
            this.updateCheck.UseVisualStyleBackColor = true;
            this.updateCheck.CheckedChanged += new System.EventHandler(this.updateCheck_CheckedChanged);
            // 
            // jobNumber
            // 
            resources.ApplyResources(this.jobNumber, "jobNumber");
            this.jobNumber.Name = "jobNumber";
            this.jobNumber.ValueChanged += new System.EventHandler(this.jobNumber_ValueChanged);
            // 
            // backupText
            // 
            resources.ApplyResources(this.backupText, "backupText");
            this.backupText.Name = "backupText";
            // 
            // labelBackup
            // 
            resources.ApplyResources(this.labelBackup, "labelBackup");
            this.labelBackup.Name = "labelBackup";
            // 
            // backupBrowse
            // 
            resources.ApplyResources(this.backupBrowse, "backupBrowse");
            this.backupBrowse.Name = "backupBrowse";
            this.backupBrowse.UseVisualStyleBackColor = true;
            this.backupBrowse.Click += new System.EventHandler(this.backupBrowse_Click);
            // 
            // checkDepend
            // 
            resources.ApplyResources(this.checkDepend, "checkDepend");
            this.checkDepend.Name = "checkDepend";
            this.checkDepend.UseVisualStyleBackColor = true;
            this.checkDepend.CheckedChanged += new System.EventHandler(this.checkDepend_CheckedChanged);
            // 
            // sm64PortLogo
            // 
            resources.ApplyResources(this.sm64PortLogo, "sm64PortLogo");
            this.sm64PortLogo.Name = "sm64PortLogo";
            this.sm64PortLogo.TabStop = false;
            // 
            // buttonCompile
            // 
            resources.ApplyResources(this.buttonCompile, "buttonCompile");
            this.buttonCompile.Name = "buttonCompile";
            this.buttonCompile.UseVisualStyleBackColor = true;
            this.buttonCompile.Click += new System.EventHandler(this.buttonCompile_Click);
            // 
            // labelMSYS2
            // 
            resources.ApplyResources(this.labelMSYS2, "labelMSYS2");
            this.labelMSYS2.Name = "labelMSYS2";
            // 
            // textMSYS2
            // 
            resources.ApplyResources(this.textMSYS2, "textMSYS2");
            this.textMSYS2.Name = "textMSYS2";
            // 
            // buttonMSYS2
            // 
            resources.ApplyResources(this.buttonMSYS2, "buttonMSYS2");
            this.buttonMSYS2.Name = "buttonMSYS2";
            this.buttonMSYS2.UseVisualStyleBackColor = true;
            this.buttonMSYS2.Click += new System.EventHandler(this.buttonMSYS2_Click);
            // 
            // checkLog
            // 
            resources.ApplyResources(this.checkLog, "checkLog");
            this.checkLog.Name = "checkLog";
            this.checkLog.UseVisualStyleBackColor = true;
            this.checkLog.CheckedChanged += new System.EventHandler(this.checkLog_CheckedChanged);
            // 
            // buttonROM
            // 
            resources.ApplyResources(this.buttonROM, "buttonROM");
            this.buttonROM.Name = "buttonROM";
            this.buttonROM.UseVisualStyleBackColor = true;
            this.buttonROM.Click += new System.EventHandler(this.buttonROM_Click);
            // 
            // textROM
            // 
            resources.ApplyResources(this.textROM, "textROM");
            this.textROM.Name = "textROM";
            // 
            // labelRepo
            // 
            this.labelRepo.AutoEllipsis = true;
            resources.ApplyResources(this.labelRepo, "labelRepo");
            this.labelRepo.Name = "labelRepo";
            // 
            // labelLog
            // 
            resources.ApplyResources(this.labelLog, "labelLog");
            this.labelLog.Name = "labelLog";
            // 
            // checkTerm
            // 
            resources.ApplyResources(this.checkTerm, "checkTerm");
            this.checkTerm.Name = "checkTerm";
            this.checkTerm.UseVisualStyleBackColor = true;
            this.checkTerm.CheckedChanged += new System.EventHandler(this.checkTerm_CheckedChanged);
            // 
            // checkShortcut
            // 
            resources.ApplyResources(this.checkShortcut, "checkShortcut");
            this.checkShortcut.Name = "checkShortcut";
            this.checkShortcut.UseVisualStyleBackColor = true;
            this.checkShortcut.CheckedChanged += new System.EventHandler(this.checkShortcut_CheckedChanged);
            // 
            // compileProgress
            // 
            resources.ApplyResources(this.compileProgress, "compileProgress");
            this.compileProgress.Name = "compileProgress";
            this.compileProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.compileProgress);
            this.Controls.Add(this.checkShortcut);
            this.Controls.Add(this.checkTerm);
            this.Controls.Add(this.labelLog);
            this.Controls.Add(this.buttonROM);
            this.Controls.Add(this.textROM);
            this.Controls.Add(this.labelRepo);
            this.Controls.Add(this.checkLog);
            this.Controls.Add(this.buttonMSYS2);
            this.Controls.Add(this.textMSYS2);
            this.Controls.Add(this.labelMSYS2);
            this.Controls.Add(this.buttonCompile);
            this.Controls.Add(this.sm64PortLogo);
            this.Controls.Add(this.checkDepend);
            this.Controls.Add(this.backupBrowse);
            this.Controls.Add(this.labelBackup);
            this.Controls.Add(this.backupText);
            this.Controls.Add(this.jobNumber);
            this.Controls.Add(this.updateCheck);
            this.Controls.Add(this.jobLabel);
            this.Controls.Add(this.repoSource);
            this.Controls.Add(this.outputText);
            this.Name = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.repoSource.ResumeLayout(false);
            this.repoSource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sm64PortLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox outputText;
        private System.Windows.Forms.GroupBox repoSource;
        private System.Windows.Forms.RadioButton sourceButton3;
        private System.Windows.Forms.RadioButton sourceButton2;
        private System.Windows.Forms.RadioButton sourceButton1;
        private System.Windows.Forms.Label jobLabel;
        private System.Windows.Forms.CheckBox updateCheck;
        private System.Windows.Forms.NumericUpDown jobNumber;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox backupText;
        private System.Windows.Forms.Label labelBackup;
        private System.Windows.Forms.Button backupBrowse;
        private System.Windows.Forms.CheckBox checkDepend;
        private System.Windows.Forms.PictureBox sm64PortLogo;
        private System.Windows.Forms.Button buttonCompile;
        private System.Windows.Forms.Label labelMSYS2;
        private System.Windows.Forms.TextBox textMSYS2;
        private System.Windows.Forms.Button buttonMSYS2;
        private System.Windows.Forms.CheckBox checkLog;
        private System.Windows.Forms.Button buttonROM;
        private System.Windows.Forms.TextBox textROM;
        private System.Windows.Forms.Label labelRepo;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.CheckBox checkTerm;
        private System.Windows.Forms.CheckBox checkShortcut;
        private System.Windows.Forms.ProgressBar compileProgress;
    }
}

