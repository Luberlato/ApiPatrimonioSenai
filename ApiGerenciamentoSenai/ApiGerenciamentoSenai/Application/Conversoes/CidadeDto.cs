using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.DTOs.CidadeDto;

namespace ApiGerenciamentoSenai.Application.Conversoes
{
    public class CidadeDto
    {
        public static ListarCidadeDto CidadeParaDto(Cidade cidade)
        {
            ListarCidadeDto cidadeDto = new ListarCidadeDto
            {
                NomeCidade = cidade.NomeCidade,
                CidadeId = cidade.CidadeID,
                NomeEstado = cidade.Estado
            };

            return cidadeDto;
        }

        public static Cidade ParaDtoCriar(CriarCidadeDto cidadeDto)
        {
            Cidade cidade = new Cidade
            {
                NomeCidade = cidadeDto.NomeCidade,
                Estado = cidadeDto.NomeEstado
            };

            return cidade;
        }
    }
}
