using Backend.IRepository;
using BusinessObjetcs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers
{
    [Route("odata/product")]
    [ApiController]
    public class ProductController : ODataController
    {
        private IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo ?? throw new ArgumentException(nameof(_repo));
        }

        [HttpGet]
        [EnableQuery]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var list = _repo.GetAllProduct();
            return Ok(list.AsQueryable());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetOne([FromRoute] string id)
        {
            var response = await _repo.GetOneProduct(id);
            return response == null ? NotFound() : Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Product request)
        {
            var response = await _repo.CreateProduct(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] Product request)
        {
            if (id.IsNullOrEmpty() || id != request.ID)
                return BadRequest();
            var response = await _repo.UpdateProduct(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("forgot-pass")]
        public async Task<IActionResult> ForgotPass([FromRoute] string id)
        {
            var response = await _repo.DeleteProduct(id);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
