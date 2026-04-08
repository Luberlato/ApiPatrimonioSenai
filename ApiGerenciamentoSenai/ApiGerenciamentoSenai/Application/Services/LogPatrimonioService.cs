using ApiGerenciamentoSenai.DTOs.LogPatrimonioDto;
using ApiGerenciamentoSenai.Interfaces;

namespace ApiGerenciamentoSenai.Application.Services
{
    public class LogpatrimonioService
    {
        private readonly ILogPatrimonioRepository _repository;

        public LogpatrimonioService(ILogPatrimonioRepository repository)
        {
            _repository = repository;
        }

        public List<ListarLogPatrimonioDto> Listar()
        {
            return _repository.Listar().Select(l => new ListarLogPatrimonioDto
            {
                LogPatrimonioID = l.LogPatrimonioID,
                DataTransferencia = l.DataTransferencia,
                PatrimonioId = l.PatrimonioID,
                DenominacaoPatrimonio = l.Patrimonio.Denominacao,
                TipoAlteracao = l.TipoAlteracao.NomeTipo,
                StautusPatrimonio = l.StatusPatrimonio.NomeStatus,
                Usuario = l.Usuario.Nome,
                Local = l.Localizacao.NomeLocal
            })
                .ToList();
        }

        public List<ListarLogPatrimonioDto> BuscarPorPatrimonio(Guid PatrimonioId)
        {
            return _repository.BuscarPorPatrimonio(PatrimonioId).Select(l => new ListarLogPatrimonioDto
            {
                LogPatrimonioID = l.LogPatrimonioID,
                DataTransferencia = l.DataTransferencia,
                PatrimonioId = l.PatrimonioID,
                DenominacaoPatrimonio = l.Patrimonio.Denominacao,
                TipoAlteracao = l.TipoAlteracao.NomeTipo,
                StautusPatrimonio = l.StatusPatrimonio.NomeStatus,
                Usuario = l.Usuario.Nome,
                Local = l.Localizacao.NomeLocal
            })
                .ToList();
        }

    }
}
