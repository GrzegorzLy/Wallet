namespace Wallet.Domain.Repository
{
    using System.Linq;
    using Wallet.Domain.Entities;
    using Wallet.Identity.Identity;

    public interface IItemRepository : IBaseRepository<Item>
    {
        IQueryable<Item> GetAllByWalletId(int walletId);
    }

    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IQueryable<Item> GetAllByWalletId(int walletId) => _context.Set<Item>().Where(i => i.WalletId == walletId);
    }
}
