using ApiGerenciamentoSenai.Application.Services;
using ApiGerenciamentoSenai.DTOs.StatusPatrimonioDto;
using ApiGerenciamentoSenai.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGerenciamentoSenai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusPatrimonioController : ControllerBase
    {
        private readonly StatusPatrimonioService _service;


        public StatusPatrimonioController(StatusPatrimonioService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<ListarStatusPatrimonioDto>> Listar()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult ObterPorId(Guid id)
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

        [HttpGet("nome/{nome}")]
        public ActionResult<ListarStatusPatrimonioDto> ObterPorNome(string nome)
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
        public ActionResult<ListarStatusPatrimonioDto> Adicionar(CriarStatusPatrimonioDto dto)
        {
            try
            {
                return StatusCode(201, _service.Adicionar(dto));
            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(Guid id, CriarStatusPatrimonioDto dto)
        {
            try
            {
                _service.Atualizar(dto, id);

                return NoContent();
            }

            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
