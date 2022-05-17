using CustomerRewards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomerRewards.Controllers
{
    public class RewardsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] Purchase purchase)
        {
            if (ModelState.IsValid && purchase != null)
            {
                try
                {
                    int rewardsforAbove50Dollars = 0;
                    int rewardsforAbove100Dollars = 0;
                    //int purchaseAmount = (int)Math.Round(purchase.TotalAmount);
                    int purchaseAmount = (int)Math.Floor(purchase.TotalAmount);

                    if (purchaseAmount >= 50)
                    {
                        rewardsforAbove50Dollars = (purchaseAmount - 50) * 1;
                    }
                    if (purchaseAmount >= 100)
                    {
                        rewardsforAbove100Dollars = (purchaseAmount - 100) * 1;
                    }

                    int result = rewardsforAbove50Dollars + rewardsforAbove100Dollars;

                    return Ok(new RewardPoints
                    {
                        Points = result
                    });
                }
                catch(Exception)
                {
                    return StatusCode(HttpStatusCode.InternalServerError);
                }

            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}