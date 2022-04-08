
namespace DocumentExportUtility_API
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMainMenu = new System.Windows.Forms.Panel();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.panelImportExportSubMenu = new System.Windows.Forms.Panel();
            this.btnExport = new FontAwesome.Sharp.IconButton();
            this.btnImport = new FontAwesome.Sharp.IconButton();
            this.btnSettings = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.btnFileManager = new FontAwesome.Sharp.IconButton();
            this.btnDashboard = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSideMenuDisplay = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMain.SuspendLayout();
            this.panelSideMenu.SuspendLayout();
            this.panelImportExportSubMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "importExcelFileDialog";
            this.OpenFileDialog.Title = "ImportExcelConfig";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelMainMenu);
            this.panelMain.Controls.Add(this.panelSideMenu);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1264, 681);
            this.panelMain.TabIndex = 0;
            // 
            // panelMainMenu
            // 
            this.panelMainMenu.AutoScroll = true;
            this.panelMainMenu.AutoSize = true;
            this.panelMainMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.panelMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainMenu.Location = new System.Drawing.Point(192, 0);
            this.panelMainMenu.Name = "panelMainMenu";
            this.panelMainMenu.Size = new System.Drawing.Size(1072, 681);
            this.panelMainMenu.TabIndex = 3;
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(18)))));
            this.panelSideMenu.Controls.Add(this.panelImportExportSubMenu);
            this.panelSideMenu.Controls.Add(this.btnSettings);
            this.panelSideMenu.Controls.Add(this.btnClose);
            this.panelSideMenu.Controls.Add(this.btnFileManager);
            this.panelSideMenu.Controls.Add(this.btnDashboard);
            this.panelSideMenu.Controls.Add(this.panel2);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(192, 681);
            this.panelSideMenu.TabIndex = 2;
            // 
            // panelImportExportSubMenu
            // 
            this.panelImportExportSubMenu.Controls.Add(this.btnExport);
            this.panelImportExportSubMenu.Controls.Add(this.btnImport);
            this.panelImportExportSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelImportExportSubMenu.Location = new System.Drawing.Point(0, 132);
            this.panelImportExportSubMenu.Name = "panelImportExportSubMenu";
            this.panelImportExportSubMenu.Size = new System.Drawing.Size(192, 86);
            this.panelImportExportSubMenu.TabIndex = 5;
            this.panelImportExportSubMenu.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(70)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.btnExport.IconColor = System.Drawing.Color.White;
            this.btnExport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExport.IconSize = 30;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(0, 40);
            this.btnExport.Name = "btnExport";
            this.btnExport.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnExport.Size = new System.Drawing.Size(192, 40);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(70)))));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.IconChar = FontAwesome.Sharp.IconChar.FileImport;
            this.btnImport.IconColor = System.Drawing.Color.White;
            this.btnImport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImport.IconSize = 30;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(0, 0);
            this.btnImport.Name = "btnImport";
            this.btnImport.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnImport.Size = new System.Drawing.Size(192, 40);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(70)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.btnSettings.IconColor = System.Drawing.Color.White;
            this.btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSettings.IconSize = 30;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(0, 591);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnSettings.Size = new System.Drawing.Size(192, 45);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(70)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 30;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(0, 636);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnClose.Size = new System.Drawing.Size(192, 45);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFileManager
            // 
            this.btnFileManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.btnFileManager.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFileManager.FlatAppearance.BorderSize = 0;
            this.btnFileManager.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(70)))));
            this.btnFileManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileManager.ForeColor = System.Drawing.Color.White;
            this.btnFileManager.IconChar = FontAwesome.Sharp.IconChar.File;
            this.btnFileManager.IconColor = System.Drawing.Color.White;
            this.btnFileManager.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFileManager.IconSize = 30;
            this.btnFileManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFileManager.Location = new System.Drawing.Point(0, 87);
            this.btnFileManager.Name = "btnFileManager";
            this.btnFileManager.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnFileManager.Size = new System.Drawing.Size(192, 45);
            this.btnFileManager.TabIndex = 2;
            this.btnFileManager.Text = "Import / Export";
            this.btnFileManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFileManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFileManager.UseVisualStyleBackColor = false;
            this.btnFileManager.Click += new System.EventHandler(this.btnFileManager_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(70)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.IconChar = FontAwesome.Sharp.IconChar.ChartArea;
            this.btnDashboard.IconColor = System.Drawing.Color.White;
            this.btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDashboard.IconSize = 30;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 42);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnDashboard.Size = new System.Drawing.Size(192, 45);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSideMenuDisplay);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 42);
            this.panel2.TabIndex = 0;
            // 
            // btnSideMenuDisplay
            // 
            this.btnSideMenuDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSideMenuDisplay.IconChar = FontAwesome.Sharp.IconChar.Bars;
            this.btnSideMenuDisplay.IconColor = System.Drawing.Color.White;
            this.btnSideMenuDisplay.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSideMenuDisplay.IconSize = 35;
            this.btnSideMenuDisplay.Location = new System.Drawing.Point(150, 2);
            this.btnSideMenuDisplay.Name = "btnSideMenuDisplay";
            this.btnSideMenuDisplay.Size = new System.Drawing.Size(36, 42);
            this.btnSideMenuDisplay.TabIndex = 1;
            this.btnSideMenuDisplay.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encompass Doc Import / Export Utility     Version: 1.0.0.91";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelSideMenu.ResumeLayout(false);
            this.panelImportExportSubMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelMainMenu;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnSideMenuDisplay;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnSettings;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton btnFileManager;
        private System.Windows.Forms.Panel panelImportExportSubMenu;
        private FontAwesome.Sharp.IconButton btnExport;
        private FontAwesome.Sharp.IconButton btnImport;
        private FontAwesome.Sharp.IconButton btnExit;
    }
}

