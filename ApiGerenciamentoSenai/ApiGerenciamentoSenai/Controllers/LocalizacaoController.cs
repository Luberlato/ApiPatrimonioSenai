using ApiGerenciamentoSenai.Application.Services;
using ApiGerenciamentoSenai.DTOs.AreaDto;
using ApiGerenciamentoSenai.DTOs.LocalizacaoDto;
using ApiGerenciamentoSenai.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGerenciamentoSenai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacaoController : ControllerBase
    {
        private readonly LocalizacaoService _service;

        public LocalizacaoController(LocalizacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ListarLocalizacaoDto>> Listar()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<ListarLocalizacaoDto> ObterPorId(Guid id)
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

        [HttpPost]
        public ActionResult<ListarLocalizacaoDto> Adicionar(CriarLocalizacaoDto localDto)
        {
            try
            {
                _service.Adicionar(localDto);
                return StatusCode(201, localDto);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ListarLocalizacaoDto> Atualizar(CriarLocalizacaoDto areaDto, Guid id)
        {
            try
            {
                ListarLocalizacaoDto area = _service.Atualizar(areaDto, id);
                return StatusCode(204, area); 
            }

            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
