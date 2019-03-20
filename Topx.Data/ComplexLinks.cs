using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topx.Data
{
    [Table("ComplexLinks")]
    public class ComplexLink
    {
        [StringLength(20)]
        public string ComplexLinkNummer { get; set; }

        [StringLength(50)]
        public string Dossier_IdentificatieKenmerk { get; set; }

        public virtual Dossier Dossiers { get; set; }
    }
}
