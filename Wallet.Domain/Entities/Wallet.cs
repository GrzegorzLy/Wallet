namespace Wallet.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Wallet : Entity
    {
        [Column(TypeName = "decimal(8, 2)")]
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
