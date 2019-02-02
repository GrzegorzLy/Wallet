namespace Wallet.Domain.Repository
{
    using System.Linq;
    using Wallet.Domain.Entities;
    using Wallet.Identity.Identity;

    public interface IBaseRepository<T> where T : Entity
    {
        void Add(T model);
        T Find(int id);
        void Delete(int id);
        void Save();
        IQueryable<T> Set();
    }

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context) => _context = context;

        public void Add(T model) => _context.Add(model);

        public void Save() => _context.SaveChanges();

        public T Find(int id) => _context.Find<T>(id);

        public IQueryable<T> Set() => _context.Set<T>();

        public void Delete(int id)
        {
            var enity = this.Find(id);
            if (enity != null)
                _context.Remove(enity);
        }
    }
}
