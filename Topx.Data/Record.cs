//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Topx.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Record
    {
        public long Id { get; set; }
        public string Naam { get; set; }
        public string Taal { get; set; }
        public string Gebruiksrechten_OmschrijvingVoorwaarden { get; set; }
        public string Gebruiksrechten_DatumOfPeriode { get; set; }
        public string Vertrouwelijkheid_ClassificatieNiveau { get; set; }
        public string Vertrouwelijkheid_DatumOfPeriode { get; set; }
        public string Openbaarheid_OmschrijvingBeperkingen { get; set; }
        public string Bestand_Vorm_Redactiegenre { get; set; }
        public string Bestand_Formaat_Bestandsnaam { get; set; }
        public Nullable<long> Bestand_Formaat_BestandsOmvang { get; set; }
        public string Bestand_Formaat_BestandsFormaat { get; set; }
        public string Bestand_Formaat_FysiekeIntegriteit_Algoritme { get; set; }
        public string Bestand_Formaat_FysiekeIntegriteit_Waarde { get; set; }
        public string DossierId { get; set; }
        public string Bestand_Formaat_FysiekeIntegriteit_DatumEnTijd { get; set; }
        public string Bestand_Formaat_DatumAanmaak { get; set; }
    
        public virtual Dossier Dossiers { get; set; }
    }
}
