namespace Topx.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        public Guid Id { get; set; }

        public DateTime? DateTime { get; set; }

        [StringLength(50)]
        public string Identifier { get; set; }

        public string Description { get; set; }
    }
}
