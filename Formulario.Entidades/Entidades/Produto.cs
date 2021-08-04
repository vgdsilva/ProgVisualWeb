using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario.Models.Entidades
{
    public class Produto
    {
        // Atributos de um Produto
        public long IDProduto { get; set; }
        public long Codigo { get; set; }
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public long IDCategoria { get; set; }
        public long IDFornecedor { get; set; }
        public long IDMarca { get; set; }

        // Controle de função do Objeto
        public bool Novo { get; set; }
        public bool Editando { get; set; }
        public bool Remover { get; set; }

        // Construtor
        public Produto() { }

    }
}
