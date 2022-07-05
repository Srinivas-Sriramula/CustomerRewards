using CustomerRewards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CustomerRewards.Controllers
{
    public class TransactionController : Controller
    {
        List<Customers> customerlist = new List<Customers>();
        // GET: Transaction
        public ActionResult Index()
        {
            var result = TempData["obj"];
            return View(result);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Customers customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44347/api/CreatePurchase");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Customers>("CreatePurchase", customer);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    customerlist.Add(new Customers()
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
                    TempData["obj"] = customerlist;
                    return RedirectToAction("Index");
                }

            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(customer);
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