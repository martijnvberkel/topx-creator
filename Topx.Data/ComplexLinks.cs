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
        [Key]
        public long Id { get; set; }
        public virtual Dossier Dossiers { get; set; }

        [StringLength(20)]
        public string ComplexLinkNummer { get; set; }
      
    }
}
