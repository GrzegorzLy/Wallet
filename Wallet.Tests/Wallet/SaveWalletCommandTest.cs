using MediatR;
using Moq;
using NUnit.Framework;
using System;
using Wallet.Domain.Handlers.Wallet;
using Wallet.Domain.Repository;

namespace Wallet.Tests.Wallet
{
    [TestFixture]
    public class SaveWalletCommandTest
    {
        private Mock<IWalletReposiotry> _walletReposiotry;
        private IRequestHandler<SaveWalletCommand> handler;

        [SetUp]
        public void SetUp()
        {
            _walletReposiotry = new Mock<IWalletReposiotry>();
            handler = new SaveWalletCommandRequest(_walletReposiotry.Object);
        }

        [Test]
        public void AddWalletToRepository_ItemHasValidData_RepositorySaved()
        {
            var command = new SaveWalletCommand { Id = 0, User = "test", Budget = 1 };
            handler.Handle(command, default);

            _walletReposiotry.Verify(r => r.Save(), Times.Once);
            _walletReposiotry.Verify(r => r.Add(It.IsAny<Domain.Entities.Wallet>()), Times.Once);
        }

        [Test]
        public void UpdateWallet_ItemHasValidData_RepositorySaved()
        {
            var command = new SaveWalletCommand { Id = 0, User = "test", Budget = 1 };
            _walletReposiotry.Setup(w => w.Exists(It.IsAny<string>())).Returns(true);
            _walletReposiotry.Setup(w => w.FindByName(It.IsAny<string>())).Returns(new Domain.Entities.Wallet(1, "s"));
            handler.Handle(command, default);

            _walletReposiotry.Verify(r => r.Save(), Times.Once);
            _walletReposiotry.Verify(r => r.Add(It.IsAny<Domain.Entities.Wallet>()), Times.Never);
        }

        [Test]
        public void UpdateWallet_ItemHasInvalidData_ThrowArgumentException()
        {
            var command = new SaveWalletCommand { Id = 0, Budget = 1 };
            Assert.That(() => handler.Handle(command, default), Throws.TypeOf<ArgumentException>());
        }
    }
}
