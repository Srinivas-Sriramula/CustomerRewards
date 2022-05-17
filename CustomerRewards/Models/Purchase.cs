using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerRewards.Models
{
    public class Purchase
    {
        [Required]
        public double TotalAmount { get; set; }
        
    }
}