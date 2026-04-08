using ApiGerenciamentoSenai.Application.Services;
using ApiGerenciamentoSenai.DTOs.LogPatrimonioDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGerenciamentoSenai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogPatrimonioController : ControllerBase
    {
        private readonly LogpatrimonioService _service;

        public LogPatrimonioController(LogpatrimonioService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<ListarLogPatrimonioDto>> Listar()
        {
            return Ok(_service.Listar());
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<List<ListarLogPatrimonioDto>> BuscarPorPatrimonio(Guid id)
        {
            return Ok(_service.BuscarPorPatrimonio(id));
        }

    }
}
