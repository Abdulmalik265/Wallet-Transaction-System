namespace WTS_CORE.Dto;

public class WalletDto
{
    public decimal Balance { get; set; }
    public string UserName { get; set; } 
    public Guid UserId { get; set; }
    public List<TransactionDto> Transactions { get; set; } = [];
}