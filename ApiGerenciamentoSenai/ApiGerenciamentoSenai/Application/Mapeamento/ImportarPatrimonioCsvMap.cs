using CsvHelper.Configuration;

namespace ApiGerenciamentoSenai.Application.Mapeamento
{
    public class ImportarPatrimonioCsvMap : ClassMap<ImportarPatrimonioCsvDto>
    {
        public ImportarPatrimonioCsvMap()
        {
            Map(m => m.NumeroPatrimonio).Name("N° invent.");
            Map(m => m.Denominacao).Name("Denominação do imobilizado");
            Map(m => m.DataIncoporacao).Name("Dt.incorp.");
            Map(m => m.ValorAquisicao).Name("");
        }
    }
}
