using BHDTest.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BHDTest.Managers
{
    public class CustomersManager
    {
        private readonly ShoppingContext _shoppingContext;

        public CustomersManager(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
        }

        public async Task<Customers> CreateCustomer(Customers customers)
        {
            if (exists(customers.DocumentNumber))
            {
                throw new ArgumentException("The document number already exists");
            }

            EntityEntry<Customers> result = _shoppingContext.Customers.Add(customers);
            await _shoppingContext.SaveChangesAsync();
            return result.Entity;
        }

        private bool exists(string documentNum) => 
            _shoppingContext.Customers.Any(customer => customer.DocumentNumber == documentNum);
    }
}
