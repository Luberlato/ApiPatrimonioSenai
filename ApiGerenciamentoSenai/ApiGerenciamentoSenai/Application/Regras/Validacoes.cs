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

        public static void ValidarEmail(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
                throw new DomainException("Email é obrigatório");
        }

        public static void ValidarSenha(string Senha)
        {
            if (string.IsNullOrWhiteSpace(Senha))
                throw new DomainException("Senha é obrigatório");
        }

        public static void ValidarNif(string Nif)
        {
            if (string.IsNullOrWhiteSpace(Nif))
                throw new DomainException("NIf é obrigatório");
        }

        public static void ValidarCpf(string Cpf)
        {
            if (string.IsNullOrWhiteSpace(Cpf))
                throw new DomainException("Cpf é obrigatório");
        }
    }
}
