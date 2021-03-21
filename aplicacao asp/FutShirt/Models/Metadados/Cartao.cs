using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FutShirt.Models
{
    [MetadataType(typeof(CartaoMetaDados))]
    public class CartaoMetaDados
    {
        [Display(Name = "Nome do titular")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar o CEP")]
        public string Titular { get; set; }

        [Display(Name = "CPF do titular")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###.###.###-##}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar um CPF válido")]
        public string CpfTitular { get; set; }

        [Display(Name = "Número do cartão")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:##### #### #### ####}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar um número válido")]
        public string Numero { get; set; }

        [Display(Name = "CVC")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar o CVC")]
        public string Cvc { get; set; }

        [Display(Name = "Data de vencimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar a data de vencimento")]
        public DateTime DataVencimento { get; set; }
    }
}