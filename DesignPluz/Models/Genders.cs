namespace DesignPluz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Genders
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
    }
}
