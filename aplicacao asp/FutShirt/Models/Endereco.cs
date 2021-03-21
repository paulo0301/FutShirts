using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutShirt.Models
{
    public class Endereco
    {
        //Cadastro endereço
        public long Id { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
        
    }
}