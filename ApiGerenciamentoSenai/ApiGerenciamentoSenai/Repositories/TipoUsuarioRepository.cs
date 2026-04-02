using ApiGerenciamentoSenai.Contexts;
using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.Interfaces;

namespace ApiGerenciamentoSenai.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly GestaoPatrimoniosContext _context;


        public TipoUsuarioRepository(GestaoPatrimoniosContext context)
        {
            _context = context;
        }

        public List<TipoUsuario> Listar()
        {
            return _context.TipoUsuario.ToList();
        }

        public TipoUsuario ObterPorId(Guid id)
        {
            return _context.TipoUsuario.Find(id);
        }

        public TipoUsuario ObterPorNome(string nome)
        {
            return _context.TipoUsuario.FirstOrDefault(tipo => tipo.NomeTipo == nome);
        }

        public void Adicionar(TipoUsuario tipoUsuario)
        {
            _context.Add(tipoUsuario);
            _context.SaveChanges();
        }

        public void Atualizar(TipoUsuario tipoUsuario)
        {
            TipoUsuario? tipoUsuarioBanco = _context.TipoUsuario.Find(tipoUsuario.TipoUsuarioID);

            tipoUsuarioBanco.NomeTipo = tipoUsuario.NomeTipo;

            _context.SaveChanges();
        }

    }
}
