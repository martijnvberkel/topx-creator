using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topx.Data
{
    
    public partial class Globals
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Globals()
        {
        }
        [Key]
        public string IdentificatieArchief { get; set; }
        public DateTime DatumArchief { get; set; }
        public string OmschrijvingArchief { get; set; }
        public string BronArchief { get; set; }
        public string DoelArchief { get; set; }
        public string NaamArchief { get; set; }
    }
}
