namespace Topx.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dossier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dossier()
        {
            Bestanden = new HashSet<Bestand>();
            Records = new HashSet<Record>();
        }

        [Key]
        [StringLength(50)]
        public string IdentificatieKenmerk { get; set; }

        public string Naam { get; set; }

        [StringLength(50)]
        public string Classificatie_Code { get; set; }

        [StringLength(50)]
        public string Classificatie_Omschrijving { get; set; }

        [StringLength(250)]
        public string Classificatie_Bron { get; set; }

        [StringLength(50)]
        public string Classificatie_DatumOfPeriode { get; set; }

        [StringLength(50)]
        public string Dekking_InTijd_Begin { get; set; }

        [StringLength(50)]
        public string Dekking_InTijd_Eind { get; set; }

        public string Dekking_GeografischGebied { get; set; }

        [StringLength(10)]
        public string Taal { get; set; }

        [StringLength(50)]
        public string Eventgeschiedenis_DatumOfPeriode { get; set; }

        [StringLength(50)]
        public string Eventgeschiedenis_Type { get; set; }

        [StringLength(50)]
        public string Eventgeschiedenis_VerantwoordelijkeFunctionaris { get; set; }

        [StringLength(50)]
        public string Eventplan_DatumOfPeriode { get; set; }

        [StringLength(50)]
        public string Eventplan_DatumOfPeriode_Type { get; set; }

        [StringLength(50)]
        public string Eventplan_Aanleiding { get; set; }

        public string Eventplan_Beschrijving { get; set; }

        [StringLength(50)]
        public string Relatie_Id { get; set; }

        [StringLength(50)]
        public string Relatie_Type { get; set; }

        [StringLength(50)]
        public string Relatie_DatumOfPeriode { get; set; }

        [StringLength(50)]
        public string Context_Actor_IdentificatieKenmerk { get; set; }

        [StringLength(50)]
        public string Context_Actor_AggregatieNiveau { get; set; }

        [StringLength(50)]
        public string Context_Actor_GeautoriseerdeNaam { get; set; }

        [StringLength(50)]
        public string Context_Activiteit_Naam { get; set; }

        public string Gebruiksrechten_OmschrijvingVoorwaarden { get; set; }

        [StringLength(50)]
        public string Gebruiksrechten_DatumOfPeriode { get; set; }

        [StringLength(50)]
        public string Vertrouwelijkheid_ClassificatieNiveau { get; set; }

        [StringLength(50)]
        public string Vertrouwelijkheid_DatumOfPeriode { get; set; }

        [StringLength(50)]
        public string Openbaarheid_OmschrijvingBeperkingen { get; set; }

        [StringLength(50)]
        public string Openbaarheid_DatumOfPeriode { get; set; }

        [StringLength(50)]
        public string Integriteit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bestand> Bestanden { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Record> Records { get; set; }
    }
}
