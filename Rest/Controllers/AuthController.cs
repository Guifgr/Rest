using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rest.Business;
using Rest.Data.VO;

namespace Rest.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class AuthController : Controller
    {
        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }
        
        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {
            if (user == null) return BadRequest("Invalid client request");
            var token = _loginBusiness.ValidateCredential(user);
            if (token == null) return Unauthorized();
            return Ok(token);
        }
        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVo)
        {
            if (tokenVo == null) return BadRequest("Invalid client request");
            tokenVo = _loginBusiness.RefreshCredential(tokenVo);
            if (tokenVo == null) return BadRequest("Invalid client request");
            return Ok(tokenVo);
        }
        [HttpGet]
        [Authorize("Bearer")]
        [Route("revoke")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
            Console.WriteLine(username);
            var result = _loginBusiness.RevokeToken(username);
            if (!result) return BadRequest("Invalid client request");
            return NoContent();
        }
    }
}

