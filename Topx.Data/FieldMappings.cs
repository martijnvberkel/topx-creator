namespace Topx.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FieldMapping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(250)]
        public string DatabaseFieldName { get; set; }

        [StringLength(250)]
        public string MappedFieldName { get; set; }

        [StringLength(50)]
        public string Type { get; set; }
    }
}
