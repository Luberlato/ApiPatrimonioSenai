using ApiGerenciamentoSenai.Domains;

namespace ApiGerenciamentoSenai.Interfaces
{
    public interface IEnderecoRepository
    {
        List<Endereco> Listar();
        Endereco ObterPorId(Guid enderecoId);
        void Adicionar(Endereco endereco);
        void Atualizar(Endereco endereco);
        Endereco BuscarPorLogradouroENumero(string logradouro,Guid bairroId, int? numero);
        bool BairroExiste(Guid bairroId);
    }
}
