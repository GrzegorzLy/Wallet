namespace Wallet.Domain.Handlers.Items
{
    using AutoMapper.QueryableExtensions;
    using global::Wallet.Domain.Dto;
    using global::Wallet.Domain.Repository;
    using MediatR;
    using System.Collections.Generic;

    public class ItemsQuery : IRequest<IEnumerable<ItemDto>>
    {
        public int WalletId { get; set; }
    }

    public class ItemsQueryHandler : RequestHandler<ItemsQuery, IEnumerable<ItemDto>>
    {
        private IItemRepository _itemReposiotry;

        public ItemsQueryHandler(IItemRepository itemReposiotry)
        {
            _itemReposiotry = itemReposiotry;
        }

        protected override IEnumerable<ItemDto> Handle(ItemsQuery request)
        {
            return _itemReposiotry.GetAllByWalletId(request.WalletId).ProjectTo<ItemDto>();
        }
    }
}
