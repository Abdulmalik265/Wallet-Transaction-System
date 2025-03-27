using WTS_CORE.Dto;
using WTS_CORE.Entities;

namespace WTS_CORE.Interface;

public interface IWalletRepo
{
    Task<Wallet> CreateWallet(Guid userId);
    Task<WalletDto> GetWalletById(Guid walletId);
    
    Task<Wallet> GetWalletByEmail(string email);
    
    Task AddMoneyToWallet(Guid walletId, decimal money);
}