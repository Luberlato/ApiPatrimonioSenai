using ApiGerenciamentoSenai.Domains;

namespace ApiGerenciamentoSenai.Interfaces
{
    public interface ILogPatrimonioRepository
    {
        List<LogPatrimonio> Listar();
        List<LogPatrimonio> BuscarPorPatrimonio(Guid patrimonioId);
    }
}
