using ApiGerenciamentoSenai.Contexts;
using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.Interfaces;

namespace ApiGerenciamentoSenai.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly GestaoPatrimoniosContext _context;

        public AreaRepository(GestaoPatrimoniosContext context)
        {
            _context = context;
        }

        public List<Area> Listar()
        {
            return _context.Area.OrderBy(area => area.NomeArea).ToList();
        }

        public Area ObterPorId(Guid id)
        {
            return _context.Area.Find(id);
        }

        public Area ObterPorNome(string Nome)
        {
            return _context.Area.FirstOrDefault(area => area.NomeArea.ToLower() == Nome.ToLower());
        }

        public void Adicionar(Area area)
        {
            _context.Area.Add(area);
        }

        public void Atualizar(Area area)
        {
            if (area == null)
                return;
            
            Area areaBanco = _context.Area.Find(area.AreaID);

            areaBanco.NomeArea = area.NomeArea;
            
            _context.SaveChanges();
        }
    }
}
