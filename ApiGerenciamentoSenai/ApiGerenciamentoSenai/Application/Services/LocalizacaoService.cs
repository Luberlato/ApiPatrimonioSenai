using ApiGerenciamentoSenai.DTOs.LocalizacaoDto;
using ApiGerenciamentoSenai.Interfaces;
using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.Application.Conversoes;
using ApiGerenciamentoSenai.Exceptions;
using ApiGerenciamentoSenai.Application.Regras;

namespace ApiGerenciamentoSenai.Application.Services
{
    public class LocalizacaoService
    {
        private readonly ILocalizacaoRepository _repository;

        public LocalizacaoService(ILocalizacaoRepository repository)
        {
            _repository = repository;
        }

        public List<ListarLocalizacaoDto> Listar()
        {
            return _repository.Listar().Select(l => LocalizacaoParaDto
            .ConverterParaDto(l))
                .ToList();
        }

        public ListarLocalizacaoDto ObterPorId(Guid id)
        {
            Localizacao? local = _repository.ObterPorId(id);
            if (local == null)
                throw new DomainException("Localização não econtrada");

            

            ListarLocalizacaoDto localDto = LocalizacaoParaDto.ConverterParaDto(local);

            return localDto;
        }

        public ListarLocalizacaoDto Adicionar(CriarLocalizacaoDto localDto)
        {
            Validacoes.ValidarNome(localDto.NomeLocal);

            if (!_repository.AreaExiste(localDto.AreaID))
                throw new DomainException("Ára informada não existe");

            Localizacao? localExistente = _repository.ObterPorNome(localDto.NomeLocal);

            if (localExistente != null)
                throw new DomainException("Esse local já existe");

            Localizacao local = LocalizacaoParaDto.ConveterParaDtoCriar(localDto);

            _repository.Adicionar(local);

            return LocalizacaoParaDto.ConverterParaDto(local);
        }

        public ListarLocalizacaoDto Atualizar(CriarLocalizacaoDto localDto, Guid id)
        {
            Localizacao? localBanco = _repository.ObterPorId(id); 
            Validacoes.ValidarNome(localDto.NomeLocal);

            if (!_repository.AreaExiste(localDto.AreaID))
                throw new DomainException("Área informada não existe");

            Localizacao? localExistente = _repository.ObterPorNome(localDto.NomeLocal);

            if (localExistente != null)
                throw new DomainException("Esse local já existe");



            Localizacao local = LocalizacaoParaDto.ConveterParaDtoCriar(localDto);
            _repository.Atualizar(id, local);

            return LocalizacaoParaDto.ConverterParaDto(local);
        }


    }
}
