using System.Windows.Forms;
using TOPX.UI.Controls;

namespace TOPX.UI.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopXConverter));
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
            this.picRecordsSelector = new System.Windows.Forms.PictureBox();
            this.picDossierSelector = new System.Windows.Forms.PictureBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtRecordBestandLocation = new System.Windows.Forms.TextBox();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.txtDossierLocation = new System.Windows.Forms.TextBox();
            this.gridFieldMappingRecords = new TOPX.UI.Controls.DragDropGridView();
            this.DatabaseFieldNameRecords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MappedFieldNameRecords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridFieldMappingDossiers = new TOPX.UI.Controls.DragDropGridView();
            this.MappedFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatabaseFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabImportFiles = new System.Windows.Forms.TabPage();
            this.btImportFilesInDb = new System.Windows.Forms.Button();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtErrorRecords = new System.Windows.Forms.TextBox();
            this.txtErrorsDossiers = new System.Windows.Forms.TextBox();
            this.tabBestanden = new System.Windows.Forms.TabPage();
            this.btAnalyse = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtFileLocation = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btFileLocation = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tabGenerateTopX = new System.Windows.Forms.TabPage();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.btGenerateTopX = new System.Windows.Forms.Button();
            this.txtLogTopXCreate = new System.Windows.Forms.TextBox();
            this.materialContextMenuStrip2.SuspendLayout();
            this.materialContextMenuStrip3.SuspendLayout();
            this.materialTabControl1.SuspendLayout();
            this.tabGlobals.SuspendLayout();
            this.tabLoadFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRecordsSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDossierSelector)).BeginInit();
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
            this.materialContextMenuStrip2.Size = new System.Drawing.Size(94, 48);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.testToolStripMenuItem.Text = "test";
            // 
            // testToolStripMenuItem1
            // 
            this.testToolStripMenuItem1.Name = "testToolStripMenuItem1";
            this.testToolStripMenuItem1.Size = new System.Drawing.Size(93, 22);
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
            this.materialContextMenuStrip3.Size = new System.Drawing.Size(104, 70);
            // 
            // ditIs1ToolStripMenuItem
            // 
            this.ditIs1ToolStripMenuItem.Name = "ditIs1ToolStripMenuItem";
            this.ditIs1ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.ditIs1ToolStripMenuItem.Text = "DitIs1";
            // 
            // ditIs2ToolStripMenuItem
            // 
            this.ditIs2ToolStripMenuItem.Name = "ditIs2ToolStripMenuItem";
            this.ditIs2ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.ditIs2ToolStripMenuItem.Text = "DitIs2";
            // 
            // ditIs3ToolStripMenuItem
            // 
            this.ditIs3ToolStripMenuItem.Name = "ditIs3ToolStripMenuItem";
            this.ditIs3ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
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
            this.materialTabSelector1.Location = new System.Drawing.Point(138, 27);
            this.materialTabSelector1.Margin = new System.Windows.Forms.Padding(2);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(1219, 34);
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
            this.materialTabControl1.Location = new System.Drawing.Point(27, 130);
            this.materialTabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1263, 806);
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
            this.tabGlobals.Location = new System.Drawing.Point(4, 22);
            this.tabGlobals.Margin = new System.Windows.Forms.Padding(2);
            this.tabGlobals.Name = "tabGlobals";
            this.tabGlobals.Padding = new System.Windows.Forms.Padding(2);
            this.tabGlobals.Size = new System.Drawing.Size(1255, 780);
            this.tabGlobals.TabIndex = 0;
            this.tabGlobals.Text = "Gegevens";
            this.tabGlobals.UseVisualStyleBackColor = true;
            // 
            // txtIdentificatieArchief
            // 
            this.txtIdentificatieArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtIdentificatieArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtIdentificatieArchief.Location = new System.Drawing.Point(268, 77);
            this.txtIdentificatieArchief.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdentificatieArchief.Name = "txtIdentificatieArchief";
            this.txtIdentificatieArchief.PlaceHolderText = "NL-0784-10009";
            this.txtIdentificatieArchief.Size = new System.Drawing.Size(194, 20);
            this.txtIdentificatieArchief.TabIndex = 13;
            this.txtIdentificatieArchief.Text = "NL-0784-10009";
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(112, 77);
            this.materialLabel12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(140, 19);
            this.materialLabel12.TabIndex = 12;
            this.materialLabel12.Text = "Identificatie Archief";
            // 
            // btSaveGlobals
            // 
            this.btSaveGlobals.Location = new System.Drawing.Point(268, 259);
            this.btSaveGlobals.Margin = new System.Windows.Forms.Padding(2);
            this.btSaveGlobals.Name = "btSaveGlobals";
            this.btSaveGlobals.Size = new System.Drawing.Size(80, 22);
            this.btSaveGlobals.TabIndex = 10;
            this.btSaveGlobals.Text = "Opslaan";
            this.btSaveGlobals.UseVisualStyleBackColor = true;
            this.btSaveGlobals.Click += new System.EventHandler(this.btSaveGlobals_Click);
            // 
            // btFillDatumArchief
            // 
            this.btFillDatumArchief.Location = new System.Drawing.Point(381, 112);
            this.btFillDatumArchief.Margin = new System.Windows.Forms.Padding(2);
            this.btFillDatumArchief.Name = "btFillDatumArchief";
            this.btFillDatumArchief.Size = new System.Drawing.Size(80, 22);
            this.btFillDatumArchief.TabIndex = 9;
            this.btFillDatumArchief.Text = "Vandaag";
            this.btFillDatumArchief.UseVisualStyleBackColor = true;
            this.btFillDatumArchief.Click += new System.EventHandler(this.btFillDatumArchief_Click);
            // 
            // txtNaamArchief
            // 
            this.txtNaamArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtNaamArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtNaamArchief.Location = new System.Drawing.Point(268, 47);
            this.txtNaamArchief.Margin = new System.Windows.Forms.Padding(2);
            this.txtNaamArchief.Name = "txtNaamArchief";
            this.txtNaamArchief.PlaceHolderText = "Bouwvergunningen Gemeente Raamsdonk 1993 - 1996";
            this.txtNaamArchief.Size = new System.Drawing.Size(480, 20);
            this.txtNaamArchief.TabIndex = 1;
            this.txtNaamArchief.Text = "Bouwvergunningen Gemeente Raamsdonk 1993 - 1996";
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(112, 47);
            this.materialLabel9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(101, 19);
            this.materialLabel9.TabIndex = 8;
            this.materialLabel9.Text = "Naam Archief";
            // 
            // txtDoelArchief
            // 
            this.txtDoelArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtDoelArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtDoelArchief.Location = new System.Drawing.Point(268, 202);
            this.txtDoelArchief.Margin = new System.Windows.Forms.Padding(2);
            this.txtDoelArchief.Name = "txtDoelArchief";
            this.txtDoelArchief.PlaceHolderText = "Bouwvergunningen om op te nemen in e-Depot";
            this.txtDoelArchief.Size = new System.Drawing.Size(480, 20);
            this.txtDoelArchief.TabIndex = 7;
            this.txtDoelArchief.Text = "Bouwvergunningen om op te nemen in e-Depot";
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(112, 202);
            this.materialLabel11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(92, 19);
            this.materialLabel11.TabIndex = 6;
            this.materialLabel11.Text = "Doel Archief";
            // 
            // txtBronArchief
            // 
            this.txtBronArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtBronArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtBronArchief.Location = new System.Drawing.Point(268, 172);
            this.txtBronArchief.Margin = new System.Windows.Forms.Padding(2);
            this.txtBronArchief.Name = "txtBronArchief";
            this.txtBronArchief.PlaceHolderText = "Digitale bouwvergunningen";
            this.txtBronArchief.Size = new System.Drawing.Size(480, 20);
            this.txtBronArchief.TabIndex = 5;
            this.txtBronArchief.Text = "Digitale bouwvergunningen";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(112, 172);
            this.materialLabel8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(92, 19);
            this.materialLabel8.TabIndex = 4;
            this.materialLabel8.Text = "Bron Archief";
            // 
            // txtOmschrijvingArchief
            // 
            this.txtOmschrijvingArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtOmschrijvingArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtOmschrijvingArchief.Location = new System.Drawing.Point(268, 142);
            this.txtOmschrijvingArchief.Margin = new System.Windows.Forms.Padding(2);
            this.txtOmschrijvingArchief.Name = "txtOmschrijvingArchief";
            this.txtOmschrijvingArchief.PlaceHolderText = "Bouwvergunningen Gemeente Raamsdonk 1993 - 1996";
            this.txtOmschrijvingArchief.Size = new System.Drawing.Size(480, 20);
            this.txtOmschrijvingArchief.TabIndex = 3;
            this.txtOmschrijvingArchief.Text = "Bouwvergunningen Gemeente Raamsdonk 1993 - 1996";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(112, 142);
            this.materialLabel7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(148, 19);
            this.materialLabel7.TabIndex = 2;
            this.materialLabel7.Text = "Omschrijving Archief";
            // 
            // txtDatumArchief
            // 
            this.txtDatumArchief.Location = new System.Drawing.Point(268, 112);
            this.txtDatumArchief.Margin = new System.Windows.Forms.Padding(2);
            this.txtDatumArchief.Mask = "00-00-0000";
            this.txtDatumArchief.Name = "txtDatumArchief";
            this.txtDatumArchief.Size = new System.Drawing.Size(81, 20);
            this.txtDatumArchief.TabIndex = 2;
            this.txtDatumArchief.ValidatingType = typeof(System.DateTime);
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.Location = new System.Drawing.Point(112, 112);
            this.materialLabel10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(105, 19);
            this.materialLabel10.TabIndex = 0;
            this.materialLabel10.Text = "Datum Archief";
            // 
            // tabLoadFiles
            // 
            this.tabLoadFiles.Controls.Add(this.picRecordsSelector);
            this.tabLoadFiles.Controls.Add(this.picDossierSelector);
            this.tabLoadFiles.Controls.Add(this.materialLabel2);
            this.tabLoadFiles.Controls.Add(this.materialLabel1);
            this.tabLoadFiles.Controls.Add(this.txtRecordBestandLocation);
            this.tabLoadFiles.Controls.Add(this.materialLabel6);
            this.tabLoadFiles.Controls.Add(this.materialLabel5);
            this.tabLoadFiles.Controls.Add(this.txtDossierLocation);
            this.tabLoadFiles.Controls.Add(this.gridFieldMappingRecords);
            this.tabLoadFiles.Controls.Add(this.gridFieldMappingDossiers);
            this.tabLoadFiles.Location = new System.Drawing.Point(4, 22);
            this.tabLoadFiles.Margin = new System.Windows.Forms.Padding(2);
            this.tabLoadFiles.Name = "tabLoadFiles";
            this.tabLoadFiles.Padding = new System.Windows.Forms.Padding(2);
            this.tabLoadFiles.Size = new System.Drawing.Size(1255, 780);
            this.tabLoadFiles.TabIndex = 1;
            this.tabLoadFiles.Text = "Bestanden";
            this.tabLoadFiles.UseVisualStyleBackColor = true;
            // 
            // picRecordsSelector
            // 
            this.picRecordsSelector.Image = ((System.Drawing.Image)(resources.GetObject("picRecordsSelector.Image")));
            this.picRecordsSelector.Location = new System.Drawing.Point(1049, 41);
            this.picRecordsSelector.Margin = new System.Windows.Forms.Padding(2);
            this.picRecordsSelector.Name = "picRecordsSelector";
            this.picRecordsSelector.Size = new System.Drawing.Size(31, 33);
            this.picRecordsSelector.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRecordsSelector.TabIndex = 22;
            this.picRecordsSelector.TabStop = false;
            this.picRecordsSelector.Click += new System.EventHandler(this.picRecordsSelector_Click);
            // 
            // picDossierSelector
            // 
            this.picDossierSelector.Image = ((System.Drawing.Image)(resources.GetObject("picDossierSelector.Image")));
            this.picDossierSelector.Location = new System.Drawing.Point(446, 41);
            this.picDossierSelector.Margin = new System.Windows.Forms.Padding(2);
            this.picDossierSelector.Name = "picDossierSelector";
            this.picDossierSelector.Size = new System.Drawing.Size(31, 33);
            this.picDossierSelector.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDossierSelector.TabIndex = 21;
            this.picDossierSelector.TabStop = false;
            this.picDossierSelector.Click += new System.EventHandler(this.picDossierSelector_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(678, 101);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(249, 19);
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
            this.materialLabel1.Location = new System.Drawing.Point(71, 101);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(160, 19);
            this.materialLabel1.TabIndex = 19;
            this.materialLabel1.Text = "Veldmapping Dossiers";
            // 
            // txtRecordBestandLocation
            // 
            this.txtRecordBestandLocation.Location = new System.Drawing.Point(682, 54);
            this.txtRecordBestandLocation.Name = "txtRecordBestandLocation";
            this.txtRecordBestandLocation.Size = new System.Drawing.Size(362, 20);
            this.txtRecordBestandLocation.TabIndex = 18;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(678, 21);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(313, 19);
            this.materialLabel6.TabIndex = 17;
            this.materialLabel6.Text = "Selecteer Records en Bestanden-Metadatafile";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(71, 21);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(216, 19);
            this.materialLabel5.TabIndex = 16;
            this.materialLabel5.Text = "Selecteer Dossier-Metadatafile";
            // 
            // txtDossierLocation
            // 
            this.txtDossierLocation.Location = new System.Drawing.Point(75, 51);
            this.txtDossierLocation.Name = "txtDossierLocation";
            this.txtDossierLocation.Size = new System.Drawing.Size(366, 20);
            this.txtDossierLocation.TabIndex = 15;
            this.txtDossierLocation.TextChanged += new System.EventHandler(this.txtDossierLocation_TextChanged);
            // 
            // gridFieldMappingRecords
            // 
            this.gridFieldMappingRecords.AllowDrop = true;
            this.gridFieldMappingRecords.AllowUserToAddRows = false;
            this.gridFieldMappingRecords.AllowUserToDeleteRows = false;
            this.gridFieldMappingRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFieldMappingRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DatabaseFieldNameRecords,
            this.MappedFieldNameRecords});
            this.gridFieldMappingRecords.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridFieldMappingRecords.Location = new System.Drawing.Point(680, 123);
            this.gridFieldMappingRecords.Name = "gridFieldMappingRecords";
            this.gridFieldMappingRecords.Size = new System.Drawing.Size(525, 587);
            this.gridFieldMappingRecords.TabIndex = 14;
            this.gridFieldMappingRecords.Leave += new System.EventHandler(this.gridFieldMappingRecords_Leave);
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
            this.MappedFieldNameRecords.Width = 250;
            // 
            // gridFieldMappingDossiers
            // 
            this.gridFieldMappingDossiers.AllowDrop = true;
            this.gridFieldMappingDossiers.AllowUserToAddRows = false;
            this.gridFieldMappingDossiers.AllowUserToDeleteRows = false;
            this.gridFieldMappingDossiers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFieldMappingDossiers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MappedFieldName,
            this.DatabaseFieldName});
            this.gridFieldMappingDossiers.Location = new System.Drawing.Point(75, 123);
            this.gridFieldMappingDossiers.Name = "gridFieldMappingDossiers";
            this.gridFieldMappingDossiers.Size = new System.Drawing.Size(524, 587);
            this.gridFieldMappingDossiers.TabIndex = 13;
            this.gridFieldMappingDossiers.Leave += new System.EventHandler(this.gridFieldMappingDossiers_Leave);
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
            this.DatabaseFieldName.Width = 250;
            // 
            // tabImportFiles
            // 
            this.tabImportFiles.Controls.Add(this.btImportFilesInDb);
            this.tabImportFiles.Controls.Add(this.materialLabel4);
            this.tabImportFiles.Controls.Add(this.materialLabel3);
            this.tabImportFiles.Controls.Add(this.txtErrorRecords);
            this.tabImportFiles.Controls.Add(this.txtErrorsDossiers);
            this.tabImportFiles.Location = new System.Drawing.Point(4, 22);
            this.tabImportFiles.Margin = new System.Windows.Forms.Padding(2);
            this.tabImportFiles.Name = "tabImportFiles";
            this.tabImportFiles.Size = new System.Drawing.Size(1255, 780);
            this.tabImportFiles.TabIndex = 2;
            this.tabImportFiles.Text = "Import";
            this.tabImportFiles.UseVisualStyleBackColor = true;
            // 
            // btImportFilesInDb
            // 
            this.btImportFilesInDb.Location = new System.Drawing.Point(111, 34);
            this.btImportFilesInDb.Name = "btImportFilesInDb";
            this.btImportFilesInDb.Size = new System.Drawing.Size(112, 26);
            this.btImportFilesInDb.TabIndex = 10;
            this.btImportFilesInDb.Text = "Import bestanden";
            this.btImportFilesInDb.UseVisualStyleBackColor = true;
            this.btImportFilesInDb.Click += new System.EventHandler(this.btImportFilesInDb_Click);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(634, 107);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(109, 19);
            this.materialLabel4.TabIndex = 9;
            this.materialLabel4.Text = "Errors Records";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(109, 107);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(114, 19);
            this.materialLabel3.TabIndex = 8;
            this.materialLabel3.Text = "Errors Dossiers";
            // 
            // txtErrorRecords
            // 
            this.txtErrorRecords.Location = new System.Drawing.Point(628, 131);
            this.txtErrorRecords.Multiline = true;
            this.txtErrorRecords.Name = "txtErrorRecords";
            this.txtErrorRecords.Size = new System.Drawing.Size(499, 307);
            this.txtErrorRecords.TabIndex = 7;
            // 
            // txtErrorsDossiers
            // 
            this.txtErrorsDossiers.Location = new System.Drawing.Point(111, 131);
            this.txtErrorsDossiers.Multiline = true;
            this.txtErrorsDossiers.Name = "txtErrorsDossiers";
            this.txtErrorsDossiers.Size = new System.Drawing.Size(512, 307);
            this.txtErrorsDossiers.TabIndex = 6;
            // 
            // tabBestanden
            // 
            this.tabBestanden.BackColor = System.Drawing.Color.White;
            this.tabBestanden.Controls.Add(this.btAnalyse);
            this.tabBestanden.Controls.Add(this.txtFileLocation);
            this.tabBestanden.Controls.Add(this.btFileLocation);
            this.tabBestanden.Location = new System.Drawing.Point(4, 22);
            this.tabBestanden.Margin = new System.Windows.Forms.Padding(2);
            this.tabBestanden.Name = "tabBestanden";
            this.tabBestanden.Size = new System.Drawing.Size(1255, 780);
            this.tabBestanden.TabIndex = 3;
            this.tabBestanden.Text = "Bestanden";
            // 
            // btAnalyse
            // 
            this.btAnalyse.AutoSize = true;
            this.btAnalyse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btAnalyse.Depth = 0;
            this.btAnalyse.Icon = null;
            this.btAnalyse.Location = new System.Drawing.Point(778, 41);
            this.btAnalyse.MouseState = MaterialSkin.MouseState.HOVER;
            this.btAnalyse.Name = "btAnalyse";
            this.btAnalyse.Primary = true;
            this.btAnalyse.Size = new System.Drawing.Size(163, 36);
            this.btAnalyse.TabIndex = 5;
            this.btAnalyse.Text = "Analyse bestanden";
            this.btAnalyse.UseVisualStyleBackColor = true;
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Depth = 0;
            this.txtFileLocation.Hint = "";
            this.txtFileLocation.Location = new System.Drawing.Point(450, 41);
            this.txtFileLocation.MaxLength = 32767;
            this.txtFileLocation.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.PasswordChar = '\0';
            this.txtFileLocation.SelectedText = "";
            this.txtFileLocation.SelectionLength = 0;
            this.txtFileLocation.SelectionStart = 0;
            this.txtFileLocation.Size = new System.Drawing.Size(292, 23);
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
            this.btFileLocation.Location = new System.Drawing.Point(322, 42);
            this.btFileLocation.MouseState = MaterialSkin.MouseState.HOVER;
            this.btFileLocation.Name = "btFileLocation";
            this.btFileLocation.Primary = true;
            this.btFileLocation.Size = new System.Drawing.Size(76, 36);
            this.btFileLocation.TabIndex = 3;
            this.btFileLocation.Text = "Locatie";
            this.btFileLocation.UseVisualStyleBackColor = true;
            // 
            // tabGenerateTopX
            // 
            this.tabGenerateTopX.Controls.Add(this.materialLabel13);
            this.tabGenerateTopX.Controls.Add(this.btGenerateTopX);
            this.tabGenerateTopX.Controls.Add(this.txtLogTopXCreate);
            this.tabGenerateTopX.Location = new System.Drawing.Point(4, 22);
            this.tabGenerateTopX.Margin = new System.Windows.Forms.Padding(2);
            this.tabGenerateTopX.Name = "tabGenerateTopX";
            this.tabGenerateTopX.Size = new System.Drawing.Size(1255, 780);
            this.tabGenerateTopX.TabIndex = 4;
            this.tabGenerateTopX.Text = "Genereer TopX";
            this.tabGenerateTopX.UseVisualStyleBackColor = true;
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel13.Location = new System.Drawing.Point(103, 120);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(71, 19);
            this.materialLabel13.TabIndex = 9;
            this.materialLabel13.Text = "Error Log";
            // 
            // btGenerateTopX
            // 
            this.btGenerateTopX.Location = new System.Drawing.Point(107, 61);
            this.btGenerateTopX.Name = "btGenerateTopX";
            this.btGenerateTopX.Size = new System.Drawing.Size(97, 23);
            this.btGenerateTopX.TabIndex = 4;
            this.btGenerateTopX.Text = "Genereer TopX";
            this.btGenerateTopX.UseVisualStyleBackColor = true;
            this.btGenerateTopX.Click += new System.EventHandler(this.btGenerateTopX_Click);
            // 
            // txtLogTopXCreate
            // 
            this.txtLogTopXCreate.Location = new System.Drawing.Point(107, 142);
            this.txtLogTopXCreate.Multiline = true;
            this.txtLogTopXCreate.Name = "txtLogTopXCreate";
            this.txtLogTopXCreate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogTopXCreate.Size = new System.Drawing.Size(709, 377);
            this.txtLogTopXCreate.TabIndex = 3;
            // 
            // TopXConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1355, 1009);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
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
            ((System.ComponentModel.ISupportInitialize)(this.picRecordsSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDossierSelector)).EndInit();
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
        private System.Windows.Forms.TabPage tabImportFiles;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.TextBox txtErrorRecords;
        private System.Windows.Forms.TextBox txtErrorsDossiers;
        private System.Windows.Forms.TabPage tabBestanden;
        private MaterialSkin.Controls.MaterialRaisedButton btAnalyse;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtFileLocation;
        private MaterialSkin.Controls.MaterialRaisedButton btFileLocation;
        private System.Windows.Forms.TabPage tabGenerateTopX;
        private System.Windows.Forms.TextBox txtLogTopXCreate;
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
        private PictureBox picRecordsSelector;
        private PictureBox picDossierSelector;
        private Button btImportFilesInDb;
        private DragDropGridView gridFieldMappingRecords;
        private DragDropGridView gridFieldMappingDossiers;
        private DataGridViewTextBoxColumn DatabaseFieldNameRecords;
        private DataGridViewTextBoxColumn MappedFieldNameRecords;
        private DataGridViewTextBoxColumn MappedFieldName;
        private DataGridViewTextBoxColumn DatabaseFieldName;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private Button btGenerateTopX;
    }
}

