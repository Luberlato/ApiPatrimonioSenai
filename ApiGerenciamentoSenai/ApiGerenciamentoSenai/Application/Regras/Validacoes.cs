using ApiGerenciamentoSenai.Exceptions;

namespace ApiGerenciamentoSenai.Application.Regras
{
    public class Validacoes
    {
        public static void ValidarNome(string Nome)
        {
            if (string.IsNullOrWhiteSpace(Nome))
            {
                throw new DomainException("Nome é obrigatório");
            }
        }
    }
}
