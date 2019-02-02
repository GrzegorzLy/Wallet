namespace Wallet.Domain.Handlers.Wallet
{
    using global::Wallet.Domain.Repository;
    using MediatR;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SaveWalletCommand : IRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string User { get; set; }
        [Required]
        [Range(0, 100_000_000)]
        public decimal Budget { get; set; }
    }

    public class SaveWalletCommandRequest : RequestHandler<SaveWalletCommand>
    {
        private IWalletReposiotry _walletReposiotry;

        public SaveWalletCommandRequest(IWalletReposiotry walletReposiotry)
        {
            _walletReposiotry = walletReposiotry;
        }

        protected override void Handle(SaveWalletCommand request)
        {
            if (string.IsNullOrEmpty(request.User))
                throw new ArgumentException();

            if (_walletReposiotry.Exists(request.User))
            {
                var entity = _walletReposiotry.FindByName(request.User);
                entity.Budget = request.Budget;
            }
            else
            {
                var entity = new Entities.Wallet(request.Budget, request.User);
                _walletReposiotry.Add(entity);
            }
            _walletReposiotry.Save();
        }
    }
}
