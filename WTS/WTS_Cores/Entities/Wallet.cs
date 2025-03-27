namespace WTS_CORE.Entities;

public class Wallet : BaseEntity
{
    public decimal Balance { get; set; }
    public User User { get; set; } 
    public Guid UserId { get; set; }
    public List<Transaction> Transactions { get; set; } = [];
}