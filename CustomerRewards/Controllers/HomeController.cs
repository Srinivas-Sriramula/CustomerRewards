using CustomerRewards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CustomerRewards.Controllers
{
    public class HomeController : Controller
    {
        List<Customers> customerlist = new List<Customers>()
        {
               new Customers()
                    { CustomerId =1,CustomerName="Rakesh",CustomerPhone="123345", Email="raki.kalluri@gmail.com", TotalCost=30000, RewardPoints=0, PurchaseDate="2020-02-28 06:54:09.713" },
                    new Customers()
                    { CustomerId =2,CustomerName="Naresh",CustomerPhone="123345", Email="Naresh.C@gmail.com", TotalCost=50000, RewardPoints=0, PurchaseDate="2020-02-28 06:54:09.713" },
                    new Customers()
                    { CustomerId =3,CustomerName="Madhu",CustomerPhone="123345", Email="Madhu.K@gmail.com", TotalCost=20000, RewardPoints=0, PurchaseDate="2020-02-28 06:54:09.713" },
                    new Customers()
                    { CustomerId =4,CustomerName="Ali",CustomerPhone="123345", Email="Ali.MD@gmail.com", TotalCost=26700, RewardPoints=0, PurchaseDate="2020-02-28 06:54:09.713" },
                    new Customers()
                    { CustomerId =5,CustomerName="Chithu",CustomerPhone="123345", Email="Chithu.Raju@gmail.com", TotalCost=25000, RewardPoints=0, PurchaseDate="2020-02-28 06:54:09.713" },
                    new Customers()
                    { CustomerId =6,CustomerName="Nani",CustomerPhone="123345", Email="Nani.Kumar@gmail.com", TotalCost=24500, RewardPoints=0, PurchaseDate="2020-02-28 06:54:09.713" },
        };

        // GET: Customer
        public ActionResult Index()
        {
            foreach (var item in customerlist)
            {
                item.RewardPoints = CalculateRewards((double)item.TotalCost);
                item.PurchaseDate = DateTime.UtcNow.ToString();
            }

            return View(customerlist);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customers customerModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", customerModel);
                }
                customerlist.Add(customerModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            Customers customerModel = customerlist.Find(emp => emp.CustomerId == id);
            return View(customerModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Customers customerModel = customerlist.Find(emp => emp.CustomerId == id);
            return View(customerModel);
        }

        public ActionResult Delete()
        {
            return View();
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
