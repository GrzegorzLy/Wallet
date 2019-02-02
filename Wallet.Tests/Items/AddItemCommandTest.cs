using MediatR;
using Moq;
using NUnit.Framework;
using System;
using Wallet.Domain.Handlers.Items;
using Wallet.Domain.Repository;

namespace Wallet.Tests.Items
{
    [TestFixture]
    public class AddItemCommandTest
    {
        private Mock<IItemRepository> _itemReposiotry;
        private IRequestHandler<AddItemCommand> handler;

        [SetUp]
        public void SetUp()
        {
            _itemReposiotry = new Mock<IItemRepository>();
            handler = new AddItemCommandHandler(_itemReposiotry.Object);
        }

        [Test]
        public void AddItemToRepository_ItemHasValidData_RepositorySaved()
        {
            var command = new AddItemCommand { Amount = 1, Name = "test", WalletId = 1 };
            handler.Handle(command, default);

            _itemReposiotry.Verify(r => r.Save(), Times.Once);
        }

        [TestCase("", 1)]
        [TestCase("a", 0)]
        [TestCase("", 0)]
        public void AddItemToRepository_ItemHasNotValidData_ArgumentException(string name, int id)
        {
            var command = new AddItemCommand { Amount = 1, Name = name, WalletId = id };
            ;

            Assert.That(() => handler.Handle(command, default), Throws.TypeOf<ArgumentException>());
        }

    }
}
