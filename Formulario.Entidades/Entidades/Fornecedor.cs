using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario.Entidades.Entidades
{
    public class Fornecedor
    {
        public long IDFornecedor { get; set; }
        public long Codigo { get; set; }
        public string Descricao { get; set; }

        public Fornecedor() { }
    }
}
