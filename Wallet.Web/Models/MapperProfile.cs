using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Domain.Dto;

namespace Wallet.Web.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Domain.Entities.Wallet, WalletDto>();
            CreateMap<Domain.Entities.Item, ItemDto>();


            CreateMap<Wallet.Domain.Entities.Wallet, WalletViewModel>();
            CreateMap<Wallet.Domain.Entities.Item, WalletItemViewModel>();

        }
    }
}
