using ApiGerenciamentoSenai.Application.Services;
using ApiGerenciamentoSenai.DTOs.CidadeDto;
using ApiGerenciamentoSenai.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGerenciamentoSenai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly CidadeService _service;

        public CidadeController(CidadeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ListarCidadeDto>> Listar()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<ListarCidadeDto> ObterPorId(Guid id)
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

        [HttpGet("{nome}/{estado}")]
        public ActionResult<ListarCidadeDto> ObterPorNomeEEestado(string nome, string estado)
        {
            try
            {
                return Ok(_service.ObterPorNomeEEstado(nome, estado));
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<ListarCidadeDto> Adicionar(CriarCidadeDto cidadeDto)
        {
            try
            {
                ListarCidadeDto cidade = _service.Adicionar(cidadeDto);
                return StatusCode(201, cidade);
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ListarCidadeDto> Atualizar(CriarCidadeDto cidade, Guid id)
        {
            try
            {
                ListarCidadeDto cidadeDto = _service.Atualizar(cidade, id);

                return StatusCode(204, cidadeDto);
            }

            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
