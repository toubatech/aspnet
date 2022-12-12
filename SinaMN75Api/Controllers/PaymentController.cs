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
        public async Task<IActionResult> WalletCallBack(string userId ,int amount, string authority, string status)
        {
            GenericResponse i = await _paymentRepository.WalletCallBack(amount, authority, status, userId, ZarinPalMerchantId);
            if(i.Status == UtilitiesStatusCodes.Success)
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
    }
}
