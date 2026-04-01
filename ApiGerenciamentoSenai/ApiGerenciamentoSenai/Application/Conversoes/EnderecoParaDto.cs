using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.DTOs.EnderecoDto;

namespace ApiGerenciamentoSenai.Application.Conversoes
{
    public class EnderecoParaDto
    {
        public static ListarEnderecoDto ConverterParaDto (Endereco endereco)
        {
            return new ListarEnderecoDto
            {
                EnderecoID = endereco.EnderecoID,
                Logradouro = endereco.Logradouro,
                Numero = endereco.Numero,
                Complemento = endereco.Complemento,
                BairroID = endereco.BairroID,
                CEP = endereco.CEP
            };

        }

        public static Endereco ConverterParaDtoCriar(CriarEnderecoDto enderecoDto)
        {
            return new Endereco
            {
                Logradouro = enderecoDto.Logradouro,
                Complemento = enderecoDto.Complemento,
                CEP = enderecoDto.CEP,
                Numero = enderecoDto.Numero,
                BairroID = enderecoDto.BairroID
            };
        }
    }
}
