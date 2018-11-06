using System.Windows.Forms;
using TOPX.UI.Controls;

namespace TOPX.UI
{
    partial class TopXConverter
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
            this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.materialContextMenuStrip2 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.materialContextMenuStrip3 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.ditIs1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ditIs2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ditIs3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogDossiers = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogRecords = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogFiles = new System.Windows.Forms.FolderBrowserDialog();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabGlobals = new System.Windows.Forms.TabPage();
            this.txtIdentificatieArchief = new TOPX.UI.Controls.PlaceHolderTextBox();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.btSaveGlobals = new System.Windows.Forms.Button();
            this.btFillDatumArchief = new System.Windows.Forms.Button();
            this.txtNaamArchief = new TOPX.UI.Controls.PlaceHolderTextBox();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.txtDoelArchief = new TOPX.UI.Controls.PlaceHolderTextBox();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.txtBronArchief = new TOPX.UI.Controls.PlaceHolderTextBox();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.txtOmschrijvingArchief = new TOPX.UI.Controls.PlaceHolderTextBox();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.txtDatumArchief = new System.Windows.Forms.MaskedTextBox();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.tabLoadFiles = new System.Windows.Forms.TabPage();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtRecordBestandLocation = new System.Windows.Forms.TextBox();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.txtDossierLocation = new System.Windows.Forms.TextBox();
            this.gridFieldMappingRecords = new System.Windows.Forms.DataGridView();
            this.DatabaseFieldNameRecords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MappedFieldNameRecords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridFieldMappingDossiers = new System.Windows.Forms.DataGridView();
            this.MappedFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatabaseFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabImportFiles = new System.Windows.Forms.TabPage();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtErrorRecords = new System.Windows.Forms.TextBox();
            this.txtErrorsDossiers = new System.Windows.Forms.TextBox();
            this.btImportFiles = new MaterialSkin.Controls.MaterialFlatButton();
            this.tabBestanden = new System.Windows.Forms.TabPage();
            this.btAnalyse = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtFileLocation = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btFileLocation = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tabGenerateTopX = new System.Windows.Forms.TabPage();
            this.txtLogTopXCreate = new System.Windows.Forms.TextBox();
            this.btCreateTopX = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialContextMenuStrip2.SuspendLayout();
            this.materialContextMenuStrip3.SuspendLayout();
            this.materialTabControl1.SuspendLayout();
            this.tabGlobals.SuspendLayout();
            this.tabLoadFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFieldMappingRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFieldMappingDossiers)).BeginInit();
            this.tabImportFiles.SuspendLayout();
            this.tabBestanden.SuspendLayout();
            this.tabGenerateTopX.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // materialContextMenuStrip2
            // 
            this.materialContextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip2.Depth = 0;
            this.materialContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.materialContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.testToolStripMenuItem1});
            this.materialContextMenuStrip2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip2.Name = "materialContextMenuStrip2";
            this.materialContextMenuStrip2.Size = new System.Drawing.Size(114, 64);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(113, 30);
            this.testToolStripMenuItem.Text = "test";
            // 
            // testToolStripMenuItem1
            // 
            this.testToolStripMenuItem1.Name = "testToolStripMenuItem1";
            this.testToolStripMenuItem1.Size = new System.Drawing.Size(113, 30);
            this.testToolStripMenuItem1.Text = "test";
            // 
            // materialContextMenuStrip3
            // 
            this.materialContextMenuStrip3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip3.Depth = 0;
            this.materialContextMenuStrip3.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.materialContextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ditIs1ToolStripMenuItem,
            this.ditIs2ToolStripMenuItem,
            this.ditIs3ToolStripMenuItem});
            this.materialContextMenuStrip3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip3.Name = "materialContextMenuStrip3";
            this.materialContextMenuStrip3.Size = new System.Drawing.Size(131, 94);
            // 
            // ditIs1ToolStripMenuItem
            // 
            this.ditIs1ToolStripMenuItem.Name = "ditIs1ToolStripMenuItem";
            this.ditIs1ToolStripMenuItem.Size = new System.Drawing.Size(130, 30);
            this.ditIs1ToolStripMenuItem.Text = "DitIs1";
            // 
            // ditIs2ToolStripMenuItem
            // 
            this.ditIs2ToolStripMenuItem.Name = "ditIs2ToolStripMenuItem";
            this.ditIs2ToolStripMenuItem.Size = new System.Drawing.Size(130, 30);
            this.ditIs2ToolStripMenuItem.Text = "DitIs2";
            // 
            // ditIs3ToolStripMenuItem
            // 
            this.ditIs3ToolStripMenuItem.Name = "ditIs3ToolStripMenuItem";
            this.ditIs3ToolStripMenuItem.Size = new System.Drawing.Size(130, 30);
            this.ditIs3ToolStripMenuItem.Text = "DitIs3";
            // 
            // openFileDialogDossiers
            // 
            this.openFileDialogDossiers.FileName = "openDossierFileDialog";
            // 
            // openFileDialogRecords
            // 
            this.openFileDialogRecords.FileName = "openDossierFileDialog";
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(40, 98);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(1894, 52);
            this.materialTabSelector1.TabIndex = 4;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabGlobals);
            this.materialTabControl1.Controls.Add(this.tabLoadFiles);
            this.materialTabControl1.Controls.Add(this.tabImportFiles);
            this.materialTabControl1.Controls.Add(this.tabBestanden);
            this.materialTabControl1.Controls.Add(this.tabGenerateTopX);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(40, 200);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1894, 1240);
            this.materialTabControl1.TabIndex = 5;
            // 
            // tabGlobals
            // 
            this.tabGlobals.Controls.Add(this.txtIdentificatieArchief);
            this.tabGlobals.Controls.Add(this.materialLabel12);
            this.tabGlobals.Controls.Add(this.btSaveGlobals);
            this.tabGlobals.Controls.Add(this.btFillDatumArchief);
            this.tabGlobals.Controls.Add(this.txtNaamArchief);
            this.tabGlobals.Controls.Add(this.materialLabel9);
            this.tabGlobals.Controls.Add(this.txtDoelArchief);
            this.tabGlobals.Controls.Add(this.materialLabel11);
            this.tabGlobals.Controls.Add(this.txtBronArchief);
            this.tabGlobals.Controls.Add(this.materialLabel8);
            this.tabGlobals.Controls.Add(this.txtOmschrijvingArchief);
            this.tabGlobals.Controls.Add(this.materialLabel7);
            this.tabGlobals.Controls.Add(this.txtDatumArchief);
            this.tabGlobals.Controls.Add(this.materialLabel10);
            this.tabGlobals.Location = new System.Drawing.Point(4, 29);
            this.tabGlobals.Name = "tabGlobals";
            this.tabGlobals.Padding = new System.Windows.Forms.Padding(3);
            this.tabGlobals.Size = new System.Drawing.Size(1886, 1207);
            this.tabGlobals.TabIndex = 0;
            this.tabGlobals.Text = "Gegevens";
            this.tabGlobals.UseVisualStyleBackColor = true;
            // 
            // txtIdentificatieArchief
            // 
            this.txtIdentificatieArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtIdentificatieArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtIdentificatieArchief.Location = new System.Drawing.Point(402, 119);
            this.txtIdentificatieArchief.Name = "txtIdentificatieArchief";
            this.txtIdentificatieArchief.PlaceHolderText = "NL-0784-10009";
            this.txtIdentificatieArchief.Size = new System.Drawing.Size(289, 26);
            this.txtIdentificatieArchief.TabIndex = 13;
            this.txtIdentificatieArchief.Text = "NL-0784-10009";
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(169, 119);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(202, 27);
            this.materialLabel12.TabIndex = 12;
            this.materialLabel12.Text = "Identificatie Archief";
            // 
            // btSaveGlobals
            // 
            this.btSaveGlobals.Location = new System.Drawing.Point(402, 399);
            this.btSaveGlobals.Name = "btSaveGlobals";
            this.btSaveGlobals.Size = new System.Drawing.Size(120, 29);
            this.btSaveGlobals.TabIndex = 10;
            this.btSaveGlobals.Text = "Opslaan";
            this.btSaveGlobals.UseVisualStyleBackColor = true;
            this.btSaveGlobals.Click += new System.EventHandler(this.btSaveGlobals_Click);
            // 
            // btFillDatumArchief
            // 
            this.btFillDatumArchief.Location = new System.Drawing.Point(571, 172);
            this.btFillDatumArchief.Name = "btFillDatumArchief";
            this.btFillDatumArchief.Size = new System.Drawing.Size(120, 29);
            this.btFillDatumArchief.TabIndex = 9;
            this.btFillDatumArchief.Text = "Vandaag";
            this.btFillDatumArchief.UseVisualStyleBackColor = true;
            this.btFillDatumArchief.Click += new System.EventHandler(this.btFillDatumArchief_Click);
            // 
            // txtNaamArchief
            // 
            this.txtNaamArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtNaamArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtNaamArchief.Location = new System.Drawing.Point(402, 72);
            this.txtNaamArchief.Name = "txtNaamArchief";
            this.txtNaamArchief.PlaceHolderText = "Bouwvergunningen Gemeente Raamsdonk 1993 - 1996";
            this.txtNaamArchief.Size = new System.Drawing.Size(718, 26);
            this.txtNaamArchief.TabIndex = 1;
            this.txtNaamArchief.Text = "Bouwvergunningen Gemeente Raamsdonk 1993 - 1996";
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(169, 72);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(146, 27);
            this.materialLabel9.TabIndex = 8;
            this.materialLabel9.Text = "Naam Archief";
            // 
            // txtDoelArchief
            // 
            this.txtDoelArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtDoelArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtDoelArchief.Location = new System.Drawing.Point(402, 311);
            this.txtDoelArchief.Name = "txtDoelArchief";
            this.txtDoelArchief.PlaceHolderText = "Bouwvergunningen om op te nemen in e-Depot";
            this.txtDoelArchief.Size = new System.Drawing.Size(718, 26);
            this.txtDoelArchief.TabIndex = 7;
            this.txtDoelArchief.Text = "Bouwvergunningen om op te nemen in e-Depot";
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(169, 311);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(131, 27);
            this.materialLabel11.TabIndex = 6;
            this.materialLabel11.Text = "Doel Archief";
            // 
            // txtBronArchief
            // 
            this.txtBronArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtBronArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtBronArchief.Location = new System.Drawing.Point(402, 265);
            this.txtBronArchief.Name = "txtBronArchief";
            this.txtBronArchief.PlaceHolderText = "Digitale bouwvergunningen";
            this.txtBronArchief.Size = new System.Drawing.Size(718, 26);
            this.txtBronArchief.TabIndex = 5;
            this.txtBronArchief.Text = "Digitale bouwvergunningen";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(169, 265);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(133, 27);
            this.materialLabel8.TabIndex = 4;
            this.materialLabel8.Text = "Bron Archief";
            // 
            // txtOmschrijvingArchief
            // 
            this.txtOmschrijvingArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtOmschrijvingArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtOmschrijvingArchief.Location = new System.Drawing.Point(402, 219);
            this.txtOmschrijvingArchief.Name = "txtOmschrijvingArchief";
            this.txtOmschrijvingArchief.PlaceHolderText = "Bouwvergunningen Gemeente Raamsdonk 1993 - 1996";
            this.txtOmschrijvingArchief.Size = new System.Drawing.Size(718, 26);
            this.txtOmschrijvingArchief.TabIndex = 3;
            this.txtOmschrijvingArchief.Text = "Bouwvergunningen Gemeente Raamsdonk 1993 - 1996";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(169, 219);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(213, 27);
            this.materialLabel7.TabIndex = 2;
            this.materialLabel7.Text = "Omschrijving Archief";
            // 
            // txtDatumArchief
            // 
            this.txtDatumArchief.Location = new System.Drawing.Point(402, 173);
            this.txtDatumArchief.Mask = "00-00-0000";
            this.txtDatumArchief.Name = "txtDatumArchief";
            this.txtDatumArchief.Size = new System.Drawing.Size(120, 26);
            this.txtDatumArchief.TabIndex = 2;
            this.txtDatumArchief.ValidatingType = typeof(System.DateTime);
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.Location = new System.Drawing.Point(169, 173);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(151, 27);
            this.materialLabel10.TabIndex = 0;
            this.materialLabel10.Text = "Datum Archief";
            // 
            // tabLoadFiles
            // 
            this.tabLoadFiles.Controls.Add(this.materialLabel2);
            this.tabLoadFiles.Controls.Add(this.materialLabel1);
            this.tabLoadFiles.Controls.Add(this.txtRecordBestandLocation);
            this.tabLoadFiles.Controls.Add(this.materialLabel6);
            this.tabLoadFiles.Controls.Add(this.materialLabel5);
            this.tabLoadFiles.Controls.Add(this.txtDossierLocation);
            this.tabLoadFiles.Controls.Add(this.gridFieldMappingRecords);
            this.tabLoadFiles.Controls.Add(this.gridFieldMappingDossiers);
            this.tabLoadFiles.Location = new System.Drawing.Point(4, 29);
            this.tabLoadFiles.Name = "tabLoadFiles";
            this.tabLoadFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabLoadFiles.Size = new System.Drawing.Size(1886, 1207);
            this.tabLoadFiles.TabIndex = 1;
            this.tabLoadFiles.Text = "Bestanden";
            this.tabLoadFiles.UseVisualStyleBackColor = true;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(1017, 232);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(363, 27);
            this.materialLabel2.TabIndex = 20;
            this.materialLabel2.Text = "Veldmapping Records en Bestanden";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.White;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(107, 232);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(228, 27);
            this.materialLabel1.TabIndex = 19;
            this.materialLabel1.Text = "Veldmapping Dossiers";
            // 
            // txtRecordBestandLocation
            // 
            this.txtRecordBestandLocation.Location = new System.Drawing.Point(1477, 82);
            this.txtRecordBestandLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRecordBestandLocation.Name = "txtRecordBestandLocation";
            this.txtRecordBestandLocation.Size = new System.Drawing.Size(319, 26);
            this.txtRecordBestandLocation.TabIndex = 18;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(1012, 82);
            this.materialLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(457, 27);
            this.materialLabel6.TabIndex = 17;
            this.materialLabel6.Text = "Selecteer Records en Bestanden-Metadatafile";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(119, 80);
            this.materialLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(311, 27);
            this.materialLabel5.TabIndex = 16;
            this.materialLabel5.Text = "Selecteer Dossier-Metadatafile";
            // 
            // txtDossierLocation
            // 
            this.txtDossierLocation.Location = new System.Drawing.Point(508, 82);
            this.txtDossierLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDossierLocation.Name = "txtDossierLocation";
            this.txtDossierLocation.Size = new System.Drawing.Size(319, 26);
            this.txtDossierLocation.TabIndex = 15;
            // 
            // gridFieldMappingRecords
            // 
            this.gridFieldMappingRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFieldMappingRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DatabaseFieldNameRecords,
            this.MappedFieldNameRecords});
            this.gridFieldMappingRecords.Location = new System.Drawing.Point(1019, 264);
            this.gridFieldMappingRecords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridFieldMappingRecords.Name = "gridFieldMappingRecords";
            this.gridFieldMappingRecords.Size = new System.Drawing.Size(732, 677);
            this.gridFieldMappingRecords.TabIndex = 14;
            // 
            // DatabaseFieldNameRecords
            // 
            this.DatabaseFieldNameRecords.DataPropertyName = "MappedFieldName";
            this.DatabaseFieldNameRecords.HeaderText = "Veldnaam Bron";
            this.DatabaseFieldNameRecords.Name = "DatabaseFieldNameRecords";
            this.DatabaseFieldNameRecords.Width = 220;
            // 
            // MappedFieldNameRecords
            // 
            this.MappedFieldNameRecords.DataPropertyName = "DatabaseFieldName";
            this.MappedFieldNameRecords.HeaderText = "Veldnaam TopX";
            this.MappedFieldNameRecords.Name = "MappedFieldNameRecords";
            this.MappedFieldNameRecords.Width = 220;
            // 
            // gridFieldMappingDossiers
            // 
            this.gridFieldMappingDossiers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFieldMappingDossiers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MappedFieldName,
            this.DatabaseFieldName});
            this.gridFieldMappingDossiers.Location = new System.Drawing.Point(112, 264);
            this.gridFieldMappingDossiers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridFieldMappingDossiers.Name = "gridFieldMappingDossiers";
            this.gridFieldMappingDossiers.Size = new System.Drawing.Size(724, 677);
            this.gridFieldMappingDossiers.TabIndex = 13;
            // 
            // MappedFieldName
            // 
            this.MappedFieldName.DataPropertyName = "MappedFieldName";
            this.MappedFieldName.HeaderText = "Veldnaam Bron";
            this.MappedFieldName.Name = "MappedFieldName";
            this.MappedFieldName.Width = 220;
            // 
            // DatabaseFieldName
            // 
            this.DatabaseFieldName.DataPropertyName = "DatabaseFieldName";
            this.DatabaseFieldName.HeaderText = "Veldnaam TopX";
            this.DatabaseFieldName.Name = "DatabaseFieldName";
            this.DatabaseFieldName.Width = 220;
            // 
            // tabImportFiles
            // 
            this.tabImportFiles.Controls.Add(this.materialLabel4);
            this.tabImportFiles.Controls.Add(this.materialLabel3);
            this.tabImportFiles.Controls.Add(this.txtErrorRecords);
            this.tabImportFiles.Controls.Add(this.txtErrorsDossiers);
            this.tabImportFiles.Controls.Add(this.btImportFiles);
            this.tabImportFiles.Location = new System.Drawing.Point(4, 29);
            this.tabImportFiles.Name = "tabImportFiles";
            this.tabImportFiles.Size = new System.Drawing.Size(1886, 1207);
            this.tabImportFiles.TabIndex = 2;
            this.tabImportFiles.Text = "Import";
            this.tabImportFiles.UseVisualStyleBackColor = true;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(955, 108);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(156, 27);
            this.materialLabel4.TabIndex = 9;
            this.materialLabel4.Text = "Errors Records";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(179, 109);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(159, 27);
            this.materialLabel3.TabIndex = 8;
            this.materialLabel3.Text = "Errors Dossiers";
            // 
            // txtErrorRecords
            // 
            this.txtErrorRecords.Location = new System.Drawing.Point(943, 201);
            this.txtErrorRecords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtErrorRecords.Multiline = true;
            this.txtErrorRecords.Name = "txtErrorRecords";
            this.txtErrorRecords.Size = new System.Drawing.Size(746, 470);
            this.txtErrorRecords.TabIndex = 7;
            // 
            // txtErrorsDossiers
            // 
            this.txtErrorsDossiers.Location = new System.Drawing.Point(167, 201);
            this.txtErrorsDossiers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtErrorsDossiers.Multiline = true;
            this.txtErrorsDossiers.Name = "txtErrorsDossiers";
            this.txtErrorsDossiers.Size = new System.Drawing.Size(766, 470);
            this.txtErrorsDossiers.TabIndex = 6;
            // 
            // btImportFiles
            // 
            this.btImportFiles.AutoSize = true;
            this.btImportFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btImportFiles.BackColor = System.Drawing.Color.White;
            this.btImportFiles.Depth = 0;
            this.btImportFiles.Icon = null;
            this.btImportFiles.Location = new System.Drawing.Point(179, 231);
            this.btImportFiles.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btImportFiles.MouseState = MaterialSkin.MouseState.HOVER;
            this.btImportFiles.Name = "btImportFiles";
            this.btImportFiles.Primary = false;
            this.btImportFiles.Size = new System.Drawing.Size(292, 36);
            this.btImportFiles.TabIndex = 5;
            this.btImportFiles.Text = "Import files in database";
            this.btImportFiles.UseVisualStyleBackColor = false;
            // 
            // tabBestanden
            // 
            this.tabBestanden.BackColor = System.Drawing.Color.White;
            this.tabBestanden.Controls.Add(this.btAnalyse);
            this.tabBestanden.Controls.Add(this.txtFileLocation);
            this.tabBestanden.Controls.Add(this.btFileLocation);
            this.tabBestanden.Location = new System.Drawing.Point(4, 29);
            this.tabBestanden.Name = "tabBestanden";
            this.tabBestanden.Size = new System.Drawing.Size(1886, 1207);
            this.tabBestanden.TabIndex = 3;
            this.tabBestanden.Text = "Bestanden";
            // 
            // btAnalyse
            // 
            this.btAnalyse.AutoSize = true;
            this.btAnalyse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btAnalyse.Depth = 0;
            this.btAnalyse.Icon = null;
            this.btAnalyse.Location = new System.Drawing.Point(1167, 64);
            this.btAnalyse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btAnalyse.MouseState = MaterialSkin.MouseState.HOVER;
            this.btAnalyse.Name = "btAnalyse";
            this.btAnalyse.Primary = true;
            this.btAnalyse.Size = new System.Drawing.Size(236, 36);
            this.btAnalyse.TabIndex = 5;
            this.btAnalyse.Text = "Analyse bestanden";
            this.btAnalyse.UseVisualStyleBackColor = true;
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Depth = 0;
            this.txtFileLocation.Hint = "";
            this.txtFileLocation.Location = new System.Drawing.Point(675, 64);
            this.txtFileLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFileLocation.MaxLength = 32767;
            this.txtFileLocation.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.PasswordChar = '\0';
            this.txtFileLocation.SelectedText = "";
            this.txtFileLocation.SelectionLength = 0;
            this.txtFileLocation.SelectionStart = 0;
            this.txtFileLocation.Size = new System.Drawing.Size(438, 32);
            this.txtFileLocation.TabIndex = 4;
            this.txtFileLocation.TabStop = false;
            this.txtFileLocation.UseSystemPasswordChar = false;
            // 
            // btFileLocation
            // 
            this.btFileLocation.AutoSize = true;
            this.btFileLocation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btFileLocation.Depth = 0;
            this.btFileLocation.Icon = null;
            this.btFileLocation.Location = new System.Drawing.Point(483, 65);
            this.btFileLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btFileLocation.MouseState = MaterialSkin.MouseState.HOVER;
            this.btFileLocation.Name = "btFileLocation";
            this.btFileLocation.Primary = true;
            this.btFileLocation.Size = new System.Drawing.Size(106, 36);
            this.btFileLocation.TabIndex = 3;
            this.btFileLocation.Text = "Locatie";
            this.btFileLocation.UseVisualStyleBackColor = true;
            // 
            // tabGenerateTopX
            // 
            this.tabGenerateTopX.Controls.Add(this.txtLogTopXCreate);
            this.tabGenerateTopX.Controls.Add(this.btCreateTopX);
            this.tabGenerateTopX.Location = new System.Drawing.Point(4, 29);
            this.tabGenerateTopX.Name = "tabGenerateTopX";
            this.tabGenerateTopX.Size = new System.Drawing.Size(1886, 1207);
            this.tabGenerateTopX.TabIndex = 4;
            this.tabGenerateTopX.Text = "Genereer TopX";
            this.tabGenerateTopX.UseVisualStyleBackColor = true;
            // 
            // txtLogTopXCreate
            // 
            this.txtLogTopXCreate.Location = new System.Drawing.Point(321, 60);
            this.txtLogTopXCreate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLogTopXCreate.Multiline = true;
            this.txtLogTopXCreate.Name = "txtLogTopXCreate";
            this.txtLogTopXCreate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogTopXCreate.Size = new System.Drawing.Size(1244, 362);
            this.txtLogTopXCreate.TabIndex = 3;
            // 
            // btCreateTopX
            // 
            this.btCreateTopX.AutoSize = true;
            this.btCreateTopX.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btCreateTopX.Depth = 0;
            this.btCreateTopX.Icon = null;
            this.btCreateTopX.Location = new System.Drawing.Point(321, 137);
            this.btCreateTopX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCreateTopX.MouseState = MaterialSkin.MouseState.HOVER;
            this.btCreateTopX.Name = "btCreateTopX";
            this.btCreateTopX.Primary = true;
            this.btCreateTopX.Size = new System.Drawing.Size(157, 36);
            this.btCreateTopX.TabIndex = 2;
            this.btCreateTopX.Text = "Create TopX";
            this.btCreateTopX.UseVisualStyleBackColor = true;
            // 
            // TopXConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(2033, 1552);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TopXConverter";
            this.Text = "TopX Creator";
            this.Load += new System.EventHandler(this.TopXConverter_Load);
            this.materialContextMenuStrip2.ResumeLayout(false);
            this.materialContextMenuStrip3.ResumeLayout(false);
            this.materialTabControl1.ResumeLayout(false);
            this.tabGlobals.ResumeLayout(false);
            this.tabGlobals.PerformLayout();
            this.tabLoadFiles.ResumeLayout(false);
            this.tabLoadFiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFieldMappingRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFieldMappingDossiers)).EndInit();
            this.tabImportFiles.ResumeLayout(false);
            this.tabImportFiles.PerformLayout();
            this.tabBestanden.ResumeLayout(false);
            this.tabBestanden.PerformLayout();
            this.tabGenerateTopX.ResumeLayout(false);
            this.tabGenerateTopX.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem1;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem ditIs1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ditIs2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ditIs3ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogDossiers;
        private System.Windows.Forms.OpenFileDialog openFileDialogRecords;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogFiles;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabGlobals;
        private System.Windows.Forms.TabPage tabLoadFiles;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TextBox txtRecordBestandLocation;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.TextBox txtDossierLocation;
        private System.Windows.Forms.DataGridView gridFieldMappingRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatabaseFieldNameRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn MappedFieldNameRecords;
        private System.Windows.Forms.DataGridView gridFieldMappingDossiers;
        private System.Windows.Forms.DataGridViewTextBoxColumn MappedFieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatabaseFieldName;
        private System.Windows.Forms.TabPage tabImportFiles;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.TextBox txtErrorRecords;
        private System.Windows.Forms.TextBox txtErrorsDossiers;
        private MaterialSkin.Controls.MaterialFlatButton btImportFiles;
        private System.Windows.Forms.TabPage tabBestanden;
        private MaterialSkin.Controls.MaterialRaisedButton btAnalyse;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFileLocation;
        private MaterialSkin.Controls.MaterialRaisedButton btFileLocation;
        private System.Windows.Forms.TabPage tabGenerateTopX;
        private System.Windows.Forms.TextBox txtLogTopXCreate;
        private MaterialSkin.Controls.MaterialRaisedButton btCreateTopX;
        private MaskedTextBox txtDatumArchief;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private PlaceHolderTextBox txtOmschrijvingArchief;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private PlaceHolderTextBox txtNaamArchief;
        private PlaceHolderTextBox txtDoelArchief;
        private PlaceHolderTextBox txtBronArchief;
        private System.Windows.Forms.Button btFillDatumArchief;
        private System.Windows.Forms.Button btSaveGlobals;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private PlaceHolderTextBox txtIdentificatieArchief;
    }
}

