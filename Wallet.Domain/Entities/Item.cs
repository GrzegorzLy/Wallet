namespace Wallet.Domain.Entities
{
    public class Item : Entity
    {

        public decimal Amount { get; set; }
        public string Name { get; set; }

        public virtual Wallet Wallet { get; set; }

        public int WalletId { get; set; }

        protected Item()
        {
        }

        public Item(decimal amount, string name,int walletId) : base()
        {
            if (walletId == 0)
                throw new System.ArgumentException();

            Amount = amount;
            Name = name;
            WalletId = walletId;
        }
    }
}
