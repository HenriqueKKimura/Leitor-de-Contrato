using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMaluco.Entities
{
    public class ArquivoImportadoMap : ClassMap<ArquivoImportado>
    {
        public ArquivoImportadoMap()
        {
            Map(arquivo => arquivo.Nome).Name("Nome").Index(0);
            Map(arquivo => arquivo.CPF).Name("CPF").Index(1);
            Map(arquivo => arquivo.NumeroContrato).Name("Contrato").Index(2);
            Map(arquivo => arquivo.Produto).Name("Produto").Index(3);
            Map(arquivo => arquivo.DataVencimento).Name("Vencimento").Index(4);
            Map(arquivo => arquivo.ValorContrato).Name("Valor").Index(5);
        }
    }
}
