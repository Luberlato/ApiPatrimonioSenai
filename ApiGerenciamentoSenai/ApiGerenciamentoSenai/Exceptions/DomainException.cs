namespace ApiGerenciamentoSenai.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string mensagem) : base(mensagem)
        { }
    }
}
