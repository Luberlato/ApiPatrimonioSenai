using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.DTOs.StatusPatrimonioDto;

namespace ApiGerenciamentoSenai.Application.Conversoes
{
    public class StatusPatrimonioParaDto
    {
        public static ListarStatusPatrimonioDto StatusParaDto(StatusPatrimonio status)
        {
            return new ListarStatusPatrimonioDto
            {
                IdStatus = status.StatusPatrimonioID,
                Nome = status.NomeStatus
            };
        }

        public static StatusPatrimonio StatusParaDtoCriar(CriarStatusPatrimonioDto status)
        {
            return new StatusPatrimonio
            {
                NomeStatus = status.Nome
            };
        }
    }
}
