namespace TOPX.UI.Forms
{
    partial class FormSelectDossierMapper
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
            this.btSubmitSelection = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbFieldSelector
            // 
            this.cmbFieldSelector.FormattingEnabled = true;
            this.cmbFieldSelector.Location = new System.Drawing.Point(22, 12);
            this.cmbFieldSelector.Name = "cmbFieldSelector";
            this.cmbFieldSelector.Size = new System.Drawing.Size(388, 21);
            this.cmbFieldSelector.TabIndex = 0;
            this.cmbFieldSelector.SelectedIndexChanged += new System.EventHandler(this.cmbFieldSelector_SelectedIndexChanged);
            // 
            // btSubmitSelection
            // 
            this.btSubmitSelection.Location = new System.Drawing.Point(428, 11);
            this.btSubmitSelection.Name = "btSubmitSelection";
            this.btSubmitSelection.Size = new System.Drawing.Size(54, 23);
            this.btSubmitSelection.TabIndex = 1;
            this.btSubmitSelection.Text = "Select";
            this.btSubmitSelection.UseVisualStyleBackColor = true;
            this.btSubmitSelection.Click += new System.EventHandler(this.btSubmitSelection_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(499, 11);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(54, 23);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // FormSelectDossierMapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 46);
            this.ControlBox = false;
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSubmitSelection);
            this.Controls.Add(this.cmbFieldSelector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectDossierMapper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormSelectDossierMapper";
            this.Load += new System.EventHandler(this.FormSelectDossierMapper_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFieldSelector;
        private System.Windows.Forms.Button btSubmitSelection;
        private System.Windows.Forms.Button btCancel;
    }
}