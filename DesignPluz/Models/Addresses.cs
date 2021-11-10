namespace DesignPluz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Addresses
    {
        public int id { get; set; } 

        public int AddressTypeId { get; set; }

        public int CustomerId { get; set; }

        [Required]
        [StringLength(150)]
        public string StreetAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Max 4 numeric accept only")]
        public int PostalCode { get; set; }

        public bool Primary { get; set; }

        [ForeignKey("AddressTypeId")]
        public AddressTypes AddressTypes { get; set; }
    }
}
