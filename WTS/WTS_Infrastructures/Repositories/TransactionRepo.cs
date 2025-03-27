using WTS_CORE.Dto;
using WTS_CORE.Entities;
using WTS_CORE.Enums;
using WTS_CORE.Interface;
using WTS_INFRASTRUCTURE.Data;

namespace WTS_INFRASTRUCTURE.Repositories;

public class TransactionRepo : ITransactionRepo
{
    private WtsDbContext _context;

    public TransactionRepo(WtsDbContext context)
    {
        _context = context;
    }
    public async Task<List<TransactionDto>> GetAllTransactionsAsync(Guid walletId)
    {
        var wallet = _context.Wallets.SingleOrDefault(x=>x.Id == walletId);
        if(wallet is null) 
            throw new ArgumentException("No wallet found");
        
        var transactions = _context.Transactions.Where(x=>x.WalletId == walletId)
            .Select(x=> new TransactionDto
            {
                Amount = x.Amount,
                FailureReason = x.FailureReason,
                WalletId = x.WalletId,
                Type = x.Type,
                IsSuccessful = x.IsSuccessful
                
            }).ToList();
        
        return transactions;
    }

    public async Task<Transaction> PerformTransaction(Guid walletId, decimal amount, TransactionType type)
    {
        if(amount < 0)
            throw new ArgumentException("Amount cannot be negative");
        using var transactions = _context.Database.BeginTransaction();
        try
        {
            var wallet = _context.Wallets.SingleOrDefault(x => x.Id == walletId);
            if (wallet == null)
                throw new ArgumentException("Wallet not found");

            string? failureReason;
            bool isSuccessfull;

            switch (type)
            {
                case TransactionType.Power:
                    isSuccessfull = false;
                    failureReason = "Power transactions are not supported";
                    break;
                case TransactionType.Airtime:
                    isSuccessfull = wallet.Balance >= amount;
                    failureReason = isSuccessfull ? null : "Insufficient funds";
                    break;
                case TransactionType.Data:
                    isSuccessfull = wallet.Balance >= amount;
                    failureReason = isSuccessfull ? null : "Insufficient funds";
                    break;
                case TransactionType.TVSubscription :
                    isSuccessfull = wallet.Balance >= amount;
                    failureReason = isSuccessfull ? null : "Insufficient funds";
                    break;
                default:
                    throw new ArgumentException("Invalid transaction type", nameof(type));
            }

            if (isSuccessfull)
            {
                wallet.Balance -= amount;
                await _context.SaveChangesAsync();
            }

            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                WalletId = wallet.Id,
                Amount = wallet.Balance,
                CreatedAt = DateTime.UtcNow,
                FailureReason = failureReason,
                IsSuccessful = isSuccessfull
            };
            
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            await transactions.CommitAsync();
            
            return transaction;
        }
        catch (Exception ex)
        {
            await transactions.RollbackAsync();
            throw new ArgumentException(ex.Message);
            
        }
        
    }
}
