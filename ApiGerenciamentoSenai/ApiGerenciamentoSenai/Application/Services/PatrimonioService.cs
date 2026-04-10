using ApiGerenciamentoSenai.Application.Conversoes;
using ApiGerenciamentoSenai.DTOs.PatrimonioDto;
using ApiGerenciamentoSenai.Interfaces;
using ApiGerenciamentoSenai.Exceptions;

namespace ApiGerenciamentoSenai.Application.Services
{
    public class PatrimonioService
    {
        private readonly IPatrimonioRepository _repository;

        public PatrimonioService(IPatrimonioRepository repository)
        {
            _repository = repository;
        }

        public List<ListarPatrimonioDto> Listar()
        {
            return _repository.Listar().Select(p => PatrimonioParaDto.ConverterParaDto(p)).ToList();
        }

        public ListarPatrimonioDto ObterPorId(Guid id)
        {
            if (_repository.ObterPorId(id) == null)
                throw new DomainException("Patrimonio não encontrado");

            return PatrimonioParaDto.ConverterParaDto(_repository.ObterPorId(id));
        }

        public ListarPatrimonioDto BuscarPorNumeroPatrimonio(string numeroPatrimonio, Guid? patrimonioId = null)
        {
            if (_repository.BuscarPorNumeroPatrimonio(numeroPatrimonio, patrimonioId) == null)
                throw new DomainException("Patrimonio não econtrado");

            return PatrimonioParaDto.ConverterParaDto(_repository.BuscarPorNumeroPatrimonio(numeroPatrimonio, patrimonioId));
        }

        public ListarPatrimonioDto Adicionar(


    }
}
