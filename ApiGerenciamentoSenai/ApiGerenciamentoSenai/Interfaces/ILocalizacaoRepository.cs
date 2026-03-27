using ApiGerenciamentoSenai.Domains;

namespace ApiGerenciamentoSenai.Interfaces
{
    public interface ILocalizacaoRepository
    {
        List<Localizacao> Listar();
        Localizacao ObterPorId(Guid id);
        Localizacao ObterPorNome(string nome);
        void Adicionar(Localizacao local);
        void Atualizar(Guid id, Localizacao local);
        bool AreaExiste(Guid AreaId);
        
    }
}
