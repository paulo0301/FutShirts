using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Modelo.Tabelas
{
    public partial class Endereco
    {
        //Cadastro endereço
        public long? Id { get; set; }
        //Cadastro endereço
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
        public string Complemento { get; set; }

        
        public long? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}