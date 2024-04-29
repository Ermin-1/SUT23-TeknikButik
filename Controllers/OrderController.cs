using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT23_TeknikButik.Services;
using SUT23_TeknikButikModels;

namespace SUT23_TeknikButik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private ITeknikButik<Order> _teknikButik;

        public OrderController(ITeknikButik<Order> teknikbutik) 
        {
        _teknikButik = teknikbutik;
        }


        [HttpPost]
        public async Task<ActionResult<Order>> CreateNewOrder(Order NewOrder)
        {
            try
            {
                if(NewOrder == null)
                {
                    return BadRequest();
                }

               var CreatedOrder = await _teknikButik.Add(NewOrder);
                return CreatedAtAction(nameof(GetOrder), 
                    new {id=CreatedOrder.OrderId}, CreatedOrder);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to create data to database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {

            try
            {
                var result = _teknikButik.GetSingel(id);
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrieve data from database");
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                return Ok(await _teknikButik.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {

            try
            {
                var orderToDelete = await _teknikButik.GetSingel(id);
                if (orderToDelete == null)
                {
                    return NotFound($"Order witd ID {id} not found to delete...");
                }

                return await _teknikButik.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to Delete data from database");
            }
          
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Order>> UpdateOrder(int id, Order order)
        {
            try
            {
                if(id != order.OrderId)
                {
                    return BadRequest("Order does not match");
                }

                var orderToUpdate = await _teknikButik.GetSingel(id);
                if(orderToUpdate == null)
                {
                    return NotFound($"Order with id {id} not found");
                }
                return await _teknikButik.Update(order);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update order in database");
            }
        }
    }
}
