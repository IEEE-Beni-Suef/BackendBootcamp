using IEEEProject.DTO;
using IEEEProject.IReposatory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IEEEProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Products : ControllerBase
    {
        private readonly IProductRepo productReposatory;
        public Products(IProductRepo productReposatory) => this.productReposatory = productReposatory;
        

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            return Ok(productReposatory.GetAllProduct());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetProductWithId()
        {
            bool f =int.TryParse( HttpContext.Request.RouteValues["id"].ToString(),out int id);
            if (!f)
                return BadRequest();
           return Ok( productReposatory.GetProductWithId(id));
        }
        [HttpPost]
        public IActionResult AddProduct(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                if (productReposatory.AddProduct(product))
                {
                    return Ok("Product added successufully");
                }
            }
            return BadRequest();
        }
        [HttpPut("{id:int}")]
        public IActionResult Update(ProductDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(dto);
            }
            int id = int.Parse(HttpContext.Request.RouteValues["id"].ToString());
            if (!productReposatory.Update(id, dto))
                return NotFound("product not found");
            return Ok("Product Updated successfully");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete()
        {
            int id = int.Parse(HttpContext.Request.RouteValues["id"].ToString());
            if (productReposatory.Delete(id))
            {
                return Ok("Product deleted successufully");
            }
            return NotFound("product not found");
        }
    }
}
