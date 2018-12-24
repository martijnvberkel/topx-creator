using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using TOPX;
using TOPX.Classes;

namespace Topx.Converter
{
    public partial class Topx : Form
    {
        private Parser topx;

        public Topx()
        {
            InitializeComponent();
        }


        private void btConvert_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Log wissen?", "Log", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (var entities = new TOPXEntities())
                {
                    entities.Database.ExecuteSqlCommand("delete from log");
                }
            }

            Cursor.Current = Cursors.WaitCursor;
            topx = new TOPX.Parser();
            var data = txtNrOfRecords.Text != string.Empty ? topx.ParseCSV(Convert.ToInt32(txtNrOfRecords.Text))
                : topx.ParseCSV();

            txtLog.Text = Logger.GetLog();
            Cursor.Current = Cursors.Default;

            if (MessageBox.Show("Save xml?", "xml", MessageBoxButtons.YesNo) == DialogResult.Yes)
                SaveAsXml(data);

        }

        private void SaveAsXml(recordInformationPackage result)
        {
            var savefile = new SaveFileDialog();

            savefile.FileName = "export.xml";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                var encoding = Encoding.UTF8;//.GetEncoding("ISO-8859-1");
                using (var writer = new StreamWriter(savefile.FileName, false, encoding))
                {
                    var serializer = new XmlSerializer(typeof(recordInformationPackage));
                    serializer.Serialize(writer, result);
                    writer.Flush();
                }

            }

        }

        private void btImport_Click(object sender, EventArgs e)
        {
            var file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    CsvImporter.Import(file.FileName);
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception exception)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(exception.Message);
                }
              
            }
        }

        private void btImportFileSize_Click(object sender, EventArgs e)
        {
            var file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                CsvImporter.ImportFileSize(file.FileName);
            }
        }

        private void btChecksum_Click(object sender, EventArgs e)
        {
            var file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                CsvImporter.ImportChecksum(file.FileName);
            }
        }

        private void txtNrOfRecords_TextChanged(object sender, EventArgs e)
        {

        }

        private void btDelivered_Click(object sender, EventArgs e)
        {
            using (var entities = new TOPXEntities())
            {

                if (MessageBox.Show("Delete MarkedAsDelivered?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    entities.Database.ExecuteSqlCommand("DELETE FROM MarkedAsDelivered");
                }

                foreach (var zaaknummer in topx.ZaaknummerMarkForDelivered.Distinct())
                {
                    var markedAsDelivered = new MarkedAsDelivered() {Zaaknr = zaaknummer, DatumProcessed = DateTime.Now};
                    entities.MarkedAsDelivered.Add(markedAsDelivered);

                }
                entities.SaveChanges();
            }
        }

        private void btImportTemp_Click(object sender, EventArgs e)
        {
            var file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                CsvImporter.Import(file.FileName, true);
            }
        }

        private void btMoveTmpToSource_Click(object sender, EventArgs e)
        {
            using (var entities = new TOPXEntities())
            {
                var tempRecords = from t in entities.Source_temp select t;
                foreach (var tempRecord in tempRecords)
                {
                    var sourceRecord =
                        (from s in entities.Source where s.C2_dn_Bestand == tempRecord.C2_dn_Bestand select s)
                            .FirstOrDefault();
                    if (sourceRecord != null)
                    {
                        CopyRecord(sourceRecord, tempRecord);
                       
                    }

                }
                entities.SaveChanges();

            }
        }

        private void CopyRecord(Source sourceRecord, Source_temp tempRecord)
        {
           
            sourceRecord.C2_dn_Bestand = tempRecord.C2_dn_Bestand;
            sourceRecord.Bouwvergnr2 = tempRecord.Bouwvergnr2;
            sourceRecord.Straat = tempRecord.Straat;
            sourceRecord.Postcode = tempRecord.Postcode;
            sourceRecord.AdresFull = tempRecord.AdresFull;
            sourceRecord.Adres = tempRecord.Adres;
            sourceRecord.Huisnr = tempRecord.Huisnr;
            sourceRecord.Voorvoegsl = tempRecord.Voorvoegsl;
            sourceRecord.StraatHuisnr = tempRecord.StraatHuisnr;
            sourceRecord.Postcode2 = tempRecord.Postcode2;
            sourceRecord.Bvnr = tempRecord.Bvnr;
            sourceRecord.Jaar = tempRecord.Jaar;
            sourceRecord.C2zn__Zaaknummer = tempRecord.C2zn__Zaaknummer;
            sourceRecord.C19_1_DN_Tabnaam = tempRecord.C19_1_DN_Tabnaam;
            sourceRecord.C4_dn_Omschrijving = tempRecord.C4_dn_Omschrijving;
            sourceRecord.C91_zn_Datum_vergunning = tempRecord.C91_zn_Datum_vergunning;
            sourceRecord.C4_zn_Omschrijving = tempRecord.C4_zn_Omschrijving;
            sourceRecord.OmschrijvingCompleet = tempRecord.OmschrijvingCompleet;
            sourceRecord.Plaatsnaam = tempRecord.Plaatsnaam;
            sourceRecord.C15c_Gemeente = tempRecord.C15c_Gemeente;
            sourceRecord.C51zn_classificatiecode = tempRecord.C51zn_classificatiecode;
            sourceRecord.C52zn_Omschrijving_classificatiecode_ = tempRecord.C52zn_Omschrijving_classificatiecode_;
            sourceRecord.C53_zn_Bron_ = tempRecord.C53_zn_Bron_;
            sourceRecord.Omschrijving_ = tempRecord.Omschrijving_;
            sourceRecord.Gemeentecode = tempRecord.Gemeentecode;
            sourceRecord.C54_zn_Bron_classificatiecode = tempRecord.C54_zn_Bron_classificatiecode;
            sourceRecord.KvK_nummer = tempRecord.KvK_nummer;
            sourceRecord.Omvang_in_MB = tempRecord.Omvang_in_MB;
            sourceRecord.Bestandsformaat = tempRecord.Bestandsformaat;
            sourceRecord.Language = tempRecord.Language;
            sourceRecord.Datum_vergunning = tempRecord.Datum_vergunning;
            sourceRecord.C_Bouw_en_woningtoezicht = tempRecord.C_Bouw_en_woningtoezicht;
            sourceRecord.zn_bn_Hierarchisch = tempRecord.zn_bn_Hierarchisch;
            sourceRecord.Gemeente = tempRecord.Gemeente;
            sourceRecord.Organisatie = tempRecord.Organisatie;
            sourceRecord.Verlenen_bouwvergunningen = tempRecord.Verlenen_bouwvergunningen;
            sourceRecord.Vrij_te_gebruiken = tempRecord.Vrij_te_gebruiken;
            sourceRecord.Openbaar = tempRecord.Openbaar;
            sourceRecord.C_Integer = tempRecord.C_Integer;
            sourceRecord.Enkelvoudig = tempRecord.Enkelvoudig;
            sourceRecord.Aanmaakdatum_bestand = tempRecord.Aanmaakdatum_bestand;
            sourceRecord.C_Aggregatieniveau = tempRecord.C_Aggregatieniveau;
            sourceRecord.C_Relatie_ID = tempRecord.C_Relatie_ID;
            sourceRecord.Checksum = tempRecord.Checksum;
            sourceRecord.Datum = tempRecord.Datum;
            sourceRecord.C_BN_Algoritme = tempRecord.C_BN_Algoritme;
            sourceRecord.ZN_DN_Classificatie = tempRecord.ZN_DN_Classificatie;
            
        }

        private void btTroep_Click(object sender, EventArgs e)
        {
            var errors = new List<string>();
            using (var entities = new TOPXEntities())
            {
                var file = new OpenFileDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {
                    var xml = XDocument.Load(file.FileName);
                    //foreach (var record in entities.Source)

                    var results = xml.Descendants("item");
                    foreach (var r in results)
                    {
                        var sha = r.Element("sha-256").Value;
                        var filename = r.Element("filename").Value;

                        var checksdumrecord = (from a in entities.checksum where a.Filename == filename select a).FirstOrDefault();
                        if (checksdumrecord == null)
                        {
                            errors.Add($"file {filename} not found in checksums");
                        }
                        checksdumrecord.Checksum1 = sha;
                    }

                    entities.SaveChanges();

                    //IEnumerable<XElement> resultx =
                    //    xml.Descendants().Where(a => a.Name.LocalName == "identificatiekenmerk");
                    //foreach (var xElement in result)
                    //{
                    //    var value = xElement.Value;
                    //    if (value.StartsWith("GDB"))
                    //    {
                    //       zaaknrs.Add(value.Substring(0, value.Length-3));
                    //    }
                    //}

                    //foreach (var zaaknr in zaaknrs.Distinct())
                    //{
                    //    var markedAsDelivered = new MarkedAsDelivered()
                    //    {
                    //        DatumProcessed = DateTime.Now,
                    //        Zaaknr = zaaknr
                    //    };
                    //    entities.MarkedAsDelivered.Add(markedAsDelivered);

                    //}
                    //entities.SaveChanges();
                }
            }
        }

        private void btUpdateSource_Click(object sender, EventArgs e)
        {
            var file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                var header = MessageBox.Show("Header aanwezig?", "", MessageBoxButtons.YesNo);
                CsvImporter.UpdateSource(file.FileName, header == DialogResult.Yes);
            }
        }

        private void btDeleteSource_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Source wissen?", "Source", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (var entities = new TOPXEntities())
                {
                    entities.Database.ExecuteSqlCommand("delete from source");
                }
            }

            result = MessageBox.Show("MarkedAsDelivered wissen?", "Source", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (var entities = new TOPXEntities())
                {
                    entities.Database.ExecuteSqlCommand("delete from MarkedAsDelivered");
                }
            }

            MessageBox.Show("deleted", "", MessageBoxButtons.OK);
        }
    }
}
