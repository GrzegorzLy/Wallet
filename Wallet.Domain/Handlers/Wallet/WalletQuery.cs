namespace Wallet.Domain.Handlers.Wallet
{
    using AutoMapper;
    using global::Wallet.Domain.Dto;
    using global::Wallet.Domain.Repository;
    using MediatR;

    public class WalletQuery : IRequest<WalletDto>
    {
        public string User { get; set; }
    }

    public class WalletQueryHandler : RequestHandler<WalletQuery, WalletDto>
    {
        private IWalletReposiotry _walletReposiotry;

        public WalletQueryHandler(IWalletReposiotry walletReposiotry)
        {
            _walletReposiotry = walletReposiotry;
        }

        protected override WalletDto Handle(WalletQuery query)
        {
            var entity = _walletReposiotry.FindByName(query.User);
            return entity == null ? new WalletDto { User = query.User } : Mapper.Map<WalletDto>(entity);
        }
    }
}
