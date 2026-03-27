using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.DTOs.LocalizacaoDto;

namespace ApiGerenciamentoSenai.Application.Conversoes
{
    public class LocalizacaoParaDto
    {
        public static ListarLocalizacaoDto ConverterParaDto(Localizacao localizacao)
        {
            ListarLocalizacaoDto localizacaoDto = new ListarLocalizacaoDto
            {
                LocalizacaoId = localizacao.LocalizacaoID,
                NomeLocal = localizacao.NomeLocal,
                LocalSAP = localizacao.LocalSAP,
                DescricaoSAP = localizacao.DescricaoSAP,
                AreaID = localizacao.AreaID,
            };
            return localizacaoDto;
        }

        public static Localizacao ConveterParaDtoCriar(CriarLocalizacaoDto localDto)
        {
            Localizacao local = new Localizacao
            {
                NomeLocal = localDto.NomeLocal,
                LocalSAP = localDto.LocalSAP,
                DescricaoSAP = localDto.DescricaoSAP,
                AreaID = localDto.AreaID,
            };
            return local;
        }
    }
}
