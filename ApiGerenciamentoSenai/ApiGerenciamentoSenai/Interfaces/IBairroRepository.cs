using ApiGerenciamentoSenai.Domains;
using System.Xml.Serialization;

namespace ApiGerenciamentoSenai.Interfaces
{
    public interface IBairroRepository
    {
        List<Bairro> Listar();
        Bairro ObterPorId(Guid bairroId);
        Bairro ObterPorNome(Guid cidadeId, string nomeBairro);
        bool CidadeExiste(Guid cidadeId);
        void Adicionar(Bairro bairro);
        void Atualizar(Bairro bairro);

    }
}
