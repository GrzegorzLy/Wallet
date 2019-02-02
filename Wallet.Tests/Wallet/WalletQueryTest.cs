using MediatR;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Wallet.Domain.Dto;
using Wallet.Domain.Entities;
using Wallet.Domain.Handlers.Wallet;
using Wallet.Domain.Repository;
using Wallet.Tests.Helpers;

namespace Wallet.Tests.Wallet
{
    [TestFixture]
    public class WalletQueryTest
    {
        private Mock<IWalletReposiotry> _walletReposiotry;
        private IRequestHandler<WalletQuery, WalletDto> handler;

        [SetUp]
        public void SetUp()
        {
            _walletReposiotry = new Mock<IWalletReposiotry>();
            handler = new WalletQueryHandler(_walletReposiotry.Object);
        }

        [Test]
        public void WalletQuery_NotExist_ReturnNewWalletDto()
        {
            var query = new WalletQuery {User = "test"};
            var result = handler.Handle(query, default);

            Assert.AreEqual(result.Result.User, "test");
            Assert.AreEqual(result.Result.Id, 0);
        }

        [Test]
        public void WalletQuery_Exist_ReturnWalletDtoWithItemsDto()
        {
            AutoMapperHelper.Init();

            _walletReposiotry.Setup(w => w.FindByName(It.IsAny<string>())).Returns(new Domain.Entities.Wallet(1, "test")
            {
                Id = 1,
                Items = new List<Item>
                {
                    new Item(1, ""),
                    new Item(2, "")
                }
            });

            var query = new WalletQuery { User = "test" };
            var result = handler.Handle(query, default);

            Assert.AreEqual(result.Result.User, "test");
            Assert.AreEqual(result.Result.Id, 1);
            Assert.That(result.Result.Items.ToList(), Has.Count.EqualTo(2));

        }   
    }
}
