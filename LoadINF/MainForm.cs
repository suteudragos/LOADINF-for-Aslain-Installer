﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace LoadINF {
    public partial class Form1 : Form {
        string version = Assembly.GetEntryAssembly().GetName().Version.ToString(2);
        string author = "BeGiN";

        String WorkingDir;

        string InstallerFileName;
        string InfFileName;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Form1() {
            InitializeComponent();
            InitializeApplication();
            InitializeTempFiles();
            InitializeFilesCheck();
        }

        /// <summary>
        /// Initializes the application Title, Logger & Setup the WorkingDir.
        /// </summary>
        public void InitializeApplication() {
            WorkingDir = Application.StartupPath;
            Text = $"LOADINF for Aslain's Installer v{version}";
            Logger.Text = $"LOADINF for Aslain's Installer v{version} \n";
            Logger.Text = Logger.Text + $"Author: {author} \n\n";
            Logger.Text = Logger.Text + $"Working Directory: \n{WorkingDir}\n\n";
        }

        /// <summary>
        /// Creates the Temp Folder in order for the application can work
        /// It also creates the loadinf.bat that is located into the temp file.
        /// </summary>
        public void InitializeTempFiles() {
            if (!Directory.Exists(WorkingDir + "\\LOADINF_temp")) {
                DirectoryInfo dirInfo = Directory.CreateDirectory(WorkingDir + "\\LOADINF_temp");
                dirInfo.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }

            if (!File.Exists(WorkingDir + "\\LOADINF_temp\\loadinf.bat")) {
                using (StreamWriter Writer = new StreamWriter(WorkingDir + "\\LOADINF_temp\\loadinf.bat")) {
                    Writer.WriteLine("cd %~dp0");
                    Writer.WriteLine("%1 /LOADINF=_Aslains_Installer_Options.inf");
                };
            }
        }

        /// <summary>
        /// Not used yet.
        /// </summary>
        /// <param name="Files"></param>
        /// <param name="Image"></param>
        void SetupForGame(string[] Files, Image Image) {
            pictureBox1.BackgroundImage = Image;
            installer_label.ForeColor = Color.Green;
            installer_label.Text = "AUTO-LOADED";
            InstallerFileName = Files[Files.Length - 1].Substring(Files[0].LastIndexOf('\\') + 1);
            Logger.Text = Logger.Text + $"{InstallerFileName} - Successfully auto-loaded!\n";
            loadInfBtn.Enabled = true;
            File.Copy(Files[Files.Length - 1], WorkingDir + "\\LOADINF_temp\\aslains_installer.exe", true);
        }

        /// <summary>
        /// Handles the autodetection for both installers , WoT Installer & WoWs Installer
        /// Also it will popup a question if both installer are in the same folder with
        /// the application.
        /// </summary>
        public void InitializeFilesCheck() {
            //Check for Aslains_WoT_Modpack_Installer_*.exe in root and returns an array of filenames
            string[] wotFiles = Directory.GetFiles(WorkingDir, "Aslains_WoT_Modpack_Installer_*.exe", SearchOption.TopDirectoryOnly);

            //Check for Aslains_XVM_Mod_Installer_*.exe in root and returns an array of filenames
            string[] wowsFiles = Directory.GetFiles(WorkingDir, "Aslains_WoWs_Modpack_Installer_*.exe", SearchOption.TopDirectoryOnly);

            DialogResult dialog = DialogResult.None;
            //If both , WoT & WoWs Installers found
            if (wotFiles.Length > 0 && wowsFiles.Length > 0) {
                dialog = LoadINF.BetterBox.Show("Question", "Both installers are located in the same folder.\nWhich do you want to run?");

                //User selected World of Tanks
                if (dialog == DialogResult.Yes) {
                    pictureBox1.BackgroundImage = Properties.Resources.welcomePageWoT;
                    installer_label.ForeColor = Color.Green;
                    installer_label.Text = "AUTO-LOADED";
                    InstallerFileName = wotFiles[wotFiles.Length - 1].Substring(wotFiles[0].LastIndexOf('\\') + 1);
                    Logger.Text = Logger.Text + $"{InstallerFileName} - Successfully auto-loaded!\n";
                    loadInfBtn.Enabled = true;
                    File.Copy(wotFiles[wotFiles.Length - 1], WorkingDir + "\\LOADINF_temp\\aslains_installer.exe", true);

                    //User selected World of Warships
                } else if (dialog == DialogResult.No) {
                    pictureBox1.BackgroundImage = Properties.Resources.welcomePageWoWs;
                    installer_label.ForeColor = Color.Green;
                    installer_label.Text = "AUTO-LOADED";
                    InstallerFileName = wowsFiles[wowsFiles.Length - 1].Substring(wowsFiles[0].LastIndexOf('\\') + 1);
                    Logger.Text = Logger.Text + $"{InstallerFileName} - Successfully auto-loaded!\n";
                    loadInfBtn.Enabled = true;
                    File.Copy(wowsFiles[wowsFiles.Length - 1], WorkingDir + "\\LOADINF_temp\\aslains_installer.exe", true);

                    //User selected Cancel
                } else if (dialog == DialogResult.Cancel) {
                    //Environment.Exit(1);
                }

            }

            //If only WoT installers found
            if (wotFiles.Length > 0 && wowsFiles.Length == 0) {
                pictureBox1.BackgroundImage = Properties.Resources.welcomePageWoT;
                installer_label.ForeColor = Color.Green;
                installer_label.Text = "AUTO-LOADED";
                InstallerFileName = wotFiles[wotFiles.Length - 1].Substring(wotFiles[0].LastIndexOf('\\') + 1);
                Logger.Text = Logger.Text + $"{InstallerFileName} - Successfully auto-loaded!\n";
                loadInfBtn.Enabled = true;
                File.Copy(wotFiles[wotFiles.Length - 1], WorkingDir + "\\LOADINF_temp\\aslains_installer.exe", true);

                //If only WoWs installers found
            } else if (wotFiles.Length == 0 && wowsFiles.Length > 0) {
                pictureBox1.BackgroundImage = Properties.Resources.welcomePageWoWs;
                installer_label.ForeColor = Color.Green;
                installer_label.Text = "AUTO-LOADED";
                InstallerFileName = wowsFiles[wowsFiles.Length - 1].Substring(wowsFiles[0].LastIndexOf('\\') + 1);
                Logger.Text = Logger.Text + $"{InstallerFileName} - Successfully auto-loaded!\n";
                loadInfBtn.Enabled = true;
                File.Copy(wowsFiles[wowsFiles.Length - 1], WorkingDir + "\\LOADINF_temp\\aslains_installer.exe", true);
            }

            if ((wotFiles.Length > 0 || wowsFiles.Length > 0) && dialog != DialogResult.Cancel) {
                //Check for _Aslains_Installer_Options.inf in root
                InfFileName = "Aslains_Installer_Options.inf";
                if (File.Exists(WorkingDir + "\\_Aslains_Installer_Options.inf")) {
                    INF_label.ForeColor = Color.Green;
                    INF_label.Text = "AUTO-LOADED";
                    Logger.Text = Logger.Text + $"{InfFileName} - Successfully auto-loaded!\n";
                    runInstallerBtn.Enabled = true;
                    File.Copy(WorkingDir + "\\_Aslains_Installer_Options.inf", WorkingDir + "\\LOADINF_temp\\_Aslains_Installer_Options.inf", true);
                } else Logger.Text = Logger.Text + $"{InfFileName} - Not found!\n";
            }
        }

        /// <summary>
        /// Cleaning the .INF File & Reinitializing the buttons & labels
        /// </summary>
        public void CleanINFFile() {
            if (File.Exists(WorkingDir + "\\LOADINF_temp\\_Aslains_Installer_Options.inf")) {
                try {
                    File.Delete(WorkingDir + "\\LOADINF_temp\\_Aslains_Installer_Options.inf");
                } catch { }
            }

            loadInfBtn.Enabled = runInstallerBtn.Enabled = false;
            INF_label.Text = "NOT LOADED";
            INF_label.ForeColor = Color.Red;
        }

        /// <summary>
        /// Function bound to LoadInstallerBtn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadInstallerBtn_Click(object sender, EventArgs e) {
            CleanINFFile();
            InstallerDialog.InitialDirectory = WorkingDir;
            InstallerDialog.Filter = "Aslain's Modpack Installer |*.exe";
            InstallerDialog.DefaultExt = ".exe";
            InstallerDialog.FileName = "";
            DialogResult result = InstallerDialog.ShowDialog();
            if (result == DialogResult.OK) {
                installer_label.ForeColor = Color.Green;
                installer_label.Text = "LOADED";
                InstallerFileName = InstallerDialog.FileName.Substring(InstallerDialog.FileName.LastIndexOf('\\') + 1);
                Logger.Text = Logger.Text + $"{InstallerFileName}  - Successfully loaded!\n";
                loadInfBtn.Enabled = true;
                if (InstallerFileName.Contains("WoT")) {
                    pictureBox1.BackgroundImage = Properties.Resources.welcomePageWoT;
                } else if (InstallerFileName.Contains("WoWs")) {
                    pictureBox1.BackgroundImage = Properties.Resources.welcomePageWoWs;
                }
                File.Copy(InstallerDialog.FileName, WorkingDir + "\\LOADINF_temp\\aslains_installer.exe", true);
            } else {
                loadInfBtn.Enabled = false;
            }
        }

        /// <summary>
        /// Function bound to LoadInfBtn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadInfBtn_Click(object sender, EventArgs e) {
            InfDialog.InitialDirectory = WorkingDir;
            InfDialog.Filter = "_Aslains_Installer_Options.inf |*.inf";
            InfDialog.DefaultExt = ".inf";
            InfDialog.FileName = "";
            DialogResult result = InfDialog.ShowDialog();
            if (result == DialogResult.OK) {
                INF_label.ForeColor = Color.Green;
                INF_label.Text = "LOADED";
                InfFileName = InfDialog.FileName.Substring(InfDialog.FileName.LastIndexOf('\\') + 1);
                Logger.Text = Logger.Text + $"{InfFileName} - Successfully loaded!\n";
                runInstallerBtn.Enabled = true;
                File.Copy(InfDialog.FileName, WorkingDir + "\\LOADINF_temp\\_Aslains_Installer_Options.inf", true);
            } else {
                runInstallerBtn.Enabled = false;
            }
        }

        /// <summary>
        /// Function bound to RunInstallerBtn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunInstallerBtn_Click(object sender, EventArgs e) {
            if (File.Exists(WorkingDir + "\\LOADINF_temp\\aslains_installer.exe") &&
                File.Exists(WorkingDir + "\\LOADINF_temp\\loadinf.bat") &&
                File.Exists(WorkingDir + "\\LOADINF_temp\\_Aslains_Installer_Options.inf")) {

                if (installer_label.Text == "LOADED" || installer_label.Text == "AUTO-LOADED") {
                    Process p = new Process();
                    p.StartInfo.FileName = WorkingDir + "\\LOADINF_temp\\loadinf.bat";
                    p.StartInfo.Arguments = "aslains_installer.exe";
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Start();
                    timer1.Start();
                    Logger.Text = Logger.Text + $"Executing:\n{InstallerFileName} /LOADINF={InfFileName}\n";
                }
            }
        }

        /// <summary>
        /// Initializes the cleanup procedure, removing directories, files, etc.
        /// </summary>
        public void InitializeCleanUp() {
            if (File.Exists(WorkingDir + "\\LOADINF_temp\\aslains_installer.exe")) {
                if (Running_label.Text == "NOT RUNNING") {
                    File.Delete(WorkingDir + "\\LOADINF_temp\\aslains_installer.exe");
                } else {
                    DialogResult m = MessageBox.Show("Do you want to turn the installer off so we can clean the temporary file?", "Question", MessageBoxButtons.YesNo);
                    if (m == DialogResult.Yes) {
                        Process[] proc = Process.GetProcessesByName("aslains_installer.tmp");
                        for (int i = 0; i < proc.Length; i++) {
                            proc[i].Kill();
                        }
                        Thread.Sleep(1000);
                        try {
                            File.Delete(WorkingDir + "\\LOADINF_temp\\aslains_installer.exe");
                        } catch { }
                    }
                }
            }
            if (File.Exists(WorkingDir + "\\LOADINF_temp\\_Aslains_Installer_Options.inf")) {
                try {
                    File.Delete(WorkingDir + "\\LOADINF_temp\\_Aslains_Installer_Options.inf");
                } catch { }
            }
            if (File.Exists(WorkingDir + "\\LOADINF_temp\\loadinf.bat")) {
                try {
                    File.Delete(WorkingDir + "\\LOADINF_temp\\loadinf.bat");
                } catch { }
            }
            if (Directory.Exists(WorkingDir + "\\LOADINF_temp")) {
                try {
                    Directory.Delete(WorkingDir + "\\LOADINF_temp");
                } catch { }
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            InitializeCleanUp();
            timer1.Stop();
        }

        /// <summary>
        /// Check on timer wether the installer is running or not setting
        /// a label acordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e) {
            if (Process.GetProcessesByName("aslains_installer").Count() > 0) {
                Running_label.Text = "RUNNING";
                Running_label.ForeColor = Color.Green;
                Running_label.Refresh();
                loadInstallerBtn.Enabled = loadInfBtn.Enabled = runInstallerBtn.Enabled = false;
            } else {
                Running_label.Text = "NOT RUNNING";
                Running_label.ForeColor = Color.Red;
                Running_label.Refresh();
                loadInstallerBtn.Enabled = loadInfBtn.Enabled = runInstallerBtn.Enabled = true;
            }
        }


        /// <summary>
        /// Logger scroll to bottom function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logger_TextChanged(object sender, EventArgs e) {
            Logger.SelectionStart = Logger.Text.Length;
            Logger.ScrollToCaret();
        }
    }
}
