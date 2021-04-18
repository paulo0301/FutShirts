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
		[Display(Name = "Senha Antiga")]
		[DataType(DataType.Password)]
		public string SenhaAntiga { get; set; }

		[Display(Name = "Nova Senha")]
		[DataType(DataType.Password)]
		[MinLength(8, ErrorMessage = "A senha deve possuir no mínimo 8 caracteres.")]
		public string SenhaNova { get; set; }

		[Display(Name = "Confirmar Senha Nova")]
		[DataType(DataType.Password)]
		[MinLength(8, ErrorMessage = "A senha deve possuir no mínimo 8 caracteres.")]
		public string ConfirmarSenhaNova { get; set; }

		public Usuario Usuario { get; set; }
	}
}
