﻿namespace LoadINF {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing ) {
            if (disposing && ( components != null )) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Logger = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.runInstallerBtn = new System.Windows.Forms.Button();
            this.loadInfBtn = new System.Windows.Forms.Button();
            this.loadInstallerBtn = new System.Windows.Forms.Button();
            this.Running_label = new System.Windows.Forms.Label();
            this.INF_label = new System.Windows.Forms.Label();
            this.installer_label = new System.Windows.Forms.Label();
            this.InstallerDialog = new System.Windows.Forms.OpenFileDialog();
            this.InfDialog = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Logger
            // 
            this.Logger.BackColor = System.Drawing.Color.White;
            this.Logger.Dock = System.Windows.Forms.DockStyle.Left;
            this.Logger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logger.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Logger.Location = new System.Drawing.Point(0, 0);
            this.Logger.Name = "Logger";
            this.Logger.ReadOnly = true;
            this.Logger.Size = new System.Drawing.Size(330, 247);
            this.Logger.TabIndex = 0;
            this.Logger.Text = "";
            this.Logger.TextChanged += new System.EventHandler(this.Logger_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Logger);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(261, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 247);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::LoadINF.Properties.Resources.welcomePageWoTWoWs;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(330, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(361, 247);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.runInstallerBtn);
            this.panel2.Controls.Add(this.loadInfBtn);
            this.panel2.Controls.Add(this.loadInstallerBtn);
            this.panel2.Controls.Add(this.Running_label);
            this.panel2.Controls.Add(this.INF_label);
            this.panel2.Controls.Add(this.installer_label);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 253);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(691, 124);
            this.panel2.TabIndex = 2;
            // 
            // runInstallerBtn
            // 
            this.runInstallerBtn.Enabled = false;
            this.runInstallerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runInstallerBtn.Location = new System.Drawing.Point(480, 42);
            this.runInstallerBtn.Name = "runInstallerBtn";
            this.runInstallerBtn.Size = new System.Drawing.Size(175, 53);
            this.runInstallerBtn.TabIndex = 5;
            this.runInstallerBtn.Text = "Run the installer";
            this.runInstallerBtn.UseVisualStyleBackColor = true;
            this.runInstallerBtn.Click += new System.EventHandler(this.RunInstallerBtn_Click);
            // 
            // loadInfBtn
            // 
            this.loadInfBtn.Enabled = false;
            this.loadInfBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadInfBtn.Location = new System.Drawing.Point(255, 42);
            this.loadInfBtn.Name = "loadInfBtn";
            this.loadInfBtn.Size = new System.Drawing.Size(175, 53);
            this.loadInfBtn.TabIndex = 4;
            this.loadInfBtn.Text = "Load the .inf file";
            this.loadInfBtn.UseVisualStyleBackColor = true;
            this.loadInfBtn.Click += new System.EventHandler(this.LoadInfBtn_Click);
            // 
            // loadInstallerBtn
            // 
            this.loadInstallerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadInstallerBtn.Location = new System.Drawing.Point(33, 42);
            this.loadInstallerBtn.Name = "loadInstallerBtn";
            this.loadInstallerBtn.Size = new System.Drawing.Size(175, 53);
            this.loadInstallerBtn.TabIndex = 3;
            this.loadInstallerBtn.Text = "Load the installer";
            this.loadInstallerBtn.UseVisualStyleBackColor = true;
            this.loadInstallerBtn.Click += new System.EventHandler(this.LoadInstallerBtn_Click);
            // 
            // Running_label
            // 
            this.Running_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Running_label.ForeColor = System.Drawing.Color.Red;
            this.Running_label.Location = new System.Drawing.Point(514, 15);
            this.Running_label.Name = "Running_label";
            this.Running_label.Size = new System.Drawing.Size(101, 13);
            this.Running_label.TabIndex = 2;
            this.Running_label.Text = "NOT RUNNING";
            this.Running_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // INF_label
            // 
            this.INF_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.INF_label.ForeColor = System.Drawing.Color.Red;
            this.INF_label.Location = new System.Drawing.Point(294, 15);
            this.INF_label.Name = "INF_label";
            this.INF_label.Size = new System.Drawing.Size(101, 13);
            this.INF_label.TabIndex = 1;
            this.INF_label.Text = "NOT LOADED";
            this.INF_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // installer_label
            // 
            this.installer_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installer_label.ForeColor = System.Drawing.Color.Red;
            this.installer_label.Location = new System.Drawing.Point(70, 15);
            this.installer_label.Name = "installer_label";
            this.installer_label.Size = new System.Drawing.Size(101, 13);
            this.installer_label.TabIndex = 0;
            this.installer_label.Text = "NOT LOADED";
            this.installer_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstallerDialog
            // 
            this.InstallerDialog.FileName = "openFileDialog1";
            // 
            // InfDialog
            // 
            this.InfDialog.FileName = "openFileDialog2";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(691, 377);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOADINF for Aslain\'s Installer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox Logger;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button runInstallerBtn;
        private System.Windows.Forms.Button loadInfBtn;
        private System.Windows.Forms.Button loadInstallerBtn;
        private System.Windows.Forms.Label Running_label;
        private System.Windows.Forms.Label INF_label;
        private System.Windows.Forms.Label installer_label;
        private System.Windows.Forms.OpenFileDialog InstallerDialog;
        private System.Windows.Forms.OpenFileDialog InfDialog;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

