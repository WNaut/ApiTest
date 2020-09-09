using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHDTest.ViewModels
{
    public class ShoppingCartItemsRequest
    {
        public int IdProduct { get; set; }
        public string Description { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

        public ShoppingCartHeaderRequest IdOrderNavigation { get; set; }
        //public virtual Products IdProductNavigation { get; set; }
    }
}
