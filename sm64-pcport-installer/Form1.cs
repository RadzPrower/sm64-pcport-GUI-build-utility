using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using IWshRuntimeLibrary;
using sm64_pcport_installer.Properties;

namespace sm64_pcport_installer
{
    public partial class Main : Form
    {
        private string sourceRepo;
        private string sourceRepoURL;
        private string baseArgs;
        private string repoDir;
        private string portPath;
        private string logDir;

        private Boolean fresh = false;
        private Boolean advanced;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            loadSettings();
            switch (sourceRepo)
            {
                case "sm64ex-main":
                    this.sourceButton3.Checked = true;
                    break;
                case "sm64ex-nightly":
                    this.sourceButton2.Checked = true;
                    break;
                default:
                    this.sourceButton1.Checked = true;
                    break;
            }

            if (advanced)
            {
                this.advancedBar.Image = Resources.advanced_open;
                this.panelAdvanced.Show();
            }
            else
            {
                this.advancedBar.Image = Resources.advanced_closed;
                this.panelAdvanced.Hide();
            }
        }

        private void Main_FormClosing(object sender, FormClosedEventArgs e)
        {
            // Save user settings prior to closing
            saveSettings();

        }

        private void sourceButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.sourceButton1.Checked)
            {
                sourceRepoURL = "https://github.com/sm64-port/sm64-port.git";
                sourceRepo = "sm64-port";
                handleMakeChecks(true);                

                // Log action
                this.outputText.Text += "Changed the source repository to:\n" + sourceRepo + "\n";
            }
        }

        private void sourceButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.sourceButton2.Checked)
            {
                sourceRepoURL = "-b nightly git://github.com/sm64pc/sm64ex";
                sourceRepo = "sm64ex-nightly";
                handleMakeChecks(false);

                // Log action
                this.outputText.Text += "Changed the source repository to:\n" + sourceRepo + "\n";
            }
        }

        private void sourceButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.sourceButton3.Checked)
            {
                sourceRepoURL = "git://github.com/sm64pc/sm64ex";
                sourceRepo = "sm64ex-main";
                handleMakeChecks(false);

                // Log action
                this.outputText.Text += "Changed the source repository to:\n" + sourceRepo + "\n";
            }
        }

        private void updateCheck_CheckedChanged(object sender, EventArgs e)
        {
            //Log action taken
            this.outputText.Text += "Repository update check was set to " + this.updateCheck.Checked + "\n";
        }

        private void checkDepend_CheckedChanged(object sender, EventArgs e)
        {
            //Log action taken
            this.outputText.Text += "Dependency update check was set to " + this.checkDepend.Checked + "\n";
        }

        private void checkShortcut_CheckedChanged(object sender, EventArgs e)
        {
            //Log action taken
            this.outputText.Text += "Create Shortcut was changed to " + this.checkShortcut.Checked + "\n";
        }

        private void jobNumber_ValueChanged(object sender, EventArgs e)
        {
            //Log action taken
            this.outputText.Text += "Number of jobs allocated was set to " + this.jobNumber.Value + "\n";
        }

        private void backupBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if( result == DialogResult.OK )
            {
                this.backupText.Text = folderBrowserDialog1.SelectedPath;

                // Log action
                this.outputText.Text += "Changed the backup directory to:\n" + this.backupText.Text + "\n";
            }
        }

        private void buttonMSYS2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.textMSYS2.Text = folderBrowserDialog1.SelectedPath;

                // Log action
                this.outputText.Text += "Changed the MSYS2 directory to:\n" + this.textMSYS2.Text + "\n";
            }
        }

        private void buttonROM_Click(object sender, EventArgs e)
        {
            Boolean exit = false;
            while (!exit)
            {
                var result = new OpenFileDialog();
                if (result.ShowDialog() == DialogResult.OK)
                {
                    if (checkHash(result.FileName))
                    {
                        this.textROM.Text = result.FileName;
                        exit = true;

                        // Log action
                        this.outputText.Text += "Baserom location is :\n" + this.textROM.Text + "\n";
                        this.outputText.Text += "This is only used if baserom is not found in existing repository.\n";
                    }
                    else
                    {
                        // Create message
                        string message = "The selected file does not have a valid hash!\n";
                        message += "Your build settings currently require a ";
                        if (this.verCombo.SelectedIndex >= 0)
                        {
                            message += this.verCombo.Text.ToUpper();
                        }
                        else
                        {
                            message += "US";
                        }
                        message += " ROM file.";

                        // Error message
                        MessageBox.Show(message, "Invalid Hash", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else exit = true;
            }
        }

        private void outputText_TextChanged(object sender, EventArgs e)
        {
            this.outputText.SelectionStart = this.outputText.Text.Length;
            this.outputText.ScrollToCaret();
        }

        private void checkTerm_CheckedChanged(object sender, EventArgs e)
        {
            this.checkLog.Enabled = this.checkTerm.Checked;

            if (!this.checkTerm.Checked)
            {
                this.checkLog.Checked = false;
            }

            //Log action taken
            this.outputText.Text += "Terminal display was changed to " + this.checkTerm.Checked + "\n";
        }

        private void checkLog_CheckedChanged(object sender, EventArgs e)
        {
            //Log action taken
            this.outputText.Text += "Leave log open changed to " + this.checkLog.Checked + "\n";
        }

        private void buttonCompile_Click(object sender, EventArgs e)
        {
            // Check for existing backup folder and create if not found
            if (!Directory.Exists(this.backupText.Text))
            {
                Directory.CreateDirectory(this.backupText.Text);
            }

            // Set up repository and logging directory path
            repoDir = Path.Combine(this.textMSYS2.Text, "home", Environment.UserName, sourceRepo);
            portPath = Path.Combine(repoDir, "build", this.verCombo.Text + "_pc");
            if (Directory.Exists(repoDir))
            {
                logDir = repoDir;
            }
            else
            {
                logDir = this.backupText.Text;
            }

            addToLog(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
            addToLog("----------------------------------------");
            addToLog("Pre-compile log dump:");
            addToLog(this.outputText.Text);
            addToLog("\nMSYS2 calls:");

            this.outputText.Text += "Configuring MSYS2 process...\n";
            baseArgs = null;

            // Check if terminal should be shown to the user
            if (!checkTerm.Checked)
            {
                // Log action
                this.outputText.Text += "Configuring for hidden terminal...\n";

                baseArgs += "-w hide ";
            }

            // Check if log should remain open after completion
            if (checkLog.Checked)
            {
                // Log action
                this.outputText.Text += "Configuring for holding terminal...\n";

                baseArgs += "-h always ";
            }

            baseArgs += "/bin/env MSYSTEM=MINGW64 /bin/bash -l -c '";

            // Check for dependency updates via pacman
            if (this.checkDepend.Checked)
            {
                // Log action
                this.outputText.Text += "Checking for dependency udpates via pacman...\n";

                executeMSYS2("pacman -S --needed --noconfirm git make python3 mingw-w64-x86_64-gcc");

                // Log action
                this.outputText.Text += "Dependencies are up-to-date.\n";
            }
            
            if (this.updateCheck.Checked) updateRepository();

            // Log action
            this.outputText.Text += "Checking for baserom...\n";

            // Check for baserom
            if (!System.IO.File.Exists(Path.Combine(repoDir, "baserom." + this.verCombo.Text + ".z64")))
            {
                // Log action
                this.outputText.Text += "Baserom not found in repsitory.\n";
                this.outputText.Text += "Checking for alternate baserom...\n";

                if (System.IO.File.Exists(this.textROM.Text) && (checkHash(this.textROM.Text)))
                {
                    this.outputText.Text += "baserom." + this.verCombo.Text + ".z64 found.\n";
                    this.outputText.Text += "Copying to repository directory...\n";
                    if (Directory.Exists(repoDir))
                    {
                        System.IO.File.Copy(this.textROM.Text, Path.Combine(repoDir, "baserom." + this.verCombo.Text + ".z64"));
                        this.outputText.Text += "baserom." + this.verCombo.Text + ".z64 copied to " + repoDir;
                    }
                    else
                    {
                        this.outputText.Text += "Repository directory does not yet exist.\n";
                        this.outputText.Text += "Now downloading repository before continuing...\n";
                        updateRepository();
                        System.IO.File.Copy(this.textROM.Text, Path.Combine(repoDir, "baserom." + this.verCombo.Text + ".z64"));
                        this.outputText.Text += "baserom." + this.verCombo.Text + ".z64 copied to " + repoDir;
                    }
                }
                else
                {
                    this.outputText.Text += "You are missing baserom." + this.verCombo.Text + ".z64.\n";
                    this.outputText.Text += "Ending compilation process.\n";
                    this.outputText.Text += "Place baserom." + this.verCombo.Text + ".z64 in the same directory as this app:\n";
                    this.outputText.Text += Directory.GetCurrentDirectory();
                    return;
                }
            }
            else
            {
                // Log action
                this.outputText.Text += "Baserom already located in repository.\n";
            }

            // Log make action
            this.outputText.Text += "This could take several minutes.\n";
            this.outputText.Text += "When the process is completed ";
            if (checkShortcut.Checked)
            {
                this.outputText.Text += "a shortcut will be added to your desktop.\n";
            }
            else
            {
                this.outputText.Text += "the directory containing the executable will be opened.\n";
            }

            object desktop = (object)"Desktop";

            string compileCommand = "cd ./" + sourceRepo + " && make";

            if (this.jobNumber.Value > 0)
            {
                // Log number of jobs used
                this.outputText.Text += "Compiling executable with " + jobNumber.Value + " jobs allocated...\n";

                compileCommand += " -j" + jobNumber.Value;
            }
            else
            {
                // Log number of jobs used
                this.outputText.Text += "Compiling executable with unlimited jobs allocated...\n";
            }

            if (this.verCombo.SelectedIndex > 0)
            {
                if (!checkHash(this.textROM.Text))
                {
                    // Create message
                    string message = "The selected file does not have a valid hash!\n";
                    message += "Your build settings currently require a ";
                    if (this.verCombo.SelectedIndex >= 0)
                    {
                        message += this.verCombo.Text.ToUpper();
                    }
                    else
                    {
                        message += "US";
                    }
                    message += " ROM file.\n";
                    message += "Compile has stopped and no executable has been created.";

                    // Error message
                    MessageBox.Show(message, "Invalid Hash", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                compileCommand += " VERSION=" + this.verCombo.Text;

                // Log action
                this.outputText.Text += "Adding VERSION flag...\n";
            }
            
            /*if (this.n64Check.Checked)
            {
                compileCommand += " TARGET_N64=1";

                // Log action
                this.outputText.Text += "Adding TARGET_N64 flag...\n";
            }*/

            if (this.camCheck.Checked)
            {
                compileCommand += " BETTERCAMERA=1";

                // Log action
                this.outputText.Text += "Adding BETTERCAMERA flag...\n";
            }

            if (this.drawCheck.Checked)
            {
                compileCommand += " NODRAWINGDISTANCE=1";

                // Log action
                this.outputText.Text += "Adding NODRAWINGDISTANCE flag...\n";
            }

            if (this.textureCheck.Checked)
            {
                compileCommand += " TEXTURE_FIX=1";

                // Log action
                this.outputText.Text += "Adding TEXTURE_FIX flag...\n";
            }

            if (this.optionsCheck.Checked)
            {
                compileCommand += " EXT_OPTIONS_MENU=1";

                // Log action
                this.outputText.Text += "Adding EXT_OPTIONS_MENU flag...\n";
            }

            if (this.extCheck.Checked)
            {
                compileCommand += " EXTERNAL_DATA=1";

                // Log action
                this.outputText.Text += "Adding EXTERNAL_DATA flag...\n";
            }

            if (this.discordCheck.Checked)
            {
                compileCommand += " DISCORDRPC=1";

                // Log action
                this.outputText.Text += "Adding DISCORDRPC flag...\n";
            }

            if (this.saveCheck.Checked)
            {
                compileCommand += " TEXTSAVES=1";

                // Log action
                this.outputText.Text += "Adding TEXTSAVES flag...\n";
            }

            if (this.renderCombo.Enabled && (this.renderCombo.Text.Length > 0))
            {
                switch (this.renderCombo.SelectedIndex)
                {
                    case 0:
                        compileCommand += " RENDER_API=GL";

                        // Log action
                        this.outputText.Text += "Adding RENDER_API flag...\n";
                        break;
                    case 1:
                        compileCommand += " D3D11";

                         // Log action
                        this.outputText.Text += "Adding RENDER_API flag...\n";
                        break;
                    case 2:
                        compileCommand += " RENDER_API=D3D12";

                        // Log action
                        this.outputText.Text += "Adding RENDER_API flag...\n";
                        break;
                    case 3:
                        compileCommand += " RENDER_API=GL_LEGACY";

                        // Log action
                        this.outputText.Text += "Adding RENDER_API flag...\n";
                        break;
                    default:
                        break;
                }
            }

            //compileCommand += "'";

            executeMSYS2(compileCommand, true);

            addToLog("----------------------------------------\n\n");

            if (!logDir.Equals(repoDir))
            {
                System.IO.File.Move(Path.Combine(logDir, "build.log"), Path.Combine(repoDir, "build.log"));
            }

            // Check if 'Create Shortcut' is checked and act accordingly
            if (checkShortcut.Checked)
            {
                string destination;
                WshShell shell = new WshShell();
                destination = @"\SM64 (" + sourceRepo + @")\sm64." + this.verCombo.Text + ".f3dex2e.exe.lnk";
                Directory.CreateDirectory((string)shell.SpecialFolders.Item(ref desktop) + @"\SM64 (" + sourceRepo + ")");
                string shorcutAddress = (string)shell.SpecialFolders.Item(ref desktop) + destination;
                IWshShortcut winAppShortcut = (IWshShortcut)shell.CreateShortcut(shorcutAddress);
                winAppShortcut.Description = "Super Mario 64 compiled from " + sourceRepo;
                //winAppShortcut.WorkingDirectory = portPath;
                winAppShortcut.TargetPath = Path.Combine(portPath, "sm64." + this.verCombo.Text + ".f3dex2e.exe");
                winAppShortcut.Save();
                this.outputText.Text += "Shortcut folder added to desktop.\n";
            }
            else
            {
                Process.Start(portPath);
                this.outputText.Text += portPath + " opened.\n";
            }
        }

        private void executeMSYS2(string commands)
        {
            // Set up individual processes
            Process mintty = new Process();

            // Set up MinTTy process
            ProcessStartInfo minttyStart = new ProcessStartInfo();
            minttyStart.FileName = this.textMSYS2.Text + "\\usr\\bin\\mintty.exe";

            // Combine individual commands with common arguments
            minttyStart.Arguments = baseArgs + commands + " |& tee msys2.log'";

            // Add call to log file
            addToLog(minttyStart.Arguments);

            minttyStart.UseShellExecute = false;
            minttyStart.RedirectStandardOutput = true;
            mintty.StartInfo = minttyStart;
            mintty.Start();
            Thread.Sleep(100);
            while (mintty.StartTime == null)
            {
                Thread.Sleep(10);
            }
            mintty.StandardOutput.ReadToEnd();
            this.outputText.Text += System.IO.File.ReadAllText(Path.Combine(this.textMSYS2.Text, "home", Environment.UserName, "msys2.log"));
        }

        private void executeMSYS2(string commands, Boolean compile)
        {
            // Set up individual processes
            Process mintty = new Process();

            // Set up MinTTy process
            ProcessStartInfo minttyStart = new ProcessStartInfo();
            minttyStart.FileName = this.textMSYS2.Text + "\\usr\\bin\\mintty.exe";

            // Combine individual commands with common arguments
            minttyStart.Arguments = baseArgs + commands + " |& tee msys2.log'";

            // Add call to log file
            addToLog(minttyStart.Arguments);

            minttyStart.UseShellExecute = false;
            minttyStart.RedirectStandardOutput = true;
            mintty.StartInfo = minttyStart;
            mintty.Start();

            Thread.Sleep(100);

            string dirCount;
            string logPath;
            if (fresh)
            {
                dirCount = repoDir;
                if (!Directory.Exists(dirCount))
                {
                    compileProgress.Minimum = 0;
                    compileProgress.Maximum = 3200;
                }
                else
                {
                    compileProgress.Maximum = 8250;
                    compileProgress.Minimum = 3200;
                }
            }
            else
            {
                dirCount = portPath;
                compileProgress.Maximum = 3500;
                compileProgress.Minimum = 0;
            }

            if (commands.Contains("cd ./"))
            {
                logPath = Path.Combine(repoDir, "msys2.log");
            }
            else
            {
                logPath = Path.Combine(this.textMSYS2.Text, "home", Environment.UserName, "msys2.log");
            }

            while (!Directory.Exists(dirCount))
            {
                Thread.Sleep(10);
            }

            while ((Directory.GetFiles(dirCount, "*", SearchOption.AllDirectories).Length < compileProgress.Maximum))
            {
                try
                {
                    using (FileStream logStream = new FileStream(logPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader logReader = new StreamReader(logStream))
                    {
                        this.outputText.Text = logReader.ReadToEnd();
                    }
                }
                catch { }

                try
                {
                    compileProgress.Value = Directory.GetFiles(dirCount, "*", SearchOption.AllDirectories).Length;
                }
                catch
                {
                    compileProgress.Value = compileProgress.Maximum;
                }
            }
            mintty.StandardOutput.ReadToEnd();
            compileProgress.Value = compileProgress.Minimum;
        }

        private Boolean checkHash(string file)
        {
            using (SHA1Managed sha1Hasher = new SHA1Managed())
            using (FileStream stream = new FileStream(file,FileMode.Open))
            using (BufferedStream buffer = new BufferedStream(stream))
            {
                byte[] hash = sha1Hasher.ComputeHash(buffer);
                StringBuilder hashString = new StringBuilder(2 * hash.Length);
                foreach (byte b in hash)
                {
                    hashString.AppendFormat("{0:x2}", b);
                }

                switch (this.verCombo.SelectedIndex)
                {
                    case int n when (n < 1):
                        if (hashString.ToString() == "9bef1128717f958171a4afac3ed78ee2bb4e86ce") return true;
                        break;
                    case 1:
                        if (hashString.ToString() == "8a20a5c83d6ceb0f0506cfc9fa20d8f438cafe51") return true;
                        break;
                    case 2:
                        if (hashString.ToString() == "4ac5721683d0e0b6bbb561b58a71740845dceea9") return true;
                        break;
                    case 3:
                        return true;
                }
            }
            return false;
        }

        private void advancedBar_Click(object sender, EventArgs e)
        {
            if (advanced)
            {
                this.advancedBar.Image = Resources.advanced_closed;
                this.panelAdvanced.Hide();
            }
            else
            {
                this.advancedBar.Image = Resources.advanced_open;
                this.panelAdvanced.Show();
            }
            advanced = !advanced;
        }

        private void verCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Log action
            this.outputText.Text += "VERSION build option set to " + this.verCombo.Text + "\n";

            // Warn user regarding usage of 'sh' build version
            if (this.verCombo.SelectedIndex == 3)
            {
                MessageBox.Show("SH build version is a work in progress.\nIt may not work at this time.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void handleMakeChecks(Boolean official)
        {
            if (official)
            {
                saveSettings();
                this.n64Check.Enabled = true;
                this.n64Check.Checked = Settings.Default.n64;
                foreach (var box in this.makeGroup.Controls.OfType<CheckBox>())
                {
                    if (box.Name != "n64Check")
                    {
                        box.Checked = false;
                        box.Enabled = false;
                    }
                }
                this.renderCombo.Enabled = false;
            }
            else
            {
                saveSettings();
                this.n64Check.Enabled = false;
                this.n64Check.Checked = false;
                foreach (var box in this.makeGroup.Controls.OfType<CheckBox>())
                {
                    if (box.Name != "n64Check")
                    {
                        box.Enabled = true;
                    }
                }
                this.renderCombo.Enabled = true;
                this.renderCombo.SelectedIndex = Settings.Default.render;
                this.camCheck.Checked = Settings.Default.bettercam;
                this.textureCheck.Checked = Settings.Default.textureFix;
                this.drawCheck.Checked = Settings.Default.draw;
                this.optionsCheck.Checked = Settings.Default.extraOptions;
                this.extCheck.Checked = Settings.Default.externalData;
                this.discordCheck.Checked = Settings.Default.discord;
                this.saveCheck.Checked = Settings.Default.textSaves;
            }
        }

        private void n64Check_CheckedChanged(object sender, EventArgs e)
        {
            // Log action
            this.outputText.Text += "Compile to N64 ROM option set to " + Convert.ToInt32(this.n64Check.Checked) + "\n";
        }

        private void renderCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Log action
            this.outputText.Text += "Render API was set to " + this.renderCombo.Text + "\n";
        }

        private void camCheck_CheckedChanged(object sender, EventArgs e)
        {
            // Log action
            this.outputText.Text += "BetterCam compile option set to " + Convert.ToInt32(this.camCheck.Checked) + "\n";
        }

        private void textureCheck_CheckedChanged(object sender, EventArgs e)
        {
            // Log action
            this.outputText.Text += "Texture fix option set to " + Convert.ToInt32(this.textureCheck.Checked) + "\n";
        }

        private void drawCheck_CheckedChanged(object sender, EventArgs e)
        {
            // Log action
            this.outputText.Text += "Draw Distance option set to " + Convert.ToInt32(this.textureCheck.Checked) + "\n";
        }

        private void optionsCheck_CheckedChanged(object sender, EventArgs e)
        {
            // Log action
            this.outputText.Text += "Extra Menu option set to " + Convert.ToInt32(this.optionsCheck.Checked) + "\n";
        }

        private void extCheck_CheckedChanged(object sender, EventArgs e)
        {
            // Log action
            this.outputText.Text += "Load externtal files option set to " + Convert.ToInt32(this.extCheck.Checked) + "\n";
        }

        private void discordCheck_CheckedChanged(object sender, EventArgs e)
        {
            // Log action
            this.outputText.Text += "Discord Rich Presence option set to " + Convert.ToInt32(this.discordCheck.Checked) + "\n";
        }

        private void saveCheck_CheckedChanged(object sender, EventArgs e)
        {
            // Log action
            this.outputText.Text += "Experimental text saves option set to " + Convert.ToInt32(this.saveCheck.Checked) + "\n";
        }

        private void saveSettings()
        {
            if (this.updateCheck.Enabled) Settings.Default.updateSrc = this.updateCheck.Checked;
            if (this.checkDepend.Enabled) Settings.Default.updateMSY2 = this.checkDepend.Checked;
            if (this.checkShortcut.Enabled) Settings.Default.shortcut = this.checkShortcut.Checked;
            if (this.jobNumber.Enabled) Settings.Default.jobNum = (int)this.jobNumber.Value;
            if (this.textROM.Enabled) Settings.Default.ROM = this.textROM.Text;
            if (this.backupText.Enabled) Settings.Default.backup = this.backupText.Text;
            Settings.Default.source = this.sourceRepo;
            if (this.textMSYS2.Enabled) Settings.Default.msys2 = this.textMSYS2.Text;
            if (this.checkTerm.Enabled) Settings.Default.terminal = this.checkTerm.Checked;
            if (this.checkLog.Enabled) Settings.Default.log = this.checkLog.Checked;
            Settings.Default.advanced = this.advanced;
            if (this.verCombo.Enabled) Settings.Default.version = this.verCombo.SelectedIndex;
            if (this.n64Check.Enabled) Settings.Default.n64 = this.n64Check.Checked;
            if (this.renderCombo.Enabled) Settings.Default.render = this.renderCombo.SelectedIndex;
            if (this.camCheck.Enabled) Settings.Default.bettercam = this.camCheck.Checked;
            if (this.textureCheck.Enabled) Settings.Default.textureFix = this.textureCheck.Checked;
            if (this.drawCheck.Enabled) Settings.Default.draw = this.drawCheck.Checked;
            if (this.extCheck.Enabled) Settings.Default.externalData = this.extCheck.Checked;
            if (this.optionsCheck.Enabled) Settings.Default.extraOptions = this.optionsCheck.Checked;
            if (this.discordCheck.Enabled) Settings.Default.discord = this.discordCheck.Checked;
            if (this.saveCheck.Enabled) Settings.Default.textSaves = this.saveCheck.Checked;
            Settings.Default.Save();
        }

        private void loadSettings()
        {
            this.updateCheck.Checked = Settings.Default.updateSrc;
            this.checkDepend.Checked = Settings.Default.updateMSY2;
            this.checkShortcut.Checked = Settings.Default.shortcut;
            if (Settings.Default.jobNum < 0)
            {
                int jobCount = Environment.ProcessorCount - 2;
                if (jobCount < 1) jobCount = 2;
                this.jobNumber.Value = jobCount;
            }
            else
            {
                this.jobNumber.Value = Settings.Default.jobNum;
            }
            if (System.IO.File.Exists(Settings.Default.ROM))
            {
                this.textROM.Text = Settings.Default.ROM;
            }
            else
            {
                this.textROM.Text = Directory.GetCurrentDirectory();
            }
            if (Directory.Exists(Settings.Default.backup))
            {
                this.backupText.Text = Settings.Default.backup;
            }
            else
            {
                this.backupText.Text = Path.Combine(Directory.GetCurrentDirectory(), "backup");
            }
            this.sourceRepo = Settings.Default.source;
            if (Directory.Exists(Settings.Default.msys2))
            {
                this.textMSYS2.Text = Settings.Default.msys2;
            }
            else
            {
                this.textMSYS2.Text = @"C:\msys64";
            }
            this.checkTerm.Checked = Settings.Default.terminal;
            this.checkLog.Checked = Settings.Default.log;
            this.advanced = Settings.Default.advanced;
            this.verCombo.SelectedIndex = Settings.Default.version;
            this.n64Check.Checked = Settings.Default.n64;
            this.renderCombo.SelectedIndex = Settings.Default.render;
            this.camCheck.Checked = Settings.Default.bettercam;
            this.textureCheck.Checked = Settings.Default.textureFix;
            this.drawCheck.Checked = Settings.Default.draw;
            this.extCheck.Checked = Settings.Default.externalData;
            this.optionsCheck.Checked = Settings.Default.extraOptions;
            this.discordCheck.Checked = Settings.Default.discord;
            this.saveCheck.Checked = Settings.Default.textSaves;
        }

        private void updateRepository()
        {
            if (Directory.Exists(repoDir))
            {
                if (Directory.Exists(Path.Combine(repoDir, ".git")))
                {
                    // Log action
                    this.outputText.Text += "Updating from " + sourceRepo + " repository...\n";
                    this.outputText.Text += "Connecting to " + sourceRepoURL + "\n";

                    executeMSYS2("cd ./" + sourceRepo + " && git stash push && git pull " + sourceRepoURL + "'");

                    // Log action
                    this.outputText.Text += sourceRepo + " repository updated.\n";
                }
                else
                {
                    // Log directory move action
                    this.outputText.Text += "Moving " + this.textROM.Text + "\\" + sourceRepo + " to\n";
                    this.outputText.Text += this.backupText + "\\" + sourceRepo + "\n";

                    // Log cloning action
                    this.outputText.Text += "Cloning from " + sourceRepo + " repository...\n";
                    this.outputText.Text += "Connecting to " + sourceRepoURL + "\n";

                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd_Hmm");
                    Directory.CreateDirectory(Path.Combine(this.backupText.Text, sourceRepo));
                    Directory.Move(repoDir, Path.Combine(this.backupText.Text, sourceRepo, timestamp));

                    fresh = true;
                    executeMSYS2("git clone " + sourceRepoURL + " " + sourceRepo, true);

                    // Log action
                    this.outputText.Text += sourceRepo + " repository cloned.\n";
                    return;
                }
            }
            else
            {
                // Log cloning action
                this.outputText.Text += "Cloning from " + sourceRepo + " repository...\n";
                this.outputText.Text += "Connecting to " + sourceRepoURL + "\n";

                fresh = true;
                executeMSYS2("git clone " + sourceRepoURL + " " + sourceRepo, true);

                // Log action
                this.outputText.Text += sourceRepo + " repository cloned.\n";
            }
        }

        private void addToLog(string input)
        {
            using (StreamWriter logFile = new StreamWriter(Path.Combine(logDir, "build.log"),true))
            {
                logFile.WriteLine(input);
            }
        }
    }
}
