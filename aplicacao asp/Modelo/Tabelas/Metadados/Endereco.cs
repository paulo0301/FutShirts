using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Tabelas.Metadados
{
    [MetadataType(typeof(EnderecoMetaDados))]
    public class Endereco
    {
    }
    public class EnderecoMetaDados
    {
        [Display(Name = "CEP")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#####-###}")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar o CEP")]
        public string Cep { get; set; }
        
        [Display(Name = "Estado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar o seu estado")]
        public string Estado { get; set; }
        
        [Display(Name = "Cidade")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar a sua cidade")]
        public string Cidade { get; set; }
        
        [Display(Name = "Bairro")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar o seu bairro")]
        public string Bairro { get; set; }
        
        [Display(Name = "Logradouro")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar o seu logradouro")]
        public string Logradouro { get; set; }
        
        [Display(Name = "Número")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar o número da sua residência")]
        public string Numero { get; set; }

        [Display(Name = "Complemento")]
        [Required(AllowEmptyStrings = true)]
        public string Complemento { get; set; }
    }
}