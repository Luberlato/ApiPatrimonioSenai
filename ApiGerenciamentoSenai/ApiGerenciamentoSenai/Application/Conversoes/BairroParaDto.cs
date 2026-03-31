using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.DTOs.BairroDto;

namespace ApiGerenciamentoSenai.Application.Conversoes
{
    public class BairroParaDto
    {
        public static ListarBairroDto ConverterParaDto(Bairro bairro)
        {
            return new ListarBairroDto
            {
                BairroId = bairro.BairroID,
                Nome = bairro.NomeBairro,
                CidadeId = bairro.CidadeID

            };
        }

        public static Bairro ConverterParaDtoCriar(CriarBairroDto bairroDto)
        {
            return new Bairro
            {
                NomeBairro = bairroDto.NomeBairro,
                CidadeID = bairroDto.CidadeId
            };
        }
    }
}
