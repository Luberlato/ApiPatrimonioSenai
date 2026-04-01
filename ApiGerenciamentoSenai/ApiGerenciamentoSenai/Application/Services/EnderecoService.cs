using ApiGerenciamentoSenai.Application.Conversoes;
using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.DTOs.EnderecoDto;
using ApiGerenciamentoSenai.Interfaces;
using ApiGerenciamentoSenai.Exceptions;
using ApiGerenciamentoSenai.Application.Regras;

namespace ApiGerenciamentoSenai.Application.Services
{
    public class EnderecoService
    {
        private readonly IEnderecoRepository _repository;

        public EnderecoService(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        public List<ListarEnderecoDto> Listar()
        {
            return _repository.Listar().Select(c => EnderecoParaDto.ConverterParaDto(c)).ToList(); 
        }

        public ListarEnderecoDto ObterPorId(Guid id)
        {
            return EnderecoParaDto.ConverterParaDto(_repository.ObterPorId(id));
        }

        public ListarEnderecoDto BuscarPorLogradouroENumero(string logradouro, Guid bairroId, int? numero)
        {
            ListarEnderecoDto? enderecoDto = EnderecoParaDto.ConverterParaDto(_repository.BuscarPorLogradouroENumero(logradouro, bairroId, numero));

            if (enderecoDto == null)
                throw new DomainException("Endereco não encontrado");

            return enderecoDto;
        }

        public ListarEnderecoDto Adicionar(CriarEnderecoDto enderecoDto)
        {
            Validacoes.ValidarNome(enderecoDto.Logradouro);
            
            Endereco endereco = EnderecoParaDto.ConverterParaDtoCriar(enderecoDto);

            _repository.Adicionar(endereco);

            return EnderecoParaDto.ConverterParaDto(endereco);
        }

        public void Atuaizar(CriarEnderecoDto enderecoDto, Guid Id)
        {
            Endereco? enderecoBanco = _repository.ObterPorId(Id);

            Validacoes.ValidarNome(enderecoDto.Logradouro);

            if (enderecoBanco == null)
                throw new DomainException("Endereco não encontrado");

            enderecoBanco.Logradouro = enderecoDto.Logradouro;
            enderecoBanco.CEP = enderecoDto.CEP;
            enderecoBanco.Complemento = enderecoDto.Complemento;
            enderecoBanco.BairroID = enderecoDto.BairroID;

            _repository.Atualizar(enderecoBanco);

        }

    }
}
