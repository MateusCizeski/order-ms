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

        #region CreateOrder
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
        #endregion

        #region EditOrder
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
        #endregion

        #region GetOrderById
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOrderById([FromRoute] int id)
        {
            try
            {
                var result = _aplicOrder.GetOrderById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region ListOrders
        [HttpGet]
        public IActionResult ListOrders()
        {
            try
            {
                var result = _aplicOrder.ListOrders();

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region DeleteOrder
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteOrder([FromRoute] int id)
        {
            try
            {
                _aplicOrder.DeleteOrder(id);

                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
