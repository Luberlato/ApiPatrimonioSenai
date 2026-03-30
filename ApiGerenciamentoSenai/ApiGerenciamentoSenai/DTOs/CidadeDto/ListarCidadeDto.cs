using ApiGerenciamentoSenai.Domains;

namespace ApiGerenciamentoSenai.DTOs.CidadeDto
{
    public class ListarCidadeDto
    {
        public Guid CidadeId {  get; set; }
        public string NomeCidade { get; set; }
        public string NomeEstado { get; set; }
        
    }
}
