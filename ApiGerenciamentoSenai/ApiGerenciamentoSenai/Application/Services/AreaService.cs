using ApiGerenciamentoSenai.Application.Conversoes;
using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.DTOs.AreaDto;
using ApiGerenciamentoSenai.Interfaces;
using ApiGerenciamentoSenai.Exceptions;
using ApiGerenciamentoSenai.Application.Regras;

namespace ApiGerenciamentoSenai.Application.Services
{
    public class AreaService
    {
        private readonly IAreaRepository _repository;

        public AreaService(IAreaRepository repository)
        {
            _repository = repository;
        }

        public List<ListarAreaDto> Listar()
        {
            List<Area> areas = _repository.Listar();
            List<ListarAreaDto> areasDto = areas.Select(a => AreaParaDto.ConverterParaDto(a)).ToList();
            return areasDto;
        }

        public ListarAreaDto ObterPorId(Guid id)
        { 
            Area? area = _repository.ObterPorId(id);

            if (area == null)
            {
                throw new DomainException("Área não encontrada0");
            }

            return AreaParaDto.ConverterParaDto(area);
        }

        public ListarAreaDto Adicionar(CriarAreaDto areaDto)
        {
            Validacoes.ValidarNome(areaDto.NomeArea);

            Area areaExistente = _repository.ObterPorNome(areaDto.NomeArea);

            if (areaExistente != null)
                throw new DomainException("A área já existe");

            Area area = AreaParaDto.ConverterDtoCriar(areaDto);

            _repository.Adicionar(area);

            return AreaParaDto.ConverterParaDto(area);
        }

        public ListarAreaDto Atualizar(CriarAreaDto areaDto, Guid id)
        {
            Area? areaBanco = _repository.ObterPorId(id);

            if (areaBanco == null)
                throw new DomainException("Area não encontrada");

            Area? areaExistente = _repository.ObterPorNome(areaDto.NomeArea);

            if (areaExistente != null)
                throw new DomainException("Essa área já existe");
                    

            Area area = AreaParaDto.ConverterDtoCriar(areaDto);

            areaBanco.NomeArea = area.NomeArea;

            _repository.Atualizar(area);

            return AreaParaDto.ConverterParaDto(area);

        }
    }
}
