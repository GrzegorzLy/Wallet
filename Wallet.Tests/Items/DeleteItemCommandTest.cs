using MediatR;
using Moq;
using NUnit.Framework;
using Wallet.Domain.Handlers.Items;
using Wallet.Domain.Repository;

namespace Wallet.Tests.Items
{
    [TestFixture]
    public class DeleteItemCommandTest
    {
        private Mock<IItemRepository> _itemReposiotry;
        private IRequestHandler<DeleteItemCommand> handler;

        [SetUp]
        public void SetUp()
        {
            _itemReposiotry = new Mock<IItemRepository>();
            handler = new DeleteItemCommandHandler(_itemReposiotry.Object);
        }

        [Test]
        public void DeleteItem_RepositorySaved()
        {
            var command = new DeleteItemCommand { Id = 1 };
            handler.Handle(command, default);

            _itemReposiotry.Verify(r => r.Save(), Times.Once);
        }
    }
}
