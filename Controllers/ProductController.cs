using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT23_TeknikButik.Services;
using SUT23_TeknikButikModels;

namespace SUT23_TeknikButik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ITeknikButik<Product> _teknikButik;

        public ProductController(ITeknikButik<Product> teknikButik)
        {
            _teknikButik = teknikButik;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                return Ok(await _teknikButik.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrivve data from database!");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var result = await _teknikButik.GetSingel(id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrivve data from database!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateNewProduct(Product newPro)
        {
            try
            {
                if (newPro == null)
                {
                    return BadRequest();
                }

                var createdProduct = await _teknikButik.Add(newPro);
                return CreatedAtAction(nameof(GetAllProduct),
                    new { id = createdProduct.ProductId }, createdProduct);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to create data in database!");
            }

        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {

            try
            {
              var productToDelete = await _teknikButik.GetSingel(id);
                if(productToDelete == null)
                {
                    return NotFound($"Product with {id} Not found to delete!");
                }

                return await _teknikButik.Delete(id);
            }

            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to delete from database");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product pro)
        {
            try
            {
                if( id != pro.ProductId)
                {
                    return BadRequest("Product ID dosent match!");
                }

               var productToUpdate = await _teknikButik.GetSingel(id);
                if (productToUpdate == null)
                {
                    return NotFound($"Product with ID {id} Not Founded ");
                }

                return await _teknikButik.Update(pro);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update to database");
            }
        }
        
    }

   
}
