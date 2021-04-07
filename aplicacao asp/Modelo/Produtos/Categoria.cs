using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Produtos
{
    public class Categoria
    {
        public long Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O produto deve possuir uma descrição.")]
        public string Descricao { get; set; }

        [Display(Name = "Time")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O produto deve possuir um time.")]
        public string Time { get; set; }

        [Display(Name = "Clube")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O produto deve possuir um clube.")]
        public string Clube { get; set; }

        [Display(Name = "Gênero")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O produto deve possuir um gênero.")]
        public string Genero { get; set; }

        [Display(Name = "Indicado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O produto deve possuir uma indicação.")]
        public string Indicacao { get; set; }

        [Display(Name = "Material")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O produto deve possuir um tipo de material.")]
        public string Material { get; set; }

        [Display(Name = "Gola")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O produto deve possuir um tipo de gola.")]
        public string Gola { get; set; }

        [Display(Name = "Manga")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O produto deve possuir um tipo de manga.")]
        public string Manga { get; set; }

        [Display(Name = "Numero")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O produto deve possuir um número.")]
        public string Numero { get; set; }

        [Display(Name = "Escudo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O produto deve possuir um tipo de escudo.")]
        public string Escudo { get; set; }

        [Display(Name = "Origem")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O produto deve possuir uma órigem.")]
        public string Origem { get; set; }

        [Display(Name = "Marca")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O produto deve possuir uma marca.")]
        public string Marca { get; set; }

        [Display(Name = "Cor")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O produto deve possuir uma cor.")]
        public string Cor { get; set; }

    }
}
