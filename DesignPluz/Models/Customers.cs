namespace DesignPluz.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customers
    {
        
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("First Name")]
        public string firstname { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string lastname { get; set; }

       
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        [DisplayName("Mobile Number")]
        public int mobilenumber { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        [DisplayName("Email")]
        public string email { get; set; }

        [Required]
        [DisplayName("Gender")]
        public int genderId { get; set; }

        public DateTime? createdon { get; set; }

        [ForeignKey("genderId")]
        public Genders Genders { get; set; }
    }
}
