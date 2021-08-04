using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario.Entidades.Entidades
{
    public class Categoria
    {
        public long IDCategoria { get; set; }
        public long Codigo { get; set; }
        public string Descricao { get; set; }

        // Controle de função do Objeto
        public bool Novo { get; set; }
        public bool Editando { get; set; }
        public bool Remover { get; set; }

        public Categoria() { }


    }
}
