using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BHDTest.Managers;
using BHDTest.Models;
using BHDTest.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BHDTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartHeaderController : ControllerBase
    {
        private readonly ShoppingCartHeaderManager _shoppingCartHeaderManager;
        public ShoppingCartHeaderController(ShoppingCartHeaderManager shoppingCartHeaderManager)
        {
            _shoppingCartHeaderManager = shoppingCartHeaderManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShoppingCartHeaderRequest shoppingCartHeaderRequest)
        {
            var randomGenerator = new Random();
            var ShoppingCartItemsList = shoppingCartHeaderRequest.shoppingCartItemsRequests
                .Select(shoppingCartItemRequest => new ShoppingCartItems
                {
                    Description = shoppingCartItemRequest.Description,
                    IdProduct = shoppingCartItemRequest.IdProduct,
                    Price = shoppingCartItemRequest.Price,
                    Qty = shoppingCartItemRequest.Qty,
                    Total = shoppingCartItemRequest.Price * shoppingCartItemRequest.Qty,
                }).ToList();

            var shoppingCartHeader = new ShoppingCartHeader
            {
                IdCustomer = shoppingCartHeaderRequest.IdCustomer,
                IsCredit = shoppingCartHeaderRequest.IsCredit,
                OrderAmount = shoppingCartHeaderRequest.OrderAmount,
                ShoppingCartItems = ShoppingCartItemsList,
                Active = true,
                OrderDate = DateTime.Now,
                OrderNumber = randomGenerator.Next(1000000000, 999999999).ToString(),
            };

            try
            {
                var response = await _shoppingCartHeaderManager.CreateOrder(shoppingCartHeader);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("");
            }


        }
    }
}