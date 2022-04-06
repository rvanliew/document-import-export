
namespace DocumentExportUtility_API.Forms
{
    partial class Import
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCloseForm = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelImportSingle = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLoanGuid = new System.Windows.Forms.TextBox();
            this.btnBrowsePdfs = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.cbCopyGuid = new System.Windows.Forms.CheckBox();
            this.tbAssignDocsGuid = new System.Windows.Forms.TextBox();
            this.tbAssignDocsConfigPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowseConfig = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAssignDocs = new System.Windows.Forms.Button();
            this.panelImportBatch = new System.Windows.Forms.Panel();
            this.lbLoanReportPath = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbRootFolderPath = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnBrowseRootFolder = new System.Windows.Forms.Button();
            this.btnBrowseLoanReport = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.mtbConsole = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelImportSingle.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panelImportBatch.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(18)))));
            this.panel1.Controls.Add(this.btnCloseForm);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1056, 42);
            this.panel1.TabIndex = 0;
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
            this.btnCloseForm.TabIndex = 37;
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(138, 30);
            this.label1.TabIndex = 29;
            this.label1.Text = "Import Data";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(147, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(230, 15);
            this.label8.TabIndex = 32;
            this.label8.Text = "(Imports files into File Manager in eFolder)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Gainsboro;
            this.label9.Location = new System.Drawing.Point(398, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(530, 15);
            this.label9.TabIndex = 35;
            this.label9.Text = "(Assigns unassigned eFolder files to a document specified by the selected documen" +
    "t configuration)";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(18)))));
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.mtbConsole);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1056, 639);
            this.panel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 21);
            this.label6.TabIndex = 42;
            this.label6.Text = "Output";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.panel3.Controls.Add(this.panelImportSingle);
            this.panel3.Controls.Add(this.panelImportBatch);
            this.panel3.Location = new System.Drawing.Point(12, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1032, 305);
            this.panel3.TabIndex = 0;
            // 
            // panelImportSingle
            // 
            this.panelImportSingle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelImportSingle.Controls.Add(this.panel7);
            this.panelImportSingle.Controls.Add(this.label2);
            this.panelImportSingle.Controls.Add(this.tbLoanGuid);
            this.panelImportSingle.Controls.Add(this.btnBrowsePdfs);
            this.panelImportSingle.Controls.Add(this.label4);
            this.panelImportSingle.Controls.Add(this.btnImport);
            this.panelImportSingle.Controls.Add(this.cbCopyGuid);
            this.panelImportSingle.Controls.Add(this.tbAssignDocsGuid);
            this.panelImportSingle.Controls.Add(this.tbAssignDocsConfigPath);
            this.panelImportSingle.Controls.Add(this.label3);
            this.panelImportSingle.Controls.Add(this.btnBrowseConfig);
            this.panelImportSingle.Controls.Add(this.label7);
            this.panelImportSingle.Controls.Add(this.label5);
            this.panelImportSingle.Controls.Add(this.btnAssignDocs);
            this.panelImportSingle.Location = new System.Drawing.Point(4, 4);
            this.panelImportSingle.Name = "panelImportSingle";
            this.panelImportSingle.Size = new System.Drawing.Size(505, 298);
            this.panelImportSingle.TabIndex = 44;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label11);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(503, 25);
            this.panel7.TabIndex = 56;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(197, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 21);
            this.label11.TabIndex = 1;
            this.label11.Text = "Single Import";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 15);
            this.label2.TabIndex = 44;
            this.label2.Text = "Please select file(s) you would like to import:";
            // 
            // tbLoanGuid
            // 
            this.tbLoanGuid.Location = new System.Drawing.Point(115, 60);
            this.tbLoanGuid.Name = "tbLoanGuid";
            this.tbLoanGuid.PlaceholderText = "No GUID Entered";
            this.tbLoanGuid.Size = new System.Drawing.Size(268, 23);
            this.tbLoanGuid.TabIndex = 49;
            // 
            // btnBrowsePdfs
            // 
            this.btnBrowsePdfs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(70)))));
            this.btnBrowsePdfs.FlatAppearance.BorderSize = 0;
            this.btnBrowsePdfs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(115)))));
            this.btnBrowsePdfs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowsePdfs.ForeColor = System.Drawing.Color.White;
            this.btnBrowsePdfs.Location = new System.Drawing.Point(272, 31);
            this.btnBrowsePdfs.Name = "btnBrowsePdfs";
            this.btnBrowsePdfs.Size = new System.Drawing.Size(111, 23);
            this.btnBrowsePdfs.TabIndex = 45;
            this.btnBrowsePdfs.Text = "Browse PDF(s)";
            this.btnBrowsePdfs.UseVisualStyleBackColor = false;
            this.btnBrowsePdfs.Click += new System.EventHandler(this.btnBrowsePdfs_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 46;
            this.label4.Text = "GUID:";
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(70)))));
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(115)))));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(115, 89);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(268, 32);
            this.btnImport.TabIndex = 50;
            this.btnImport.Text = "Import File(s)";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cbCopyGuid
            // 
            this.cbCopyGuid.AutoSize = true;
            this.cbCopyGuid.ForeColor = System.Drawing.Color.Gainsboro;
            this.cbCopyGuid.Location = new System.Drawing.Point(389, 212);
            this.cbCopyGuid.Name = "cbCopyGuid";
            this.cbCopyGuid.Size = new System.Drawing.Size(106, 19);
            this.cbCopyGuid.TabIndex = 55;
            this.cbCopyGuid.Text = "Use same GUID";
            this.cbCopyGuid.UseVisualStyleBackColor = true;
            this.cbCopyGuid.CheckedChanged += new System.EventHandler(this.cbCopyGuid_CheckedChanged);
            // 
            // tbAssignDocsGuid
            // 
            this.tbAssignDocsGuid.Location = new System.Drawing.Point(115, 209);
            this.tbAssignDocsGuid.Name = "tbAssignDocsGuid";
            this.tbAssignDocsGuid.PlaceholderText = "No GUID Entered";
            this.tbAssignDocsGuid.Size = new System.Drawing.Size(268, 23);
            this.tbAssignDocsGuid.TabIndex = 54;
            // 
            // tbAssignDocsConfigPath
            // 
            this.tbAssignDocsConfigPath.Enabled = false;
            this.tbAssignDocsConfigPath.Location = new System.Drawing.Point(115, 180);
            this.tbAssignDocsConfigPath.Name = "tbAssignDocsConfigPath";
            this.tbAssignDocsConfigPath.PlaceholderText = "No File Selected";
            this.tbAssignDocsConfigPath.Size = new System.Drawing.Size(268, 23);
            this.tbAssignDocsConfigPath.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 53;
            this.label3.Text = "GUID:";
            // 
            // btnBrowseConfig
            // 
            this.btnBrowseConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(70)))));
            this.btnBrowseConfig.FlatAppearance.BorderSize = 0;
            this.btnBrowseConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(115)))));
            this.btnBrowseConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseConfig.ForeColor = System.Drawing.Color.White;
            this.btnBrowseConfig.Location = new System.Drawing.Point(389, 180);
            this.btnBrowseConfig.Name = "btnBrowseConfig";
            this.btnBrowseConfig.Size = new System.Drawing.Size(111, 23);
            this.btnBrowseConfig.TabIndex = 51;
            this.btnBrowseConfig.Text = "Browse";
            this.btnBrowseConfig.UseVisualStyleBackColor = false;
            this.btnBrowseConfig.Click += new System.EventHandler(this.btnBrowseConfig_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(8, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 15);
            this.label7.TabIndex = 48;
            this.label7.Text = "Config File (.xlsx)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 21);
            this.label5.TabIndex = 47;
            this.label5.Text = "Assign Documents";
            // 
            // btnAssignDocs
            // 
            this.btnAssignDocs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(70)))));
            this.btnAssignDocs.FlatAppearance.BorderSize = 0;
            this.btnAssignDocs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(115)))));
            this.btnAssignDocs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignDocs.ForeColor = System.Drawing.Color.White;
            this.btnAssignDocs.Location = new System.Drawing.Point(115, 238);
            this.btnAssignDocs.Name = "btnAssignDocs";
            this.btnAssignDocs.Size = new System.Drawing.Size(268, 32);
            this.btnAssignDocs.TabIndex = 43;
            this.btnAssignDocs.Text = "Assign";
            this.btnAssignDocs.UseVisualStyleBackColor = false;
            this.btnAssignDocs.Click += new System.EventHandler(this.btnAssignDocs_Click);
            // 
            // panelImportBatch
            // 
            this.panelImportBatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.panelImportBatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelImportBatch.Controls.Add(this.lbLoanReportPath);
            this.panelImportBatch.Controls.Add(this.label14);
            this.panelImportBatch.Controls.Add(this.lbRootFolderPath);
            this.panelImportBatch.Controls.Add(this.label12);
            this.panelImportBatch.Controls.Add(this.btnBrowseRootFolder);
            this.panelImportBatch.Controls.Add(this.btnBrowseLoanReport);
            this.panelImportBatch.Controls.Add(this.panel6);
            this.panelImportBatch.Location = new System.Drawing.Point(524, 4);
            this.panelImportBatch.Name = "panelImportBatch";
            this.panelImportBatch.Size = new System.Drawing.Size(505, 298);
            this.panelImportBatch.TabIndex = 43;
            // 
            // lbLoanReportPath
            // 
            this.lbLoanReportPath.AutoSize = true;
            this.lbLoanReportPath.ForeColor = System.Drawing.Color.White;
            this.lbLoanReportPath.Location = new System.Drawing.Point(121, 133);
            this.lbLoanReportPath.Name = "lbLoanReportPath";
            this.lbLoanReportPath.Size = new System.Drawing.Size(91, 15);
            this.lbLoanReportPath.TabIndex = 53;
            this.lbLoanReportPath.Text = "No file selected.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(4, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(206, 15);
            this.label14.TabIndex = 51;
            this.label14.Text = "Select Encompass loan report (.xlsx)";
            // 
            // lbRootFolderPath
            // 
            this.lbRootFolderPath.AutoSize = true;
            this.lbRootFolderPath.ForeColor = System.Drawing.Color.White;
            this.lbRootFolderPath.Location = new System.Drawing.Point(121, 53);
            this.lbRootFolderPath.Name = "lbRootFolderPath";
            this.lbRootFolderPath.Size = new System.Drawing.Size(106, 15);
            this.lbRootFolderPath.TabIndex = 50;
            this.lbRootFolderPath.Text = "No folder selected.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(4, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(148, 15);
            this.label12.TabIndex = 49;
            this.label12.Text = "Select Import root folder";
            // 
            // btnBrowseRootFolder
            // 
            this.btnBrowseRootFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(70)))));
            this.btnBrowseRootFolder.FlatAppearance.BorderSize = 0;
            this.btnBrowseRootFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(115)))));
            this.btnBrowseRootFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseRootFolder.ForeColor = System.Drawing.Color.White;
            this.btnBrowseRootFolder.Location = new System.Drawing.Point(4, 49);
            this.btnBrowseRootFolder.Name = "btnBrowseRootFolder";
            this.btnBrowseRootFolder.Size = new System.Drawing.Size(111, 23);
            this.btnBrowseRootFolder.TabIndex = 48;
            this.btnBrowseRootFolder.Text = "Browse";
            this.btnBrowseRootFolder.UseVisualStyleBackColor = false;
            this.btnBrowseRootFolder.Click += new System.EventHandler(this.btnBrowseRootFolder_Click);
            // 
            // btnBrowseLoanReport
            // 
            this.btnBrowseLoanReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(70)))));
            this.btnBrowseLoanReport.FlatAppearance.BorderSize = 0;
            this.btnBrowseLoanReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(115)))));
            this.btnBrowseLoanReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseLoanReport.ForeColor = System.Drawing.Color.White;
            this.btnBrowseLoanReport.Location = new System.Drawing.Point(4, 129);
            this.btnBrowseLoanReport.Name = "btnBrowseLoanReport";
            this.btnBrowseLoanReport.Size = new System.Drawing.Size(111, 23);
            this.btnBrowseLoanReport.TabIndex = 46;
            this.btnBrowseLoanReport.Text = "Browse";
            this.btnBrowseLoanReport.UseVisualStyleBackColor = false;
            this.btnBrowseLoanReport.Click += new System.EventHandler(this.btnBrowseLoanReport_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label10);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(503, 25);
            this.panel6.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(191, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 21);
            this.label10.TabIndex = 0;
            this.label10.Text = "Batch Import";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mtbConsole
            // 
            this.mtbConsole.AcceptsReturn = true;
            this.mtbConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(36)))));
            this.mtbConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mtbConsole.ForeColor = System.Drawing.Color.Gainsboro;
            this.mtbConsole.Location = new System.Drawing.Point(12, 342);
            this.mtbConsole.Multiline = true;
            this.mtbConsole.Name = "mtbConsole";
            this.mtbConsole.ReadOnly = true;
            this.mtbConsole.Size = new System.Drawing.Size(1032, 285);
            this.mtbConsole.TabIndex = 41;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 681);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Import";
            this.Text = "Import";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelImportSingle.ResumeLayout(false);
            this.panelImportSingle.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panelImportBatch.ResumeLayout(false);
            this.panelImportBatch.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton btnCloseForm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox mtbConsole;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelImportSingle;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLoanGuid;
        private System.Windows.Forms.Button btnBrowsePdfs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.CheckBox cbCopyGuid;
        private System.Windows.Forms.TextBox tbAssignDocsGuid;
        private System.Windows.Forms.TextBox tbAssignDocsConfigPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowseConfig;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAssignDocs;
        private System.Windows.Forms.Panel panelImportBatch;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnBrowseLoanReport;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label lbLoanReportPath;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbRootFolderPath;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnBrowseRootFolder;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}