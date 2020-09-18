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
            this.materialTab = new MaterialSkin.Controls.MaterialTabControl();
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
            this.chkTestForPasswProtection = new System.Windows.Forms.CheckBox();
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
            this.SidecarExport = new System.Windows.Forms.TabPage();
            this.materialLabel24 = new MaterialSkin.Controls.MaterialLabel();
            this.txtLogSidecarExport = new System.Windows.Forms.TextBox();
            this.btGenerateSidecarExport = new System.Windows.Forms.Button();
            this.materialLabel23 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel22 = new MaterialSkin.Controls.MaterialLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSourceDirOfSidecarFiles = new System.Windows.Forms.TextBox();
            this.picSelectSourceDirOfSidecarFiles = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTargetDirOfSidecarFiles = new System.Windows.Forms.TextBox();
            this.picSelectTargetDirOfSidecarFiles = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSidecarNrOfBatches = new System.Windows.Forms.TextBox();
            this.chkSidecarMakeBatches = new System.Windows.Forms.CheckBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.linkOpenSidecarExportInExplorer = new System.Windows.Forms.LinkLabel();
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
            this.materialTab.SuspendLayout();
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
            this.SidecarExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectSourceDirOfSidecarFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectTargetDirOfSidecarFiles)).BeginInit();
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
            this.materialContextMenuStrip2.Size = new System.Drawing.Size(114, 68);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(113, 32);
            this.testToolStripMenuItem.Text = "test";
            // 
            // testToolStripMenuItem1
            // 
            this.testToolStripMenuItem1.Name = "testToolStripMenuItem1";
            this.testToolStripMenuItem1.Size = new System.Drawing.Size(113, 32);
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
            this.materialContextMenuStrip3.Size = new System.Drawing.Size(131, 100);
            // 
            // ditIs1ToolStripMenuItem
            // 
            this.ditIs1ToolStripMenuItem.Name = "ditIs1ToolStripMenuItem";
            this.ditIs1ToolStripMenuItem.Size = new System.Drawing.Size(130, 32);
            this.ditIs1ToolStripMenuItem.Text = "DitIs1";
            // 
            // ditIs2ToolStripMenuItem
            // 
            this.ditIs2ToolStripMenuItem.Name = "ditIs2ToolStripMenuItem";
            this.ditIs2ToolStripMenuItem.Size = new System.Drawing.Size(130, 32);
            this.ditIs2ToolStripMenuItem.Text = "DitIs2";
            // 
            // ditIs3ToolStripMenuItem
            // 
            this.ditIs3ToolStripMenuItem.Name = "ditIs3ToolStripMenuItem";
            this.ditIs3ToolStripMenuItem.Size = new System.Drawing.Size(130, 32);
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
            this.materialTabSelector1.BaseTabControl = this.materialTab;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(184, 30);
            this.materialTabSelector1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(1511, 42);
            this.materialTabSelector1.TabIndex = 4;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTab
            // 
            this.materialTab.Controls.Add(this.tabGlobals);
            this.materialTab.Controls.Add(this.tabLoadFiles);
            this.materialTab.Controls.Add(this.tabImportFiles);
            this.materialTab.Controls.Add(this.tabMetadata);
            this.materialTab.Controls.Add(this.tabGenerateTopX);
            this.materialTab.Controls.Add(this.SidecarExport);
            this.materialTab.Depth = 0;
            this.materialTab.Location = new System.Drawing.Point(29, 100);
            this.materialTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.materialTab.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTab.Name = "materialTab";
            this.materialTab.SelectedIndex = 0;
            this.materialTab.Size = new System.Drawing.Size(1635, 844);
            this.materialTab.TabIndex = 5;
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
            this.tabGlobals.Location = new System.Drawing.Point(4, 25);
            this.tabGlobals.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabGlobals.Name = "tabGlobals";
            this.tabGlobals.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabGlobals.Size = new System.Drawing.Size(1627, 815);
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
            this.materialLabel21.Location = new System.Drawing.Point(99, 201);
            this.materialLabel21.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel21.Name = "materialLabel21";
            this.materialLabel21.Size = new System.Drawing.Size(594, 26);
            this.materialLabel21.TabIndex = 75;
            this.materialLabel21.Text = "Zie ook de handleiding (in Word) voor functionele toelichting.";
            // 
            // materialLabel20
            // 
            this.materialLabel20.AutoSize = true;
            this.materialLabel20.Depth = 0;
            this.materialLabel20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel20.Location = new System.Drawing.Point(99, 150);
            this.materialLabel20.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel20.Name = "materialLabel20";
            this.materialLabel20.Size = new System.Drawing.Size(989, 26);
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
            this.materialLabel19.Location = new System.Drawing.Point(99, 116);
            this.materialLabel19.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel19.Name = "materialLabel19";
            this.materialLabel19.Size = new System.Drawing.Size(757, 26);
            this.materialLabel19.TabIndex = 73;
            this.materialLabel19.Text = "- Csv met de records-metadata, = de documenten-metadata (Tab Bestanden)";
            // 
            // materialLabel18
            // 
            this.materialLabel18.AutoSize = true;
            this.materialLabel18.Depth = 0;
            this.materialLabel18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel18.Location = new System.Drawing.Point(99, 82);
            this.materialLabel18.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel18.Name = "materialLabel18";
            this.materialLabel18.Size = new System.Drawing.Size(472, 26);
            this.materialLabel18.TabIndex = 72;
            this.materialLabel18.Text = "- Csv met de dossiergegevens (Tab Bestanden)";
            // 
            // materialLabel17
            // 
            this.materialLabel17.AutoSize = true;
            this.materialLabel17.Depth = 0;
            this.materialLabel17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel17.Location = new System.Drawing.Point(99, 46);
            this.materialLabel17.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel17.Name = "materialLabel17";
            this.materialLabel17.Size = new System.Drawing.Size(814, 26);
            this.materialLabel17.TabIndex = 71;
            this.materialLabel17.Text = "Voor een succesvolle data-import en TopX-conversie zijn de volgende zaken nodig:";
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(99, 326);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(196, 26);
            this.materialLabel12.TabIndex = 12;
            this.materialLabel12.Text = "Identificatie Archief";
            // 
            // btFillDatumArchief
            // 
            this.btFillDatumArchief.Location = new System.Drawing.Point(492, 370);
            this.btFillDatumArchief.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btFillDatumArchief.Name = "btFillDatumArchief";
            this.btFillDatumArchief.Size = new System.Drawing.Size(107, 27);
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
            this.materialLabel9.Location = new System.Drawing.Point(99, 290);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(145, 26);
            this.materialLabel9.TabIndex = 8;
            this.materialLabel9.Text = "Naam Archief";
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(99, 480);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(131, 26);
            this.materialLabel11.TabIndex = 6;
            this.materialLabel11.Text = "Doel Archief";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(99, 443);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(132, 26);
            this.materialLabel8.TabIndex = 4;
            this.materialLabel8.Text = "Bron Archief";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(99, 406);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(213, 26);
            this.materialLabel7.TabIndex = 2;
            this.materialLabel7.Text = "Omschrijving Archief";
            // 
            // txtDatumArchief
            // 
            this.txtDatumArchief.Location = new System.Drawing.Point(341, 370);
            this.txtDatumArchief.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDatumArchief.Mask = "00-00-0000";
            this.txtDatumArchief.Name = "txtDatumArchief";
            this.txtDatumArchief.Size = new System.Drawing.Size(107, 22);
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
            this.materialLabel10.Location = new System.Drawing.Point(99, 370);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(151, 26);
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
            this.tabLoadFiles.Location = new System.Drawing.Point(4, 25);
            this.tabLoadFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLoadFiles.Name = "tabLoadFiles";
            this.tabLoadFiles.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLoadFiles.Size = new System.Drawing.Size(1627, 815);
            this.tabLoadFiles.TabIndex = 1;
            this.tabLoadFiles.Text = "Bestanden";
            this.tabLoadFiles.UseVisualStyleBackColor = true;
            // 
            // btLoadRecordMapping
            // 
            this.btLoadRecordMapping.Location = new System.Drawing.Point(1445, 48);
            this.btLoadRecordMapping.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btLoadRecordMapping.Name = "btLoadRecordMapping";
            this.btLoadRecordMapping.Size = new System.Drawing.Size(57, 28);
            this.btLoadRecordMapping.TabIndex = 46;
            this.btLoadRecordMapping.Text = "Load";
            this.btLoadRecordMapping.UseVisualStyleBackColor = true;
            this.btLoadRecordMapping.Click += new System.EventHandler(this.btLoadRecordMapping_Click);
            // 
            // btSaveRecordMapping
            // 
            this.btSaveRecordMapping.Location = new System.Drawing.Point(1380, 48);
            this.btSaveRecordMapping.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSaveRecordMapping.Name = "btSaveRecordMapping";
            this.btSaveRecordMapping.Size = new System.Drawing.Size(57, 28);
            this.btSaveRecordMapping.TabIndex = 45;
            this.btSaveRecordMapping.Text = "Save";
            this.btSaveRecordMapping.UseVisualStyleBackColor = true;
            this.btSaveRecordMapping.Click += new System.EventHandler(this.btSaveRecordMapping_Click);
            // 
            // btLoadDossierMapping
            // 
            this.btLoadDossierMapping.Location = new System.Drawing.Point(629, 48);
            this.btLoadDossierMapping.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btLoadDossierMapping.Name = "btLoadDossierMapping";
            this.btLoadDossierMapping.Size = new System.Drawing.Size(57, 28);
            this.btLoadDossierMapping.TabIndex = 44;
            this.btLoadDossierMapping.Text = "Load";
            this.btLoadDossierMapping.UseVisualStyleBackColor = true;
            this.btLoadDossierMapping.Click += new System.EventHandler(this.btLoadDossierMapping_Click);
            // 
            // btSaveDossierMapping
            // 
            this.btSaveDossierMapping.Location = new System.Drawing.Point(564, 48);
            this.btSaveDossierMapping.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSaveDossierMapping.Name = "btSaveDossierMapping";
            this.btSaveDossierMapping.Size = new System.Drawing.Size(57, 28);
            this.btSaveDossierMapping.TabIndex = 43;
            this.btSaveDossierMapping.Text = "Save";
            this.btSaveDossierMapping.UseVisualStyleBackColor = true;
            this.btSaveDossierMapping.Click += new System.EventHandler(this.btSaveDossierMapping_Click);
            // 
            // btClearMappingsRecords
            // 
            this.btClearMappingsRecords.Location = new System.Drawing.Point(1549, 48);
            this.btClearMappingsRecords.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btClearMappingsRecords.Name = "btClearMappingsRecords";
            this.btClearMappingsRecords.Size = new System.Drawing.Size(64, 28);
            this.btClearMappingsRecords.TabIndex = 42;
            this.btClearMappingsRecords.Text = "Reset";
            this.btClearMappingsRecords.UseVisualStyleBackColor = true;
            this.btClearMappingsRecords.Click += new System.EventHandler(this.btClearMappingsRecords_Click);
            // 
            // btClearMappingsDossiers
            // 
            this.btClearMappingsDossiers.Location = new System.Drawing.Point(728, 48);
            this.btClearMappingsDossiers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btClearMappingsDossiers.Name = "btClearMappingsDossiers";
            this.btClearMappingsDossiers.Size = new System.Drawing.Size(57, 28);
            this.btClearMappingsDossiers.TabIndex = 41;
            this.btClearMappingsDossiers.Text = "Reset";
            this.btClearMappingsDossiers.UseVisualStyleBackColor = true;
            this.btClearMappingsDossiers.Click += new System.EventHandler(this.btClearMappingsDossiers_Click);
            // 
            // picRecordsSelector
            // 
            this.picRecordsSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRecordsSelector.Image = ((System.Drawing.Image)(resources.GetObject("picRecordsSelector.Image")));
            this.picRecordsSelector.Location = new System.Drawing.Point(1197, 50);
            this.picRecordsSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picRecordsSelector.Name = "picRecordsSelector";
            this.picRecordsSelector.Size = new System.Drawing.Size(30, 28);
            this.picRecordsSelector.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRecordsSelector.TabIndex = 22;
            this.picRecordsSelector.TabStop = false;
            this.picRecordsSelector.Click += new System.EventHandler(this.picRecordsSelector_Click);
            // 
            // picDossierSelector
            // 
            this.picDossierSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDossierSelector.Image = ((System.Drawing.Image)(resources.GetObject("picDossierSelector.Image")));
            this.picDossierSelector.Location = new System.Drawing.Point(375, 46);
            this.picDossierSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picDossierSelector.Name = "picDossierSelector";
            this.picDossierSelector.Size = new System.Drawing.Size(30, 28);
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
            this.materialLabel2.Location = new System.Drawing.Point(848, 98);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(367, 26);
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
            this.materialLabel1.Location = new System.Drawing.Point(12, 96);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(231, 26);
            this.materialLabel1.TabIndex = 19;
            this.materialLabel1.Text = "Veldmapping Dossiers";
            // 
            // txtRecordBestandLocation
            // 
            this.txtRecordBestandLocation.Location = new System.Drawing.Point(856, 52);
            this.txtRecordBestandLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRecordBestandLocation.Name = "txtRecordBestandLocation";
            this.txtRecordBestandLocation.ReadOnly = true;
            this.txtRecordBestandLocation.Size = new System.Drawing.Size(332, 22);
            this.txtRecordBestandLocation.TabIndex = 20;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(851, 18);
            this.materialLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(456, 26);
            this.materialLabel6.TabIndex = 17;
            this.materialLabel6.Text = "Selecteer Records en Bestanden-Metadatafile";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(27, 16);
            this.materialLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(309, 26);
            this.materialLabel5.TabIndex = 16;
            this.materialLabel5.Text = "Selecteer Dossier-Metadatafile";
            // 
            // txtDossierLocation
            // 
            this.txtDossierLocation.Location = new System.Drawing.Point(32, 48);
            this.txtDossierLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDossierLocation.Name = "txtDossierLocation";
            this.txtDossierLocation.ReadOnly = true;
            this.txtDossierLocation.Size = new System.Drawing.Size(332, 22);
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
            this.tabImportFiles.Location = new System.Drawing.Point(4, 25);
            this.tabImportFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabImportFiles.Name = "tabImportFiles";
            this.tabImportFiles.Size = new System.Drawing.Size(1627, 815);
            this.tabImportFiles.TabIndex = 2;
            this.tabImportFiles.Text = "Import";
            this.tabImportFiles.UseVisualStyleBackColor = true;
            // 
            // linkCopyErrorsRecords
            // 
            this.linkCopyErrorsRecords.AutoSize = true;
            this.linkCopyErrorsRecords.Location = new System.Drawing.Point(1527, 82);
            this.linkCopyErrorsRecords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkCopyErrorsRecords.Name = "linkCopyErrorsRecords";
            this.linkCopyErrorsRecords.Size = new System.Drawing.Size(62, 16);
            this.linkCopyErrorsRecords.TabIndex = 12;
            this.linkCopyErrorsRecords.TabStop = true;
            this.linkCopyErrorsRecords.Text = "Kopiëren";
            this.linkCopyErrorsRecords.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCopyErrorsRecords_LinkClicked);
            // 
            // linkCopyErrorsDossiers
            // 
            this.linkCopyErrorsDossiers.AutoSize = true;
            this.linkCopyErrorsDossiers.Location = new System.Drawing.Point(711, 78);
            this.linkCopyErrorsDossiers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkCopyErrorsDossiers.Name = "linkCopyErrorsDossiers";
            this.linkCopyErrorsDossiers.Size = new System.Drawing.Size(62, 16);
            this.linkCopyErrorsDossiers.TabIndex = 11;
            this.linkCopyErrorsDossiers.TabStop = true;
            this.linkCopyErrorsDossiers.Text = "Kopiëren";
            this.linkCopyErrorsDossiers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCopyErrorsDossiers_LinkClicked);
            // 
            // btImportFilesInDb
            // 
            this.btImportFilesInDb.Location = new System.Drawing.Point(56, 23);
            this.btImportFilesInDb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btImportFilesInDb.Name = "btImportFilesInDb";
            this.btImportFilesInDb.Size = new System.Drawing.Size(151, 32);
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
            this.materialLabel4.Location = new System.Drawing.Point(873, 76);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(158, 26);
            this.materialLabel4.TabIndex = 9;
            this.materialLabel4.Text = "Errors Records";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(52, 74);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(162, 26);
            this.materialLabel3.TabIndex = 8;
            this.materialLabel3.Text = "Errors Dossiers";
            // 
            // txtErrorRecords
            // 
            this.txtErrorRecords.Location = new System.Drawing.Point(866, 106);
            this.txtErrorRecords.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtErrorRecords.Multiline = true;
            this.txtErrorRecords.Name = "txtErrorRecords";
            this.txtErrorRecords.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrorRecords.Size = new System.Drawing.Size(722, 681);
            this.txtErrorRecords.TabIndex = 7;
            this.txtErrorRecords.WordWrap = false;
            // 
            // txtErrorsDossiers
            // 
            this.txtErrorsDossiers.Location = new System.Drawing.Point(55, 103);
            this.txtErrorsDossiers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtErrorsDossiers.Multiline = true;
            this.txtErrorsDossiers.Name = "txtErrorsDossiers";
            this.txtErrorsDossiers.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrorsDossiers.Size = new System.Drawing.Size(722, 683);
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
            this.tabMetadata.Location = new System.Drawing.Point(4, 25);
            this.tabMetadata.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMetadata.Name = "tabMetadata";
            this.tabMetadata.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMetadata.Size = new System.Drawing.Size(1627, 815);
            this.tabMetadata.TabIndex = 5;
            this.tabMetadata.Text = "Genereer Metadata";
            this.tabMetadata.UseVisualStyleBackColor = true;
            // 
            // chkTestForPasswProtection
            // 
            this.chkTestForPasswProtection.AutoSize = true;
            this.chkTestForPasswProtection.Location = new System.Drawing.Point(100, 233);
            this.chkTestForPasswProtection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkTestForPasswProtection.Name = "chkTestForPasswProtection";
            this.chkTestForPasswProtection.Size = new System.Drawing.Size(395, 21);
            this.chkTestForPasswProtection.TabIndex = 41;
            this.chkTestForPasswProtection.Text = "Test pdf\'s en MSOffice-bestanden op wachtwoordbeveiliging";
            this.chkTestForPasswProtection.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 326);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(432, 16);
            this.label6.TabIndex = 40;
            this.label6.Text = "Zorg dat DROID goed functioneert, en de laatste signature files gebruikt.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 302);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(497, 16);
            this.label5.TabIndex = 39;
            this.label5.Text = "Voor bepalen van de file signature, moet DROID op de computer zijn geinstalleerd." +
    "";
            // 
            // txtProgressMetaData
            // 
            this.txtProgressMetaData.Location = new System.Drawing.Point(100, 550);
            this.txtProgressMetaData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProgressMetaData.Multiline = true;
            this.txtProgressMetaData.Name = "txtProgressMetaData";
            this.txtProgressMetaData.Size = new System.Drawing.Size(523, 168);
            this.txtProgressMetaData.TabIndex = 38;
            // 
            // picSelectDroidLocation
            // 
            this.picSelectDroidLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSelectDroidLocation.Image = ((System.Drawing.Image)(resources.GetObject("picSelectDroidLocation.Image")));
            this.picSelectDroidLocation.Location = new System.Drawing.Point(595, 350);
            this.picSelectDroidLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picSelectDroidLocation.Name = "picSelectDroidLocation";
            this.picSelectDroidLocation.Size = new System.Drawing.Size(29, 36);
            this.picSelectDroidLocation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSelectDroidLocation.TabIndex = 37;
            this.picSelectDroidLocation.TabStop = false;
            this.picSelectDroidLocation.Click += new System.EventHandler(this.picSelectDroidLocation_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 366);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 36;
            this.label4.Text = "droid.bat locatie";
            // 
            // txtDroidLocation
            // 
            this.txtDroidLocation.Location = new System.Drawing.Point(240, 362);
            this.txtDroidLocation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDroidLocation.Name = "txtDroidLocation";
            this.txtDroidLocation.Size = new System.Drawing.Size(347, 22);
            this.txtDroidLocation.TabIndex = 35;
            this.txtDroidLocation.Leave += new System.EventHandler(this.txtDroidLocation_Leave);
            // 
            // linkCopyMetadataErrors
            // 
            this.linkCopyMetadataErrors.AutoSize = true;
            this.linkCopyMetadataErrors.Location = new System.Drawing.Point(1529, 41);
            this.linkCopyMetadataErrors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkCopyMetadataErrors.Name = "linkCopyMetadataErrors";
            this.linkCopyMetadataErrors.Size = new System.Drawing.Size(62, 16);
            this.linkCopyMetadataErrors.TabIndex = 34;
            this.linkCopyMetadataErrors.TabStop = true;
            this.linkCopyMetadataErrors.Text = "Kopiëren";
            this.linkCopyMetadataErrors.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCopyMetadataErrors_LinkClicked);
            // 
            // btMetadataCancel
            // 
            this.btMetadataCancel.Location = new System.Drawing.Point(313, 434);
            this.btMetadataCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btMetadataCancel.Name = "btMetadataCancel";
            this.btMetadataCancel.Size = new System.Drawing.Size(123, 28);
            this.btMetadataCancel.TabIndex = 33;
            this.btMetadataCancel.Text = "Cancel scan";
            this.btMetadataCancel.UseVisualStyleBackColor = true;
            this.btMetadataCancel.Click += new System.EventHandler(this.btMetadataCancel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(100, 492);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(336, 28);
            this.progressBar1.TabIndex = 32;
            // 
            // btGenerateMetadata
            // 
            this.btGenerateMetadata.Location = new System.Drawing.Point(100, 434);
            this.btGenerateMetadata.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btGenerateMetadata.Name = "btGenerateMetadata";
            this.btGenerateMetadata.Size = new System.Drawing.Size(126, 28);
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
            this.materialLabel16.Location = new System.Drawing.Point(759, 34);
            this.materialLabel16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel16.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel16.Name = "materialLabel16";
            this.materialLabel16.Size = new System.Drawing.Size(71, 26);
            this.materialLabel16.TabIndex = 30;
            this.materialLabel16.Text = "Errors";
            // 
            // txtMetadataErrors
            // 
            this.txtMetadataErrors.Location = new System.Drawing.Point(752, 73);
            this.txtMetadataErrors.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMetadataErrors.Multiline = true;
            this.txtMetadataErrors.Name = "txtMetadataErrors";
            this.txtMetadataErrors.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMetadataErrors.Size = new System.Drawing.Size(841, 669);
            this.txtMetadataErrors.TabIndex = 29;
            this.txtMetadataErrors.WordWrap = false;
            // 
            // chkGetFileSignature
            // 
            this.chkGetFileSignature.AutoSize = true;
            this.chkGetFileSignature.Location = new System.Drawing.Point(100, 268);
            this.chkGetFileSignature.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkGetFileSignature.Name = "chkGetFileSignature";
            this.chkGetFileSignature.Size = new System.Drawing.Size(227, 21);
            this.chkGetFileSignature.TabIndex = 28;
            this.chkGetFileSignature.Text = "Bestandsformaat (File signature)";
            this.chkGetFileSignature.UseVisualStyleBackColor = true;
            // 
            // chkGetFileSize
            // 
            this.chkGetFileSize.AutoSize = true;
            this.chkGetFileSize.Location = new System.Drawing.Point(100, 201);
            this.chkGetFileSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkGetFileSize.Name = "chkGetFileSize";
            this.chkGetFileSize.Size = new System.Drawing.Size(192, 21);
            this.chkGetFileSize.TabIndex = 27;
            this.chkGetFileSize.Text = "Bestandsgrootte (FileSize)";
            this.chkGetFileSize.UseVisualStyleBackColor = true;
            // 
            // checkGetCreationDate
            // 
            this.checkGetCreationDate.AutoSize = true;
            this.checkGetCreationDate.Location = new System.Drawing.Point(100, 170);
            this.checkGetCreationDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkGetCreationDate.Name = "checkGetCreationDate";
            this.checkGetCreationDate.Size = new System.Drawing.Size(219, 21);
            this.checkGetCreationDate.TabIndex = 26;
            this.checkGetCreationDate.Text = "Aanmaakdatum (CreationDate)";
            this.checkGetCreationDate.UseVisualStyleBackColor = true;
            // 
            // chkGetHash
            // 
            this.chkGetHash.AutoSize = true;
            this.chkGetHash.Location = new System.Drawing.Point(100, 139);
            this.chkGetHash.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkGetHash.Name = "chkGetHash";
            this.chkGetHash.Size = new System.Drawing.Size(170, 21);
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
            this.materialLabel15.Location = new System.Drawing.Point(94, 30);
            this.materialLabel15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel15.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel15.Name = "materialLabel15";
            this.materialLabel15.Size = new System.Drawing.Size(350, 26);
            this.materialLabel15.TabIndex = 24;
            this.materialLabel15.Text = "Selecteer directory te scannen files";
            // 
            // picSelectDirToScan
            // 
            this.picSelectDirToScan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSelectDirToScan.Image = ((System.Drawing.Image)(resources.GetObject("picSelectDirToScan.Image")));
            this.picSelectDirToScan.Location = new System.Drawing.Point(595, 66);
            this.picSelectDirToScan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picSelectDirToScan.Name = "picSelectDirToScan";
            this.picSelectDirToScan.Size = new System.Drawing.Size(29, 36);
            this.picSelectDirToScan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSelectDirToScan.TabIndex = 23;
            this.picSelectDirToScan.TabStop = false;
            this.picSelectDirToScan.Click += new System.EventHandler(this.picSelectDirToScan_Click);
            // 
            // txtFilesDirToScan
            // 
            this.txtFilesDirToScan.Location = new System.Drawing.Point(100, 73);
            this.txtFilesDirToScan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFilesDirToScan.Name = "txtFilesDirToScan";
            this.txtFilesDirToScan.Size = new System.Drawing.Size(487, 22);
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
            this.tabGenerateTopX.Location = new System.Drawing.Point(4, 25);
            this.tabGenerateTopX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabGenerateTopX.Name = "tabGenerateTopX";
            this.tabGenerateTopX.Size = new System.Drawing.Size(1627, 815);
            this.tabGenerateTopX.TabIndex = 4;
            this.tabGenerateTopX.Text = "Genereer TopX";
            this.tabGenerateTopX.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(629, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Bron-directory";
            // 
            // txtBatchSourceDirectory
            // 
            this.txtBatchSourceDirectory.Enabled = false;
            this.txtBatchSourceDirectory.Location = new System.Drawing.Point(738, 59);
            this.txtBatchSourceDirectory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBatchSourceDirectory.Name = "txtBatchSourceDirectory";
            this.txtBatchSourceDirectory.Size = new System.Drawing.Size(415, 22);
            this.txtBatchSourceDirectory.TabIndex = 24;
            // 
            // picSelectBatchSourceDir
            // 
            this.picSelectBatchSourceDir.Enabled = false;
            this.picSelectBatchSourceDir.Image = ((System.Drawing.Image)(resources.GetObject("picSelectBatchSourceDir.Image")));
            this.picSelectBatchSourceDir.Location = new System.Drawing.Point(1160, 54);
            this.picSelectBatchSourceDir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picSelectBatchSourceDir.Name = "picSelectBatchSourceDir";
            this.picSelectBatchSourceDir.Size = new System.Drawing.Size(30, 36);
            this.picSelectBatchSourceDir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSelectBatchSourceDir.TabIndex = 23;
            this.picSelectBatchSourceDir.TabStop = false;
            this.picSelectBatchSourceDir.Click += new System.EventHandler(this.picSelectBatchSourceDir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(629, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Doel-directory";
            // 
            // txtBatchTargetDirectory
            // 
            this.txtBatchTargetDirectory.Enabled = false;
            this.txtBatchTargetDirectory.Location = new System.Drawing.Point(738, 91);
            this.txtBatchTargetDirectory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBatchTargetDirectory.Name = "txtBatchTargetDirectory";
            this.txtBatchTargetDirectory.Size = new System.Drawing.Size(415, 22);
            this.txtBatchTargetDirectory.TabIndex = 21;
            // 
            // picSelectBatchTargetDir
            // 
            this.picSelectBatchTargetDir.Enabled = false;
            this.picSelectBatchTargetDir.Image = ((System.Drawing.Image)(resources.GetObject("picSelectBatchTargetDir.Image")));
            this.picSelectBatchTargetDir.Location = new System.Drawing.Point(1160, 86);
            this.picSelectBatchTargetDir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picSelectBatchTargetDir.Name = "picSelectBatchTargetDir";
            this.picSelectBatchTargetDir.Size = new System.Drawing.Size(30, 36);
            this.picSelectBatchTargetDir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSelectBatchTargetDir.TabIndex = 20;
            this.picSelectBatchTargetDir.TabStop = false;
            this.picSelectBatchTargetDir.Click += new System.EventHandler(this.picSelectBatchTargetDir_Click);
            // 
            // chkCreateBatchesSubdir
            // 
            this.chkCreateBatchesSubdir.AutoSize = true;
            this.chkCreateBatchesSubdir.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCreateBatchesSubdir.Location = new System.Drawing.Point(352, 62);
            this.chkCreateBatchesSubdir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCreateBatchesSubdir.Name = "chkCreateBatchesSubdir";
            this.chkCreateBatchesSubdir.Size = new System.Drawing.Size(229, 21);
            this.chkCreateBatchesSubdir.TabIndex = 19;
            this.chkCreateBatchesSubdir.Text = "Kopieer alle files naar directories";
            this.chkCreateBatchesSubdir.UseVisualStyleBackColor = true;
            this.chkCreateBatchesSubdir.CheckedChanged += new System.EventHandler(this.chkCreateBatchesSubdir_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(610, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Batchgrootte (GB)";
            // 
            // txtBatchSize
            // 
            this.txtBatchSize.Location = new System.Drawing.Point(738, 18);
            this.txtBatchSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBatchSize.Name = "txtBatchSize";
            this.txtBatchSize.Size = new System.Drawing.Size(44, 22);
            this.txtBatchSize.TabIndex = 4;
            this.txtBatchSize.Text = "30";
            this.txtBatchSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBatchSize_KeyPress);
            this.txtBatchSize.Leave += new System.EventHandler(this.txtBatchSize_Leave);
            // 
            // chkUseBatchSize
            // 
            this.chkUseBatchSize.AutoSize = true;
            this.chkUseBatchSize.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUseBatchSize.Location = new System.Drawing.Point(462, 22);
            this.chkUseBatchSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkUseBatchSize.Name = "chkUseBatchSize";
            this.chkUseBatchSize.Size = new System.Drawing.Size(119, 21);
            this.chkUseBatchSize.TabIndex = 3;
            this.chkUseBatchSize.Text = "Maak batches";
            this.chkUseBatchSize.UseVisualStyleBackColor = true;
            // 
            // btSaveTopxXml
            // 
            this.btSaveTopxXml.Location = new System.Drawing.Point(245, 18);
            this.btSaveTopxXml.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSaveTopxXml.Name = "btSaveTopxXml";
            this.btSaveTopxXml.Size = new System.Drawing.Size(163, 28);
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
            this.materialLabel14.Location = new System.Drawing.Point(875, 196);
            this.materialLabel14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel14.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.Size = new System.Drawing.Size(361, 26);
            this.materialLabel14.TabIndex = 14;
            this.materialLabel14.Text = "TopX XML (eerste 10.000 karakters)";
            // 
            // txtResultXml
            // 
            this.txtResultXml.Location = new System.Drawing.Point(860, 224);
            this.txtResultXml.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtResultXml.Multiline = true;
            this.txtResultXml.Name = "txtResultXml";
            this.txtResultXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResultXml.Size = new System.Drawing.Size(722, 571);
            this.txtResultXml.TabIndex = 13;
            this.txtResultXml.WordWrap = false;
            // 
            // linkCopyTopXCreateError
            // 
            this.linkCopyTopXCreateError.AutoSize = true;
            this.linkCopyTopXCreateError.Location = new System.Drawing.Point(688, 201);
            this.linkCopyTopXCreateError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkCopyTopXCreateError.Name = "linkCopyTopXCreateError";
            this.linkCopyTopXCreateError.Size = new System.Drawing.Size(62, 16);
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
            this.materialLabel13.Location = new System.Drawing.Point(62, 197);
            this.materialLabel13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(48, 26);
            this.materialLabel13.TabIndex = 9;
            this.materialLabel13.Text = "Log";
            // 
            // btGenerateTopX
            // 
            this.btGenerateTopX.Location = new System.Drawing.Point(57, 18);
            this.btGenerateTopX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btGenerateTopX.Name = "btGenerateTopX";
            this.btGenerateTopX.Size = new System.Drawing.Size(163, 28);
            this.btGenerateTopX.TabIndex = 1;
            this.btGenerateTopX.Text = "Genereer TopX";
            this.btGenerateTopX.UseVisualStyleBackColor = true;
            this.btGenerateTopX.Click += new System.EventHandler(this.btGenerateTopX_Click);
            // 
            // txtLogTopXCreate
            // 
            this.txtLogTopXCreate.Location = new System.Drawing.Point(50, 224);
            this.txtLogTopXCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLogTopXCreate.Multiline = true;
            this.txtLogTopXCreate.Name = "txtLogTopXCreate";
            this.txtLogTopXCreate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogTopXCreate.Size = new System.Drawing.Size(722, 571);
            this.txtLogTopXCreate.TabIndex = 10;
            this.txtLogTopXCreate.WordWrap = false;
            // 
            // SidecarExport
            // 
            this.SidecarExport.Controls.Add(this.linkOpenSidecarExportInExplorer);
            this.SidecarExport.Controls.Add(this.materialLabel24);
            this.SidecarExport.Controls.Add(this.txtLogSidecarExport);
            this.SidecarExport.Controls.Add(this.btGenerateSidecarExport);
            this.SidecarExport.Controls.Add(this.materialLabel23);
            this.SidecarExport.Controls.Add(this.materialLabel22);
            this.SidecarExport.Controls.Add(this.label7);
            this.SidecarExport.Controls.Add(this.txtSourceDirOfSidecarFiles);
            this.SidecarExport.Controls.Add(this.picSelectSourceDirOfSidecarFiles);
            this.SidecarExport.Controls.Add(this.label8);
            this.SidecarExport.Controls.Add(this.txtTargetDirOfSidecarFiles);
            this.SidecarExport.Controls.Add(this.picSelectTargetDirOfSidecarFiles);
            this.SidecarExport.Controls.Add(this.label9);
            this.SidecarExport.Controls.Add(this.txtSidecarNrOfBatches);
            this.SidecarExport.Controls.Add(this.chkSidecarMakeBatches);
            this.SidecarExport.Location = new System.Drawing.Point(4, 25);
            this.SidecarExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SidecarExport.Name = "SidecarExport";
            this.SidecarExport.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SidecarExport.Size = new System.Drawing.Size(1627, 815);
            this.SidecarExport.TabIndex = 6;
            this.SidecarExport.Text = "Sidecar Export";
            this.SidecarExport.UseVisualStyleBackColor = true;
            // 
            // materialLabel24
            // 
            this.materialLabel24.AutoSize = true;
            this.materialLabel24.Depth = 0;
            this.materialLabel24.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel24.Location = new System.Drawing.Point(135, 286);
            this.materialLabel24.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel24.Name = "materialLabel24";
            this.materialLabel24.Size = new System.Drawing.Size(48, 26);
            this.materialLabel24.TabIndex = 39;
            this.materialLabel24.Text = "Log";
            // 
            // txtLogSidecarExport
            // 
            this.txtLogSidecarExport.Location = new System.Drawing.Point(118, 320);
            this.txtLogSidecarExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLogSidecarExport.Multiline = true;
            this.txtLogSidecarExport.Name = "txtLogSidecarExport";
            this.txtLogSidecarExport.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogSidecarExport.Size = new System.Drawing.Size(722, 457);
            this.txtLogSidecarExport.TabIndex = 38;
            this.txtLogSidecarExport.WordWrap = false;
            // 
            // btGenerateSidecarExport
            // 
            this.btGenerateSidecarExport.Location = new System.Drawing.Point(333, 240);
            this.btGenerateSidecarExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btGenerateSidecarExport.Name = "btGenerateSidecarExport";
            this.btGenerateSidecarExport.Size = new System.Drawing.Size(171, 32);
            this.btGenerateSidecarExport.TabIndex = 37;
            this.btGenerateSidecarExport.Text = "Genereer Sidecar-export";
            this.btGenerateSidecarExport.UseVisualStyleBackColor = true;
            this.btGenerateSidecarExport.Click += new System.EventHandler(this.btGenerateSidecarExport_Click);
            // 
            // materialLabel23
            // 
            this.materialLabel23.AutoSize = true;
            this.materialLabel23.Depth = 0;
            this.materialLabel23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel23.Location = new System.Drawing.Point(112, 58);
            this.materialLabel23.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel23.Name = "materialLabel23";
            this.materialLabel23.Size = new System.Drawing.Size(1373, 26);
            this.materialLabel23.TabIndex = 36;
            this.materialLabel23.Text = "De TopX Creator maakt de Sidecar-structuur aan, en kopiëert alle bestanden naar d" +
    "e juiste plaats in de boom. (Let op voldoende schijfruimte)";
            // 
            // materialLabel22
            // 
            this.materialLabel22.AutoSize = true;
            this.materialLabel22.Depth = 0;
            this.materialLabel22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel22.Location = new System.Drawing.Point(112, 27);
            this.materialLabel22.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel22.Name = "materialLabel22";
            this.materialLabel22.Size = new System.Drawing.Size(1121, 26);
            this.materialLabel22.TabIndex = 35;
            this.materialLabel22.Text = "Om een Sidecar-export te kunnen maken, moet er een valide TopX-xml gegenereerd zi" +
    "jn (zie tab \"Genereer TopX\")";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(138, 112);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 16);
            this.label7.TabIndex = 34;
            this.label7.Text = "Bron-directory bestanden";
            // 
            // txtSourceDirOfSidecarFiles
            // 
            this.txtSourceDirOfSidecarFiles.Enabled = false;
            this.txtSourceDirOfSidecarFiles.Location = new System.Drawing.Point(338, 109);
            this.txtSourceDirOfSidecarFiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSourceDirOfSidecarFiles.Name = "txtSourceDirOfSidecarFiles";
            this.txtSourceDirOfSidecarFiles.Size = new System.Drawing.Size(415, 22);
            this.txtSourceDirOfSidecarFiles.TabIndex = 33;
            // 
            // picSelectSourceDirOfSidecarFiles
            // 
            this.picSelectSourceDirOfSidecarFiles.Image = ((System.Drawing.Image)(resources.GetObject("picSelectSourceDirOfSidecarFiles.Image")));
            this.picSelectSourceDirOfSidecarFiles.Location = new System.Drawing.Point(760, 104);
            this.picSelectSourceDirOfSidecarFiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picSelectSourceDirOfSidecarFiles.Name = "picSelectSourceDirOfSidecarFiles";
            this.picSelectSourceDirOfSidecarFiles.Size = new System.Drawing.Size(30, 36);
            this.picSelectSourceDirOfSidecarFiles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSelectSourceDirOfSidecarFiles.TabIndex = 32;
            this.picSelectSourceDirOfSidecarFiles.TabStop = false;
            this.picSelectSourceDirOfSidecarFiles.Click += new System.EventHandler(this.picSelectSourceDirOfSidecarFiles_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 144);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 16);
            this.label8.TabIndex = 31;
            this.label8.Text = "Doel-directory Sidecar-export";
            // 
            // txtTargetDirOfSidecarFiles
            // 
            this.txtTargetDirOfSidecarFiles.Enabled = false;
            this.txtTargetDirOfSidecarFiles.Location = new System.Drawing.Point(338, 141);
            this.txtTargetDirOfSidecarFiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTargetDirOfSidecarFiles.Name = "txtTargetDirOfSidecarFiles";
            this.txtTargetDirOfSidecarFiles.Size = new System.Drawing.Size(415, 22);
            this.txtTargetDirOfSidecarFiles.TabIndex = 30;
            // 
            // picSelectTargetDirOfSidecarFiles
            // 
            this.picSelectTargetDirOfSidecarFiles.Image = ((System.Drawing.Image)(resources.GetObject("picSelectTargetDirOfSidecarFiles.Image")));
            this.picSelectTargetDirOfSidecarFiles.Location = new System.Drawing.Point(760, 136);
            this.picSelectTargetDirOfSidecarFiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picSelectTargetDirOfSidecarFiles.Name = "picSelectTargetDirOfSidecarFiles";
            this.picSelectTargetDirOfSidecarFiles.Size = new System.Drawing.Size(30, 36);
            this.picSelectTargetDirOfSidecarFiles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSelectTargetDirOfSidecarFiles.TabIndex = 29;
            this.picSelectTargetDirOfSidecarFiles.TabStop = false;
            this.picSelectTargetDirOfSidecarFiles.Click += new System.EventHandler(this.picSelectTargetDirOfSidecarFiles_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(373, 186);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 16);
            this.label9.TabIndex = 28;
            this.label9.Text = "Aantal dossiers";
            // 
            // txtSidecarNrOfBatches
            // 
            this.txtSidecarNrOfBatches.Enabled = false;
            this.txtSidecarNrOfBatches.Location = new System.Drawing.Point(481, 184);
            this.txtSidecarNrOfBatches.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSidecarNrOfBatches.Name = "txtSidecarNrOfBatches";
            this.txtSidecarNrOfBatches.Size = new System.Drawing.Size(44, 22);
            this.txtSidecarNrOfBatches.TabIndex = 27;
            this.txtSidecarNrOfBatches.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSidecarNrOfBatches_KeyPress);
            // 
            // chkSidecarMakeBatches
            // 
            this.chkSidecarMakeBatches.AutoSize = true;
            this.chkSidecarMakeBatches.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSidecarMakeBatches.Location = new System.Drawing.Point(236, 184);
            this.chkSidecarMakeBatches.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSidecarMakeBatches.Name = "chkSidecarMakeBatches";
            this.chkSidecarMakeBatches.Size = new System.Drawing.Size(119, 21);
            this.chkSidecarMakeBatches.TabIndex = 26;
            this.chkSidecarMakeBatches.Text = "Maak batches";
            this.chkSidecarMakeBatches.UseVisualStyleBackColor = true;
            this.chkSidecarMakeBatches.CheckedChanged += new System.EventHandler(this.chkSidecarMakeBatches_CheckedChanged);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblVersion.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblVersion.Location = new System.Drawing.Point(1593, 42);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(79, 22);
            this.lblVersion.TabIndex = 71;
            this.lblVersion.Text = "v 1.0.0.0";
            // 
            // linkOpenSidecarExportInExplorer
            // 
            this.linkOpenSidecarExportInExplorer.AutoSize = true;
            this.linkOpenSidecarExportInExplorer.Location = new System.Drawing.Point(901, 320);
            this.linkOpenSidecarExportInExplorer.Name = "linkOpenSidecarExportInExplorer";
            this.linkOpenSidecarExportInExplorer.Size = new System.Drawing.Size(206, 16);
            this.linkOpenSidecarExportInExplorer.TabIndex = 40;
            this.linkOpenSidecarExportInExplorer.TabStop = true;
            this.linkOpenSidecarExportInExplorer.Text = "open Sidecar-export in verkenner";
            this.linkOpenSidecarExportInExplorer.Visible = false;
            this.linkOpenSidecarExportInExplorer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenSidecarExportInExplorer_LinkClicked);
            // 
            // txtIdentificatieArchief
            // 
            this.txtIdentificatieArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtIdentificatieArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtIdentificatieArchief.Location = new System.Drawing.Point(341, 326);
            this.txtIdentificatieArchief.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIdentificatieArchief.Name = "txtIdentificatieArchief";
            this.txtIdentificatieArchief.PlaceHolderText = "Bijv: NL-0784-10009";
            this.txtIdentificatieArchief.Size = new System.Drawing.Size(257, 26);
            this.txtIdentificatieArchief.TabIndex = 20;
            this.txtIdentificatieArchief.Text = "Bijv: NL-0784-10009";
            this.txtIdentificatieArchief.Leave += new System.EventHandler(this.SaveGlobals);
            // 
            // txtNaamArchief
            // 
            this.txtNaamArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtNaamArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtNaamArchief.Location = new System.Drawing.Point(341, 290);
            this.txtNaamArchief.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNaamArchief.Name = "txtNaamArchief";
            this.txtNaamArchief.PlaceHolderText = "Bijv: Bouwvergunningen Gemeente Raamsdonk 1993 - 1996";
            this.txtNaamArchief.Size = new System.Drawing.Size(639, 26);
            this.txtNaamArchief.TabIndex = 10;
            this.txtNaamArchief.Text = "Bijv: Bouwvergunningen Gemeente Raamsdonk 1993 - 1996";
            this.txtNaamArchief.Leave += new System.EventHandler(this.SaveGlobals);
            // 
            // txtDoelArchief
            // 
            this.txtDoelArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtDoelArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtDoelArchief.Location = new System.Drawing.Point(341, 480);
            this.txtDoelArchief.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDoelArchief.Name = "txtDoelArchief";
            this.txtDoelArchief.PlaceHolderText = "Bijv: Bouwvergunningen om op te nemen in e-Depot";
            this.txtDoelArchief.Size = new System.Drawing.Size(639, 26);
            this.txtDoelArchief.TabIndex = 70;
            this.txtDoelArchief.Text = "Bijv: Bouwvergunningen om op te nemen in e-Depot";
            this.txtDoelArchief.Leave += new System.EventHandler(this.SaveGlobals);
            // 
            // txtBronArchief
            // 
            this.txtBronArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtBronArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtBronArchief.Location = new System.Drawing.Point(341, 443);
            this.txtBronArchief.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBronArchief.Name = "txtBronArchief";
            this.txtBronArchief.PlaceHolderText = "Bijv: Digitale bouwvergunningen";
            this.txtBronArchief.Size = new System.Drawing.Size(639, 26);
            this.txtBronArchief.TabIndex = 60;
            this.txtBronArchief.Text = "Bijv: Digitale bouwvergunningen";
            this.txtBronArchief.Leave += new System.EventHandler(this.SaveGlobals);
            // 
            // txtOmschrijvingArchief
            // 
            this.txtOmschrijvingArchief.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.txtOmschrijvingArchief.ForeColor = System.Drawing.Color.Gray;
            this.txtOmschrijvingArchief.Location = new System.Drawing.Point(341, 406);
            this.txtOmschrijvingArchief.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOmschrijvingArchief.Name = "txtOmschrijvingArchief";
            this.txtOmschrijvingArchief.PlaceHolderText = "Bijv: Bouwvergunningen Gemeente Raamsdonk 1993 - 1996";
            this.txtOmschrijvingArchief.Size = new System.Drawing.Size(639, 26);
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
            this.gridFieldMappingRecords.Location = new System.Drawing.Point(853, 123);
            this.gridFieldMappingRecords.Margin = new System.Windows.Forms.Padding(4);
            this.gridFieldMappingRecords.Name = "gridFieldMappingRecords";
            this.gridFieldMappingRecords.RowHeadersVisible = false;
            this.gridFieldMappingRecords.RowHeadersWidth = 62;
            this.gridFieldMappingRecords.ShowCellErrors = false;
            this.gridFieldMappingRecords.ShowCellToolTips = false;
            this.gridFieldMappingRecords.ShowEditingIcon = false;
            this.gridFieldMappingRecords.ShowRowErrors = false;
            this.gridFieldMappingRecords.Size = new System.Drawing.Size(759, 679);
            this.gridFieldMappingRecords.TabIndex = 40;
            this.gridFieldMappingRecords.DataSourceChanged += new System.EventHandler(this.gridFieldMappingRecords_DataSourceChanged);
            this.gridFieldMappingRecords.Leave += new System.EventHandler(this.gridFieldMappingRecords_Leave);
            this.gridFieldMappingRecords.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridFieldMappingRecords_MouseClick);
            // 
            // DatabaseFieldNameRecords
            // 
            this.DatabaseFieldNameRecords.DataPropertyName = "MappedFieldName";
            this.DatabaseFieldNameRecords.HeaderText = "Veldnaam Bron";
            this.DatabaseFieldNameRecords.MinimumWidth = 8;
            this.DatabaseFieldNameRecords.Name = "DatabaseFieldNameRecords";
            this.DatabaseFieldNameRecords.Width = 250;
            // 
            // MappedFieldNameRecords
            // 
            this.MappedFieldNameRecords.DataPropertyName = "DatabaseFieldName";
            this.MappedFieldNameRecords.HeaderText = "Veldnaam TopX";
            this.MappedFieldNameRecords.MinimumWidth = 8;
            this.MappedFieldNameRecords.Name = "MappedFieldNameRecords";
            this.MappedFieldNameRecords.Width = 265;
            // 
            // TMLO_Records
            // 
            this.TMLO_Records.DataPropertyName = "TMLO";
            this.TMLO_Records.HeaderText = "TMLO";
            this.TMLO_Records.MinimumWidth = 8;
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
            this.gridFieldMappingDossiers.Location = new System.Drawing.Point(7, 123);
            this.gridFieldMappingDossiers.Margin = new System.Windows.Forms.Padding(4);
            this.gridFieldMappingDossiers.Name = "gridFieldMappingDossiers";
            this.gridFieldMappingDossiers.RowHeadersVisible = false;
            this.gridFieldMappingDossiers.RowHeadersWidth = 62;
            this.gridFieldMappingDossiers.ShowCellErrors = false;
            this.gridFieldMappingDossiers.ShowCellToolTips = false;
            this.gridFieldMappingDossiers.ShowEditingIcon = false;
            this.gridFieldMappingDossiers.ShowRowErrors = false;
            this.gridFieldMappingDossiers.Size = new System.Drawing.Size(830, 679);
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
            this.MappedFieldName.MinimumWidth = 8;
            this.MappedFieldName.Name = "MappedFieldName";
            this.MappedFieldName.Width = 250;
            // 
            // DatabaseFieldName
            // 
            this.DatabaseFieldName.DataPropertyName = "DatabaseFieldName";
            this.DatabaseFieldName.HeaderText = "Veldnaam TopX";
            this.DatabaseFieldName.MinimumWidth = 8;
            this.DatabaseFieldName.Name = "DatabaseFieldName";
            this.DatabaseFieldName.Width = 250;
            // 
            // TMLO
            // 
            this.TMLO.DataPropertyName = "TMLO";
            this.TMLO.HeaderText = "TMLO";
            this.TMLO.MinimumWidth = 8;
            this.TMLO.Name = "TMLO";
            this.TMLO.ReadOnly = true;
            this.TMLO.Width = 60;
            // 
            // Optional
            // 
            this.Optional.DataPropertyName = "Optional";
            this.Optional.HeaderText = "Opt.";
            this.Optional.MinimumWidth = 8;
            this.Optional.Name = "Optional";
            this.Optional.ReadOnly = true;
            this.Optional.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Optional.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Optional.ToolTipText = "Optioneel";
            this.Optional.Width = 35;
            // 
            // TopXConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1696, 971);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.materialTab);
            this.Controls.Add(this.materialTabSelector1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TopXConverter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TopX Creator";
            this.Load += new System.EventHandler(this.TopXConverter_Load);
            this.materialContextMenuStrip2.ResumeLayout(false);
            this.materialContextMenuStrip3.ResumeLayout(false);
            this.materialTab.ResumeLayout(false);
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
            this.SidecarExport.ResumeLayout(false);
            this.SidecarExport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectSourceDirOfSidecarFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSelectTargetDirOfSidecarFiles)).EndInit();
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
        private MaterialSkin.Controls.MaterialTabControl materialTab;
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
        private TabPage SidecarExport;
        private Label label7;
        private TextBox txtSourceDirOfSidecarFiles;
        private PictureBox picSelectSourceDirOfSidecarFiles;
        private Label label8;
        private TextBox txtTargetDirOfSidecarFiles;
        private PictureBox picSelectTargetDirOfSidecarFiles;
        private Label label9;
        private TextBox txtSidecarNrOfBatches;
        private CheckBox chkSidecarMakeBatches;
        private MaterialSkin.Controls.MaterialLabel materialLabel22;
        private MaterialSkin.Controls.MaterialLabel materialLabel24;
        private TextBox txtLogSidecarExport;
        private Button btGenerateSidecarExport;
        private MaterialSkin.Controls.MaterialLabel materialLabel23;
        private LinkLabel linkOpenSidecarExportInExplorer;
    }
}

