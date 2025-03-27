using Microsoft.EntityFrameworkCore;
using WTS_CORE.Entities;

namespace WTS_INFRASTRUCTURE.Data;

public class WtsDbContext : DbContext
{
    public WtsDbContext(DbContextOptions<WtsDbContext> options) : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Wallet>()
            .HasOne(w => w.User)
            .WithMany()
            .HasForeignKey(w => w.UserId);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Wallet)
            .WithMany(w => w.Transactions)
            .HasForeignKey(t => t.WalletId);
        
    }
}
