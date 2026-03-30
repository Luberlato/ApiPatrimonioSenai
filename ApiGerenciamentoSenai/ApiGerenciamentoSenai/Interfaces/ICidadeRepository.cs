using ApiGerenciamentoSenai.Domains;

namespace ApiGerenciamentoSenai.Interfaces
{
    public interface ICidadeRepository
    {
        List<Cidade> Listar();
        Cidade ObterPorId(Guid id);
        Cidade ObterPorNomeEEstado(string nomeCidade, string nomeEstado);
        void Adicionar(Cidade cidade);
        void Atualizar(Cidade cidade);
        
    }
}
