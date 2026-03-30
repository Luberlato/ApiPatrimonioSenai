using ApiGerenciamentoSenai.Application.Conversoes;
using ApiGerenciamentoSenai.DTOs.CidadeDto;
using ApiGerenciamentoSenai.Interfaces;
using ApiGerenciamentoSenai.Exceptions;
using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.Application.Regras;

namespace ApiGerenciamentoSenai.Application.Services
{
    public class CidadeService
    {
        private readonly ICidadeRepository _repository;

        public CidadeService(ICidadeRepository repository)
        {
            _repository = repository;
        }

        public List<ListarCidadeDto> Listar()
        {
            return _repository.Listar().Select(c => CidadeDto.CidadeParaDto(c)).ToList();
        }

        public ListarCidadeDto ObterPorId(Guid id)
        {
            ListarCidadeDto? cidadeDto =  CidadeDto.CidadeParaDto(_repository.ObterPorId(id));

            if (cidadeDto == null)
                throw new DomainException("Cidade não encotrada");
            return cidadeDto;
        }

        public ListarCidadeDto ObterPorNomeEEstado(string nomeCidade, string nomeEstado)
        {
            Cidade? cidade = _repository.ObterPorNomeEEstado(nomeCidade, nomeEstado);

            if (cidade == null)
                throw new DomainException("Cidade não encotrada");

            return CidadeDto.CidadeParaDto(cidade);
        }

        public ListarCidadeDto Adicionar(CriarCidadeDto criarCidadeDto)
        {
            Validacoes.ValidarNome(criarCidadeDto.NomeCidade);
            Validacoes.ValidarNome(criarCidadeDto.NomeEstado);


            Cidade? cidadeBanco = _repository.ObterPorNomeEEstado(criarCidadeDto.NomeCidade, criarCidadeDto.NomeEstado);

            if (cidadeBanco != null)
                throw new DomainException("Essa cidade já existe");

            _repository.Adicionar(CidadeDto.ParaDtoCriar(criarCidadeDto));

            return CidadeDto.CidadeParaDto(CidadeDto.ParaDtoCriar(criarCidadeDto));
        }

        public ListarCidadeDto Atualizar(CriarCidadeDto cidade, Guid CidadeId)
        {
            Cidade? cidadeBanco = _repository.ObterPorId(CidadeId);

            if (cidadeBanco == null)
                throw new DomainException("Cidade não encontrada");

            cidadeBanco.NomeCidade = cidade.NomeCidade;
            cidadeBanco.Estado = cidade.NomeEstado;

            _repository.Atualizar(cidadeBanco);

            return CidadeDto.CidadeParaDto(cidadeBanco);
        }
    }
}
