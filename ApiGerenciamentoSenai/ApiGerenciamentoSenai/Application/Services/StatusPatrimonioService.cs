using ApiGerenciamentoSenai.Application.Conversoes;
using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.DTOs.StatusPatrimonioDto;
using ApiGerenciamentoSenai.Interfaces;
using ApiGerenciamentoSenai.Exceptions;

namespace ApiGerenciamentoSenai.Application.Services
{
    public class StatusPatrimonioService
    {
        private readonly IStatusPatrimonioRepository _repository;

        public StatusPatrimonioService(IStatusPatrimonioRepository repository)
        {
            _repository = repository;
        }

        public List<ListarStatusPatrimonioDto> Listar()
        {
            return _repository.Listar().Select(s => StatusPatrimonioParaDto.StatusParaDto(s)).ToList();
        }

        public ListarStatusPatrimonioDto ObterPorId(Guid id)
        {
            StatusPatrimonio status = _repository.ObterPorId(id);

            if (status == null)
                throw new DomainException("Status não encontrado");

            return StatusPatrimonioParaDto.StatusParaDto(status);    
        }

        public ListarStatusPatrimonioDto ObterPorNome(string nome)
        {

            StatusPatrimonio status = _repository.ObterPorNome(nome);

            if (status == null)
                throw new DomainException("Status não encontrado");

            return StatusPatrimonioParaDto.StatusParaDto(status);
        }

        public ListarStatusPatrimonioDto Adicionar (CriarStatusPatrimonioDto statusDto)
        {
            StatusPatrimonio? statusBanco = _repository.ObterPorNome(statusDto.Nome);

            if (statusBanco != null)
                throw new DomainException("Esse status já existe");

            _repository.Adicionar(StatusPatrimonioParaDto.StatusParaDtoCriar(statusDto));

            return StatusPatrimonioParaDto.StatusParaDto(StatusPatrimonioParaDto.StatusParaDtoCriar(statusDto));
        }

        public void Atualizar(CriarStatusPatrimonioDto statusDto, Guid id)
        {
            StatusPatrimonio? statusBanco = _repository.ObterPorId(id);

            if (statusBanco == null)
                throw new DomainException("Status Patrimonio não encontrado");

            statusBanco.NomeStatus = statusDto.Nome;

            _repository.Atualizar(statusBanco);
        }
    }
}
