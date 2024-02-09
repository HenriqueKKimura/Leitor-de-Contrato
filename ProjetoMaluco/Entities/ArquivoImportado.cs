using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMaluco.Entities
{
    public class ArquivoImportado
    {
        public string Nome { get; set; }
        public int CPF { get; set; }
        public int NumContrato { get; set; }
        public string Produto { get; set; }
        public DateTime Vencimento { get; set; }
        public int Valor { get; set; }

    }
}
