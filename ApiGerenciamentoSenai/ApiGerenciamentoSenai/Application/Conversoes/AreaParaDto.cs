using ApiGerenciamentoSenai.Domains;
using ApiGerenciamentoSenai.DTOs.AreaDto;

namespace ApiGerenciamentoSenai.Application.Conversoes
{
    public class AreaParaDto
    {
        public static ListarAreaDto ConverterParaDto(Area area)
        {
            ListarAreaDto listar = new ListarAreaDto
            {
                AreaId = area.AreaID,
                NomeArea = area.NomeArea,
            };
            return listar;
        }

       public static Area ConverterDtoCriar(CriarAreaDto areaDto)
       {
            Area area = new Area
            {
                NomeArea = areaDto.NomeArea,
                
            };

            return area;
       }
    }
}
