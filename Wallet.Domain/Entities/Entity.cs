namespace Wallet.Domain.Entities
{
    using System;

    public class Entity : IEntity
    {
        public int Id { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public Entity()
        {
            CreateAt = DateTime.UtcNow;
            UpdateAt = DateTime.UtcNow;
        }
    }

    public interface IEntity
    {
        int Id { get; set; }

        DateTime CreateAt { get; set; }

        DateTime UpdateAt { get; set; }
    }
}
