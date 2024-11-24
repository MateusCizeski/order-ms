using Application;
using domain;
using Microsoft.AspNetCore.Mvc;
using Producer;

namespace order_ms.Controllers
{
    [Route("api/v1/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region Ctor
        private readonly IAplicOrder _aplicOrder;
        private readonly RabbitProducer _rabbitProducer;

        public OrderController(IAplicOrder aplicOrder, RabbitProducer rabbitProducer)
        {
            _aplicOrder = aplicOrder;
            _rabbitProducer = rabbitProducer;
        }
        #endregion

        #region SendMessage
        [HttpPost]
        [Route("SendMessage")]
        public IActionResult SendMessage([FromBody] string message)
        {
            try
            {
                _rabbitProducer.SendMessage(message);
                return Ok("Mensagem enviada com sucesso.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao enviar mensagem: {ex.Message}");
            }
        }
        #endregion

        #region CreateOrder
        [HttpPost]
        [Route("createOrder")]
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
        [Route("editOrder")]
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
        [Route("getOrderById/{id}")]
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
        [Route("deleteOrder/{id}")]
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

        #region GetOrderByCustomerId
        [HttpGet]
        [Route("getOrderByCustomerId/{customerId}")]
        public IActionResult GetOrderByCustomerId([FromRoute] int customerId)
        {
            try
            {
                var result = _aplicOrder.GetOrderByCustomerId(customerId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region GetPriceTotalOrder
        [HttpGet]
        [Route("getPriceTotalOrder/{id}")]
        public IActionResult GetPriceTotalOrder(int id)
        {
            try
            {
                var result = _aplicOrder.GetPriceTotalOrder(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region OrderByCustomer
        [HttpGet]
        [Route("orderByCustomer/{customerId}")]
        public IActionResult OrderByCustomer(int customerId)
        {
            try
            {
                var result = _aplicOrder.OrderByCustomer(customerId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
