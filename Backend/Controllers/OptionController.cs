using Backend.IRepository;
using BusinessObjetcs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers
{
    [Route("odata/product-option")]
    [ApiController]
    public class OptionController : ODataController
    {
        private IProductRepository _repo;

        public OptionController(IProductRepository repo)
        {
            _repo = repo ?? throw new ArgumentException(nameof(_repo));
        }

        [HttpGet]
        [EnableQuery]
        public ActionResult<IEnumerable<ProductOption>> GetAll()
        {
            var list = _repo.GetAllOption();
            return Ok(list.AsQueryable());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetOne([FromRoute] string id)
        {
            var response = await _repo.GetOneOption(id);
            return response == null ? NotFound() : Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProductOption request)
        {
            var response = await _repo.CreateOption(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] ProductOption request)
        {
            if (id.IsNullOrEmpty() || id != request.ID)
                return BadRequest();
            var response = await _repo.UpdateOption(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var response = await _repo.DeleteOption(id);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
