
namespace DocumentExportUtility_API.Forms
{
    partial class Export
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
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCloseForm = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseDocConfig = new System.Windows.Forms.Button();
            this.tbConfig = new System.Windows.Forms.TextBox();
            this.btnBrowseLoanReport = new System.Windows.Forms.Button();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.btnExportPathBrowse = new System.Windows.Forms.Button();
            this.tbExportPath = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(18)))));
            this.panel1.Controls.Add(this.btnCloseForm);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1056, 42);
            this.panel1.TabIndex = 15;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.FlatAppearance.BorderSize = 0;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnCloseForm.IconColor = System.Drawing.Color.White;
            this.btnCloseForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCloseForm.IconSize = 30;
            this.btnCloseForm.Location = new System.Drawing.Point(997, 0);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(59, 39);
            this.btnCloseForm.TabIndex = 1;
            this.toolTip.SetToolTip(this.btnCloseForm, "Close Form");
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            this.btnCloseForm.MouseLeave += new System.EventHandler(this.btnCloseForm_MouseLeave);
            this.btnCloseForm.MouseHover += new System.EventHandler(this.btnCloseForm_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(160, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Export Data";
            // 
            // btnBrowseDocConfig
            // 
            this.btnBrowseDocConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(70)))));
            this.btnBrowseDocConfig.FlatAppearance.BorderSize = 0;
            this.btnBrowseDocConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(115)))));
            this.btnBrowseDocConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseDocConfig.ForeColor = System.Drawing.Color.White;
            this.btnBrowseDocConfig.Location = new System.Drawing.Point(501, 31);
            this.btnBrowseDocConfig.Name = "btnBrowseDocConfig";
            this.btnBrowseDocConfig.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDocConfig.TabIndex = 1;
            this.btnBrowseDocConfig.Text = "Browse";
            this.btnBrowseDocConfig.UseVisualStyleBackColor = false;
            this.btnBrowseDocConfig.Click += new System.EventHandler(this.btnBrowseDocConfig_Click);
            // 
            // tbConfig
            // 
            this.tbConfig.Location = new System.Drawing.Point(19, 31);
            this.tbConfig.Name = "tbConfig";
            this.tbConfig.PlaceholderText = "No File Selected";
            this.tbConfig.ReadOnly = true;
            this.tbConfig.Size = new System.Drawing.Size(476, 23);
            this.tbConfig.TabIndex = 0;
            // 
            // btnBrowseLoanReport
            // 
            this.btnBrowseLoanReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(70)))));
            this.btnBrowseLoanReport.FlatAppearance.BorderSize = 0;
            this.btnBrowseLoanReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(115)))));
            this.btnBrowseLoanReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseLoanReport.ForeColor = System.Drawing.Color.White;
            this.btnBrowseLoanReport.Location = new System.Drawing.Point(501, 90);
            this.btnBrowseLoanReport.Name = "btnBrowseLoanReport";
            this.btnBrowseLoanReport.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseLoanReport.TabIndex = 3;
            this.btnBrowseLoanReport.Text = "Browse";
            this.btnBrowseLoanReport.UseVisualStyleBackColor = false;
            this.btnBrowseLoanReport.Click += new System.EventHandler(this.btnBrowseLoanReport_Click);
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(19, 91);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.PlaceholderText = "No File Selected";
            this.tbFileName.ReadOnly = true;
            this.tbFileName.Size = new System.Drawing.Size(476, 23);
            this.tbFileName.TabIndex = 2;
            // 
            // tbConsole
            // 
            this.tbConsole.AcceptsReturn = true;
            this.tbConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.tbConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbConsole.ForeColor = System.Drawing.Color.White;
            this.tbConsole.Location = new System.Drawing.Point(40, 316);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ReadOnly = true;
            this.tbConsole.Size = new System.Drawing.Size(965, 311);
            this.tbConsole.TabIndex = 1;
            // 
            // btnExportPathBrowse
            // 
            this.btnExportPathBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(70)))));
            this.btnExportPathBrowse.FlatAppearance.BorderSize = 0;
            this.btnExportPathBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(115)))));
            this.btnExportPathBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPathBrowse.ForeColor = System.Drawing.Color.White;
            this.btnExportPathBrowse.Location = new System.Drawing.Point(501, 147);
            this.btnExportPathBrowse.Name = "btnExportPathBrowse";
            this.btnExportPathBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnExportPathBrowse.TabIndex = 5;
            this.btnExportPathBrowse.Text = "Browse";
            this.btnExportPathBrowse.UseVisualStyleBackColor = false;
            this.btnExportPathBrowse.Click += new System.EventHandler(this.btnExportPathBrowse_Click);
            // 
            // tbExportPath
            // 
            this.tbExportPath.Location = new System.Drawing.Point(19, 148);
            this.tbExportPath.Name = "tbExportPath";
            this.tbExportPath.PlaceholderText = "No Folder Selected";
            this.tbExportPath.ReadOnly = true;
            this.tbExportPath.Size = new System.Drawing.Size(476, 23);
            this.tbExportPath.TabIndex = 4;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(70)))));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(115)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExport.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExport.Location = new System.Drawing.Point(390, 201);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(186, 30);
            this.btnExport.TabIndex = 23;
            this.btnExport.Text = "Export PDF (.pdf)";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panel7);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1056, 681);
            this.panelMain.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(18)))));
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.panel2);
            this.panel7.Controls.Add(this.tbConsole);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 42);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1056, 639);
            this.panel7.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(40, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 21);
            this.label2.TabIndex = 25;
            this.label2.Text = "Output";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tbConfig);
            this.panel2.Controls.Add(this.btnBrowseDocConfig);
            this.panel2.Controls.Add(this.btnBrowseLoanReport);
            this.panel2.Controls.Add(this.btnExportPathBrowse);
            this.panel2.Controls.Add(this.tbFileName);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.tbExportPath);
            this.panel2.Location = new System.Drawing.Point(40, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(965, 256);
            this.panel2.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(19, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "Export Path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(19, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "Please select a Loan list (Encompass report)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(19, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Please select a document configuration (xlsx)";
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.White;
            // 
            // Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1056, 681);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Export";
            this.Text = "Export";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBrowseDocConfig;
        private System.Windows.Forms.TextBox tbConfig;
        private System.Windows.Forms.Button btnBrowseLoanReport;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.Button btnExportPathBrowse;
        private System.Windows.Forms.TextBox tbExportPath;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnCloseForm;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}