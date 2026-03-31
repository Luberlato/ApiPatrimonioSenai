using ApiGerenciamentoSenai.Contexts;
using ApiGerenciamentoSenai.Interfaces;
using ApiGerenciamentoSenai.Domains;
namespace ApiGerenciamentoSenai.Repositories
{
    public class BairroRepository : IBairroRepository
    {
        private readonly GestaoPatrimoniosContext _context;

        public BairroRepository(GestaoPatrimoniosContext context)
        {
            _context = context;
        }

        public List<Bairro> Listar()
        {
            return _context.Bairro.ToList();
        }

        public Bairro ObterPorId(Guid id)
        {
            return _context.Bairro.Find(id);
        }

        public Bairro ObterPorNome(Guid cidadeId, string nome)
        {
            return _context.Bairro.FirstOrDefault(bairro => bairro.NomeBairro == nome && bairro.CidadeID == cidadeId);
        }

        public bool CidadeExiste(Guid cidadeId)
        {
            return _context.Cidade.Any(cidade => cidade.CidadeID == cidadeId);
        }

        public void Adicionar(Bairro bairro)
        {
            _context.Add(bairro);
            _context.SaveChanges();
        }

        public void Atualizar(Bairro bairro)
        {
            Bairro bairroBanco = _context.Bairro.Find(bairro.BairroID);

            bairroBanco.NomeBairro = bairro.NomeBairro;
            bairroBanco.CidadeID = bairro.CidadeID;
        }
    }
}
