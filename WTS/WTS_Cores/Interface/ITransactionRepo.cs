using WTS_CORE.Dto;
using WTS_CORE.Entities;
using WTS_CORE.Enums;

namespace WTS_CORE.Interface;

public interface ITransactionRepo
{
    Task<List<TransactionDto>> GetAllTransactionsAsync(Guid walletId);
    Task<Transaction> PerformTransaction(Guid walletId, decimal amount, TransactionType type);
}