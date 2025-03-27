using WTS_CORE.Enums;

namespace WTS_CORE.Entities;

public class Transaction : BaseEntity
{
    public Guid WalletId { get; set; }
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public bool IsSuccessful { get; set; }
    public string FailureReason { get; set; }
    public Wallet Wallet { get; set; } = null!;

}