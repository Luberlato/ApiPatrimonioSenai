using ApiGerenciamentoSenai.Application.Conversoes;
using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.DTOs.TipoUsuarioDto;
using ApiGerenciamentoSenai.Interfaces;
using ApiGerenciamentoSenai.Exceptions;
using ApiGerenciamentoSenai.Application.Regras;

namespace ApiGerenciamentoSenai.Application.Services
{
    public class TipoUsuarioService
    {
        private readonly ITipoUsuarioRepository _repository;

        public TipoUsuarioService(ITipoUsuarioRepository repository)
        {
            _repository = repository;
        }

        public List<ListarTipoUsuarioDto> Listar()
        {
            return _repository.Listar().Select(t => TipoUsuarioParaDto.ConverterParaDto(t)).ToList();
        }

        public ListarTipoUsuarioDto ObterPorId(Guid id)
        {
            TipoUsuario? tipoUsuario = _repository.ObterPorId(id);

            if (tipoUsuario == null)
                throw new DomainException("Tipo Usuário não encontrado");

            return TipoUsuarioParaDto.ConverterParaDto(tipoUsuario);
            
        }

        public ListarTipoUsuarioDto ObterPorNome(string nome)
        {
            TipoUsuario? tipoUsuario = _repository.ObterPorNome(nome);

            if (tipoUsuario == null)
                throw new DomainException("Tipo Usuário não encontrado");

            return TipoUsuarioParaDto.ConverterParaDto(tipoUsuario);
        }

        public ListarTipoUsuarioDto Adiconar(CriarTipoUsuarioDto tipoUsuarioDto)
        {
            Validacoes.ValidarNome(tipoUsuarioDto.Nome);

            TipoUsuario tipoUsuario = TipoUsuarioParaDto.ConverterParaDtoCriar(tipoUsuarioDto);

            _repository.Adicionar(tipoUsuario);

            return TipoUsuarioParaDto.ConverterParaDto(tipoUsuario);
        }


        public void Atualizar(CriarTipoUsuarioDto tipoUsuarioDto, Guid id)
        {
            Validacoes.ValidarNome(tipoUsuarioDto.Nome);

            TipoUsuario? tipoUsuarioBanco = _repository.ObterPorId(id);

            if (tipoUsuarioBanco == null)
                throw new DomainException("Usuário não encontrado");

            _repository.Atualizar(tipoUsuarioBanco);

        }


    }
}
