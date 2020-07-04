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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.outputText = new System.Windows.Forms.RichTextBox();
            this.repoSource = new System.Windows.Forms.GroupBox();
            this.sourceButton3 = new System.Windows.Forms.RadioButton();
            this.sourceButton2 = new System.Windows.Forms.RadioButton();
            this.sourceButton1 = new System.Windows.Forms.RadioButton();
            this.jobLabel = new System.Windows.Forms.Label();
            this.updateCheck = new System.Windows.Forms.CheckBox();
            this.jobNumber = new System.Windows.Forms.NumericUpDown();
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
            this.labelROM = new System.Windows.Forms.Label();
            this.textROM = new System.Windows.Forms.TextBox();
            this.buttonROM = new System.Windows.Forms.Button();
            this.labelLog = new System.Windows.Forms.Label();
            this.checkTerm = new System.Windows.Forms.CheckBox();
            this.checkShortcut = new System.Windows.Forms.CheckBox();
            this.compileProgress = new System.Windows.Forms.ProgressBar();
            this.advancedBar = new System.Windows.Forms.PictureBox();
            this.panelSimple = new System.Windows.Forms.Panel();
            this.panelAdvanced = new System.Windows.Forms.Panel();
            this.advWarning = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.makeGroup = new System.Windows.Forms.GroupBox();
            this.renderCombo = new System.Windows.Forms.ComboBox();
            this.labelRender = new System.Windows.Forms.Label();
            this.drawCheck = new System.Windows.Forms.CheckBox();
            this.extCheck = new System.Windows.Forms.CheckBox();
            this.saveCheck = new System.Windows.Forms.CheckBox();
            this.discordCheck = new System.Windows.Forms.CheckBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.verCombo = new System.Windows.Forms.ComboBox();
            this.textureCheck = new System.Windows.Forms.CheckBox();
            this.optionsCheck = new System.Windows.Forms.CheckBox();
            this.camCheck = new System.Windows.Forms.CheckBox();
            this.n64Check = new System.Windows.Forms.CheckBox();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.repoSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sm64PortLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedBar)).BeginInit();
            this.panelSimple.SuspendLayout();
            this.panelAdvanced.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.makeGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputText
            // 
            resources.ApplyResources(this.outputText, "outputText");
            this.outputText.Name = "outputText";
            this.toolTipMain.SetToolTip(this.outputText, resources.GetString("outputText.ToolTip"));
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
            this.toolTipMain.SetToolTip(this.sourceButton3, resources.GetString("sourceButton3.ToolTip"));
            this.sourceButton3.UseVisualStyleBackColor = true;
            this.sourceButton3.CheckedChanged += new System.EventHandler(this.sourceButton3_CheckedChanged);
            // 
            // sourceButton2
            // 
            resources.ApplyResources(this.sourceButton2, "sourceButton2");
            this.sourceButton2.Name = "sourceButton2";
            this.toolTipMain.SetToolTip(this.sourceButton2, resources.GetString("sourceButton2.ToolTip"));
            this.sourceButton2.UseVisualStyleBackColor = true;
            this.sourceButton2.CheckedChanged += new System.EventHandler(this.sourceButton2_CheckedChanged);
            // 
            // sourceButton1
            // 
            resources.ApplyResources(this.sourceButton1, "sourceButton1");
            this.sourceButton1.Name = "sourceButton1";
            this.toolTipMain.SetToolTip(this.sourceButton1, resources.GetString("sourceButton1.ToolTip"));
            this.sourceButton1.UseVisualStyleBackColor = true;
            this.sourceButton1.CheckedChanged += new System.EventHandler(this.sourceButton1_CheckedChanged);
            // 
            // jobLabel
            // 
            resources.ApplyResources(this.jobLabel, "jobLabel");
            this.jobLabel.Name = "jobLabel";
            this.toolTipMain.SetToolTip(this.jobLabel, resources.GetString("jobLabel.ToolTip"));
            // 
            // updateCheck
            // 
            resources.ApplyResources(this.updateCheck, "updateCheck");
            this.updateCheck.Checked = true;
            this.updateCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.updateCheck.Name = "updateCheck";
            this.toolTipMain.SetToolTip(this.updateCheck, resources.GetString("updateCheck.ToolTip"));
            this.updateCheck.UseVisualStyleBackColor = true;
            this.updateCheck.CheckedChanged += new System.EventHandler(this.updateCheck_CheckedChanged);
            // 
            // jobNumber
            // 
            resources.ApplyResources(this.jobNumber, "jobNumber");
            this.jobNumber.Name = "jobNumber";
            this.toolTipMain.SetToolTip(this.jobNumber, resources.GetString("jobNumber.ToolTip"));
            this.jobNumber.ValueChanged += new System.EventHandler(this.jobNumber_ValueChanged);
            // 
            // backupText
            // 
            resources.ApplyResources(this.backupText, "backupText");
            this.backupText.Name = "backupText";
            this.toolTipMain.SetToolTip(this.backupText, resources.GetString("backupText.ToolTip"));
            // 
            // labelBackup
            // 
            resources.ApplyResources(this.labelBackup, "labelBackup");
            this.labelBackup.Name = "labelBackup";
            this.toolTipMain.SetToolTip(this.labelBackup, resources.GetString("labelBackup.ToolTip"));
            // 
            // backupBrowse
            // 
            resources.ApplyResources(this.backupBrowse, "backupBrowse");
            this.backupBrowse.Name = "backupBrowse";
            this.toolTipMain.SetToolTip(this.backupBrowse, resources.GetString("backupBrowse.ToolTip"));
            this.backupBrowse.UseVisualStyleBackColor = true;
            this.backupBrowse.Click += new System.EventHandler(this.backupBrowse_Click);
            // 
            // checkDepend
            // 
            resources.ApplyResources(this.checkDepend, "checkDepend");
            this.checkDepend.Name = "checkDepend";
            this.toolTipMain.SetToolTip(this.checkDepend, resources.GetString("checkDepend.ToolTip"));
            this.checkDepend.UseVisualStyleBackColor = true;
            this.checkDepend.CheckedChanged += new System.EventHandler(this.checkDepend_CheckedChanged);
            // 
            // sm64PortLogo
            // 
            this.sm64PortLogo.Image = global::sm64_pcport_installer.Properties.Resources.new_icon;
            resources.ApplyResources(this.sm64PortLogo, "sm64PortLogo");
            this.sm64PortLogo.Name = "sm64PortLogo";
            this.sm64PortLogo.TabStop = false;
            // 
            // buttonCompile
            // 
            resources.ApplyResources(this.buttonCompile, "buttonCompile");
            this.buttonCompile.Name = "buttonCompile";
            this.toolTipMain.SetToolTip(this.buttonCompile, resources.GetString("buttonCompile.ToolTip"));
            this.buttonCompile.UseVisualStyleBackColor = true;
            this.buttonCompile.Click += new System.EventHandler(this.buttonCompile_Click);
            // 
            // labelMSYS2
            // 
            resources.ApplyResources(this.labelMSYS2, "labelMSYS2");
            this.labelMSYS2.Name = "labelMSYS2";
            this.toolTipMain.SetToolTip(this.labelMSYS2, resources.GetString("labelMSYS2.ToolTip"));
            // 
            // textMSYS2
            // 
            resources.ApplyResources(this.textMSYS2, "textMSYS2");
            this.textMSYS2.Name = "textMSYS2";
            this.toolTipMain.SetToolTip(this.textMSYS2, resources.GetString("textMSYS2.ToolTip"));
            // 
            // buttonMSYS2
            // 
            resources.ApplyResources(this.buttonMSYS2, "buttonMSYS2");
            this.buttonMSYS2.Name = "buttonMSYS2";
            this.toolTipMain.SetToolTip(this.buttonMSYS2, resources.GetString("buttonMSYS2.ToolTip"));
            this.buttonMSYS2.UseVisualStyleBackColor = true;
            this.buttonMSYS2.Click += new System.EventHandler(this.buttonMSYS2_Click);
            // 
            // checkLog
            // 
            resources.ApplyResources(this.checkLog, "checkLog");
            this.checkLog.Name = "checkLog";
            this.toolTipMain.SetToolTip(this.checkLog, resources.GetString("checkLog.ToolTip"));
            this.checkLog.UseVisualStyleBackColor = true;
            this.checkLog.CheckedChanged += new System.EventHandler(this.checkLog_CheckedChanged);
            // 
            // labelROM
            // 
            this.labelROM.AutoEllipsis = true;
            resources.ApplyResources(this.labelROM, "labelROM");
            this.labelROM.Name = "labelROM";
            this.toolTipMain.SetToolTip(this.labelROM, resources.GetString("labelROM.ToolTip"));
            // 
            // textROM
            // 
            resources.ApplyResources(this.textROM, "textROM");
            this.textROM.Name = "textROM";
            this.toolTipMain.SetToolTip(this.textROM, resources.GetString("textROM.ToolTip"));
            // 
            // buttonROM
            // 
            resources.ApplyResources(this.buttonROM, "buttonROM");
            this.buttonROM.Name = "buttonROM";
            this.toolTipMain.SetToolTip(this.buttonROM, resources.GetString("buttonROM.ToolTip"));
            this.buttonROM.UseVisualStyleBackColor = true;
            this.buttonROM.Click += new System.EventHandler(this.buttonROM_Click);
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
            this.toolTipMain.SetToolTip(this.checkTerm, resources.GetString("checkTerm.ToolTip"));
            this.checkTerm.UseVisualStyleBackColor = true;
            this.checkTerm.CheckedChanged += new System.EventHandler(this.checkTerm_CheckedChanged);
            // 
            // checkShortcut
            // 
            resources.ApplyResources(this.checkShortcut, "checkShortcut");
            this.checkShortcut.Name = "checkShortcut";
            this.toolTipMain.SetToolTip(this.checkShortcut, resources.GetString("checkShortcut.ToolTip"));
            this.checkShortcut.UseVisualStyleBackColor = true;
            this.checkShortcut.CheckedChanged += new System.EventHandler(this.checkShortcut_CheckedChanged);
            // 
            // compileProgress
            // 
            resources.ApplyResources(this.compileProgress, "compileProgress");
            this.compileProgress.Name = "compileProgress";
            this.compileProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // advancedBar
            // 
            this.advancedBar.Image = global::sm64_pcport_installer.Properties.Resources.advanced_closed;
            resources.ApplyResources(this.advancedBar, "advancedBar");
            this.advancedBar.InitialImage = global::sm64_pcport_installer.Properties.Resources.advanced_closed;
            this.advancedBar.Name = "advancedBar";
            this.advancedBar.TabStop = false;
            this.toolTipMain.SetToolTip(this.advancedBar, resources.GetString("advancedBar.ToolTip"));
            this.advancedBar.Click += new System.EventHandler(this.advancedBar_Click);
            // 
            // panelSimple
            // 
            resources.ApplyResources(this.panelSimple, "panelSimple");
            this.panelSimple.Controls.Add(this.repoSource);
            this.panelSimple.Controls.Add(this.advancedBar);
            this.panelSimple.Controls.Add(this.buttonCompile);
            this.panelSimple.Controls.Add(this.compileProgress);
            this.panelSimple.Controls.Add(this.labelMSYS2);
            this.panelSimple.Controls.Add(this.sm64PortLogo);
            this.panelSimple.Controls.Add(this.checkShortcut);
            this.panelSimple.Controls.Add(this.textMSYS2);
            this.panelSimple.Controls.Add(this.outputText);
            this.panelSimple.Controls.Add(this.checkDepend);
            this.panelSimple.Controls.Add(this.buttonMSYS2);
            this.panelSimple.Controls.Add(this.jobLabel);
            this.panelSimple.Controls.Add(this.backupBrowse);
            this.panelSimple.Controls.Add(this.labelLog);
            this.panelSimple.Controls.Add(this.updateCheck);
            this.panelSimple.Controls.Add(this.labelBackup);
            this.panelSimple.Controls.Add(this.buttonROM);
            this.panelSimple.Controls.Add(this.labelROM);
            this.panelSimple.Controls.Add(this.jobNumber);
            this.panelSimple.Controls.Add(this.backupText);
            this.panelSimple.Controls.Add(this.textROM);
            this.panelSimple.Name = "panelSimple";
            // 
            // panelAdvanced
            // 
            resources.ApplyResources(this.panelAdvanced, "panelAdvanced");
            this.panelAdvanced.Controls.Add(this.advWarning);
            this.panelAdvanced.Controls.Add(this.groupBox1);
            this.panelAdvanced.Controls.Add(this.makeGroup);
            this.panelAdvanced.Name = "panelAdvanced";
            // 
            // advWarning
            // 
            resources.ApplyResources(this.advWarning, "advWarning");
            this.advWarning.Name = "advWarning";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.checkTerm);
            this.groupBox1.Controls.Add(this.checkLog);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // makeGroup
            // 
            resources.ApplyResources(this.makeGroup, "makeGroup");
            this.makeGroup.Controls.Add(this.renderCombo);
            this.makeGroup.Controls.Add(this.labelRender);
            this.makeGroup.Controls.Add(this.drawCheck);
            this.makeGroup.Controls.Add(this.extCheck);
            this.makeGroup.Controls.Add(this.saveCheck);
            this.makeGroup.Controls.Add(this.discordCheck);
            this.makeGroup.Controls.Add(this.versionLabel);
            this.makeGroup.Controls.Add(this.verCombo);
            this.makeGroup.Controls.Add(this.textureCheck);
            this.makeGroup.Controls.Add(this.optionsCheck);
            this.makeGroup.Controls.Add(this.camCheck);
            this.makeGroup.Name = "makeGroup";
            this.makeGroup.TabStop = false;
            // 
            // renderCombo
            // 
            this.renderCombo.FormattingEnabled = true;
            this.renderCombo.Items.AddRange(new object[] {
            resources.GetString("renderCombo.Items"),
            resources.GetString("renderCombo.Items1"),
            resources.GetString("renderCombo.Items2"),
            resources.GetString("renderCombo.Items3")});
            resources.ApplyResources(this.renderCombo, "renderCombo");
            this.renderCombo.Name = "renderCombo";
            this.toolTipMain.SetToolTip(this.renderCombo, resources.GetString("renderCombo.ToolTip"));
            this.renderCombo.SelectedIndexChanged += new System.EventHandler(this.renderCombo_SelectedIndexChanged);
            // 
            // labelRender
            // 
            resources.ApplyResources(this.labelRender, "labelRender");
            this.labelRender.Name = "labelRender";
            this.toolTipMain.SetToolTip(this.labelRender, resources.GetString("labelRender.ToolTip"));
            // 
            // drawCheck
            // 
            resources.ApplyResources(this.drawCheck, "drawCheck");
            this.drawCheck.Name = "drawCheck";
            this.toolTipMain.SetToolTip(this.drawCheck, resources.GetString("drawCheck.ToolTip"));
            this.drawCheck.UseVisualStyleBackColor = true;
            this.drawCheck.CheckedChanged += new System.EventHandler(this.drawCheck_CheckedChanged);
            // 
            // extCheck
            // 
            resources.ApplyResources(this.extCheck, "extCheck");
            this.extCheck.Name = "extCheck";
            this.toolTipMain.SetToolTip(this.extCheck, resources.GetString("extCheck.ToolTip"));
            this.extCheck.UseVisualStyleBackColor = true;
            this.extCheck.CheckedChanged += new System.EventHandler(this.extCheck_CheckedChanged);
            // 
            // saveCheck
            // 
            resources.ApplyResources(this.saveCheck, "saveCheck");
            this.saveCheck.Name = "saveCheck";
            this.toolTipMain.SetToolTip(this.saveCheck, resources.GetString("saveCheck.ToolTip"));
            this.saveCheck.UseVisualStyleBackColor = true;
            this.saveCheck.CheckedChanged += new System.EventHandler(this.saveCheck_CheckedChanged);
            // 
            // discordCheck
            // 
            resources.ApplyResources(this.discordCheck, "discordCheck");
            this.discordCheck.Name = "discordCheck";
            this.toolTipMain.SetToolTip(this.discordCheck, resources.GetString("discordCheck.ToolTip"));
            this.discordCheck.UseVisualStyleBackColor = true;
            this.discordCheck.CheckedChanged += new System.EventHandler(this.discordCheck_CheckedChanged);
            // 
            // versionLabel
            // 
            resources.ApplyResources(this.versionLabel, "versionLabel");
            this.versionLabel.Name = "versionLabel";
            this.toolTipMain.SetToolTip(this.versionLabel, resources.GetString("versionLabel.ToolTip"));
            // 
            // verCombo
            // 
            this.verCombo.FormattingEnabled = true;
            this.verCombo.Items.AddRange(new object[] {
            resources.GetString("verCombo.Items"),
            resources.GetString("verCombo.Items1"),
            resources.GetString("verCombo.Items2"),
            resources.GetString("verCombo.Items3")});
            resources.ApplyResources(this.verCombo, "verCombo");
            this.verCombo.Name = "verCombo";
            this.toolTipMain.SetToolTip(this.verCombo, resources.GetString("verCombo.ToolTip"));
            this.verCombo.SelectedIndexChanged += new System.EventHandler(this.verCombo_SelectedIndexChanged);
            // 
            // textureCheck
            // 
            resources.ApplyResources(this.textureCheck, "textureCheck");
            this.textureCheck.Name = "textureCheck";
            this.toolTipMain.SetToolTip(this.textureCheck, resources.GetString("textureCheck.ToolTip"));
            this.textureCheck.UseVisualStyleBackColor = true;
            this.textureCheck.CheckedChanged += new System.EventHandler(this.textureCheck_CheckedChanged);
            // 
            // optionsCheck
            // 
            resources.ApplyResources(this.optionsCheck, "optionsCheck");
            this.optionsCheck.Name = "optionsCheck";
            this.toolTipMain.SetToolTip(this.optionsCheck, resources.GetString("optionsCheck.ToolTip"));
            this.optionsCheck.UseVisualStyleBackColor = true;
            this.optionsCheck.CheckedChanged += new System.EventHandler(this.optionsCheck_CheckedChanged);
            // 
            // camCheck
            // 
            resources.ApplyResources(this.camCheck, "camCheck");
            this.camCheck.Name = "camCheck";
            this.toolTipMain.SetToolTip(this.camCheck, resources.GetString("camCheck.ToolTip"));
            this.camCheck.UseVisualStyleBackColor = true;
            this.camCheck.CheckedChanged += new System.EventHandler(this.camCheck_CheckedChanged);
            // 
            // n64Check
            // 
            resources.ApplyResources(this.n64Check, "n64Check");
            this.n64Check.Name = "n64Check";
            this.n64Check.UseVisualStyleBackColor = true;
            this.n64Check.CheckedChanged += new System.EventHandler(this.n64Check_CheckedChanged);
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelAdvanced);
            this.Controls.Add(this.panelSimple);
            this.Controls.Add(this.n64Check);
            this.Name = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.repoSource.ResumeLayout(false);
            this.repoSource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sm64PortLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedBar)).EndInit();
            this.panelSimple.ResumeLayout(false);
            this.panelSimple.PerformLayout();
            this.panelAdvanced.ResumeLayout(false);
            this.panelAdvanced.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.makeGroup.ResumeLayout(false);
            this.makeGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.RichTextBox outputText;
        private System.Windows.Forms.GroupBox repoSource;
        private System.Windows.Forms.RadioButton sourceButton3;
        private System.Windows.Forms.RadioButton sourceButton2;
        private System.Windows.Forms.RadioButton sourceButton1;
        private System.Windows.Forms.Label jobLabel;
        private System.Windows.Forms.CheckBox updateCheck;
        private System.Windows.Forms.NumericUpDown jobNumber;
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
        private System.Windows.Forms.Label labelROM;
        private System.Windows.Forms.TextBox textROM;
        private System.Windows.Forms.Button buttonROM;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.CheckBox checkTerm;
        private System.Windows.Forms.CheckBox checkShortcut;
        private System.Windows.Forms.ProgressBar compileProgress;
        private System.Windows.Forms.PictureBox advancedBar;
        private System.Windows.Forms.Panel panelSimple;
        private System.Windows.Forms.Panel panelAdvanced;
        private System.Windows.Forms.GroupBox makeGroup;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.ComboBox verCombo;
        private System.Windows.Forms.CheckBox extCheck;
        private System.Windows.Forms.CheckBox n64Check;
        private System.Windows.Forms.CheckBox discordCheck;
        private System.Windows.Forms.CheckBox saveCheck;
        private System.Windows.Forms.CheckBox optionsCheck;
        private System.Windows.Forms.CheckBox textureCheck;
        private System.Windows.Forms.CheckBox camCheck;
        private System.Windows.Forms.CheckBox drawCheck;
        private System.Windows.Forms.ComboBox renderCombo;
        private System.Windows.Forms.Label labelRender;
        private System.Windows.Forms.Label advWarning;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTipMain;
    }
}

