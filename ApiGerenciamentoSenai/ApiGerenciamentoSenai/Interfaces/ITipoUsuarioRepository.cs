using ApiGerenciamentoSenai.Domains;


namespace ApiGerenciamentoSenai.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();
        TipoUsuario ObterPorId(Guid tipoUsuarioId);
        TipoUsuario ObterPorNome(string nomeTipo);
        void Adicionar(TipoUsuario tipoUsuario);
        void Atualizar(TipoUsuario tipoUsuario);
    }
}
