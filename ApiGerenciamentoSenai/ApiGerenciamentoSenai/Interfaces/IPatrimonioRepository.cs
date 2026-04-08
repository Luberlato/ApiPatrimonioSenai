using ApiGerenciamentoSenai.Domains;

namespace ApiGerenciamentoSenai.Interfaces
{
    public interface IPatrimonioRepository
    {
        List<Patrimonio> Listar();
        Patrimonio ObterPorId(Guid patrimonioId);
        Patrimonio BuscarPorNumeroPatrimonio(string numeroPatrimonio, Guid? patrimonioId = null);
        bool LocalizacaoExiste(Guid localizacaoId);
        bool StatusPatrimonioExiste(Guid statusPatrimonioId);
        void Adicionar(Patrimonio patrimonio);
        void Atualizar(Patrimonio patrimonio);
        
    }
}
