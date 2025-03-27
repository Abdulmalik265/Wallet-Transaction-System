using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WTS_CORE.Dto;
using WTS_CORE.Enums;
using WTS_CORE.Interface;

namespace WTS.Controller;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly ILogger<TransactionController> _logger;
    private readonly IWalletRepo _walletRepo;
    private readonly ITransactionRepo _transactionRepo;
    
    public TransactionController(IWalletRepo walletRepo, ITransactionRepo transactionRepo, ILogger<TransactionController> logger)
    {
        _walletRepo = walletRepo;
        _transactionRepo = transactionRepo;
        _logger = logger;
    }
    [HttpPost("{walletId}/transactions")]
    public async Task<IActionResult> ProcessTransaction(Guid walletId, [FromBody]ProceesTransactionDto request)
    {
        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                                ?? throw new UnauthorizedAccessException("User not authenticated"));

        var wallet = await _walletRepo.GetWalletById(walletId);
        if (wallet?.UserId != userId)
            return Unauthorized(new { Message = "You do not own this wallet" });

        try
        {
            var transaction = await _transactionRepo.PerformTransaction(walletId, request.Amount, request.Type);
            return Ok(transaction);

        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseDto<TransactionDto>()
            {
                Data = null,
                ResponseMessage = ex.Message,
                ResponseCode = 00
            });
        }
    }
    
    [HttpGet("{walletId}/transactions")]
    public async Task<IActionResult> GetTransactions(Guid walletId)
    {
        var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                                ?? throw new UnauthorizedAccessException("User not authenticated"));

        var wallet = await _walletRepo.GetWalletById(walletId);
        if (wallet?.UserId != userId)
            return Unauthorized(new { Message = "You do not own this wallet" });
        try
        {
            var transactions = await _transactionRepo.GetAllTransactionsAsync(walletId);
            return Ok(transactions.Select(t => new TransactionDto()
            {
                Type = t.Type,
                Amount = t.Amount,
                IsSuccessful = t.IsSuccessful,
                FailureReason = t.FailureReason
            }));

        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseDto<TransactionDto>()
            {
                Data = null,
                ResponseMessage = ex.Message,
                ResponseCode = 00
            });



        }

       
    }
}
