namespace Wallet.Domain.Handlers.Items
{
    using global::Wallet.Domain.Entities;
    using global::Wallet.Domain.Repository;
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class UpdateItemCommand : IRequest
    {
        [Required]
        public int WalletId { get; set; }

        [Required]
        [Range(0, 100000)]
        public decimal Amount { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class UpdateItemCommandHandler : RequestHandler<UpdateItemCommand>
    {
        private IItemRepository _itemReposiotry;

        public UpdateItemCommandHandler(IItemRepository itemReposiotry)
        {
            _itemReposiotry = itemReposiotry;
        }

        protected override void Handle(UpdateItemCommand request)
        {
            var entity = new Item(request.Amount, request.Name, request.WalletId);
            _itemReposiotry.Add(entity);
            _itemReposiotry.Save();
        }
    }
}
