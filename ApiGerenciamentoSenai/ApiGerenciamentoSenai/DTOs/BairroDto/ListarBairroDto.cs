namespace ApiGerenciamentoSenai.DTOs.BairroDto
{
    public class ListarBairroDto
    {
        public Guid BairroId { get; set; }
        public string Nome {  get; set; }
        public Guid CidadeId { get; set; }
    }
}
