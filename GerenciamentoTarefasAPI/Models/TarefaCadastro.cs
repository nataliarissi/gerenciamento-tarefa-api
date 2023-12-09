using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoTarefaAPI.Models
{
    public class TarefaCadastro
    {
        // public string Titulo { get; set; }
        // public string Descricao { get; set; }
        // public DateTime DataCriacao { get; set; }
        // public StatusTarefa Status { get; set; }

        //Titulo
        [Display(Name = "Título", Description = "Informe um título para a tarefa")]
        [Required(ErrorMessage = "É obrigatório informar um título")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no título")]
        public string Titulo { get; set; }

        //Descrição
        [Required(ErrorMessage = "É necessário ter uma descrição")]
        [StringLength(500, MinimumLength = 50, ErrorMessage =
            "A descrição deve ter no mínimo 50 e no máximo 500 caracteres")]
        public string Descricao { get; set; }

        //DataCriacao
        [Required]
        [Display(Name = "Data da criação")]
        [DisplayFormat(DataFormatString = "MM/dd/yyyy")]
        public DateTime DataCriacao { get; set; }

        //Status
        [Display(Name = "Status")]
        [Required(ErrorMessage = "É obrigatório informar um status")]
        [EnumDataType(typeof(StatusTarefa))]
        public StatusTarefa Status { get; set; }
    }
}