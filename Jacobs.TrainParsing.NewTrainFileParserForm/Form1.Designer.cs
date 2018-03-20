namespace Jacobs.TrainParsing.NewTrainFileParserForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenAoFile = new System.Windows.Forms.Button();
            this.btnGenerateOriginal = new System.Windows.Forms.Button();
            this.txtAoFilePath = new System.Windows.Forms.TextBox();
            this.lblAoFile = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenTsdFile = new System.Windows.Forms.Button();
            this.btnOpenPFile = new System.Windows.Forms.Button();
            this.btnGenerateNew = new System.Windows.Forms.Button();
            this.txtPFilePath = new System.Windows.Forms.TextBox();
            this.txtTsdFilePath = new System.Windows.Forms.TextBox();
            this.lblPFile = new System.Windows.Forms.Label();
            this.lblTsdFile = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSummaryFile = new System.Windows.Forms.TextBox();
            this.btnOpenSummaryFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenSummaryFile);
            this.groupBox1.Controls.Add(this.txtSummaryFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnOpenAoFile);
            this.groupBox1.Controls.Add(this.btnGenerateOriginal);
            this.groupBox1.Controls.Add(this.txtAoFilePath);
            this.groupBox1.Controls.Add(this.lblAoFile);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Original Train Parsing";
            // 
            // btnOpenAoFile
            // 
            this.btnOpenAoFile.Location = new System.Drawing.Point(566, 23);
            this.btnOpenAoFile.Name = "btnOpenAoFile";
            this.btnOpenAoFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenAoFile.TabIndex = 3;
            this.btnOpenAoFile.Text = "Open File";
            this.btnOpenAoFile.UseVisualStyleBackColor = true;
            this.btnOpenAoFile.Click += new System.EventHandler(this.btnOpenAoFile_Click);
            // 
            // btnGenerateOriginal
            // 
            this.btnGenerateOriginal.Location = new System.Drawing.Point(647, 23);
            this.btnGenerateOriginal.Name = "btnGenerateOriginal";
            this.btnGenerateOriginal.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateOriginal.TabIndex = 2;
            this.btnGenerateOriginal.Text = "Generate";
            this.btnGenerateOriginal.UseVisualStyleBackColor = true;
            this.btnGenerateOriginal.Click += new System.EventHandler(this.btnGenerateOriginal_Click);
            // 
            // txtAoFilePath
            // 
            this.txtAoFilePath.Location = new System.Drawing.Point(83, 25);
            this.txtAoFilePath.Name = "txtAoFilePath";
            this.txtAoFilePath.Size = new System.Drawing.Size(477, 20);
            this.txtAoFilePath.TabIndex = 1;
            // 
            // lblAoFile
            // 
            this.lblAoFile.AutoSize = true;
            this.lblAoFile.Location = new System.Drawing.Point(7, 28);
            this.lblAoFile.Name = "lblAoFile";
            this.lblAoFile.Size = new System.Drawing.Size(41, 13);
            this.lblAoFile.TabIndex = 0;
            this.lblAoFile.Text = "AO File";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOpenTsdFile);
            this.groupBox2.Controls.Add(this.btnOpenPFile);
            this.groupBox2.Controls.Add(this.btnGenerateNew);
            this.groupBox2.Controls.Add(this.txtPFilePath);
            this.groupBox2.Controls.Add(this.txtTsdFilePath);
            this.groupBox2.Controls.Add(this.lblPFile);
            this.groupBox2.Controls.Add(this.lblTsdFile);
            this.groupBox2.Location = new System.Drawing.Point(13, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(728, 118);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fancy New Train Parsing";
            // 
            // btnOpenTsdFile
            // 
            this.btnOpenTsdFile.Location = new System.Drawing.Point(569, 41);
            this.btnOpenTsdFile.Name = "btnOpenTsdFile";
            this.btnOpenTsdFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenTsdFile.TabIndex = 7;
            this.btnOpenTsdFile.Text = "Open File";
            this.btnOpenTsdFile.UseVisualStyleBackColor = true;
            this.btnOpenTsdFile.Click += new System.EventHandler(this.btnOpenTsdFile_Click);
            // 
            // btnOpenPFile
            // 
            this.btnOpenPFile.Location = new System.Drawing.Point(568, 80);
            this.btnOpenPFile.Name = "btnOpenPFile";
            this.btnOpenPFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPFile.TabIndex = 6;
            this.btnOpenPFile.Text = "Open File";
            this.btnOpenPFile.UseVisualStyleBackColor = true;
            this.btnOpenPFile.Click += new System.EventHandler(this.btnOpenPFile_Click);
            // 
            // btnGenerateNew
            // 
            this.btnGenerateNew.Location = new System.Drawing.Point(649, 81);
            this.btnGenerateNew.Name = "btnGenerateNew";
            this.btnGenerateNew.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateNew.TabIndex = 5;
            this.btnGenerateNew.Text = "Generate";
            this.btnGenerateNew.UseVisualStyleBackColor = true;
            this.btnGenerateNew.Click += new System.EventHandler(this.btnGenerateNew_Click);
            // 
            // txtPFilePath
            // 
            this.txtPFilePath.Location = new System.Drawing.Point(52, 84);
            this.txtPFilePath.Name = "txtPFilePath";
            this.txtPFilePath.Size = new System.Drawing.Size(510, 20);
            this.txtPFilePath.TabIndex = 4;
            // 
            // txtTsdFilePath
            // 
            this.txtTsdFilePath.Location = new System.Drawing.Point(52, 44);
            this.txtTsdFilePath.Name = "txtTsdFilePath";
            this.txtTsdFilePath.Size = new System.Drawing.Size(510, 20);
            this.txtTsdFilePath.TabIndex = 3;
            // 
            // lblPFile
            // 
            this.lblPFile.AutoSize = true;
            this.lblPFile.Location = new System.Drawing.Point(10, 87);
            this.lblPFile.Name = "lblPFile";
            this.lblPFile.Size = new System.Drawing.Size(33, 13);
            this.lblPFile.TabIndex = 2;
            this.lblPFile.Text = "P File";
            // 
            // lblTsdFile
            // 
            this.lblTsdFile.AutoSize = true;
            this.lblTsdFile.Location = new System.Drawing.Point(3, 47);
            this.lblTsdFile.Name = "lblTsdFile";
            this.lblTsdFile.Size = new System.Drawing.Size(48, 13);
            this.lblTsdFile.TabIndex = 1;
            this.lblTsdFile.Text = "TSD File";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 286);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(753, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl
            // 
            this.tssl.Name = "tssl";
            this.tssl.Size = new System.Drawing.Size(118, 17);
            this.tssl.Text = "toolStripStatusLabel1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Summary File";
            // 
            // txtSummaryFile
            // 
            this.txtSummaryFile.Location = new System.Drawing.Point(83, 58);
            this.txtSummaryFile.Name = "txtSummaryFile";
            this.txtSummaryFile.Size = new System.Drawing.Size(477, 20);
            this.txtSummaryFile.TabIndex = 5;
            // 
            // btnOpenSummaryFile
            // 
            this.btnOpenSummaryFile.Location = new System.Drawing.Point(566, 58);
            this.btnOpenSummaryFile.Name = "btnOpenSummaryFile";
            this.btnOpenSummaryFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSummaryFile.TabIndex = 6;
            this.btnOpenSummaryFile.Text = "Open File";
            this.btnOpenSummaryFile.UseVisualStyleBackColor = true;
            this.btnOpenSummaryFile.Click += new System.EventHandler(this.btnOpenSummaryFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 308);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "New Train Parser";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenAoFile;
        private System.Windows.Forms.Button btnGenerateOriginal;
        private System.Windows.Forms.TextBox txtAoFilePath;
        private System.Windows.Forms.Label lblAoFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOpenTsdFile;
        private System.Windows.Forms.Button btnOpenPFile;
        private System.Windows.Forms.Button btnGenerateNew;
        private System.Windows.Forms.TextBox txtPFilePath;
        private System.Windows.Forms.TextBox txtTsdFilePath;
        private System.Windows.Forms.Label lblPFile;
        private System.Windows.Forms.Label lblTsdFile;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl;
        private System.Windows.Forms.Button btnOpenSummaryFile;
        private System.Windows.Forms.TextBox txtSummaryFile;
        private System.Windows.Forms.Label label1;
    }
}

