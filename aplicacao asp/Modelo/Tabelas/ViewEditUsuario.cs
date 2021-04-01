using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Tabelas
{
    public class ViewEditUsuario
    {
		//Cadastro dados pessoais
		public long? Id { get; set; }
		[Display(Name = "Nome")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar um nome.")]
		public string Nome { get; set; }

		[Display(Name = "Email")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar um email.")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Display(Name = "CPF")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar um cpf válido.")]
		public string Cpf { get; set; }

		[Display(Name = "Telefone")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar um número de telefone.")]
		[DataType(DataType.PhoneNumber)]
		public string Telefone { get; set; }

		[Display(Name = "Data de Nascimento")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "É necessário informar uma data de nascimento.")]
		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime DataNascimento { get; set; }
	}
}
