using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutShirt.Models
{
    public class Usuario
    {
        //Cadastro dados pessoais
        public string nome, email, cpf, telefone, senha;
        public DateTime nascimento;
    }
    public class Cartao
    {
        //Cadastro cartão
        public long Id { get; set; }
        public string nome_titular, cpf_titular, numero, csc;
        public DateTime vencimento;
    }
    public class Endereco
    {
        //Cadastro endereço
        public long Id { get; set; }
        public string cep, estado, cidade, bairro, logradouro, numero, complemento;
    }
}