using AutoMapper;
using Wallet.Domain.Dto;
using Wallet.Domain.Entities;

namespace Wallet.Tests.Helpers
{
    public static class AutoMapperHelper
    {
        public static void Init()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<WalletDto, Domain.Entities.Wallet>();
                cfg.CreateMap<ItemDto, Item>();
            });
        }

    }
}
