using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.materialLabel21 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel20 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel19 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel18 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel17 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.btFillDatumArchief = new System.Windows.Forms.Button();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.txtDatumArchief = new System.Windows.Forms.MaskedTextBox();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.tabLoadFiles = new System.Windows.Forms.TabPage();
            this.btLoadRecordMapping = new System.Windows.Forms.Button();
            this.btSaveRecordMapping = new System.Windows.Forms.Button();
            this.btLoadDossierMapping = new System.Windows.Forms.Button();
            this.btSaveDossierMapping = new System.Windows.Forms.Button();
            this.btClearMappingsRecords = new System.Windows.Forms.Button();
            this.btClearMappingsDossiers = new System.Windows.Forms.Button();
            this.picRecordsSelector = new System.Windows.Forms.PictureBox();
            this.picDossierSelector = new System.Windows.Forms.PictureBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtRecordBestandLocation = new System.Windows.Forms.TextBox();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.txtDossierLocation = new System.Windows.Forms.TextBox();
            this.tabImportFiles = new System.Windows.Forms.TabPage();
            this.linkCopyErrorsRecords = new System.Windows.Forms.LinkLabel();
            this.linkCopyErrorsDossiers = new System.Windows.Forms.LinkLabel();
            this.btImportFilesInDb = new System.Windows.Forms.Button();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtErrorRecords = new System.Windows.Forms.TextBox();
            this.txtErrorsDossiers = new System.Windows.Forms.TextBox();
            this.tabMetadata = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProgressMetaData = new System.Windows.Forms.TextBox();
            this.picSelectDroidLocation = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDroidLocation = new System.Windows.Forms.TextBox();
            this.linkCopyMetadataErrors = new System.Windows.Forms.LinkLabel();
            this.btMetadataCancel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btGenerateMetadata = new System.Windows.Forms.Button();
            this.materialLabel16 = new MaterialSkin.Controls.MaterialLabel();
            this.txtMetadataErrors = new System.Windows.Forms.TextBox();
            this.chkGetFileSignature = new System.Windows.Forms.CheckBox();
            this.chkGetFileSize = new System.Windows.Forms.CheckBox();
            this.checkGetCreationDate = new System.Windows.Forms.CheckBox();
            this.chkGetHash = new System.Windows.Forms.CheckBox();
            this.materialLabel15 = new MaterialSkin.Controls.MaterialLabel();
            this.picSelectDirToScan = new System.Windows.Forms.PictureBox();
            this.txtFilesDirToScan = new System.Windows.Forms.TextBox();
            this.tabGenerateTopX = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBatchSourceDirectory = new System.Windows.Forms.TextBox();
            this.picSelectBatchSourceDir = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBatchTargetDirectory = new System.Windows.Forms.TextBox();
            this.picSelectBatchTargetDir = new System.Windows.Forms.PictureBox();
            this.chkCreateBatchesSubdir = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBatchSize = new System.Windows.Forms.TextBox();
            this.chkUseBatchSize = new System.Windows.Forms.CheckBox();
            this.btSaveTopxXml = new System.Windows.Forms.Button();
            this.materialLabel14 = new MaterialSkin.Controls.MaterialLabel();
            this.txtResultXml = new System.Windows.Forms.TextBox();
            this.linkCopyTopXCreateError = new System.Windows.Forms.LinkLabel();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.btGenerateTopX = new System.Windows.Forms.Button();
            this.txtLogTopXCreate = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.chkTestForPasswProtection = new System.Windows.Forms.CheckBox();
            this.txtIdentificatieArchief = new TOPX.UI.Controls.PlaceHolderTextBox();
            this.txtNaamArchief = new TOPX.UI.Controls.PlaceHolderTextBox();
            this.txtDoelArchief = new TOPX.UI.Controls.PlaceHolderTextBox();
            this.txtBronArchief = new TOPX.UI.Controls.PlaceHolderTextBox();
            this.txtOmschrijvingArchief = new TOPX.UI.Controls.PlaceHolderTextBox();
            this.gridFieldMappingRecords = new TOPX.UI.Controls.DragDropGridView();
            this.DatabaseFieldNameRecords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MappedFieldNameRecords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TMLO_Records = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridFieldMappingDossiers = new TOPX.UI.Controls.DragDropGridView();
            this.MappedFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatabaseFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TMLO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Optional = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.materialContextMenuStrip2.SuspendLayout();
            this.materialContextMenuStrip3.SuspendLayout();
            this.materialTabControl1.SuspendLayout();
            this.tabGlobals.SuspendLayout();
            this.tabLoadFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRecordsSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDossierSelector)).BeginInit();
            this.tabImportFiles.SuspendLayout();
            this.tabMetadata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectDroidLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectDirToScan)).BeginInit();
            this.tabGenerateTopX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectBatchSourceDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectBatchTargetDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFieldMappingRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFieldMappingDossiers)).BeginInit();
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
            this.materialTabSelector1.Location = new System.Drawing.Point(138, 25);
            this.materialTabSelector1.Margin = new System.Windows.Forms.Padding(2);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(1133, 34);
            this.materialTabSelector1.TabIndex = 4;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabGlobals);
            this.materialTabControl1.Controls.Add(this.tabLoadFiles);
            this.materialTabControl1.Controls.Add(this.tabImportFiles);
            this.materialTabControl1.Controls.Add(this.tabMetadata);
            this.materialTabControl1.Controls.Add(this.tabGenerateTopX);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(22, 81);
            this.materialTabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1226, 686);
            this.materialTabControl1.TabIndex = 5;
            // 
            // tabGlobals
            // 
            this.tabGlobals.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabGlobals.Controls.Add(this.materialLabel21);
            this.tabGlobals.Controls.Add(this.materialLabel20);
            this.tabGlobals.Controls.Add(this.materialLabel19);
            this.tabGlobals.Controls.Add(this.materialLabel18);
            this.tabGlobals.Controls.Add(this.materialLabel17);
            this.tabGlobals.Controls.Add(this.txtIdentificatieArchief);
            this.tabGlobals.Controls.Add(this.materialLabel12);
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
            this.tabGlobals.Size = new System.Drawing.Size(1218, 660);
            this.tabGlobals.TabIndex = 0;
            this.tabGlobals.Text = "Gegevens";
            this.tabGlobals.UseVisualStyleBackColor = true;
            // 
            // materialLabel21
            // 
            this.materialLabel21.AutoSize = true;
            this.materialLabel21.Depth = 0;
            this.materialLabel21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel21.Location = new System.Drawing.Point(74, 163);
            this.materialLabel21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel21.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel21.Name = "materialLabel21";
            this.materialLabel21.Size = new System.Drawing.Size(404, 18);
            this.materialLabel21.TabIndex = 75;
            this.materialLabel21.Text = "Zie ook de handleiding (in Word) voor functionele toelichting.";
            // 
            // materialLabel20
            // 
            this.materialLabel20.AutoSize = true;
            this.materialLabel20.Depth = 0;
            this.materialLabel20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel20.Location = new System.Drawing.Point(74, 122);
            this.materialLabel20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel20.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel20.Name = "materialLabel20";
            this.materialLabel20.Size = new System.Drawing.Size(670, 18);
            this.materialLabel20.TabIndex = 74;
            this.materialLabel20.Text = "- Optioneel: de koppeling naar de fysieke bestanden voor metadata-analyse (Tab Ge" +
    "nereer Metadata)";
            // 
            // materialLabel19
            // 
            this.materialLabel19.AutoSize = true;
            this.materialLabel19.Depth = 0;
            this.materialLabel19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel19.Location = new System.Drawing.Point(74, 94);
            this.materialLabel19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel19.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel19.Name = "materialLabel19";
            this.materialLabel19.Size = new System.Drawing.Size(515, 18);
            this.materialLabel19.TabIndex = 73;
            this.materialLabel19.Text = "- Csv met de records-metadata, = de documenten-metadata (Tab Bestanden)";
            // 
            // materialLabel18
            // 
            this.materialLabel18.AutoSize = true;
            this.materialLabel18.Depth = 0;
            this.materialLabel18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel18.Location = new System.Drawing.Point(74, 66);
            this.materialLabel18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel18.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel18.Name = "materialLabel18";
            this.materialLabel18.Size = new System.Drawing.Size(321, 18);
            this.materialLabel18.TabIndex = 72;
            this.materialLabel18.Text = "- Csv met de dossiergegevens (Tab Bestanden)";
            // 
            // materialLabel17
            // 
            this.materialLabel17.AutoSize = true;
            this.materialLabel17.Depth = 0;
            this.materialLabel17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel17.Location = new System.Drawing.Point(74, 38);
            this.materialLabel17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel17.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel17.Name = "materialLabel17";
            this.materialLabel17.Size = new System.Drawing.Size(555, 18);
            this.materialLabel17.TabIndex = 71;
            this.materialLabel17.Text = "Voor een succesvolle data-import en TopX-conversie zijn de volgende zaken nodig:";
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(74, 265);
            this.materialLabel12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(129, 18);
            this.materialLabel12.TabIndex = 12;
            this.materialLabel12.Text = "Identificatie Archief";
            // 
            // btFillDatumArchief
            // 
            this.btFillDatumArchief.Location = new System.Drawing.Point(369, 300);
            this.btFillDatumArchief.Margin = new System.Windows.Forms.Padding(2);
            this.btFillDatumArchief.Name = "btFillDatumArchief";
            this.btFillDatumArchief.Size = new System.Drawing.Size(80, 22);
            this.btFillDatumArchief.TabIndex = 40;
            this.btFillDatumArchief.Text = "Vandaag";
            this.btFillDatumArchief.UseVisualStyleBackColor = true;
            this.btFillDatumArchief.Click += new System.EventHandler(this.btFillDatumArchief_Click);
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(74, 235);
            this.materialLabel9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(97, 18);
            this.materialLabel9.TabIndex = 8;
            this.materialLabel9.Text = "Naam Archief";
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(74, 390);
            this.materialLabel11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(88, 18);
            this.materialLabel11.TabIndex = 6;
            this.materialLabel11.Text = "Doel Archief";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(74, 360);
            this.materialLabel8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(89, 18);
            this.materialLabel8.TabIndex = 4;
            this.materialLabel8.Text = "Bron Archief";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(74, 330);
            this.materialLabel7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(143, 18);
            this.materialLabel7.TabIndex = 2;
            this.materialLabel7.Text = "Omschrijving Archief";
            // 
            // txtDatumArchief
            // 
            this.txtDatumArchief.Location = new System.Drawing.Point(256, 300);
            this.txtDatumArchief.Margin = new System.Windows.Forms.Padding(2);
            this.txtDatumArchief.Mask = "00-00-0000";
            this.txtDatumArchief.Name = "txtDatumArchief";
            this.txtDatumArchief.Size = new System.Drawing.Size(81, 20);
            this.txtDatumArchief.TabIndex = 30;
            this.txtDatumArchief.ValidatingType = typeof(System.DateTime);
            this.txtDatumArchief.Leave += new System.EventHandler(this.SaveGlobals);
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.Location = new System.Drawing.Point(74, 300);
            this.materialLabel10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(101, 18);
            this.materialLabel10.TabIndex = 0;
            this.materialLabel10.Text = "Datum Archief";
            // 
            // tabLoadFiles
            // 
            this.tabLoadFiles.Controls.Add(this.btLoadRecordMapping);
            this.tabLoadFiles.Controls.Add(this.btSaveRecordMapping);
            this.tabLoadFiles.Controls.Add(this.btLoadDossierMapping);
            this.tabLoadFiles.Controls.Add(this.btSaveDossierMapping);
            this.tabLoadFiles.Controls.Add(this.btClearMappingsRecords);
            this.tabLoadFiles.Controls.Add(this.btClearMappingsDossiers);
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
            this.tabLoadFiles.Size = new System.Drawing.Size(1218, 660);
            this.tabLoadFiles.TabIndex = 1;
            this.tabLoadFiles.Text = "Bestanden";
            this.tabLoadFiles.UseVisualStyleBackColor = true;
            // 
            // btLoadRecordMapping
            // 
            this.btLoadRecordMapping.Location = new System.Drawing.Point(1084, 39);
            this.btLoadRecordMapping.Name = "btLoadRecordMapping";
            this.btLoadRecordMapping.Size = new System.Drawing.Size(43, 23);
            this.btLoadRecordMapping.TabIndex = 46;
            this.btLoadRecordMapping.Text = "Load";
            this.btLoadRecordMapping.UseVisualStyleBackColor = true;
            this.btLoadRecordMapping.Click += new System.EventHandler(this.btLoadRecordMapping_Click);
            // 
            // btSaveRecordMapping
            // 
            this.btSaveRecordMapping.Location = new System.Drawing.Point(1035, 39);
            this.btSaveRecordMapping.Name = "btSaveRecordMapping";
            this.btSaveRecordMapping.Size = new System.Drawing.Size(43, 23);
            this.btSaveRecordMapping.TabIndex = 45;
            this.btSaveRecordMapping.Text = "Save";
            this.btSaveRecordMapping.UseVisualStyleBackColor = true;
            this.btSaveRecordMapping.Click += new System.EventHandler(this.btSaveRecordMapping_Click);
            // 
            // btLoadDossierMapping
            // 
            this.btLoadDossierMapping.Location = new System.Drawing.Point(472, 39);
            this.btLoadDossierMapping.Name = "btLoadDossierMapping";
            this.btLoadDossierMapping.Size = new System.Drawing.Size(43, 23);
            this.btLoadDossierMapping.TabIndex = 44;
            this.btLoadDossierMapping.Text = "Load";
            this.btLoadDossierMapping.UseVisualStyleBackColor = true;
            this.btLoadDossierMapping.Click += new System.EventHandler(this.btLoadDossierMapping_Click);
            // 
            // btSaveDossierMapping
            // 
            this.btSaveDossierMapping.Location = new System.Drawing.Point(423, 39);
            this.btSaveDossierMapping.Name = "btSaveDossierMapping";
            this.btSaveDossierMapping.Size = new System.Drawing.Size(43, 23);
            this.btSaveDossierMapping.TabIndex = 43;
            this.btSaveDossierMapping.Text = "Save";
            this.btSaveDossierMapping.UseVisualStyleBackColor = true;
            this.btSaveDossierMapping.Click += new System.EventHandler(this.btSaveDossierMapping_Click);
            // 
            // btClearMappingsRecords
            // 
            this.btClearMappingsRecords.Location = new System.Drawing.Point(1162, 39);
            this.btClearMappingsRecords.Name = "btClearMappingsRecords";
            this.btClearMappingsRecords.Size = new System.Drawing.Size(48, 23);
            this.btClearMappingsRecords.TabIndex = 42;
            this.btClearMappingsRecords.Text = "Reset";
            this.btClearMappingsRecords.UseVisualStyleBackColor = true;
            this.btClearMappingsRecords.Click += new System.EventHandler(this.btClearMappingsRecords_Click);
            // 
            // btClearMappingsDossiers
            // 
            this.btClearMappingsDossiers.Location = new System.Drawing.Point(546, 39);
            this.btClearMappingsDossiers.Name = "btClearMappingsDossiers";
            this.btClearMappingsDossiers.Size = new System.Drawing.Size(43, 23);
            this.btClearMappingsDossiers.TabIndex = 41;
            this.btClearMappingsDossiers.Text = "Reset";
            this.btClearMappingsDossiers.UseVisualStyleBackColor = true;
            this.btClearMappingsDossiers.Click += new System.EventHandler(this.btClearMappingsDossiers_Click);
            // 
            // picRecordsSelector
            // 
            this.picRecordsSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRecordsSelector.Image = ((System.Drawing.Image)(resources.GetObject("picRecordsSelector.Image")));
            this.picRecordsSelector.Location = new System.Drawing.Point(898, 40);
            this.picRecordsSelector.Margin = new System.Windows.Forms.Padding(2);
            this.picRecordsSelector.Name = "picRecordsSelector";
            this.picRecordsSelector.Size = new System.Drawing.Size(23, 23);
            this.picRecordsSelector.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRecordsSelector.TabIndex = 22;
            this.picRecordsSelector.TabStop = false;
            this.picRecordsSelector.Click += new System.EventHandler(this.picRecordsSelector_Click);
            // 
            // picDossierSelector
            // 
            this.picDossierSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDossierSelector.Image = ((System.Drawing.Image)(resources.GetObject("picDossierSelector.Image")));
            this.picDossierSelector.Location = new System.Drawing.Point(281, 37);
            this.picDossierSelector.Margin = new System.Windows.Forms.Padding(2);
            this.picDossierSelector.Name = "picDossierSelector";
            this.picDossierSelector.Size = new System.Drawing.Size(23, 23);
            this.picDossierSelector.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDossierSelector.TabIndex = 21;
            this.picDossierSelector.TabStop = false;
            this.picDossierSelector.Click += new System.EventHandler(this.picDossierSelector_Click);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(636, 79);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(247, 18);
            this.materialLabel2.TabIndex = 20;
            this.materialLabel2.Text = "Veldmapping Records en Bestanden";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.White;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(9, 78);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(156, 18);
            this.materialLabel1.TabIndex = 19;
            this.materialLabel1.Text = "Veldmapping Dossiers";
            // 
            // txtRecordBestandLocation
            // 
            this.txtRecordBestandLocation.Location = new System.Drawing.Point(642, 42);
            this.txtRecordBestandLocation.Name = "txtRecordBestandLocation";
            this.txtRecordBestandLocation.ReadOnly = true;
            this.txtRecordBestandLocation.Size = new System.Drawing.Size(250, 20);
            this.txtRecordBestandLocation.TabIndex = 20;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(638, 14);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(309, 18);
            this.materialLabel6.TabIndex = 17;
            this.materialLabel6.Text = "Selecteer Records en Bestanden-Metadatafile";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(20, 13);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(210, 18);
            this.materialLabel5.TabIndex = 16;
            this.materialLabel5.Text = "Selecteer Dossier-Metadatafile";
            // 
            // txtDossierLocation
            // 
            this.txtDossierLocation.Location = new System.Drawing.Point(24, 39);
            this.txtDossierLocation.Name = "txtDossierLocation";
            this.txtDossierLocation.ReadOnly = true;
            this.txtDossierLocation.Size = new System.Drawing.Size(250, 20);
            this.txtDossierLocation.TabIndex = 10;
            // 
            // tabImportFiles
            // 
            this.tabImportFiles.Controls.Add(this.linkCopyErrorsRecords);
            this.tabImportFiles.Controls.Add(this.linkCopyErrorsDossiers);
            this.tabImportFiles.Controls.Add(this.btImportFilesInDb);
            this.tabImportFiles.Controls.Add(this.materialLabel4);
            this.tabImportFiles.Controls.Add(this.materialLabel3);
            this.tabImportFiles.Controls.Add(this.txtErrorRecords);
            this.tabImportFiles.Controls.Add(this.txtErrorsDossiers);
            this.tabImportFiles.Location = new System.Drawing.Point(4, 22);
            this.tabImportFiles.Margin = new System.Windows.Forms.Padding(2);
            this.tabImportFiles.Name = "tabImportFiles";
            this.tabImportFiles.Size = new System.Drawing.Size(1218, 660);
            this.tabImportFiles.TabIndex = 2;
            this.tabImportFiles.Text = "Import";
            this.tabImportFiles.UseVisualStyleBackColor = true;
            // 
            // linkCopyErrorsRecords
            // 
            this.linkCopyErrorsRecords.AutoSize = true;
            this.linkCopyErrorsRecords.Location = new System.Drawing.Point(1145, 66);
            this.linkCopyErrorsRecords.Name = "linkCopyErrorsRecords";
            this.linkCopyErrorsRecords.Size = new System.Drawing.Size(49, 13);
            this.linkCopyErrorsRecords.TabIndex = 12;
            this.linkCopyErrorsRecords.TabStop = true;
            this.linkCopyErrorsRecords.Text = "Kopiëren";
            this.linkCopyErrorsRecords.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCopyErrorsRecords_LinkClicked);
            // 
            // linkCopyErrorsDossiers
            // 
            this.linkCopyErrorsDossiers.AutoSize = true;
            this.linkCopyErrorsDossiers.Location = new System.Drawing.Point(533, 64);
            this.linkCopyErrorsDossiers.Name = "linkCopyErrorsDossiers";
            this.linkCopyErrorsDossiers.Size = new System.Drawing.Size(49, 13);
            this.linkCopyErrorsDossiers.TabIndex = 11;
            this.linkCopyErrorsDossiers.TabStop = true;
            this.linkCopyErrorsDossiers.Text = "Kopiëren";
            this.linkCopyErrorsDossiers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCopyErrorsDossiers_LinkClicked);
            // 
            // btImportFilesInDb
            // 
            this.btImportFilesInDb.Location = new System.Drawing.Point(42, 19);
            this.btImportFilesInDb.Name = "btImportFilesInDb";
            this.btImportFilesInDb.Size = new System.Drawing.Size(113, 26);
            this.btImportFilesInDb.TabIndex = 1;
            this.btImportFilesInDb.Text = "Import bestanden";
            this.btImportFilesInDb.Click += new System.EventHandler(this.btImportFilesInDb_Click);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(655, 62);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(111, 18);
            this.materialLabel4.TabIndex = 9;
            this.materialLabel4.Text = "Errors Records";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(39, 60);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(114, 18);
            this.materialLabel3.TabIndex = 8;
            this.materialLabel3.Text = "Errors Dossiers";
            // 
            // txtErrorRecords
            // 
            this.txtErrorRecords.Location = new System.Drawing.Point(649, 86);
            this.txtErrorRecords.Multiline = true;
            this.txtErrorRecords.Name = "txtErrorRecords";
            this.txtErrorRecords.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrorRecords.Size = new System.Drawing.Size(543, 554);
            this.txtErrorRecords.TabIndex = 7;
            this.txtErrorRecords.WordWrap = false;
            // 
            // txtErrorsDossiers
            // 
            this.txtErrorsDossiers.Location = new System.Drawing.Point(41, 84);
            this.txtErrorsDossiers.Multiline = true;
            this.txtErrorsDossiers.Name = "txtErrorsDossiers";
            this.txtErrorsDossiers.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrorsDossiers.Size = new System.Drawing.Size(543, 556);
            this.txtErrorsDossiers.TabIndex = 6;
            this.txtErrorsDossiers.WordWrap = false;
            // 
            // tabMetadata
            // 
            this.tabMetadata.Controls.Add(this.chkTestForPasswProtection);
            this.tabMetadata.Controls.Add(this.label6);
            this.tabMetadata.Controls.Add(this.label5);
            this.tabMetadata.Controls.Add(this.txtProgressMetaData);
            this.tabMetadata.Controls.Add(this.picSelectDroidLocation);
            this.tabMetadata.Controls.Add(this.label4);
            this.tabMetadata.Controls.Add(this.txtDroidLocation);
            this.tabMetadata.Controls.Add(this.linkCopyMetadataErrors);
            this.tabMetadata.Controls.Add(this.btMetadataCancel);
            this.tabMetadata.Controls.Add(this.progressBar1);
            this.tabMetadata.Controls.Add(this.btGenerateMetadata);
            this.tabMetadata.Controls.Add(this.materialLabel16);
            this.tabMetadata.Controls.Add(this.txtMetadataErrors);
            this.tabMetadata.Controls.Add(this.chkGetFileSignature);
            this.tabMetadata.Controls.Add(this.chkGetFileSize);
            this.tabMetadata.Controls.Add(this.checkGetCreationDate);
            this.tabMetadata.Controls.Add(this.chkGetHash);
            this.tabMetadata.Controls.Add(this.materialLabel15);
            this.tabMetadata.Controls.Add(this.picSelectDirToScan);
            this.tabMetadata.Controls.Add(this.txtFilesDirToScan);
            this.tabMetadata.Location = new System.Drawing.Point(4, 22);
            this.tabMetadata.Name = "tabMetadata";
            this.tabMetadata.Padding = new System.Windows.Forms.Padding(3);
            this.tabMetadata.Size = new System.Drawing.Size(1218, 660);
            this.tabMetadata.TabIndex = 5;
            this.tabMetadata.Text = "Genereer Metadata";
            this.tabMetadata.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(349, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Zorg dat DROID goed functioneert, en de laatste signature files gebruikt.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(395, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Voor bepalen van de file signature, moet DROID op de computer zijn geinstalleerd." +
    "";
            // 
            // txtProgressMetaData
            // 
            this.txtProgressMetaData.Location = new System.Drawing.Point(75, 447);
            this.txtProgressMetaData.Multiline = true;
            this.txtProgressMetaData.Name = "txtProgressMetaData";
            this.txtProgressMetaData.Size = new System.Drawing.Size(393, 137);
            this.txtProgressMetaData.TabIndex = 38;
            // 
            // picSelectDroidLocation
            // 
            this.picSelectDroidLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSelectDroidLocation.Image = ((System.Drawing.Image)(resources.GetObject("picSelectDroidLocation.Image")));
            this.picSelectDroidLocation.Location = new System.Drawing.Point(446, 285);
            this.picSelectDroidLocation.Margin = new System.Windows.Forms.Padding(2);
            this.picSelectDroidLocation.Name = "picSelectDroidLocation";
            this.picSelectDroidLocation.Size = new System.Drawing.Size(22, 29);
            this.picSelectDroidLocation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSelectDroidLocation.TabIndex = 37;
            this.picSelectDroidLocation.TabStop = false;
            this.picSelectDroidLocation.Click += new System.EventHandler(this.picSelectDroidLocation_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "droid.bat locatie";
            // 
            // txtDroidLocation
            // 
            this.txtDroidLocation.Location = new System.Drawing.Point(180, 294);
            this.txtDroidLocation.Name = "txtDroidLocation";
            this.txtDroidLocation.Size = new System.Drawing.Size(261, 20);
            this.txtDroidLocation.TabIndex = 35;
            this.txtDroidLocation.Leave += new System.EventHandler(this.txtDroidLocation_Leave);
            // 
            // linkCopyMetadataErrors
            // 
            this.linkCopyMetadataErrors.AutoSize = true;
            this.linkCopyMetadataErrors.Location = new System.Drawing.Point(1147, 33);
            this.linkCopyMetadataErrors.Name = "linkCopyMetadataErrors";
            this.linkCopyMetadataErrors.Size = new System.Drawing.Size(49, 13);
            this.linkCopyMetadataErrors.TabIndex = 34;
            this.linkCopyMetadataErrors.TabStop = true;
            this.linkCopyMetadataErrors.Text = "Kopiëren";
            this.linkCopyMetadataErrors.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCopyMetadataErrors_LinkClicked);
            // 
            // btMetadataCancel
            // 
            this.btMetadataCancel.Location = new System.Drawing.Point(235, 353);
            this.btMetadataCancel.Name = "btMetadataCancel";
            this.btMetadataCancel.Size = new System.Drawing.Size(92, 23);
            this.btMetadataCancel.TabIndex = 33;
            this.btMetadataCancel.Text = "Cancel scan";
            this.btMetadataCancel.UseVisualStyleBackColor = true;
            this.btMetadataCancel.Click += new System.EventHandler(this.btMetadataCancel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(75, 400);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(252, 23);
            this.progressBar1.TabIndex = 32;
            // 
            // btGenerateMetadata
            // 
            this.btGenerateMetadata.Location = new System.Drawing.Point(75, 353);
            this.btGenerateMetadata.Name = "btGenerateMetadata";
            this.btGenerateMetadata.Size = new System.Drawing.Size(95, 23);
            this.btGenerateMetadata.TabIndex = 31;
            this.btGenerateMetadata.Text = "Start scan";
            this.btGenerateMetadata.UseVisualStyleBackColor = true;
            this.btGenerateMetadata.Click += new System.EventHandler(this.btGenerateMetadata_Click);
            // 
            // materialLabel16
            // 
            this.materialLabel16.AutoSize = true;
            this.materialLabel16.Depth = 0;
            this.materialLabel16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel16.Location = new System.Drawing.Point(569, 27);
            this.materialLabel16.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel16.Name = "materialLabel16";
            this.materialLabel16.Size = new System.Drawing.Size(50, 18);
            this.materialLabel16.TabIndex = 30;
            this.materialLabel16.Text = "Errors";
            // 
            // txtMetadataErrors
            // 
            this.txtMetadataErrors.Location = new System.Drawing.Point(564, 59);
            this.txtMetadataErrors.Multiline = true;
            this.txtMetadataErrors.Name = "txtMetadataErrors";
            this.txtMetadataErrors.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMetadataErrors.Size = new System.Drawing.Size(632, 544);
            this.txtMetadataErrors.TabIndex = 29;
            this.txtMetadataErrors.WordWrap = false;
            // 
            // chkGetFileSignature
            // 
            this.chkGetFileSignature.AutoSize = true;
            this.chkGetFileSignature.Location = new System.Drawing.Point(75, 218);
            this.chkGetFileSignature.Name = "chkGetFileSignature";
            this.chkGetFileSignature.Size = new System.Drawing.Size(176, 17);
            this.chkGetFileSignature.TabIndex = 28;
            this.chkGetFileSignature.Text = "Bestandsformaat (File signature)";
            this.chkGetFileSignature.UseVisualStyleBackColor = true;
            // 
            // chkGetFileSize
            // 
            this.chkGetFileSize.AutoSize = true;
            this.chkGetFileSize.Location = new System.Drawing.Point(75, 163);
            this.chkGetFileSize.Name = "chkGetFileSize";
            this.chkGetFileSize.Size = new System.Drawing.Size(148, 17);
            this.chkGetFileSize.TabIndex = 27;
            this.chkGetFileSize.Text = "Bestandsgrootte (FileSize)";
            this.chkGetFileSize.UseVisualStyleBackColor = true;
            // 
            // checkGetCreationDate
            // 
            this.checkGetCreationDate.AutoSize = true;
            this.checkGetCreationDate.Location = new System.Drawing.Point(75, 138);
            this.checkGetCreationDate.Name = "checkGetCreationDate";
            this.checkGetCreationDate.Size = new System.Drawing.Size(171, 17);
            this.checkGetCreationDate.TabIndex = 26;
            this.checkGetCreationDate.Text = "Aanmaakdatum (CreationDate)";
            this.checkGetCreationDate.UseVisualStyleBackColor = true;
            // 
            // chkGetHash
            // 
            this.chkGetHash.AutoSize = true;
            this.chkGetHash.Location = new System.Drawing.Point(75, 113);
            this.chkGetHash.Name = "chkGetHash";
            this.chkGetHash.Size = new System.Drawing.Size(134, 17);
            this.chkGetHash.TabIndex = 25;
            this.chkGetHash.Text = "Genereer sha256-hash";
            this.chkGetHash.UseVisualStyleBackColor = true;
            // 
            // materialLabel15
            // 
            this.materialLabel15.AutoSize = true;
            this.materialLabel15.Depth = 0;
            this.materialLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel15.Location = new System.Drawing.Point(71, 24);
            this.materialLabel15.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel15.Name = "materialLabel15";
            this.materialLabel15.Size = new System.Drawing.Size(237, 18);
            this.materialLabel15.TabIndex = 24;
            this.materialLabel15.Text = "Selecteer directory te scannen files";
            // 
            // picSelectDirToScan
            // 
            this.picSelectDirToScan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSelectDirToScan.Image = ((System.Drawing.Image)(resources.GetObject("picSelectDirToScan.Image")));
            this.picSelectDirToScan.Location = new System.Drawing.Point(446, 53);
            this.picSelectDirToScan.Margin = new System.Windows.Forms.Padding(2);
            this.picSelectDirToScan.Name = "picSelectDirToScan";
            this.picSelectDirToScan.Size = new System.Drawing.Size(22, 29);
            this.picSelectDirToScan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSelectDirToScan.TabIndex = 23;
            this.picSelectDirToScan.TabStop = false;
            this.picSelectDirToScan.Click += new System.EventHandler(this.picSelectDirToScan_Click);
            // 
            // txtFilesDirToScan
            // 
            this.txtFilesDirToScan.Location = new System.Drawing.Point(75, 59);
            this.txtFilesDirToScan.Name = "txtFilesDirToScan";
            this.txtFilesDirToScan.Size = new System.Drawing.Size(366, 20);
            this.txtFilesDirToScan.TabIndex = 22;
            this.txtFilesDirToScan.Leave += new System.EventHandler(this.txtFilesDirToScan_Leave);
            // 
            // tabGenerateTopX
            // 
            this.tabGenerateTopX.Controls.Add(this.label3);
            this.tabGenerateTopX.Controls.Add(this.txtBatchSourceDirectory);
            this.tabGenerateTopX.Controls.Add(this.picSelectBatchSourceDir);
            this.tabGenerateTopX.Controls.Add(this.label2);
            this.tabGenerateTopX.Controls.Add(this.txtBatchTargetDirectory);
            this.tabGenerateTopX.Controls.Add(this.picSelectBatchTargetDir);
            this.tabGenerateTopX.Controls.Add(this.chkCreateBatchesSubdir);
            this.tabGenerateTopX.Controls.Add(this.label1);
            this.tabGenerateTopX.Controls.Add(this.txtBatchSize);
            this.tabGenerateTopX.Controls.Add(this.chkUseBatchSize);
            this.tabGenerateTopX.Controls.Add(this.btSaveTopxXml);
            this.tabGenerateTopX.Controls.Add(this.materialLabel14);
            this.tabGenerateTopX.Controls.Add(this.txtResultXml);
            this.tabGenerateTopX.Controls.Add(this.linkCopyTopXCreateError);
            this.tabGenerateTopX.Controls.Add(this.materialLabel13);
            this.tabGenerateTopX.Controls.Add(this.btGenerateTopX);
            this.tabGenerateTopX.Controls.Add(this.txtLogTopXCreate);
            this.tabGenerateTopX.Location = new System.Drawing.Point(4, 22);
            this.tabGenerateTopX.Margin = new System.Windows.Forms.Padding(2);
            this.tabGenerateTopX.Name = "tabGenerateTopX";
            this.tabGenerateTopX.Size = new System.Drawing.Size(1218, 660);
            this.tabGenerateTopX.TabIndex = 4;
            this.tabGenerateTopX.Text = "Genereer TopX";
            this.tabGenerateTopX.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Bron-directory";
            // 
            // txtBatchSourceDirectory
            // 
            this.txtBatchSourceDirectory.Enabled = false;
            this.txtBatchSourceDirectory.Location = new System.Drawing.Point(553, 48);
            this.txtBatchSourceDirectory.Name = "txtBatchSourceDirectory";
            this.txtBatchSourceDirectory.Size = new System.Drawing.Size(312, 20);
            this.txtBatchSourceDirectory.TabIndex = 24;
            // 
            // picSelectBatchSourceDir
            // 
            this.picSelectBatchSourceDir.Enabled = false;
            this.picSelectBatchSourceDir.Image = ((System.Drawing.Image)(resources.GetObject("picSelectBatchSourceDir.Image")));
            this.picSelectBatchSourceDir.Location = new System.Drawing.Point(870, 44);
            this.picSelectBatchSourceDir.Name = "picSelectBatchSourceDir";
            this.picSelectBatchSourceDir.Size = new System.Drawing.Size(23, 29);
            this.picSelectBatchSourceDir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSelectBatchSourceDir.TabIndex = 23;
            this.picSelectBatchSourceDir.TabStop = false;
            this.picSelectBatchSourceDir.Click += new System.EventHandler(this.picSelectBatchSourceDir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(472, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Doel-directory";
            // 
            // txtBatchTargetDirectory
            // 
            this.txtBatchTargetDirectory.Enabled = false;
            this.txtBatchTargetDirectory.Location = new System.Drawing.Point(553, 74);
            this.txtBatchTargetDirectory.Name = "txtBatchTargetDirectory";
            this.txtBatchTargetDirectory.Size = new System.Drawing.Size(312, 20);
            this.txtBatchTargetDirectory.TabIndex = 21;
            // 
            // picSelectBatchTargetDir
            // 
            this.picSelectBatchTargetDir.Enabled = false;
            this.picSelectBatchTargetDir.Image = ((System.Drawing.Image)(resources.GetObject("picSelectBatchTargetDir.Image")));
            this.picSelectBatchTargetDir.Location = new System.Drawing.Point(870, 70);
            this.picSelectBatchTargetDir.Name = "picSelectBatchTargetDir";
            this.picSelectBatchTargetDir.Size = new System.Drawing.Size(23, 29);
            this.picSelectBatchTargetDir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSelectBatchTargetDir.TabIndex = 20;
            this.picSelectBatchTargetDir.TabStop = false;
            this.picSelectBatchTargetDir.Click += new System.EventHandler(this.picSelectBatchTargetDir_Click);
            // 
            // chkCreateBatchesSubdir
            // 
            this.chkCreateBatchesSubdir.AutoSize = true;
            this.chkCreateBatchesSubdir.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCreateBatchesSubdir.Location = new System.Drawing.Point(264, 51);
            this.chkCreateBatchesSubdir.Name = "chkCreateBatchesSubdir";
            this.chkCreateBatchesSubdir.Size = new System.Drawing.Size(177, 17);
            this.chkCreateBatchesSubdir.TabIndex = 19;
            this.chkCreateBatchesSubdir.Text = "Kopieer alle files naar directories";
            this.chkCreateBatchesSubdir.UseVisualStyleBackColor = true;
            this.chkCreateBatchesSubdir.CheckedChanged += new System.EventHandler(this.chkCreateBatchesSubdir_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(457, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Batchgrootte (GB)";
            // 
            // txtBatchSize
            // 
            this.txtBatchSize.Location = new System.Drawing.Point(553, 15);
            this.txtBatchSize.Name = "txtBatchSize";
            this.txtBatchSize.Size = new System.Drawing.Size(34, 20);
            this.txtBatchSize.TabIndex = 4;
            this.txtBatchSize.Text = "30";
            this.txtBatchSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBatchSize_KeyPress);
            this.txtBatchSize.Leave += new System.EventHandler(this.txtBatchSize_Leave);
            // 
            // chkUseBatchSize
            // 
            this.chkUseBatchSize.AutoSize = true;
            this.chkUseBatchSize.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUseBatchSize.Location = new System.Drawing.Point(347, 18);
            this.chkUseBatchSize.Name = "chkUseBatchSize";
            this.chkUseBatchSize.Size = new System.Drawing.Size(94, 17);
            this.chkUseBatchSize.TabIndex = 3;
            this.chkUseBatchSize.Text = "Maak batches";
            this.chkUseBatchSize.UseVisualStyleBackColor = true;
            // 
            // btSaveTopxXml
            // 
            this.btSaveTopxXml.Location = new System.Drawing.Point(184, 15);
            this.btSaveTopxXml.Name = "btSaveTopxXml";
            this.btSaveTopxXml.Size = new System.Drawing.Size(122, 23);
            this.btSaveTopxXml.TabIndex = 2;
            this.btSaveTopxXml.Text = "Save TopX xml";
            this.btSaveTopxXml.UseVisualStyleBackColor = true;
            this.btSaveTopxXml.Click += new System.EventHandler(this.btSaveTopxXml_Click);
            // 
            // materialLabel14
            // 
            this.materialLabel14.AutoSize = true;
            this.materialLabel14.Depth = 0;
            this.materialLabel14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel14.Location = new System.Drawing.Point(656, 159);
            this.materialLabel14.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.Size = new System.Drawing.Size(248, 18);
            this.materialLabel14.TabIndex = 14;
            this.materialLabel14.Text = "TopX XML (eerste 10.000 karakters)";
            // 
            // txtResultXml
            // 
            this.txtResultXml.Location = new System.Drawing.Point(645, 182);
            this.txtResultXml.Multiline = true;
            this.txtResultXml.Name = "txtResultXml";
            this.txtResultXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResultXml.Size = new System.Drawing.Size(543, 465);
            this.txtResultXml.TabIndex = 13;
            this.txtResultXml.WordWrap = false;
            // 
            // linkCopyTopXCreateError
            // 
            this.linkCopyTopXCreateError.AutoSize = true;
            this.linkCopyTopXCreateError.Location = new System.Drawing.Point(516, 163);
            this.linkCopyTopXCreateError.Name = "linkCopyTopXCreateError";
            this.linkCopyTopXCreateError.Size = new System.Drawing.Size(49, 13);
            this.linkCopyTopXCreateError.TabIndex = 12;
            this.linkCopyTopXCreateError.TabStop = true;
            this.linkCopyTopXCreateError.Text = "Kopiëren";
            this.linkCopyTopXCreateError.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCopyTopXCreateError_LinkClicked);
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel13.Location = new System.Drawing.Point(47, 160);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(33, 18);
            this.materialLabel13.TabIndex = 9;
            this.materialLabel13.Text = "Log";
            // 
            // btGenerateTopX
            // 
            this.btGenerateTopX.Location = new System.Drawing.Point(43, 15);
            this.btGenerateTopX.Name = "btGenerateTopX";
            this.btGenerateTopX.Size = new System.Drawing.Size(122, 23);
            this.btGenerateTopX.TabIndex = 1;
            this.btGenerateTopX.Text = "Genereer TopX";
            this.btGenerateTopX.UseVisualStyleBackColor = true;
            this.btGenerateTopX.Click += new System.EventHandler(this.btGenerateTopX_Click);
            // 
            // txtLogTopXCreate
            // 
            this.txtLogTopXCreate.Location = new System.Drawing.Point(37, 182);
            this.txtLogTopXCreate.Multiline = true;
            this.txtLogTopXCreate.Name = "txtLogTopXCreate";
            this.txtLogTopXCreate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogTopXCreate.Size = new System.Drawing.Size(543, 465);
            this.txtLogTopXCreate.TabIndex = 10;
            this.txtLogTopXCreate.WordWrap = false;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblVersion.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblVersion.Location = new System.Drawing.Point(1195, 34);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(52, 15);
            this.lblVersion.TabIndex = 71;
            this.lblVersion.Text = "v 1.0.0.0";
            // 
            // chkTestForPasswProtection
            // 
            this.chkTestForPasswProtection.AutoSize = true;
            this.chkTestForPasswProtection.Location = new System.Drawing.Point(75, 189);
            this.chkTestForPasswProtection.Name = "chkTestForPasswProtection";
            this.chkTestForPasswProtection.Size = new System.Drawing.Size(313, 17);
            this.chkTestForPasswProtection.TabIndex = 41;
            this.chkTestForPasswProtection.Text = "Test pdf\'s en MSOffice-bestanden op wachtwoordbeveiliging";
            this.chkTestForPasswProtection.UseVisualStyleBackColor = true;
            // 
            // txtIdentificatieArchief
            // 
            this.txtIdentificatieArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtIdentificatieArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtIdentificatieArchief.Location = new System.Drawing.Point(256, 265);
            this.txtIdentificatieArchief.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdentificatieArchief.Name = "txtIdentificatieArchief";
            this.txtIdentificatieArchief.PlaceHolderText = "Bijv: NL-0784-10009";
            this.txtIdentificatieArchief.Size = new System.Drawing.Size(194, 20);
            this.txtIdentificatieArchief.TabIndex = 20;
            this.txtIdentificatieArchief.Text = "Bijv: NL-0784-10009";
            this.txtIdentificatieArchief.Leave += new System.EventHandler(this.SaveGlobals);
            // 
            // txtNaamArchief
            // 
            this.txtNaamArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtNaamArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtNaamArchief.Location = new System.Drawing.Point(256, 235);
            this.txtNaamArchief.Margin = new System.Windows.Forms.Padding(2);
            this.txtNaamArchief.Name = "txtNaamArchief";
            this.txtNaamArchief.PlaceHolderText = "Bijv: Bouwvergunningen Gemeente Raamsdonk 1993 - 1996";
            this.txtNaamArchief.Size = new System.Drawing.Size(480, 20);
            this.txtNaamArchief.TabIndex = 10;
            this.txtNaamArchief.Text = "Bijv: Bouwvergunningen Gemeente Raamsdonk 1993 - 1996";
            this.txtNaamArchief.Leave += new System.EventHandler(this.SaveGlobals);
            // 
            // txtDoelArchief
            // 
            this.txtDoelArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtDoelArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtDoelArchief.Location = new System.Drawing.Point(256, 390);
            this.txtDoelArchief.Margin = new System.Windows.Forms.Padding(2);
            this.txtDoelArchief.Name = "txtDoelArchief";
            this.txtDoelArchief.PlaceHolderText = "Bijv: Bouwvergunningen om op te nemen in e-Depot";
            this.txtDoelArchief.Size = new System.Drawing.Size(480, 20);
            this.txtDoelArchief.TabIndex = 70;
            this.txtDoelArchief.Text = "Bijv: Bouwvergunningen om op te nemen in e-Depot";
            this.txtDoelArchief.Leave += new System.EventHandler(this.SaveGlobals);
            // 
            // txtBronArchief
            // 
            this.txtBronArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtBronArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtBronArchief.Location = new System.Drawing.Point(256, 360);
            this.txtBronArchief.Margin = new System.Windows.Forms.Padding(2);
            this.txtBronArchief.Name = "txtBronArchief";
            this.txtBronArchief.PlaceHolderText = "Bijv: Digitale bouwvergunningen";
            this.txtBronArchief.Size = new System.Drawing.Size(480, 20);
            this.txtBronArchief.TabIndex = 60;
            this.txtBronArchief.Text = "Bijv: Digitale bouwvergunningen";
            this.txtBronArchief.Leave += new System.EventHandler(this.SaveGlobals);
            // 
            // txtOmschrijvingArchief
            // 
            this.txtOmschrijvingArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtOmschrijvingArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtOmschrijvingArchief.Location = new System.Drawing.Point(256, 330);
            this.txtOmschrijvingArchief.Margin = new System.Windows.Forms.Padding(2);
            this.txtOmschrijvingArchief.Name = "txtOmschrijvingArchief";
            this.txtOmschrijvingArchief.PlaceHolderText = "Bijv: Bouwvergunningen Gemeente Raamsdonk 1993 - 1996";
            this.txtOmschrijvingArchief.Size = new System.Drawing.Size(480, 20);
            this.txtOmschrijvingArchief.TabIndex = 50;
            this.txtOmschrijvingArchief.Text = "Bijv: Bouwvergunningen Gemeente Raamsdonk 1993 - 1996";
            this.txtOmschrijvingArchief.Leave += new System.EventHandler(this.SaveGlobals);
            // 
            // gridFieldMappingRecords
            // 
            this.gridFieldMappingRecords.AllowDrop = true;
            this.gridFieldMappingRecords.AllowUserToAddRows = false;
            this.gridFieldMappingRecords.AllowUserToDeleteRows = false;
            this.gridFieldMappingRecords.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridFieldMappingRecords.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFieldMappingRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridFieldMappingRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFieldMappingRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DatabaseFieldNameRecords,
            this.MappedFieldNameRecords,
            this.TMLO_Records});
            this.gridFieldMappingRecords.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridFieldMappingRecords.EnableHeadersVisualStyles = false;
            this.gridFieldMappingRecords.Location = new System.Drawing.Point(640, 100);
            this.gridFieldMappingRecords.Name = "gridFieldMappingRecords";
            this.gridFieldMappingRecords.RowHeadersVisible = false;
            this.gridFieldMappingRecords.ShowCellErrors = false;
            this.gridFieldMappingRecords.ShowCellToolTips = false;
            this.gridFieldMappingRecords.ShowEditingIcon = false;
            this.gridFieldMappingRecords.ShowRowErrors = false;
            this.gridFieldMappingRecords.Size = new System.Drawing.Size(569, 552);
            this.gridFieldMappingRecords.TabIndex = 40;
            this.gridFieldMappingRecords.DataSourceChanged += new System.EventHandler(this.gridFieldMappingRecords_DataSourceChanged);
            this.gridFieldMappingRecords.Leave += new System.EventHandler(this.gridFieldMappingRecords_Leave);
            this.gridFieldMappingRecords.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridFieldMappingRecords_MouseClick);
            // 
            // DatabaseFieldNameRecords
            // 
            this.DatabaseFieldNameRecords.DataPropertyName = "MappedFieldName";
            this.DatabaseFieldNameRecords.HeaderText = "Veldnaam Bron";
            this.DatabaseFieldNameRecords.Name = "DatabaseFieldNameRecords";
            this.DatabaseFieldNameRecords.Width = 250;
            // 
            // MappedFieldNameRecords
            // 
            this.MappedFieldNameRecords.DataPropertyName = "DatabaseFieldName";
            this.MappedFieldNameRecords.HeaderText = "Veldnaam TopX";
            this.MappedFieldNameRecords.Name = "MappedFieldNameRecords";
            this.MappedFieldNameRecords.Width = 265;
            // 
            // TMLO_Records
            // 
            this.TMLO_Records.DataPropertyName = "TMLO";
            this.TMLO_Records.HeaderText = "TMLO";
            this.TMLO_Records.Name = "TMLO_Records";
            this.TMLO_Records.ReadOnly = true;
            this.TMLO_Records.Width = 50;
            // 
            // gridFieldMappingDossiers
            // 
            this.gridFieldMappingDossiers.AllowDrop = true;
            this.gridFieldMappingDossiers.AllowUserToAddRows = false;
            this.gridFieldMappingDossiers.AllowUserToDeleteRows = false;
            this.gridFieldMappingDossiers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridFieldMappingDossiers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFieldMappingDossiers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridFieldMappingDossiers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFieldMappingDossiers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MappedFieldName,
            this.DatabaseFieldName,
            this.TMLO,
            this.Optional});
            this.gridFieldMappingDossiers.EnableHeadersVisualStyles = false;
            this.gridFieldMappingDossiers.Location = new System.Drawing.Point(5, 100);
            this.gridFieldMappingDossiers.Name = "gridFieldMappingDossiers";
            this.gridFieldMappingDossiers.RowHeadersVisible = false;
            this.gridFieldMappingDossiers.ShowCellErrors = false;
            this.gridFieldMappingDossiers.ShowCellToolTips = false;
            this.gridFieldMappingDossiers.ShowEditingIcon = false;
            this.gridFieldMappingDossiers.ShowRowErrors = false;
            this.gridFieldMappingDossiers.Size = new System.Drawing.Size(623, 552);
            this.gridFieldMappingDossiers.TabIndex = 30;
            this.gridFieldMappingDossiers.DataSourceChanged += new System.EventHandler(this.gridFieldMappingDossiers_DataSourceChanged);
            this.gridFieldMappingDossiers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridFieldMappingDossiers_DataBindingComplete);
            this.gridFieldMappingDossiers.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.gridFieldMappingDossiers_DefaultValuesNeeded);
            this.gridFieldMappingDossiers.Leave += new System.EventHandler(this.gridFieldMappingDossiers_Leave);
            this.gridFieldMappingDossiers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridFieldMappingDossiers_MouseClick);
            // 
            // MappedFieldName
            // 
            this.MappedFieldName.DataPropertyName = "MappedFieldName";
            this.MappedFieldName.HeaderText = "Veldnaam Bron";
            this.MappedFieldName.Name = "MappedFieldName";
            this.MappedFieldName.Width = 250;
            // 
            // DatabaseFieldName
            // 
            this.DatabaseFieldName.DataPropertyName = "DatabaseFieldName";
            this.DatabaseFieldName.HeaderText = "Veldnaam TopX";
            this.DatabaseFieldName.Name = "DatabaseFieldName";
            this.DatabaseFieldName.Width = 250;
            // 
            // TMLO
            // 
            this.TMLO.DataPropertyName = "TMLO";
            this.TMLO.HeaderText = "TMLO";
            this.TMLO.Name = "TMLO";
            this.TMLO.ReadOnly = true;
            this.TMLO.Width = 60;
            // 
            // Optional
            // 
            this.Optional.DataPropertyName = "Optional";
            this.Optional.HeaderText = "Opt.";
            this.Optional.Name = "Optional";
            this.Optional.ReadOnly = true;
            this.Optional.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Optional.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Optional.ToolTipText = "Optioneel";
            this.Optional.Width = 35;
            // 
            // TopXConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1272, 789);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Name = "TopXConverter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
            this.tabImportFiles.ResumeLayout(false);
            this.tabImportFiles.PerformLayout();
            this.tabMetadata.ResumeLayout(false);
            this.tabMetadata.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectDroidLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectDirToScan)).EndInit();
            this.tabGenerateTopX.ResumeLayout(false);
            this.tabGenerateTopX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectBatchSourceDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectBatchTargetDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFieldMappingRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFieldMappingDossiers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private PlaceHolderTextBox txtIdentificatieArchief;
        private PictureBox picRecordsSelector;
        private PictureBox picDossierSelector;
        private Button btImportFilesInDb;
        private DragDropGridView gridFieldMappingRecords;
        private DragDropGridView gridFieldMappingDossiers;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private Button btGenerateTopX;
        private LinkLabel linkCopyErrorsRecords;
        private LinkLabel linkCopyErrorsDossiers;
        private LinkLabel linkCopyTopXCreateError;
        private MaterialSkin.Controls.MaterialLabel materialLabel14;
        private TextBox txtResultXml;
        private Button btSaveTopxXml;
        private TabPage tabMetadata;
        private PictureBox picSelectDirToScan;
        private TextBox txtFilesDirToScan;
        private Button btGenerateMetadata;
        private MaterialSkin.Controls.MaterialLabel materialLabel16;
        private TextBox txtMetadataErrors;
        private CheckBox chkGetFileSignature;
        private CheckBox chkGetFileSize;
        private CheckBox checkGetCreationDate;
        private CheckBox chkGetHash;
        private MaterialSkin.Controls.MaterialLabel materialLabel15;
        private ProgressBar progressBar1;
        private Button btMetadataCancel;
        private LinkLabel linkCopyMetadataErrors;
        private Label lblVersion;
        private Button btClearMappingsRecords;
        private Button btClearMappingsDossiers;
        private DataGridViewTextBoxColumn DatabaseFieldNameRecords;
        private DataGridViewTextBoxColumn MappedFieldNameRecords;
        private DataGridViewTextBoxColumn TMLO_Records;
        private Button btSaveDossierMapping;
        private Button btLoadDossierMapping;
        private Button btLoadRecordMapping;
        private Button btSaveRecordMapping;
        private MaterialSkin.Controls.MaterialLabel materialLabel21;
        private MaterialSkin.Controls.MaterialLabel materialLabel20;
        private MaterialSkin.Controls.MaterialLabel materialLabel19;
        private MaterialSkin.Controls.MaterialLabel materialLabel18;
        private MaterialSkin.Controls.MaterialLabel materialLabel17;
        private Label label1;
        private TextBox txtBatchSize;
        private CheckBox chkUseBatchSize;
        private CheckBox chkCreateBatchesSubdir;
        private Label label2;
        private TextBox txtBatchTargetDirectory;
        private PictureBox picSelectBatchTargetDir;
        private Label label3;
        private TextBox txtBatchSourceDirectory;
        private PictureBox picSelectBatchSourceDir;
        private PictureBox picSelectDroidLocation;
        private Label label4;
        private TextBox txtDroidLocation;
        private TextBox txtProgressMetaData;
        private DataGridViewTextBoxColumn MappedFieldName;
        private DataGridViewTextBoxColumn DatabaseFieldName;
        private DataGridViewTextBoxColumn TMLO;
        private DataGridViewCheckBoxColumn Optional;
        private Label label6;
        private Label label5;
        private CheckBox chkTestForPasswProtection;
    }
}

