using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMaluco.Entities.ArquivoImportado
{
    public class ArquivoImportado
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }

        public string CPF { get; set; }

        public string NumeroContrato { get; set; }

        public string Produto { get; set; }

        public string DataVencimento { get; set; }

        public string ValorContrato { get; set; }

    }
}
