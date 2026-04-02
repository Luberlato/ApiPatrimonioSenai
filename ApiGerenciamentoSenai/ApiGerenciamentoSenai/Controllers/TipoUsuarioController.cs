using ApiGerenciamentoSenai.Application.Services;
using ApiGerenciamentoSenai.DTOs.TipoUsuarioDto;
using ApiGerenciamentoSenai.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGerenciamentoSenai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly TipoUsuarioService _service;

        public TipoUsuarioController(TipoUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ListarTipoUsuarioDto>> Listar()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<ListarTipoUsuarioDto> ObterPorId(Guid id)
        {
            try
            {
                return Ok(_service.ObterPorId(id));
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{nome}")]
        public ActionResult<ListarTipoUsuarioDto> ObterPorNome(string nome)
        {
            try
            {
                return Ok(_service.ObterPorNome(nome));
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<ListarTipoUsuarioDto> Adiconar(CriarTipoUsuarioDto criarTipoUsuarioDto)
        {
            try
            {
                return StatusCode(201, _service.Adiconar(criarTipoUsuarioDto));
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(CriarTipoUsuarioDto tipoUsuarioDto, Guid id)
        {
            try
            {
                _service.Atualizar(tipoUsuarioDto, id);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
