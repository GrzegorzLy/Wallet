namespace Wallet.Identity.Identity
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Wallet.Domain.Entities.Wallet> Wallets { get; set; }

        public DbSet<Wallet.Domain.Entities.Item> Items { get; set; }
    }
}
