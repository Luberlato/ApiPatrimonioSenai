using ApiGerenciamentoSenai.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiGerenciamentoSenai.DTOs.AreaDto;
using ApiGerenciamentoSenai.Exceptions;

namespace ApiGerenciamentoSenai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly AreaService _service;

        public AreaController (AreaService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ListarAreaDto>> Listar()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<ListarAreaDto> ObterPorId(Guid id)
        {
            try
            {
                ListarAreaDto area = _service.ObterPorId(id);
                return Ok(area);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPost]
        public ActionResult<ListarAreaDto> Adicionar(CriarAreaDto areaDto)
        {
            try
            {
                _service.Adicionar(areaDto);
                return StatusCode(201, areaDto);

            }
            catch(DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public ActionResult<ListarAreaDto> Atualizar(CriarAreaDto areaDto, Guid id)
        {
            try
            {
                ListarAreaDto area = _service.Atualizar(areaDto, id);
                return StatusCode(204, area);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
