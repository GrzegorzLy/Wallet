namespace Wallet.Domain.Repository
{
    using System.Linq;
    using Wallet.Identity.Identity;

    public interface IWalletReposiotry : IBaseRepository<Entities.Wallet>
    {
        Entities.Wallet FindByName(string name);
        bool Exists(string name);
    }

    public class WalletRepository : BaseRepository<Entities.Wallet>, IWalletReposiotry
    {
        public WalletRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Entities.Wallet FindByName(string name) => _context.Wallets.FirstOrDefault(w => w.User == name);

        public bool Exists(string name) => _context.Wallets.Any(w => w.User == name);
    }
}
