using GerenciamentoTarefasAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GerenciamentoTarefasAPI.Models
{
    public class Usuario
    {
        [Display(Name = "Nome", Description = "Nome do usuário")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Permitido somente caracteres no nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Login do usuário obrigatório")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O login do usuário ter no mínimo 5 e no máximo 100 caracteres")]
        public string LoginUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(8, MinimumLength = 4)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
    }
}