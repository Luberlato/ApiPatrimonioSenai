using ApiGerenciamentoSenai.Contexts;
using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.Interfaces;
using Microsoft.Identity.Client;

namespace ApiGerenciamentoSenai.Repositories
{
    public class PatrimonioRepository : IPatrimonioRepository
    {
        private readonly GestaoPatrimoniosContext _context;

        public PatrimonioRepository(GestaoPatrimoniosContext context)
        {
            _context = context;
        }

        public List<Patrimonio> Listar()
        {
            return _context.Patrimonio.ToList();
        }

        public Patrimonio ObterPorId(Guid id)
        {
            return _context.Patrimonio.Find(id);
        }

        public Patrimonio BuscarPorNumeroPatrimonio(string numeroPatrimonio, Guid? patrimonioId = null)
        {
            if (patrimonioId == null)
                return _context.Patrimonio.FirstOrDefault(patrimonio => patrimonio.NumeroPatrimonio == numeroPatrimonio);

            return _context.Patrimonio.FirstOrDefault(patrimonio => patrimonio.NumeroPatrimonio == numeroPatrimonio && patrimonio.PatrimonioID == patrimonioId);
        }

        public bool LocalizacaoExiste(Guid id)
        {
            return _context.Localizacao.Any(local => local.LocalizacaoID == id);
        }

        public bool StatusPatrimonioExiste(Guid id)
        {
            return _context.StatusPatrimonio.Any(status => status.StatusPatrimonioID == id);
        }

        public void Adicionar(Patrimonio patrimonio)
        {
            _context.Add(patrimonio);
            _context.SaveChanges();
        }

        public void Atualizar(Patrimonio patrimonio)
        {
            Patrimonio? patrimonioBanco = _context.Patrimonio.Find(patrimonio.PatrimonioID);

            patrimonioBanco.Denominacao = patrimonio.Denominacao;
            patrimonioBanco.NumeroPatrimonio = patrimonio.NumeroPatrimonio;
            patrimonioBanco.Valor = patrimonio.Valor;
            patrimonioBanco.Imagem = patrimonio.Imagem;
            patrimonioBanco.LocalizacaoID = patrimonio.LocalizacaoID;
            patrimonioBanco.Valor = patrimonio.Valor;

            _context.SaveChanges();
        }

    }
}
