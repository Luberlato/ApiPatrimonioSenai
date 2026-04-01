using ApiGerenciamentoSenai.Application.Services;
using ApiGerenciamentoSenai.DTOs.EnderecoDto;
using ApiGerenciamentoSenai.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGerenciamentoSenai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _service;

        public EnderecoController(EnderecoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ListarEnderecoDto>> Listar()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<ListarEnderecoDto> ObterPorId(Guid id)
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

        [HttpGet("{lugradouro}/{bairroId}/{numero}")]
        public ActionResult<ListarEnderecoDto> BuscarPorLogradouroENumero(string lugradouro, Guid bairroId, int? numero)
        {
            try
            {
                return Ok(_service.BuscarPorLogradouroENumero(lugradouro, bairroId, numero));
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<ListarEnderecoDto> Adicionar(CriarEnderecoDto enderecoDto)
        {
            try
            {
                return StatusCode(201, _service.Adicionar(enderecoDto));
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(CriarEnderecoDto enderecoDto, Guid id)
        {
            try
            {
                _service.Atuaizar(enderecoDto, id);

                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
