using ApiGerenciamentoSenai.Application.Conversoes;
using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.DTOs.BairroDto;
using ApiGerenciamentoSenai.Interfaces;
using ApiGerenciamentoSenai.Exceptions;

using ApiGerenciamentoSenai.Application.Regras;

namespace ApiGerenciamentoSenai.Application.Services
{
    public class BairroService
    {
        private readonly IBairroRepository _repository;

        public BairroService(IBairroRepository repository)
        {
            _repository = repository;
        }

        public List<ListarBairroDto> Listar()
        {
            return _repository.Listar().Select(b => BairroParaDto.ConverterParaDto(b)).ToList();
        }

        public ListarBairroDto ObterPorId(Guid id)
        {
            Bairro? bairro = _repository.ObterPorId(id);

            if (bairro == null)
                throw new DomainException("Bairro não encontrado");

            return BairroParaDto.ConverterParaDto(bairro);
        }

        public ListarBairroDto ObterPorNome(Guid cidadeID, string nome)
        {
            if (!_repository.CidadeExiste(cidadeID))
                throw new DomainException("Cidade não existe");

            Bairro? bairro = _repository.ObterPorNome(cidadeID, nome);

            return BairroParaDto.ConverterParaDto(bairro);
        }

        public ListarBairroDto Adicionar(CriarBairroDto bairroDto)
        {
            Validacoes.ValidarNome(bairroDto.NomeBairro);

            Bairro bairro = BairroParaDto.ConverterParaDtoCriar(bairroDto);

            _repository.Adicionar(bairro);

            return BairroParaDto.ConverterParaDto(bairro);
        }

        public void Atualizar(Guid id, CriarBairroDto bairroDto)
        {
            Bairro? bairroBanco = _repository.ObterPorId(id);

            if (bairroBanco == null)
                throw new DomainException("Bairro não existe");

            bairroBanco.NomeBairro = bairroDto.NomeBairro;
            bairroBanco.CidadeID = bairroDto.CidadeId;

            _repository.Atualizar(bairroBanco);
        }
    }
}
