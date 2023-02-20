

// Set your secret key. Remember to switch to your live secret key in production.
// See your keys here: https://dashboard.stripe.com/apikeys

using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Stripe;

//StripeConfiguration.ApiKey = "sk_test_51MYdbtDl26fbDZBl5mwqqA1uyCJQCHG8uNave9q0tHWsOni6W79IEb753a0rRpgnwqyr97E8nY8FFKetPvl3CFVu00vXwSicjS";

namespace SinaMN75Api.Controllers
{
    [Route("api/[controller]")]
    public class StripeWebHook : Controller
    {
        const string secret = "whsec_c24542f9703711b0efdbeb78c9a52b21738c501d96e55a02b678740799ff48d6";
        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                  json,
                  Request.Headers["Stripe-Signature"],
                  secret
                );

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }
    }
}