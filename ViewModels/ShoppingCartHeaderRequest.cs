using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BHDTest.ViewModels
{
    public class ShoppingCartHeaderRequest
    {
        [Required]
        public int IdCustomer { get; set; }
        [Required]
        public decimal OrderAmount { get; set; }
        [Required]
        public bool IsCredit { get; set; }
        [Required]
        public IEnumerable<ShoppingCartItemsRequest> shoppingCartItemsRequests { get; set; }
    }
}
