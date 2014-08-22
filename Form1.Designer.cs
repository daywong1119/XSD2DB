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
            this.dialogOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableDataGV = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.staffGV = new System.Windows.Forms.DataGridView();
            this.orderGV = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReadTamplate = new System.Windows.Forms.Button();
            this.btnCreateDB = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderGV)).BeginInit();
            this.SuspendLayout();
            // 
            // dialogOpenFile
            // 
            this.dialogOpenFile.FileName = "openFileDialog1";
            // 
            // txtContent
            // 
            this.txtContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(54)))));
            this.txtContent.ForeColor = System.Drawing.Color.White;
            this.txtContent.Location = new System.Drawing.Point(16, 147);
            this.txtContent.Margin = new System.Windows.Forms.Padding(4);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(553, 534);
            this.txtContent.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(588, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tables and Columns";
            // 
            // tableDataGV
            // 
            this.tableDataGV.AllowUserToAddRows = false;
            this.tableDataGV.AllowUserToDeleteRows = false;
            this.tableDataGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(54)))));
            this.tableDataGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableDataGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableDataGV.GridColor = System.Drawing.SystemColors.ControlLight;
            this.tableDataGV.Location = new System.Drawing.Point(594, 147);
            this.tableDataGV.Margin = new System.Windows.Forms.Padding(4);
            this.tableDataGV.Name = "tableDataGV";
            this.tableDataGV.ReadOnly = true;
            this.tableDataGV.Size = new System.Drawing.Size(510, 224);
            this.tableDataGV.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(590, 402);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "Table(1)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(882, 402);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "Table(2)";
            // 
            // staffGV
            // 
            this.staffGV.AllowUserToAddRows = false;
            this.staffGV.AllowUserToDeleteRows = false;
            this.staffGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(54)))));
            this.staffGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.staffGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.staffGV.GridColor = System.Drawing.SystemColors.ControlLight;
            this.staffGV.Location = new System.Drawing.Point(594, 431);
            this.staffGV.Margin = new System.Windows.Forms.Padding(4);
            this.staffGV.Name = "staffGV";
            this.staffGV.ReadOnly = true;
            this.staffGV.Size = new System.Drawing.Size(249, 247);
            this.staffGV.TabIndex = 16;
            // 
            // orderGV
            // 
            this.orderGV.AllowUserToAddRows = false;
            this.orderGV.AllowUserToDeleteRows = false;
            this.orderGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(54)))));
            this.orderGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.orderGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderGV.GridColor = System.Drawing.SystemColors.ControlLight;
            this.orderGV.Location = new System.Drawing.Point(868, 431);
            this.orderGV.Margin = new System.Windows.Forms.Padding(4);
            this.orderGV.Name = "orderGV";
            this.orderGV.ReadOnly = true;
            this.orderGV.Size = new System.Drawing.Size(235, 247);
            this.orderGV.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(16, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Information Viewer";
            // 
            // btnReadTamplate
            // 
            this.btnReadTamplate.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReadTamplate.FlatAppearance.BorderSize = 0;
            this.btnReadTamplate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnReadTamplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadTamplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadTamplate.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReadTamplate.Location = new System.Drawing.Point(505, 55);
            this.btnReadTamplate.Margin = new System.Windows.Forms.Padding(4);
            this.btnReadTamplate.Name = "btnReadTamplate";
            this.btnReadTamplate.Size = new System.Drawing.Size(180, 31);
            this.btnReadTamplate.TabIndex = 26;
            this.btnReadTamplate.Text = "Read Template";
            this.btnReadTamplate.UseVisualStyleBackColor = true;
            this.btnReadTamplate.Click += new System.EventHandler(this.btnReadTamplate_Click_1);
            // 
            // btnCreateDB
            // 
            this.btnCreateDB.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCreateDB.FlatAppearance.BorderSize = 0;
            this.btnCreateDB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnCreateDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateDB.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCreateDB.Location = new System.Drawing.Point(882, 17);
            this.btnCreateDB.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateDB.Name = "btnCreateDB";
            this.btnCreateDB.Size = new System.Drawing.Size(180, 31);
            this.btnCreateDB.TabIndex = 25;
            this.btnCreateDB.Text = "Create Database";
            this.btnCreateDB.UseVisualStyleBackColor = true;
            this.btnCreateDB.Click += new System.EventHandler(this.btnCreateDB_Click_1);
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(54)))));
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.ForeColor = System.Drawing.Color.White;
            this.txtPath.Location = new System.Drawing.Point(188, 22);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(189, 22);
            this.txtPath.TabIndex = 24;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.Transparent;
            this.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBrowse.Location = new System.Drawing.Point(79, 55);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(300, 31);
            this.btnBrowse.TabIndex = 23;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(75, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "XSD Location: ";
            // 
            // btnLoad
            // 
            this.btnLoad.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLoad.Location = new System.Drawing.Point(505, 17);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(180, 31);
            this.btnLoad.TabIndex = 21;
            this.btnLoad.Text = "Load XSD";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click_1);
            // 
            // btnGenerate
            // 
            this.btnGenerate.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGenerate.Location = new System.Drawing.Point(693, 17);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(180, 31);
            this.btnGenerate.TabIndex = 20;
            this.btnGenerate.Text = "Generate SQL";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(-8, 1);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 91);
            this.label6.TabIndex = 27;
            this.label6.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(435, 1);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 91);
            this.label7.TabIndex = 28;
            this.label7.Text = "2";
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1124, 102);
            this.splitter1.TabIndex = 19;
            this.splitter1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1124, 692);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnReadTamplate);
            this.Controls.Add(this.btnCreateDB);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.orderGV);
            this.Controls.Add(this.staffGV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableDataGV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtContent);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "XSD2SQL Generator";
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dialogOpenFile;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView tableDataGV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView staffGV;
        private System.Windows.Forms.DataGridView orderGV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReadTamplate;
        private System.Windows.Forms.Button btnCreateDB;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Splitter splitter1;
    }
}

