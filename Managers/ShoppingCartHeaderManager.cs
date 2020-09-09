using BHDTest.Models;
using BHDTest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHDTest.Managers
{
    public class ShoppingCartHeaderManager
    {
        private readonly ShoppingContext _shoppingContext;

        public ShoppingCartHeaderManager(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
        }

        [HttpPost]
        public async Task<ShoppingCartHeader> CreateOrder(ShoppingCartHeader shoppingCartHeader)
        {
            var result = _shoppingContext.ShoppingCartHeader.Add(shoppingCartHeader);
            await _shoppingContext.SaveChangesAsync();

            return result.Entity;
        }
    }
}
