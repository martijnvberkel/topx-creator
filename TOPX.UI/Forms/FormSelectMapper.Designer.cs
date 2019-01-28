namespace TOPX.UI.Forms
{
    partial class FormSelectMapper
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
            this.cmbFieldSelector = new System.Windows.Forms.ComboBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbFieldSelector
            // 
            this.cmbFieldSelector.FormattingEnabled = true;
            this.cmbFieldSelector.Location = new System.Drawing.Point(22, 31);
            this.cmbFieldSelector.Name = "cmbFieldSelector";
            this.cmbFieldSelector.Size = new System.Drawing.Size(278, 21);
            this.cmbFieldSelector.TabIndex = 0;
            this.cmbFieldSelector.SelectionChangeCommitted += new System.EventHandler(this.cmbFieldSelector_SelectionChangeCommitted);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btCancel.Location = new System.Drawing.Point(306, 30);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(54, 23);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selecteer te koppelen veld";
            // 
            // FormSelectDossierMapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(380, 81);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.cmbFieldSelector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectDossierMapper";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormSelectDossierMapper";
            this.Load += new System.EventHandler(this.FormSelectDossierMapper_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFieldSelector;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label1;
    }
}