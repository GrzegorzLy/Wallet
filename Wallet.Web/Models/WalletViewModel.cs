using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wallet.Web.Models
{
    public class WalletViewModel
    {
        public WalletViewModel()
        {
            Items = new List<WalletItemViewModel>();
        }

        public int Id { get; set; }
        public string User { get; set; }
        public decimal Budget { get; set; }

        public List<WalletItemViewModel> Items { get; set; }

    }
}
