using BulkyBookAPI.Domain.DTOs.OrderDTOs;
using BulkyBookAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookAPI.Controllers
{

    [ApiController]
    [Route("order")]
    public class OrderController : Controller
    {

        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        [Route("addOrder")]
        //[Authorize]
        public async Task<IActionResult> AddOrderAsync([FromBody] AddOrderDTO addOrderDTO) {


            var addResult = await _orderRepository.AddOrderAsync(addOrderDTO);

            if (addResult) {

                return Ok("Your order has been successfuly taken");
            
            }

            return BadRequest("Something went wrong taking your order, please try again later");

        
        }



    }
}
