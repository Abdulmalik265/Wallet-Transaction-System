using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WTS_CORE.Dto;
using WTS_CORE.Entities;
using WTS_CORE.Interface;

namespace WTS.Controller;
[Route("api/[controller]")]
[ApiController]
public class WalletController : ControllerBase
{
    private readonly IUserRegistration _userRegistration;
    private readonly IWalletRepo _walletRepo;
    private readonly IConfiguration _configuration;
    private IHttpClientFactory _httpClientFactory;
    public WalletController(IUserRegistration userRegistration, IWalletRepo walletRepo, 
        IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _userRegistration = userRegistration;
        _walletRepo = walletRepo;
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
    }
    [HttpPost("Wallets")]
    public async Task<IActionResult> CreateWallet()
    {
        try
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var response = await _walletRepo.CreateWallet(userId);
            return Ok(new ResponseDto<Wallet>()
            {
                Data = response,
                ResponseMessage = "Wallet created successfully.",
                ResponseCode = 200,
                
            });
            
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseDto<Wallet>()
            {
                Data = null,
                ResponseMessage = ex.Message,
                ResponseCode = 00
            });
        }
        
        
    }

    [HttpGet("Wallets/{id}")]
    public async Task<IActionResult> GetWallet(Guid id)
    {
        try
        {
            var response = await _walletRepo.GetWalletById(id);
            return Ok(response);

        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseDto<Wallet>()
            {
                Data = null,
                ResponseMessage = ex.Message,
                ResponseCode = 00
            });
        }
    }

    [HttpPost("Wallets/{walletId}/fund")]
    public async Task<IActionResult> FundWallet(Guid walletId, [FromBody] WalletFundingRequestDto request)
    {
        try
        {
            var wallet = await _walletRepo.GetWalletById(walletId);
            if (wallet is null) 
                throw new ArgumentException("Wallet not found");
            var url = _configuration.GetValue<string>("Paystack : PaystackUrl");
            var secretKey = _configuration.GetValue<string>("Paystack : SecretKey");
            var callbackUrl = _configuration.GetValue<string>("Paystack : WebhookUrl");
            var client = _httpClientFactory.CreateClient();

            var requestBody = new
            {
                email = request.Email,
                amount = request.Amount,
                currency = "NGN",
                reference = Guid.NewGuid().ToString(),
                callback_url = callbackUrl
            };
            
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {secretKey}");
            
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                return BadRequest(responseContent);
            
            var paystackResponse = JsonConvert.DeserializeObject<PaystackResponse>(responseContent);
            
            return Ok(new { message = "Payment initialized", paystackResponse.Data.AuthorizationUrl });
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseDto<Wallet>()
            {
                Data = null,
                ResponseMessage = ex.Message,
                ResponseCode = 00

            });

        }
    }
    
    [HttpPost("verify-payment")]
    public async Task<IActionResult> VerifyPayment([FromBody] PayStackCallBackDto data)
    {
        if (data.Event != "charge.success" || data.Data.Status != "success")
            return BadRequest("Invalid or failed payment.");

        var wallet = await _walletRepo.GetWalletByEmail(data.Data.Customer.Email);
        if (wallet == null) return NotFound("Wallet not found");

        await _walletRepo.AddMoneyToWallet(wallet.Id, data.Data.Amount / 100); 
        return Ok(new { message = "Wallet funded successfully" });
    }

    
}
