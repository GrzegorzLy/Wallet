using MediatR;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Wallet.Domain.Dto;
using Wallet.Domain.Entities;
using Wallet.Domain.Handlers.Items;
using Wallet.Domain.Repository;
using Wallet.Tests.Helpers;

namespace Wallet.Tests.Items
{
    [TestFixture]
    public class ItemsQueryTest
    {
        private Mock<IItemRepository> _itemReposiotry;
        private IRequestHandler<ItemsQuery, IEnumerable<ItemDto>> handler;

        [SetUp]
        public void SetUp()
        {
            _itemReposiotry = new Mock<IItemRepository>();
            _itemReposiotry.Setup(r => r.GetAllByWalletId(1)).Returns(new List<Item>
            {
                new Item(1,"a",1),
                new Item(2,"b",2),
                new Item(3,"c",13),
            }.AsQueryable());

            handler = new ItemsQueryHandler(_itemReposiotry.Object);       
        }

        [Test]
        public void ItemsQuery_ItemsExist_CountEqualThree()
        {
            AutoMapperHelper.Init();

            var query = new ItemsQuery { WalletId = 1 };
            var result = handler.Handle(query, default);

            Assert.That(result.Result.ToList(), Has.Count.EqualTo(3));
        }

        [Test]
        public void ItemsQuery_ItemsNotExist_CountEqualZero()
        {
            AutoMapperHelper.Init();

            var query = new ItemsQuery { WalletId = 2 };
            var result = handler.Handle(query, default);

            Assert.That(result.Result.ToList(), Has.Count.EqualTo(0));
        }
    }
}
