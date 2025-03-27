using WTS_CORE.Entities;
using WTS_CORE.Enums;

namespace WTS_CORE.Dto;

public class TransactionDto
{
    public Guid? WalletId { get; set; }
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public bool IsSuccessful { get; set; }
    public string FailureReason { get; set; }
    
    public WalletDto? Wallet { get; set; } = null!;
}