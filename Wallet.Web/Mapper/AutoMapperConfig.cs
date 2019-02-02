using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Domain.Dto;
using Wallet.Web.Models;

namespace Wallet.Web.Mapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration((cfg =>
            {
                cfg.CreateMap<Domain.Entities.Wallet, WalletDto>();
                cfg.CreateMap<Domain.Entities.Item, ItemDto>();
                cfg.CreateMap<Wallet.Domain.Entities.Wallet, WalletViewModel>();
                cfg.CreateMap<Wallet.Domain.Entities.Item, WalletItemViewModel>();

            })).CreateMapper();
        }
    }
}
