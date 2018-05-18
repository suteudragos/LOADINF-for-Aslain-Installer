using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace Loadinf {
    public partial class Form1 : Form {
        string version = Assembly.GetEntryAssembly().GetName().Version.ToString(2);
        string author = "BeGiN";

        String WorkingDir;
        string installer_name;
        string INF_name;

        public Form1() {
            InitializeComponent();
            InitializeApplication();
            InitializeTempFiles();
            InitializeFilesCheck();
        }

        public void InitializeApplication() {
            WorkingDir = Application.StartupPath;
            Text = $"LOADINF for Aslain's Installer v{version}";
            Logger.Text = $"LOADINF for Aslain's Installer v{version} \n";
            Logger.Text = Logger.Text + $"Author: {author} \n\n";
            Logger.Text = Logger.Text + $"Working Directory: \n{WorkingDir}\n\n";
        }

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

        public void InitializeFilesCheck() {
            //Check for Aslains_XVM_Mod_Installer_*.exe in root
            string[] files = Directory.GetFiles(WorkingDir, "Aslains_WoT_Modpack_Installer_*.exe", SearchOption.TopDirectoryOnly);
            if (files.Length > 0) {
                installer_label.ForeColor = Color.Green;
                installer_label.Text = "AUTO-LOADED";
                installer_name = files[files.Length - 1].Substring(files[0].LastIndexOf('\\') + 1);
                Logger.Text = Logger.Text + $"{installer_name} - Successfully auto-loaded!\n";
                loadInfBtn.Enabled = true;
                File.Copy(files[files.Length - 1], WorkingDir + "\\LOADINF_temp\\aslains_installer.exe", true);
            } else
                Logger.Text = Logger.Text + "Aslains_WoT_Modpack_Installer_*.exe  - Not found!\n";


            //Check for _Aslains_Installer_Options.inf in root
            INF_name = "Aslains_Installer_Options.inf";
            if (File.Exists(WorkingDir + "\\_Aslains_Installer_Options.inf")) {
                INF_label.ForeColor = Color.Green;
                INF_label.Text = "AUTO-LOADED";
                Logger.Text = Logger.Text + $"{INF_name} - Successfully auto-loaded!\n";
                runInstallerBtn.Enabled = true;
                File.Copy(WorkingDir + "\\_Aslains_Installer_Options.inf", WorkingDir + "\\LOADINF_temp\\_Aslains_Installer_Options.inf", true);
            } else
                Logger.Text = Logger.Text + $"{INF_name} - Not found!\n";
        }

        private void load_installer_button_Click(object sender, EventArgs e) {
            InstallerDialog.InitialDirectory = WorkingDir;
            InstallerDialog.Filter = "Aslain's Installer |*.exe";
            InstallerDialog.DefaultExt = ".exe";
            InstallerDialog.FileName = "";
            DialogResult result = InstallerDialog.ShowDialog();
            if (result == DialogResult.OK) {
                installer_label.ForeColor = Color.Green;
                installer_label.Text = "LOADED";
                installer_name = InstallerDialog.FileName.Substring(InstallerDialog.FileName.LastIndexOf('\\') + 1);
                Logger.Text = Logger.Text + $"{installer_name}  - Successfully loaded!\n";
                loadInfBtn.Enabled = true;
                File.Copy(InstallerDialog.FileName, WorkingDir + "\\LOADINF_temp\\aslains_installer.exe", true);
            } else {
                loadInfBtn.Enabled = false;
            }
        }

        private void load_INF_button_Click(object sender, EventArgs e) {
            InfDialog.InitialDirectory = WorkingDir;
            InfDialog.Filter = "_Aslains_Installer_Options.inf |*.inf";
            InfDialog.DefaultExt = ".inf";
            InfDialog.FileName = "";
            DialogResult result = InfDialog.ShowDialog();
            if (result == DialogResult.OK) {
                INF_label.ForeColor = Color.Green;
                INF_label.Text = "LOADED";
                INF_name = InfDialog.FileName.Substring(InfDialog.FileName.LastIndexOf('\\') + 1);
                Logger.Text = Logger.Text + $"{INF_name} - Successfully loaded!\n";
                runInstallerBtn.Enabled = true;
                File.Copy(InfDialog.FileName, WorkingDir + "\\LOADINF_temp\\_Aslains_Installer_Options.inf", true);
            } else {
                runInstallerBtn.Enabled = false;
            }
        }

        private void RUN_installer_button_Click(object sender, EventArgs e) {
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
                    Logger.Text = Logger.Text + $"Executing:\n{installer_name} /LOADINF={INF_name}\n";
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
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
            timer1.Stop();
        }

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

        private void Logger_TextChanged(object sender, EventArgs e) {
            Logger.SelectionStart = Logger.Text.Length;
            Logger.ScrollToCaret();
        }
    }
}
