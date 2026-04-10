using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.DTOs.PatrimonioDto;

namespace ApiGerenciamentoSenai.Application.Conversoes
{
    public class PatrimonioParaDto
    {
        public static ListarPatrimonioDto ConverterParaDto(Patrimonio patrimonio)
        {
            return new ListarPatrimonioDto
            {
                IdPatrimonio = patrimonio.PatrimonioID,
                Denominacao = patrimonio.Denominacao,
                NumeroPatrimonio = patrimonio.NumeroPatrimonio,
                Valor = patrimonio.Valor,
                Imagem = patrimonio.Imagem,
                LocalizacaoId = patrimonio.LocalizacaoID,
                StatusPatrimonioId = patrimonio.StatusPatrimonioID
            };
        }
    }
}
