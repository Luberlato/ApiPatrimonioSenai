using ApiGerenciamentoSenai.Contexts;
using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.Interfaces;

namespace ApiGerenciamentoSenai.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly GestaoPatrimoniosContext _context;

        public LocalizacaoRepository(GestaoPatrimoniosContext context)
        {
            _context = context;
        }

        public List<Localizacao> Listar()
        {
            return _context.Localizacao.OrderBy(localizacao => localizacao.NomeLocal).ToList();
        }

        public Localizacao ObterPorId(Guid id)
        {
            return _context.Localizacao.Find(id);
        }

        public Localizacao ObterPorNome(string nome)
        {
            return _context.Localizacao.FirstOrDefault(local => local.NomeLocal == nome);
        }

        public void Adicionar(Localizacao local)
        {
            _context.Localizacao.Add(local);
            _context.SaveChanges();
        }

        public void Atualizar(Guid id, Localizacao local)
        {
            Localizacao localBanco = this.ObterPorId(id);

            localBanco.NomeLocal = local.NomeLocal;
            localBanco.LocalSAP = local.LocalSAP;
            localBanco.DescricaoSAP = local.DescricaoSAP;
            localBanco.AreaID = local.AreaID;

            _context.SaveChanges();

        }

        public bool AreaExiste(Guid AreaId)
        {
            return _context.Area.Any(area => area.AreaID == AreaId);
        }
    }
}
