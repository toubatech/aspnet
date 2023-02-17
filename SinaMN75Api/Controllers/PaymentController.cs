

namespace SinaMN75Api.Controllers
{
    [Route("[controller]")]
    public class PaymentController : Controller
    {

        private readonly IPaymentRepository _paymentRepository;
        static string ZarinPalMerchantId = "630e2aba-383e-449a-9c45-9eb324ed90fc";

        public PaymentController(IPaymentRepository paymentRepository) => _paymentRepository = paymentRepository;

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
        public async Task<GenericResponse<string?>> PayOrderStripe(Guid orderId)
        {
            string param = "";
           // GenericResponse<string?> i = await _paymentRepository.PayOrderStripe(orderId, param);
            return null;
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
