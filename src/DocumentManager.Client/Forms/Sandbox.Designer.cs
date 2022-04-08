
namespace DocumentExportUtility_API.Forms
{
    partial class Sandbox
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
            this.button1 = new System.Windows.Forms.Button();
            this.mtbConsole = new System.Windows.Forms.TextBox();
            this.btnCloseForm = new FontAwesome.Sharp.IconButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLoanGuid = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.cbCopyGuid = new System.Windows.Forms.CheckBox();
            this.tbAssignDocsGuid = new System.Windows.Forms.TextBox();
            this.tbAssignDocsConfigPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowseConfig = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAssignDocs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mtbConsole
            // 
            this.mtbConsole.AcceptsReturn = true;
            this.mtbConsole.Location = new System.Drawing.Point(12, 203);
            this.mtbConsole.Multiline = true;
            this.mtbConsole.Name = "mtbConsole";
            this.mtbConsole.ReadOnly = true;
            this.mtbConsole.Size = new System.Drawing.Size(120, 81);
            this.mtbConsole.TabIndex = 1;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.FlatAppearance.BorderSize = 0;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnCloseForm.IconColor = System.Drawing.Color.White;
            this.btnCloseForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCloseForm.IconSize = 30;
            this.btnCloseForm.Location = new System.Drawing.Point(1178, 142);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(59, 39);
            this.btnCloseForm.TabIndex = 18;
            this.btnCloseForm.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(287, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(230, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "(Imports files into File Manager in eFolder)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(189, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "Assign Files";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(487, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Please select a file(s) you would like to import:";
            // 
            // tbLoanGuid
            // 
            this.tbLoanGuid.Location = new System.Drawing.Point(579, 192);
            this.tbLoanGuid.Name = "tbLoanGuid";
            this.tbLoanGuid.Size = new System.Drawing.Size(359, 23);
            this.tbLoanGuid.TabIndex = 14;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(748, 163);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 8;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(509, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Loan GUID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(186, 142);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(161, 30);
            this.label1.TabIndex = 10;
            this.label1.Text = "Import Files";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(640, 221);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(160, 23);
            this.btnImport.TabIndex = 15;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // cbCopyGuid
            // 
            this.cbCopyGuid.AutoSize = true;
            this.cbCopyGuid.ForeColor = System.Drawing.Color.Gainsboro;
            this.cbCopyGuid.Location = new System.Drawing.Point(920, 311);
            this.cbCopyGuid.Name = "cbCopyGuid";
            this.cbCopyGuid.Size = new System.Drawing.Size(155, 19);
            this.cbCopyGuid.TabIndex = 23;
            this.cbCopyGuid.Text = "Use same GUID as above";
            this.cbCopyGuid.UseVisualStyleBackColor = true;
            // 
            // tbAssignDocsGuid
            // 
            this.tbAssignDocsGuid.Location = new System.Drawing.Point(555, 309);
            this.tbAssignDocsGuid.Name = "tbAssignDocsGuid";
            this.tbAssignDocsGuid.Size = new System.Drawing.Size(359, 23);
            this.tbAssignDocsGuid.TabIndex = 21;
            // 
            // tbAssignDocsConfigPath
            // 
            this.tbAssignDocsConfigPath.Enabled = false;
            this.tbAssignDocsConfigPath.Location = new System.Drawing.Point(709, 283);
            this.tbAssignDocsConfigPath.Name = "tbAssignDocsConfigPath";
            this.tbAssignDocsConfigPath.Size = new System.Drawing.Size(205, 23);
            this.tbAssignDocsConfigPath.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(485, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Loan GUID:";
            // 
            // btnBrowseConfig
            // 
            this.btnBrowseConfig.Location = new System.Drawing.Point(920, 282);
            this.btnBrowseConfig.Name = "btnBrowseConfig";
            this.btnBrowseConfig.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseConfig.TabIndex = 17;
            this.btnBrowseConfig.Text = "Browse";
            this.btnBrowseConfig.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Gainsboro;
            this.label9.Location = new System.Drawing.Point(624, 265);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(530, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "(Assigns unassigned eFolder files to a document specified by the selected documen" +
    "t configuration)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(485, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(218, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Please select a document configuration:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(478, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "Assign Documents";
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.textBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBox1.Location = new System.Drawing.Point(287, 193);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(173, 110);
            this.textBox1.TabIndex = 22;
            // 
            // btnAssignDocs
            // 
            this.btnAssignDocs.Location = new System.Drawing.Point(619, 397);
            this.btnAssignDocs.Name = "btnAssignDocs";
            this.btnAssignDocs.Size = new System.Drawing.Size(160, 23);
            this.btnAssignDocs.TabIndex = 5;
            this.btnAssignDocs.Text = "Assign";
            this.btnAssignDocs.UseVisualStyleBackColor = true;
            // 
            // Sandbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 832);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLoanGuid);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.cbCopyGuid);
            this.Controls.Add(this.tbAssignDocsGuid);
            this.Controls.Add(this.tbAssignDocsConfigPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowseConfig);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnAssignDocs);
            this.Controls.Add(this.mtbConsole);
            this.Controls.Add(this.button1);
            this.Name = "Sandbox";
            this.Text = "Sandbox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox mtbConsole;
        private FontAwesome.Sharp.IconButton btnCloseForm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLoanGuid;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.CheckBox cbCopyGuid;
        private System.Windows.Forms.TextBox tbAssignDocsGuid;
        private System.Windows.Forms.TextBox tbAssignDocsConfigPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowseConfig;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAssignDocs;
    }
}