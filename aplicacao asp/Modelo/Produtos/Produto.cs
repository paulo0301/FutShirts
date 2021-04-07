using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Produtos
{
    public class Produto
    {
        public long? Id { get; set; }

        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O produto deve possuir um nome.")]
        public string Nome { get; set; }

        [Display(Name = "Estoque")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O produto deve uma quantidade minima.")]
        public int Estoque { get; set; }

        [Display(Name = "Valor")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O produto deve possuir um valor.")]
        public decimal Valor { get; set; }

        public bool Ativo { get; set; }

        public long? CategoriaId { get; set; }
        public Categoria Categorias { get; set; }
    }
}
