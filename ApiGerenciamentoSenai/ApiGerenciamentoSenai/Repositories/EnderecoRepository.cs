using ApiGerenciamentoSenai.Contexts;
using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.Interfaces;
using Microsoft.Identity.Client;
using System.Runtime.InteropServices;
namespace ApiGerenciamentoSenai.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly GestaoPatrimoniosContext _context;

        public EnderecoRepository(GestaoPatrimoniosContext context)
        {
            _context = context;
        }

        public List<Endereco> Listar()
        {
            return _context.Endereco.ToList();
        }

        public Endereco ObterPorId(Guid id)
        {
            return _context.Endereco.Find(id);
        }

        public void Adicionar(Endereco endereco)
        {
            _context.Add(endereco);
            _context.SaveChanges();
        }

        public void Atualizar(Endereco endereco)
        {
            Endereco? enderecoBanco = _context.Endereco.Find(endereco.EnderecoID);

            if (enderecoBanco == null)
                return;

            enderecoBanco.EnderecoID = endereco.EnderecoID;
            enderecoBanco.Numero = endereco.Numero;
            enderecoBanco.Logradouro = endereco.Logradouro;
            enderecoBanco.Complemento = endereco.Complemento;
            enderecoBanco.CEP = endereco.CEP;
            enderecoBanco.BairroID = endereco.BairroID;
        }

        public Endereco BuscarPorLogradouroENumero(string logradouro, Guid bairroId, int? numero)
        {
            if (numero.HasValue)
            {
                return _context.Endereco.FirstOrDefault(endereco => endereco.Logradouro.ToLower() == logradouro && endereco.Numero == numero.Value && endereco.BairroID == bairroId);
            }

            return _context.Endereco.FirstOrDefault(endereco => endereco.Logradouro.ToLower() == logradouro && endereco.BairroID == bairroId);
        }

        public bool BairroExiste(Guid bairroId)
        {
            return _context.Bairro .Any(c => c.BairroID == bairroId);
        }



    }
}
