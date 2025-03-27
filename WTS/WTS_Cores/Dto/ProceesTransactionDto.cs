using WTS_CORE.Enums;

namespace WTS_CORE.Dto;

public class ProceesTransactionDto
{
    public TransactionType Type{ get; set; }
    public decimal Amount { get; set; }
    
}