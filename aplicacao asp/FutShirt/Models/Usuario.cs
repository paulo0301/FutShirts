using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutShirt.Models
{
    public class Usuario
    {
        //Cadastro dados pessoais
        public string nome { get; set; }
        public string email { get; set; }
        public int cpf { get; set; }
        public string telefone { get; set; }
        public string senha { get; set; }
        public DateTime nascimento { get; set; }
    }
    public class Cartao
    {
        //Cadastro cartão
        public long id { get; set; }
        public string titular { get; set; }
        public string cpf_titular { get; set; }
        public string numero { get; set; }
        public string cvc { get; set; }
        public DateTime vencimento { get; set; }
    }
    public class Endereco
    {
        //Cadastro endereço
        public long id { get; set; }
        public string cep { get; set; }
        public string estado { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento{ get; set; }
    }
}