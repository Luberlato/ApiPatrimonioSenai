using ApiGerenciamentoSenai.Contexts;
using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace ApiGerenciamentoSenai.Repositories
{
    public class LogPatrimonioRepository : ILogPatrimonioRepository
    {
        private readonly GestaoPatrimoniosContext _context;

        public LogPatrimonioRepository(GestaoPatrimoniosContext context)
        {
            _context = context;
        }

        public List<LogPatrimonio> Listar()
        {
            return _context.LogPatrimonio.Include(
                log => log.Usuario)
                .Include(log => log.Localizacao)
                .Include(log => log.TipoAlteracao)
                .Include(log => log.TipoAlteracao)
                .Include(log => log.StatusPatrimonio)
                .Include(log => log.Patrimonio).OrderByDescending(log => log.DataTransferencia)
                .ToList();
        }

        public List<LogPatrimonio> BuscarPorPatrimonio(Guid PatrimonioId)
        {
            return _context.LogPatrimonio.Include(
                log => log.Usuario)
                .Include(log => log.Localizacao)
                .Include(log => log.TipoAlteracao)
                .Include(log => log.TipoAlteracao)
                .Include(log => log.StatusPatrimonio)
                .Include(log => log.Patrimonio).Where(log => log.PatrimonioID == PatrimonioId)
                .OrderByDescending(log => log.DataTransferencia)
                .ToList();
        }
    }
}
