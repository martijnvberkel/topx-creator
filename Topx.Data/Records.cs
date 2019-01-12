namespace Topx.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Record
    {
        public long Id { get; set; }

        public string Naam { get; set; }

      
        public string Gebruiksrechten_OmschrijvingVoorwaarden { get; set; }

        [StringLength(50)]
        public string Gebruiksrechten_DatumOfPeriode { get; set; }

        [StringLength(50)]
        public string Vertrouwelijkheid_ClassificatieNiveau { get; set; }

        [StringLength(50)]
        public string Vertrouwelijkheid_DatumOfPeriode { get; set; }

        public string Openbaarheid_OmschrijvingBeperkingen { get; set; }

        [StringLength(50)]
        public string Bestand_Vorm_Redactiegenre { get; set; }

        [StringLength(50)]
        public string Bestand_Formaat_Bestandsnaam { get; set; }

        public long? Bestand_Formaat_BestandsOmvang { get; set; }

        [StringLength(20)]
        public string Bestand_Formaat_BestandsFormaat { get; set; }

        [StringLength(10)]
        public string Bestand_Formaat_FysiekeIntegriteit_Algoritme { get; set; }

        [StringLength(250)]
        public string Bestand_Formaat_FysiekeIntegriteit_Waarde { get; set; }

        public DateTime? Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd { get; set; }
       
        public DateTime? Bestand_Formaat_DatumAanmaak { get; set; }

        [StringLength(50)]
        public string DossierId { get; set; }

        [StringLength(50)]
        public string Relatie_RelatieId { get; set; }

        [StringLength(50)]
        public string Relatie_TypeRelatie { get; set; }

        [StringLength(50)]
        public string Relatie_DatumOfPperiode { get; set; }

        [StringLength(50)]
        public string Bestand_Formaat_IdentificatieKenmerk { get; set; }

        public virtual Dossier Dossiers { get; set; }
    }
}
