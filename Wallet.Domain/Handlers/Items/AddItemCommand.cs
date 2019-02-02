namespace Wallet.Domain.Handlers.Items
{
    using global::Wallet.Domain.Entities;
    using global::Wallet.Domain.Repository;
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class AddItemCommand : IRequest
    {
        [Required]
        public int WalletId { get; set; }

        [Required]
        [Range(0, 100000)]
        public decimal Amount { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class AddItemCommandHandler : RequestHandler<AddItemCommand>
    {
        private ItemRepository _itemReposiotry;

        public AddItemCommandHandler(ItemRepository itemReposiotry)
        {
            this._itemReposiotry = itemReposiotry;
        }

        protected override void Handle(AddItemCommand request)
        {
            var entity = new Item(request.Amount, request.Name, request.WalletId);
            _itemReposiotry.Add(entity);
            _itemReposiotry.Save();
        }
    }
}
