using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallet.Web.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Wallet.Domain.Entities.Wallet, WalletViewModel>();
            CreateMap<Wallet.Domain.Entities.Item, WalletItemViewModel>();

        }
    }
}
