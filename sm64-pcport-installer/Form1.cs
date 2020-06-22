using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using IWshRuntimeLibrary;

namespace sm64_pcport_installer
{
    public partial class Main : Form
    {
        private string sourceRepo;
        private string sourceRepoURL;
        private string baseArgs;
        private string repoDir;
        private string portPath;
        private Boolean fresh = false;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.jobNumber.Value = Environment.ProcessorCount - 2;
            this.backupText.Text = Directory.GetCurrentDirectory() + "\\backup";
            this.textMSYS2.Text = "C:\\msys64";
            this.textROM.Text = Directory.GetCurrentDirectory();
            this.sm64PortLogo.Image = Properties.Resources.new_icon;

            sourceRepoURL = "https://github.com/sm64-port/sm64-port.git";
            sourceRepo = "sm64-port";
        }

        private void sourceButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.sourceButton1.Checked)
            {
                string sourceRepoURL = "https://github.com/sm64-port/sm64-port.git";
                sourceRepo = "sm64-port";

                // Log action
                this.outputText.Text += "Changed the source repository to:\n" + sourceRepo + "\n";
            }
        }

        private void sourceButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.sourceButton2.Checked)
            {
                string sourceRepoURL = "-b nightly git://github.com/sm64pc/sm64ex sm64ex-nightly";
                sourceRepo = "sm64ex-nightly";

                // Log action
                this.outputText.Text += "Changed the source repository to:\n" + sourceRepo + "\n";
            }
        }

        private void sourceButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.sourceButton3.Checked)
            {
                string sourceRepoURL = "git://github.com/sm64pc/sm64ex sm64ex-main";
                sourceRepo = "sm64ex-main";

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
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.textROM.Text = folderBrowserDialog1.SelectedPath;

                // Log action
                this.outputText.Text += "Changed the existing ROM directory to:\n" + this.textROM.Text + "\n";
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
            Boolean exit = false;

            // Set up repository directory path
            repoDir = Path.Combine(this.textMSYS2.Text, "home", Environment.UserName, sourceRepo);

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

            baseArgs += "-R p /bin/env MSYSTEM=MINGW64 /bin/bash -l -c '";

            // Check for dependency updates via pacman
            if (this.checkDepend.Checked)
            {
                // Log action
                this.outputText.Text += "Checking for dependency udpates via pacman...\n";

                executeMSYS2("pacman -S --needed --noconfirm git make python3 mingw-w64-x86_64-gcc'");

                // Log action
                this.outputText.Text += "Dependencies are up-to-date.\n";
            }
            
            if (this.updateCheck.Checked)
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
                        executeMSYS2("git clone " + sourceRepoURL + " " + sourceRepo + "'",true);

                        // Log action
                        this.outputText.Text += sourceRepo + " repository cloned.\n";
                    }
                }
                else
                {
                    // Log cloning action
                    this.outputText.Text += "Cloning from " + sourceRepo + " repository...\n";
                    this.outputText.Text += "Connecting to " + sourceRepoURL + "\n";

                    fresh = true;
                    executeMSYS2("git clone " + sourceRepoURL + " " + sourceRepo + "'", true);

                    // Log action
                    this.outputText.Text += sourceRepo + " repository cloned.\n";
                }
            }

            // Log action
            this.outputText.Text += "Checking for baserom...\n";

            // Check for baserom
            if (!System.IO.File.Exists(Path.Combine(repoDir, "baserom.us.z64")))
            {
                // Log action
                this.outputText.Text += "Baserom not found in repsitory.\n";
                this.outputText.Text += "Checking " + this.textROM.Text + " for baserom...\n";

                if (System.IO.File.Exists(Path.Combine(this.textROM.Text, "baserom.us.z64")))
                {
                    this.outputText.Text += "baserom.us.z64 found.\n";
                    this.outputText.Text += "Copying to repository directory...\n";
                    System.IO.File.Copy(Path.Combine(this.textROM.Text, "baserom.us.z64"), Path.Combine(repoDir, "baserom.us.z64"));
                    this.outputText.Text += "baserom.us.z64 copied to " + repoDir;
                }
                else
                {
                    exit = true;
                    this.outputText.Text += "You are missing baserom.us.z64.\n";
                    this.outputText.Text += "Ending compilation process.\n";
                    this.outputText.Text += "Place baserom.us.z64 in the same directory as this app:\n";
                    this.outputText.Text += Directory.GetCurrentDirectory();
                }
            }
            else
            {
                // Log action
                this.outputText.Text += "Baserom already located in repository.\n";
            }

            if (exit) return;

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
            portPath = Path.Combine(repoDir, "build", "us_pc");

            if (this.jobNumber.Value > 0)
            {
                // Log number of jobs used
                this.outputText.Text += "Compiling executable with " + jobNumber.Value + " jobs allocated...\n";

                executeMSYS2("cd ./" + sourceRepo + " && make -j" + jobNumber.Value + "'", true);
            }
            else
            {
                // Log that job number is unrestricted
                this.outputText.Text += "Compiling executable with no job limit...\n";

                executeMSYS2("cd ./" + sourceRepo + " && make", true);
            }

            // Check if 'Create Shortcut' is checked and act accordingly
            if (checkShortcut.Checked)
            {
                string destination;
                WshShell shell = new WshShell();
                destination = @"\SM64 (" + sourceRepo + @")\sm64.us.f3dex2e.exe.lnk";
                Directory.CreateDirectory((string)shell.SpecialFolders.Item(ref desktop) + @"\SM64 (" + sourceRepo + ")");
                string shorcutAddress = (string)shell.SpecialFolders.Item(ref desktop) + destination;
                IWshShortcut winAppShortcut = (IWshShortcut)shell.CreateShortcut(shorcutAddress);
                winAppShortcut.Description = "Super Mario 64 compiled from " + sourceRepo;
                //winAppShortcut.WorkingDirectory = portPath;
                winAppShortcut.TargetPath = Path.Combine(portPath, "sm64.us.f3dex2e.exe");
                winAppShortcut.Save();
                this.outputText.Text += "Shortcut for added to desktop.\n";
            }
            else
            {
                Process.Start(portPath);
                this.outputText.Text += portPath + " opened.\n";
            }

            /* Work in progress to get the terminal output to the GUI directly
            compile.OutputDataReceived += captureOutput;
            compile.ErrorDataReceived += captureOutput;
            compile.Start();

            compile.BeginOutputReadLine();
            compile.BeginErrorReadLine();
            compile.WaitForExit();
            using (MemoryMappedViewStream stream = mmf.CreateViewStream())
            {
                BinaryReader reader = new BinaryReader(stream);
                this.outputText.Text += reader.ReadString();
            }*/
        }

        /* Also for getting terminal output to GUI
        static void captureOutput(object sender, DataReceivedEventArgs e)
        {
            MemoryMappedFile mmf = MemoryMappedFile.CreateOrOpen("terminal",1000);
            using (MemoryMappedViewStream stream = mmf.CreateViewStream())
            {
                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(e.Data);
            }
        }*/

        private void executeMSYS2(string commands)
        {
            Boolean found = false;

            // Set up individual processes
            Process mintty = new Process();
            Process msys2 = new Process();

            // Set up MinTTy process
            ProcessStartInfo minttyStart = new ProcessStartInfo();
            minttyStart.FileName = this.textMSYS2.Text + "\\usr\\bin\\mintty.exe";

            // Combine individual commands with common arguments
            minttyStart.Arguments = baseArgs + commands;

            // Trim arguments for eventual window title
            string title = trimArgs(minttyStart.Arguments);

            minttyStart.UseShellExecute = false;
            minttyStart.RedirectStandardOutput = true;
            mintty.StartInfo = minttyStart;
            mintty.Start();
            while (mintty.StartTime == null)
            {
                Thread.Sleep(10);
            }
            int.Parse(mintty.StandardOutput.ReadToEnd());
        }

        private void executeMSYS2(string commands, Boolean compile)
        {
            Boolean found = false;

            // Set up individual processes
            Process mintty = new Process();
            Process msys2 = new Process();

            // Set up MinTTy process
            ProcessStartInfo minttyStart = new ProcessStartInfo();
            minttyStart.FileName = this.textMSYS2.Text + "\\usr\\bin\\mintty.exe";

            // Combine individual commands with common arguments
            minttyStart.Arguments = baseArgs + commands;

            // Trim arguments for eventual window title
            string title = trimArgs(minttyStart.Arguments);

            minttyStart.UseShellExecute = false;
            minttyStart.RedirectStandardOutput = true;
            mintty.StartInfo = minttyStart;
            mintty.Start();

            Thread.Sleep(100);

            string dirCount;
            if (fresh)
            {
                dirCount = repoDir;
                if (!Directory.Exists(dirCount))
                {
                    compileProgress.Minimum = 0;
                    compileProgress.Maximum = 3217;
                }
                else
                {
                    compileProgress.Maximum = 8285;
                    compileProgress.Minimum = 3217;
                }
            }
            else
            {
                dirCount = portPath;
                compileProgress.Maximum = 3513;
                compileProgress.Minimum = 0;
            }
            
            while (!Directory.Exists(dirCount))
            {
                Thread.Sleep(10);
            }

            while (Directory.GetFiles(dirCount, "*", SearchOption.AllDirectories).Length < compileProgress.Maximum)
            {
                compileProgress.Value = Directory.GetFiles(dirCount, "*", SearchOption.AllDirectories).Length;
                Thread.Sleep(100);
            }
            int.Parse(mintty.StandardOutput.ReadToEnd());
            compileProgress.Value = compileProgress.Minimum;
        }

        private string trimArgs(string args)
        {
            string stringTrim = "-h always ";
            int index = args.IndexOf(stringTrim);
            if (index >= 0) args = args.Remove(index, stringTrim.Length);

            stringTrim = "-w hide ";
            index = args.IndexOf(stringTrim);
            if (index >= 0) args = args.Remove(index, stringTrim.Length);

            args = args.Replace("'", "");
            return args;
        }
    }
}
