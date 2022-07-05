using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerRewards.Models
{
    public class Customers
    {
        public int? CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public string Email { get; set; }

        public double? TotalCost { get; set; }

        public int RewardPoints { get; set; }

        public string PurchaseDate { get; set; }
    }
}