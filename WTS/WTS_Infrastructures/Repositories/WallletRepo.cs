using Microsoft.EntityFrameworkCore;
using WTS_CORE.Dto;
using WTS_CORE.Entities;
using WTS_CORE.Interface;
using WTS_INFRASTRUCTURE.Data;

namespace WTS_INFRASTRUCTURE.Repositories;

public class WallletRepo : IWalletRepo
{
    private readonly WtsDbContext _context;

    public WallletRepo(WtsDbContext context)
    {
        _context = context;
    }
    public async Task<Wallet> CreateWallet(Guid UserId)
    {
        try
        {
            var user = _context.Wallets.SingleOrDefault(x => x.UserId == UserId);
            if (user == null)
                throw new NullReferenceException("Wallet does not exist");

            var wallet = new Wallet()
            {
                Id = Guid.NewGuid(),
                Balance = 0m,
                Transactions = new List<Transaction>(),
                CreatedAt = DateTime.Now,
                UserId = user.Id,
            };

            _context.Wallets.Add(wallet);
            _context.SaveChanges();
            
            return wallet;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred when creating a new wallet: {ex.Message}");
        }
        
    }

    public async Task<WalletDto> GetWalletById(Guid walletId)
    {
        var wallet = _context.Wallets.Include(x=>x.User)
            .SingleOrDefault(x => x.Id == walletId);
        
        var newWallet = new WalletDto()
        {
            Balance = wallet.Balance,
            Transactions = wallet.Transactions.Select(x=>new TransactionDto
            {
                Amount = x.Amount,
                FailureReason = x.FailureReason,
                Type = x.Type,
                IsSuccessful = x.IsSuccessful
                
            }).ToList(),
            UserName = wallet.User.Username
        };
        
        if(wallet == null)
            throw new NullReferenceException("Wallet does not exist");
        
        return newWallet;
    }

    public async Task<Wallet> GetWalletByEmail(string email)
    {
        return await  _context.Wallets.FirstOrDefaultAsync(w => w.User.Email == email);

    }

    public async Task AddMoneyToWallet(Guid walletId, decimal money)
    {
        var wallet = _context.Wallets.SingleOrDefault(x => x.Id == walletId);
        if(wallet == null)
            throw new NullReferenceException("Wallet does not exist");
        wallet.Balance += money;
         _context.SaveChangesAsync();
    }
}
