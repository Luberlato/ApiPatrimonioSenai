using ApiGerenciamentoSenai.Domains;

namespace ApiGerenciamentoSenai.Interfaces
{
    public interface IAreaRepository
    {
        List<Area> Listar();
        Area ObterPorId(Guid id);
        Area ObterPorNome(string Nome);
        void Adicionar(Area area);
        public void Atualizar(Area area);


    }
}
