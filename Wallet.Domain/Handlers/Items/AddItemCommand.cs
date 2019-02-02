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
        private IItemRepository _itemReposiotry;

        public AddItemCommandHandler(IItemRepository itemReposiotry)
        {
            this._itemReposiotry = itemReposiotry;
        }

        protected override void Handle(AddItemCommand request)
        {
            if (string.IsNullOrEmpty(request.Name) || request.WalletId == 0)
                throw new System.ArgumentException();

            var entity = new Item(request.Amount, request.Name, request.WalletId);
            _itemReposiotry.Add(entity);
            _itemReposiotry.Save();
        }
    }
}
