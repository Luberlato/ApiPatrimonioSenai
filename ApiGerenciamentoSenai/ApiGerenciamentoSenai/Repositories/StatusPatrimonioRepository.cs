using ApiGerenciamentoSenai.Contexts;
using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.Interfaces;

namespace ApiGerenciamentoSenai.Repositories
{
    public class StatusPatrimonioRepository : IStatusPatrimonioRepository
    {
        private readonly GestaoPatrimoniosContext _context;

        public StatusPatrimonioRepository(GestaoPatrimoniosContext context)
        {
            _context = context;
        }

        public List<StatusPatrimonio> Listar()
        {
            return _context.StatusPatrimonio.ToList();
        }

        public StatusPatrimonio ObterPorId(Guid id)
        {
            return _context.StatusPatrimonio.Find(id);
        }

        public StatusPatrimonio ObterPorNome(string nome)
        {
            return _context.StatusPatrimonio.FirstOrDefault(status => status.NomeStatus == nome);
        }

        public void Adicionar(StatusPatrimonio patrimonio)
        {
            _context.Add(patrimonio);
            _context.SaveChanges();
        }

        public void Atualizar(StatusPatrimonio patrimonio)
        {
            StatusPatrimonio? statusBanco = _context.StatusPatrimonio.Find(patrimonio.StatusPatrimonioID);

            statusBanco.NomeStatus = patrimonio.NomeStatus;

            _context.SaveChanges();
        }

    }
}
