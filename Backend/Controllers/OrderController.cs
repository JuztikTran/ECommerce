using Backend.IRepository;
using BusinessObjetcs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers
{
    [Route("odata/order")]
    [ApiController]
    public class OrderController : ODataController
    {
        private IOrderRepository _repo;

        public OrderController(IOrderRepository repo)
        {
            _repo = repo ?? throw new ArgumentException(nameof(_repo));
        }

        [HttpGet]
        [EnableQuery]
        public ActionResult<IEnumerable<Order>> GetAll()
        {
            var list = _repo.GetAll();
            return Ok(list.AsQueryable());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetOne([FromRoute] string id)
        {
            var response = await _repo.GetOne(id);
            return response == null ? NotFound() : Ok(response);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Order request)
        {
            var response = await _repo.Create(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] Order request)
        {
            if (id.IsNullOrEmpty() || id != request.ID)
                return BadRequest();
            var response = await _repo.Update(request);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
