using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPluz.Models
{
    public class CustomerViewModel
    {
        public int genderId { get; set; }
        public Customers Customers { get; set; }
        public List<Addresses> Addresses { get; set; }

        
    }
}