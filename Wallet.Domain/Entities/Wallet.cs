namespace Wallet.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Wallet : Entity
    {
        public decimal Budget { get; set; }

        public string User { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        protected Wallet()
        {
            Items = new HashSet<Item>();
        }

        public Wallet(decimal budget, string user) : base()
        {
            Budget = budget;
            User = user;
            Items = new HashSet<Item>();
        }
    }
}
