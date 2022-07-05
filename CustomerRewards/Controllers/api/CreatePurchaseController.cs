using CustomerRewards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomerRewards.Controllers.api
{
    public class CreatePurchaseController : ApiController
    {
        

        public CreatePurchaseController()
        {
        }
        public IHttpActionResult PostNewPurchase(Customers customer)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            List<Customers> obj = new List<Customers>();

            obj.Add(new Customers()
                    {
                        CustomerId = 1,
                        CustomerName = customer.CustomerName,
                        CustomerPhone = customer.CustomerPhone,
                        Email = customer.Email,
                        TotalCost = customer.TotalCost,
                        RewardPoints = CalculateRewards((double)customer.TotalCost),
                        PurchaseDate = DateTime.Now.ToString(),
                    }
                );

            return Ok(obj);
        }
        public int CalculateRewards(double TotalAmount)
        {

            try
            {
                int rewardsforAbove50Dollars = 0;
                int rewardsforAbove100Dollars = 0;
                //int purchaseAmount = (int)Math.Round(purchase.TotalAmount);
                int purchaseAmount = (int)Math.Floor(TotalAmount);

                if (purchaseAmount >= 50)
                {
                    rewardsforAbove50Dollars = (purchaseAmount - 50) * 1;
                }
                if (purchaseAmount >= 100)
                {
                    rewardsforAbove100Dollars = (purchaseAmount - 100) * 1;
                }

                int result = rewardsforAbove50Dollars + rewardsforAbove100Dollars;

                return result;
              
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}