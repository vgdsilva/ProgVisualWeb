using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgVisualWeb.Entities.Entidades
{
    public class Produtos
    {
        // Atributos de um Produto
        public long IDProduto { get; set; }
        public long Codigo { get; set; }
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public long IDCategoria { get; set; }
        public string Fornecedor { get; set; }
        public string Marca { get; set; }

        // Controle de função do Objeto
        public bool Adicionar { get; set; }
        public bool Editando { get; set; }
        public bool Remover { get; set; }

        // Construtor
        public Produtos() { }

    }
}
