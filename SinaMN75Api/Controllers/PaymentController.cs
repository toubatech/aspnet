

using Stripe;
using Stripe.Checkout;

namespace SinaMN75Api.Controllers
{
    [Route("[controller]")]
    public class PaymentController : Controller
    {

        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;
        static string ZarinPalMerchantId = "630e2aba-383e-449a-9c45-9eb324ed90fc";

        public PaymentController(IPaymentRepository paymentRepository, IOrderRepository orderRepository)
        {
            _paymentRepository = paymentRepository;
            _orderRepository= orderRepository;

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("IncreaseWalletBalance/{amount:double}")]
        public async Task<GenericResponse<string?>> IncreaseWalletBalance(double amount)
        {
            GenericResponse<string?> i = await _paymentRepository.IncreaseWalletBalance(amount, ZarinPalMerchantId);
            return i;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("WalletCallBack/{userId}/{amount:int}")]
        [HttpPost("WalletCallBack/{userId}/{amount:int}")]
        public async Task<IActionResult> WalletCallBack(string userId, int amount, string authority, string status)
        {
            GenericResponse i = await _paymentRepository.WalletCallBack(amount, authority, status, userId, ZarinPalMerchantId);
            if (i.Status == UtilitiesStatusCodes.Success)
            {
                return RedirectToAction(nameof(Verify));
            }
            return RedirectToAction(nameof(Fail));
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("Fail")]
        public ActionResult Fail()
        {
            return View();
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("Verify")]
        public ActionResult Verify()
        {
            return View("~/Views/Payment/Verify.cshtml");
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("BuyProduct/{productId}")]
        public async Task<GenericResponse<string?>> BuyProduct(Guid productId)
        {
            GenericResponse<string?> i = await _paymentRepository.BuyProduct(productId, ZarinPalMerchantId);
            return i;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("CallBack/{productId:guid}")]
        [HttpPost("CallBack/{productId:guid}")]
        public async Task<IActionResult> CallBack(Guid productId, string authority, string status)
        {
            GenericResponse i = await _paymentRepository.CallBack(productId, authority, status, ZarinPalMerchantId);
            if (i.Status == UtilitiesStatusCodes.Success)
            {
                return RedirectToAction(nameof(Verify));
            }
            return RedirectToAction(nameof(Fail));
        }



        //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("PayOrderStripe/{orderId}")]
        public async Task<GenericResponse<string?>> PayOrderStripe(Guid orderId, string? param)
        {
            return await _paymentRepository.StripeBuyProduct(orderId, param);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("CallBackOrderStripe/{orderId:guid}")]
        [HttpPost("CallBackOrderStripe/{orderId:guid}")]
        public async Task<IActionResult> CallBackOrderStripe(Guid productId, string authority, string status)
        {
            GenericResponse i = await _paymentRepository.CallBack(productId, authority, status, ZarinPalMerchantId);
            if (i.Status == UtilitiesStatusCodes.Success)
            {
                return RedirectToAction(nameof(Verify));
            }
            return RedirectToAction(nameof(Fail));
        }

        const string secret = "whsec_...";


        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("paystripe")]
        public ActionResult paystripe()
        {
            return View("~/Views/Payment/paystripe.cshtml");
        }

        [HttpPost("create-checkout-session")]
        public ActionResult CreateCheckoutSession()
        {
            StripeConfiguration.ApiKey = "sk_test_51MYdbtDl26fbDZBl5mwqqA1uyCJQCHG8uNave9q0tHWsOni6W79IEb753a0rRpgnwqyr97E8nY8FFKetPvl3CFVu00vXwSicjS";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
        {
          new SessionLineItemOptions
          {
            PriceData = new SessionLineItemPriceDataOptions
            {
              UnitAmount = 2000,
              Currency = "usd",
              ProductData = new SessionLineItemPriceDataProductDataOptions
              {
                Name = "T-shirt",
              },
            },
            Quantity = 1,
          },
        },
                Mode = "payment",
                SuccessUrl = "http://localhost:4242/success",
                CancelUrl = "http://localhost:4242/cancel",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }


        [HttpGet("cancelStripe/{orderId:guid}")]
        public async Task<ActionResult> cancelStripe(Guid orderId)
        {
            await _orderRepository.UpdateOrderPaymentData(orderId, TransactionStatus.Fail,"",0);
            return Redirect("https://touba.sinamn75.com/#/dashboard/details-order/"+orderId);
        }

        [HttpGet("successStripe/{orderId:guid}")]
        public async Task<ActionResult>  successStripe(Guid orderId)
        {
            //return View("~/Views/Payment/successStripe.cshtml");
            await _orderRepository.UpdateOrderPaymentData(orderId, TransactionStatus.Success,"", 0);
            return Redirect("https://touba.sinamn75.com/#/dashboard/details-order/" + orderId);
        }

        //https://localhost:7125/payment/paystripe
        [HttpPost("PayOrderStripeAsync/{orderId:guid}")]
        public async Task<ActionResult> PayOrderStripeAsync(Guid orderId)
        {
            StripeConfiguration.ApiKey = "sk_test_51MYdbtDl26fbDZBl5mwqqA1uyCJQCHG8uNave9q0tHWsOni6W79IEb753a0rRpgnwqyr97E8nY8FFKetPvl3CFVu00vXwSicjS";


            OrderCreateUpdateDto? orderPaymentData = await _orderRepository.GetOrderPaymentData(orderId);
            if (orderPaymentData == null) return new StatusCodeResult(404);
            if (orderPaymentData.TotalPrice == -1) return new StatusCodeResult(608);
            if (orderPaymentData.TotalPrice == 0) return new StatusCodeResult(609);
            long.TryParse(orderPaymentData?.TotalPrice?.ToString(), out long price);


            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                { 
                  new SessionLineItemOptions
                  {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                      UnitAmount = (long)orderPaymentData?.TotalPrice,
                      Currency = "usd",
                      ProductData = new SessionLineItemPriceDataProductDataOptions
                      {
                        Name = orderId.ToString(),
                      },

                    },
                    Quantity = 1,
                  },
                },
                Mode = "payment",
                SuccessUrl = "https://api.sinamn75.com/payment/successStripe/" + orderId,
                CancelUrl = "https://api.sinamn75.com/payment/cancelStripe/" + orderId,
            };

            var service = new SessionService();
            Session session = service.Create(options);
            await _orderRepository.UpdateOrderPaymentData(orderId, TransactionStatus.Pending, session.Id, orderPaymentData?.TotalPrice );

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }
        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            Console.WriteLine(json);

            return Ok();
        }
        //[HttpPost]
        //public async Task<IActionResult> Index()
        //{
        //    var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

        //    try
        //    {
        //        var stripeEvent = EventUtility.ConstructEvent(
        //          json,
        //          Request.Headers["Stripe-Signature"],
        //          secret
        //        );

        //        // Handle the checkout.session.completed event
        //        if (stripeEvent.Type == Events.CheckoutSessionCompleted)
        //        {
        //            var session = stripeEvent.Data.Object;//as Checkout.Session;
        //            var options = new SessionGetOptions();
        //            options.AddExpand("line_items");

        //            var service = new SessionService();
        //            // Retrieve the session. If you require line items in the response, you may include them by expanding line_items.
        //            Session sessionWithLineItems = service.Get("session.Id", options);
        //            StripeList<LineItem> lineItems = sessionWithLineItems.LineItems;

        //            // Fulfill the purchase...
        //            //this.FulfillOrder(lineItems);
        //        }

        //        return Ok();
        //    }
        //    catch (StripeException e)
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
