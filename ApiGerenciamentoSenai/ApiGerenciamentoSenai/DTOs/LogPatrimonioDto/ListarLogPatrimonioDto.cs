namespace ApiGerenciamentoSenai.DTOs.LogPatrimonioDto
{
    public class ListarLogPatrimonioDto
    {
        public Guid LogPatrimonioID { get; set; }
        public DateTime DataTransferencia { get; set; }
        public Guid PatrimonioId { get; set; }
        public string DenominacaoPatrimonio { get; set; } = string.Empty;
        public string TipoAlteracao { get; set; } = string.Empty;
        public string StautusPatrimonio { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public string Local { get; set; } = string.Empty;
    }
}
