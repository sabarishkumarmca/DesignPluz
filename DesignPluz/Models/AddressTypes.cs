namespace DesignPluz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AddressTypes
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string AddressType { get; set; }
    }
}
