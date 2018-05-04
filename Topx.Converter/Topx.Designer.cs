namespace Topx.Converter
{
    partial class Topx
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
            this.btConvert = new System.Windows.Forms.Button();
            this.btImport = new System.Windows.Forms.Button();
            this.btImportFileSize = new System.Windows.Forms.Button();
            this.btChecksum = new System.Windows.Forms.Button();
            this.txtNrOfRecords = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btDelivered = new System.Windows.Forms.Button();
            this.btImportTemp = new System.Windows.Forms.Button();
            this.btMoveTmpToSource = new System.Windows.Forms.Button();
            this.btTroep = new System.Windows.Forms.Button();
            this.btUpdateSource = new System.Windows.Forms.Button();
            this.btDeleteSource = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btConvert
            // 
            this.btConvert.Location = new System.Drawing.Point(199, 192);
            this.btConvert.Name = "btConvert";
            this.btConvert.Size = new System.Drawing.Size(129, 23);
            this.btConvert.TabIndex = 0;
            this.btConvert.Text = "Convert";
            this.btConvert.UseVisualStyleBackColor = true;
            this.btConvert.Click += new System.EventHandler(this.btConvert_Click);
            // 
            // btImport
            // 
            this.btImport.Location = new System.Drawing.Point(199, 41);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(129, 23);
            this.btImport.TabIndex = 1;
            this.btImport.Text = "Import archief in db";
            this.btImport.UseVisualStyleBackColor = true;
            this.btImport.Click += new System.EventHandler(this.btImport_Click);
            // 
            // btImportFileSize
            // 
            this.btImportFileSize.Location = new System.Drawing.Point(199, 112);
            this.btImportFileSize.Name = "btImportFileSize";
            this.btImportFileSize.Size = new System.Drawing.Size(129, 23);
            this.btImportFileSize.TabIndex = 2;
            this.btImportFileSize.Text = "Import filesize in db";
            this.btImportFileSize.UseVisualStyleBackColor = true;
            this.btImportFileSize.Click += new System.EventHandler(this.btImportFileSize_Click);
            // 
            // btChecksum
            // 
            this.btChecksum.Location = new System.Drawing.Point(199, 154);
            this.btChecksum.Name = "btChecksum";
            this.btChecksum.Size = new System.Drawing.Size(129, 23);
            this.btChecksum.TabIndex = 3;
            this.btChecksum.Text = "Import checksum in db";
            this.btChecksum.UseVisualStyleBackColor = true;
            this.btChecksum.Click += new System.EventHandler(this.btChecksum_Click);
            // 
            // txtNrOfRecords
            // 
            this.txtNrOfRecords.Location = new System.Drawing.Point(483, 195);
            this.txtNrOfRecords.Name = "txtNrOfRecords";
            this.txtNrOfRecords.Size = new System.Drawing.Size(62, 20);
            this.txtNrOfRecords.TabIndex = 4;
            this.txtNrOfRecords.TextChanged += new System.EventHandler(this.txtNrOfRecords_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(397, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nr of records";
            // 
            // btDelivered
            // 
            this.btDelivered.Location = new System.Drawing.Point(400, 112);
            this.btDelivered.Name = "btDelivered";
            this.btDelivered.Size = new System.Drawing.Size(145, 23);
            this.btDelivered.TabIndex = 6;
            this.btDelivered.Text = "Mark as Delivered";
            this.btDelivered.UseVisualStyleBackColor = true;
            this.btDelivered.Click += new System.EventHandler(this.btDelivered_Click);
            // 
            // btImportTemp
            // 
            this.btImportTemp.Location = new System.Drawing.Point(400, 41);
            this.btImportTemp.Name = "btImportTemp";
            this.btImportTemp.Size = new System.Drawing.Size(145, 23);
            this.btImportTemp.TabIndex = 7;
            this.btImportTemp.Text = "Import archief in Temp";
            this.btImportTemp.UseVisualStyleBackColor = true;
            this.btImportTemp.Click += new System.EventHandler(this.btImportTemp_Click);
            // 
            // btMoveTmpToSource
            // 
            this.btMoveTmpToSource.Location = new System.Drawing.Point(400, 70);
            this.btMoveTmpToSource.Name = "btMoveTmpToSource";
            this.btMoveTmpToSource.Size = new System.Drawing.Size(145, 23);
            this.btMoveTmpToSource.TabIndex = 8;
            this.btMoveTmpToSource.Text = "Move Temp naar Source";
            this.btMoveTmpToSource.UseVisualStyleBackColor = true;
            this.btMoveTmpToSource.Click += new System.EventHandler(this.btMoveTmpToSource_Click);
            // 
            // btTroep
            // 
            this.btTroep.Location = new System.Drawing.Point(400, 149);
            this.btTroep.Name = "btTroep";
            this.btTroep.Size = new System.Drawing.Size(145, 23);
            this.btTroep.TabIndex = 9;
            this.btTroep.Text = "troep";
            this.btTroep.UseVisualStyleBackColor = true;
            this.btTroep.Click += new System.EventHandler(this.btTroep_Click);
            // 
            // btUpdateSource
            // 
            this.btUpdateSource.Location = new System.Drawing.Point(199, 70);
            this.btUpdateSource.Name = "btUpdateSource";
            this.btUpdateSource.Size = new System.Drawing.Size(129, 23);
            this.btUpdateSource.TabIndex = 10;
            this.btUpdateSource.Text = "Update archief in db";
            this.btUpdateSource.UseVisualStyleBackColor = true;
            this.btUpdateSource.Click += new System.EventHandler(this.btUpdateSource_Click);
            // 
            // btDeleteSource
            // 
            this.btDeleteSource.Location = new System.Drawing.Point(46, 41);
            this.btDeleteSource.Name = "btDeleteSource";
            this.btDeleteSource.Size = new System.Drawing.Size(129, 23);
            this.btDeleteSource.TabIndex = 11;
            this.btDeleteSource.Text = "Delete source table";
            this.btDeleteSource.UseVisualStyleBackColor = true;
            this.btDeleteSource.Click += new System.EventHandler(this.btDeleteSource_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(41, 283);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(578, 173);
            this.txtLog.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Log";
            // 
            // Topx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 510);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btDeleteSource);
            this.Controls.Add(this.btUpdateSource);
            this.Controls.Add(this.btTroep);
            this.Controls.Add(this.btMoveTmpToSource);
            this.Controls.Add(this.btImportTemp);
            this.Controls.Add(this.btDelivered);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNrOfRecords);
            this.Controls.Add(this.btChecksum);
            this.Controls.Add(this.btImportFileSize);
            this.Controls.Add(this.btImport);
            this.Controls.Add(this.btConvert);
            this.Name = "Topx";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConvert;
        private System.Windows.Forms.Button btImport;
        private System.Windows.Forms.Button btImportFileSize;
        private System.Windows.Forms.Button btChecksum;
        private System.Windows.Forms.TextBox txtNrOfRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btDelivered;
        private System.Windows.Forms.Button btImportTemp;
        private System.Windows.Forms.Button btMoveTmpToSource;
        private System.Windows.Forms.Button btTroep;
        private System.Windows.Forms.Button btUpdateSource;
        private System.Windows.Forms.Button btDeleteSource;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label2;
    }
}

