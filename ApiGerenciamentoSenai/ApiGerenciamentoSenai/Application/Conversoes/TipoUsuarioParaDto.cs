using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.DTOs.TipoUsuarioDto;

namespace ApiGerenciamentoSenai.Application.Conversoes
{
    public class TipoUsuarioParaDto
    {
        public static ListarTipoUsuarioDto ConverterParaDto(TipoUsuario tipoUsuario)
        {
            return new ListarTipoUsuarioDto
            {
                Id = tipoUsuario.TipoUsuarioID,
                Nome = tipoUsuario.NomeTipo  
            };

        }

        public static TipoUsuario ConverterParaDtoCriar(CriarTipoUsuarioDto tipoUsuarioDto)
        {
            return new TipoUsuario
            {
                NomeTipo = tipoUsuarioDto.Nome
            };
        }

    }
}
