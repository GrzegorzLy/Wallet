namespace Wallet.Domain.Handlers.Items
{
    using global::Wallet.Domain.Repository;
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class DeleteItemCommand : IRequest
    {
        [Required]
        public int Id { get; set; }
    }

    public class DeleteItemCommandHandler : RequestHandler<DeleteItemCommand>
    {
        private IItemRepository _itemReposiotry;

        public DeleteItemCommandHandler(IItemRepository itemReposiotry)
        {
            _itemReposiotry = itemReposiotry;
        }

        protected override void Handle(DeleteItemCommand request)
        {
            _itemReposiotry.Delete(request.Id);
            _itemReposiotry.Save();
        }
    }
}
