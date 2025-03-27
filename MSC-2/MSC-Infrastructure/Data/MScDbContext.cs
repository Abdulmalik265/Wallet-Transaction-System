using Microsoft.EntityFrameworkCore;
using MSC_Core.Entities;

namespace MSC_Infrastructure.Data;

public class MScDbContext : DbContext
{
    public MScDbContext(DbContextOptions<MScDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<Merchant> Merchants {get; set; }
    public DbSet<Settelement> Settlements { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<History> Histories { get; set; }
    public DbSet<StatusEntity> Statuses { get; set; }
    public DbSet<Validation> Validations { get; set; }
    public DbSet<Config> Configs { get; set; }
    public DbSet<Posting> Postings { get; set; }

}