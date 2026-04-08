using ApiGerenciamentoSenai.Application.Auth;
using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.DTOs.AuthDto;
using ApiGerenciamentoSenai.Interfaces;
using ApiGerenciamentoSenai.Exceptions;
using ApiGerenciamentoSenai.Application.Regras;
namespace ApiGerenciamentoSenai.Application.Services
{
    public class AuthService
    {
        private readonly IUsuarioRepository _repository;
        private readonly GeradorTokenJwt _tokenJwt;

        public AuthService(IUsuarioRepository repository, GeradorTokenJwt tokenJwt)
        {
            _repository = repository;
            _tokenJwt = tokenJwt;
        }

        private static bool VerificarSenha(string senhaDigitada, byte[] senhaHashBanco)
        {
            var hashDigitado = CriptografiaUsuario.CriptografarSenha(senhaDigitada);

            return hashDigitado.Equals(senhaHashBanco);
        }

        public TokenDto Login(LoginDto loginDto)
        {
            Usuario usuario = _repository.ObterPorNIFComTipoUsuario(loginDto.NIF);

            if (usuario == null)
                throw new DomainException("NIF ou senha inválidos");

            if(usuario.Ativo == false)
                throw new DomainException("Usuário inativo");
            
            if (!VerificarSenha(loginDto.Senha, usuario.Senha))
                throw new DomainException("NIF ou senha inválidos");

            string token = _tokenJwt.GerarToken(usuario);

            return new TokenDto
            {
                Token = token,
                PrimeiroAcesso = usuario.PrimeiroAcessoUsuario,
                TipoUsuario = usuario.TipoUsuario.NomeTipo
            };
        }

        public void TrocarPrimeiraSenha(Guid usuarioId, TrocarPrimeiraSenhaDto dto)
        {
            Validacoes.ValidarSenha(dto.SenhaAtual);
            Validacoes.ValidarSenha(dto.NovaSenha);

            Usuario usuario = _repository.BuscarPorId(usuarioId);

            if (usuario == null)
                throw new DomainException("Usuário não encontrado");

            if (!VerificarSenha(dto.SenhaAtual, usuario.Senha))
                throw new DomainException("Senha invalida");

            if (dto.NovaSenha == dto.SenhaAtual)
                throw new DomainException("As senhas devem ser diferentes");

            usuario.Senha = CriptografiaUsuario.CriptografarSenha(dto.NovaSenha);
            usuario.PrimeiroAcessoUsuario = false;

            _repository.AtualizarSenha(usuario);
            _repository.AtualizarPrimeiroAcesso(usuario);
        }
    }
}
