using ApiGerenciamentoSenai.Contexts;
using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.Interfaces;

namespace ApiGerenciamentoSenai.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly GestaoPatrimoniosContext _context;

        public CidadeRepository(GestaoPatrimoniosContext context)
        {
            _context = context;
        }

        public List<Cidade> Listar()
        {
            return _context.Cidade.OrderBy(cidade => cidade.NomeCidade).ToList();
        }

        public Cidade ObterPorId(Guid id)
        {
            return _context.Cidade.Find(id);
        }

        public Cidade ObterPorNomeEEstado(string nomeCidade, string nomeEstado)
        {
            return _context.Cidade.FirstOrDefault(cidade => cidade.NomeCidade == nomeCidade && cidade.Estado == nomeEstado);
        }

        public void Adicionar(Cidade cidade)
        {
            _context.Cidade.Add(cidade);
            _context.SaveChanges();
        }

        public void Atualizar(Cidade cidade)
        {
            if(cidade == null)
            {
                return;
            }


            Cidade? cidadeBanco = _context.Cidade.Find(cidade.CidadeID);

            cidadeBanco.NomeCidade = cidade.NomeCidade;
            cidadeBanco.Estado = cidade.Estado;

            _context.SaveChanges();
           
        }

       


    }
}
