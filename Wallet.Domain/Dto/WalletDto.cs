using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Wallet.Domain.Dto
{
    public class WalletDto
    {
        public int Id { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, 100_000)]
        public decimal Budget { get; set; }

        public string User { get; set; }

        public IEnumerable<ItemDto> Items { get; set; }
        
    }
}
