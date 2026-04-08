using ApiGerenciamentoSenai.Application.Services;
using ApiGerenciamentoSenai.DTOs.AuthDto;
using ApiGerenciamentoSenai.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace ApiGerenciamentoSenai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _service;

        public AuthController(AuthService service)
        {
            _service = service;
        }


        [HttpPost("login")]
        public ActionResult<TokenDto> Login(LoginDto login)
        {
            try
            {
                return Ok(_service.Login(login));
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPatch("trocar-senha")]
        public ActionResult TrocarPrimeiraSenha(TrocarPrimeiraSenhaDto dto)
        {
            try
            {
                string usuarioIdClaim = User.FindFirst(ClaimTypes
                    .NameIdentifier)?.Value;

                if (string.IsNullOrWhiteSpace(usuarioIdClaim))
                    return Unauthorized("Usuário não autenticado");

                Guid usuarioId = Guid.Parse(usuarioIdClaim);

                return NoContent();
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
