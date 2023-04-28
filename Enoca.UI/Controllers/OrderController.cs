using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enoca.Business.Abstract;
using Enoca.Business.ViewModels.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enoca.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpGet("GetAll")]
        public IEnumerable<GetOrderVM> GetAllOrders()
        {
            return orderService.GetAll();
        }
        [HttpPost("Create")]
        public string CreateOrder(CreateOrderVM createOrderVM)
        {
            return orderService.Add(createOrderVM);

        }

        [HttpGet("Delete/{id}")]
        public string DeleteOrder(int id)
        {
            return orderService.Delete(id);
        }
    }
}
