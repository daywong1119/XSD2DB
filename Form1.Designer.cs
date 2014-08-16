namespace xsd2sql
{
    partial class Form1
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dialogOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnCreateDB = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tableDataGV = new System.Windows.Forms.DataGridView();
            this.btnReadTamplate = new System.Windows.Forms.Button();
            this.lbLine = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGV)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(341, 3);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(103, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate SQL";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dialogOpenFile
            // 
            this.dialogOpenFile.FileName = "openFileDialog1";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(260, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load XSD";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "XSD Location: ";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(15, 41);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(225, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(12, 119);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(448, 380);
            this.txtContent.TabIndex = 5;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(97, 15);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(143, 20);
            this.txtPath.TabIndex = 6;
            // 
            // btnCreateDB
            // 
            this.btnCreateDB.Location = new System.Drawing.Point(450, 3);
            this.btnCreateDB.Name = "btnCreateDB";
            this.btnCreateDB.Size = new System.Drawing.Size(103, 23);
            this.btnCreateDB.TabIndex = 7;
            this.btnCreateDB.Text = "Create Database";
            this.btnCreateDB.UseVisualStyleBackColor = true;
            this.btnCreateDB.Click += new System.EventHandler(this.btnCreateDB_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(477, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tables and Columns";
            // 
            // tableDataGV
            // 
            this.tableDataGV.AllowUserToAddRows = false;
            this.tableDataGV.AllowUserToDeleteRows = false;
            this.tableDataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableDataGV.Location = new System.Drawing.Point(481, 119);
            this.tableDataGV.Name = "tableDataGV";
            this.tableDataGV.ReadOnly = true;
            this.tableDataGV.Size = new System.Drawing.Size(440, 380);
            this.tableDataGV.TabIndex = 11;
            // 
            // btnReadTamplate
            // 
            this.btnReadTamplate.Location = new System.Drawing.Point(260, 49);
            this.btnReadTamplate.Name = "btnReadTamplate";
            this.btnReadTamplate.Size = new System.Drawing.Size(103, 23);
            this.btnReadTamplate.TabIndex = 12;
            this.btnReadTamplate.Text = "Read Template";
            this.btnReadTamplate.UseVisualStyleBackColor = true;
            this.btnReadTamplate.Click += new System.EventHandler(this.btnReadTamplate_Click);
            // 
            // lbLine
            // 
            this.lbLine.AutoSize = true;
            this.lbLine.Location = new System.Drawing.Point(260, 30);
            this.lbLine.Name = "lbLine";
            this.lbLine.Size = new System.Drawing.Size(457, 13);
            this.lbLine.TabIndex = 13;
            this.lbLine.Text = "---------------------------------------------------------------------------------" +
    "---------------------------------------------------------------------";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 511);
            this.Controls.Add(this.lbLine);
            this.Controls.Add(this.btnReadTamplate);
            this.Controls.Add(this.tableDataGV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCreateDB);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnGenerate);
            this.Name = "Form1";
            this.Text = "XSD2SQL Generator";
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.OpenFileDialog dialogOpenFile;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnCreateDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView tableDataGV;
        private System.Windows.Forms.Button btnReadTamplate;
        private System.Windows.Forms.Label lbLine;
    }
}

