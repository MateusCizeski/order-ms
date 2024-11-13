using Microsoft.AspNetCore.Mvc;
using order_ms.Application;
using order_ms.DTOs;
using order_ms.Models;

namespace order_ms.Controllers
{
    [Route("api/v1/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IAplicOrder _aplicOrder;

        public OrderController(IAplicOrder aplicOrder)
        {
            _aplicOrder = aplicOrder;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public IActionResult InsertOrder(Order order)
        {
            try
            {
                var result = _aplicOrder.InsertOrder(order);

                return Ok(result);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        [Route("EditOrder")]
        public IActionResult EditOrder(EditOrderDTO dto)
        {
            try
            {
                var result = _aplicOrder.EditOrder(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
