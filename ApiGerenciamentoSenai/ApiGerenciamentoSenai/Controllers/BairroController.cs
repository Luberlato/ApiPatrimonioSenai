using ApiGerenciamentoSenai.Application.Services;
using ApiGerenciamentoSenai.DTOs.BairroDto;
using ApiGerenciamentoSenai.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGerenciamentoSenai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BairroController : ControllerBase
    {
        private readonly BairroService _service;

        public BairroController(BairroService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ListarBairroDto>> Listar()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<ListarBairroDto> ObterPorId(Guid id)
        {
            try
            {
                return Ok(_service.ObterPorId(id));
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{nome}/{id}")]
        public ActionResult<ListarBairroDto> ObterPorNome(string nome, Guid id)
        {
            try
            {
                return Ok(_service.ObterPorNome(id, nome));
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<ListarBairroDto> Adicionar(CriarBairroDto bairroDto)
        {
            try
            {
                return StatusCode(201, _service.Adicionar(bairroDto));
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(Guid id, CriarBairroDto bairroDto)
        {
            try
            {
                _service.Atualizar(id, bairroDto);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
