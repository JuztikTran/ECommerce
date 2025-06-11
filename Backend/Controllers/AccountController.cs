using Backend.IRepository;
using BusinessObjetcs.DTOs;
using BusinessObjetcs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Backend.Controllers
{
    [Route("odata/account")]
    [ApiController]
    public class AccountController : ODataController
    {
        private IAccountRepository _repo;

        public AccountController(IAccountRepository repo)
        {
            _repo = repo ?? throw new ArgumentException(nameof(_repo));
        }

        [HttpGet]
        [EnableQuery]
        public ActionResult<IEnumerable<Account>> GetAll()
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

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] DTOAuth request)
        {
            var response = await _repo.SignIn(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] Account request)
        {
            var response = await _repo.SignUp(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPut("forgot-pass")]
        public async Task<IActionResult> ForgotPass([FromBody] DTOAuth request)
        {
            var response = await _repo.ForgotPass(request);
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var response = await _repo.Delete(id);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
