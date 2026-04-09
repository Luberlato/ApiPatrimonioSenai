using Microsoft.Identity.Client;

namespace ApiGerenciamentoSenai.DTOs.PatrimonioDto
{
    public class ListarPatrimonioDto
    {
        public Guid IdPatrimonio {  get; set; }
        public string Denominacao { get; set; }
        public string NumeroPatrimonio { get; set; }
        public decimal? Valor {  get; set; }
        public string? Imagem {  get; set; }
        public Guid LocalizacaoId { get; set; }
        public Guid StatusPatrimonioId { get; set; }
    }
}
