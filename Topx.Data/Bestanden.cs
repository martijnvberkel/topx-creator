namespace Topx.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bestanden")]
    public partial class Bestand
    {
        public long Id { get; set; }

        [StringLength(50)]
        public string Dossier_IdentificatieKenmerk { get; set; }

        public string Naam { get; set; }

        [StringLength(50)]
        public string Relatie_RelatieId { get; set; }

        [StringLength(50)]
        public string Relatie_TypeRelatie { get; set; }

        [StringLength(50)]
        public string Relatie_DatumOfPperiode { get; set; }

        [StringLength(50)]
        public string Vorm_RedactieGenre { get; set; }

        [StringLength(50)]
        public string Formaat_IdentificatieKenmerk { get; set; }

        [StringLength(50)]
        public string Formaat_Bestandsnaam_Naam { get; set; }

        [StringLength(10)]
        public string Formaat_Bestandsnaam_Extentie { get; set; }

        public long? Formaat_Omvang { get; set; }

        [StringLength(50)]
        public string Formaat_Bestandsformaat { get; set; }

        [StringLength(50)]
        public string Formaat_FysiekeIntegriteit_Algoritme { get; set; }

        [StringLength(250)]
        public string Formaat_FysiekeIntegriteit_Waarde { get; set; }

        public DateTime? Formaat_FysiekeIntegriteit_DatumEnTijd { get; set; }

        [StringLength(50)]
        public string Formaat_DatumAanmaak { get; set; }

        public virtual Dossier Dossiers { get; set; }
    }
}
