using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Drawing;

namespace GerenciamentoTarefaAPI.Models
{
    public class Tarefa
    {    
        [Display(Name = "Id", Description = "Informe um inteiro entre 1 e 99999 para a tarefa")]
        [Range(1, 99999)]
        public int Id { get; set; }

        [Display(Name = "Título", Description = "Informe um título para a tarefa")]
        [Required(ErrorMessage = "É obrigatório informar um título")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "É necessário ter uma descrição")]
        [MinLength(50, ErrorMessage = "A descrição deve ter no mínimo 50")]
        [MaxLength(500, ErrorMessage = "O máximo 500 caracteres")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Data da criação")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DataCriacao { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "É obrigatório informar um status")]
        [EnumDataType(typeof(StatusTarefa))]
        public StatusTarefa Status { get; set; }

        public string AlteracaoValida()
        {
            var limiteTitulo = 50;
            var limiteDescricao = 100;

            if (Id <= 0){
                return "Id menor ou igual a 0";
            }

            if (Titulo?.Length > limiteTitulo){
                return "Título possui mais de 50 caracteres";
            }

            if (Descricao?.Length > limiteDescricao){
                return "Descrição ultrapassa de 100 caracteres";
            }

            if (DataCriacao < DateTime.Now){
                return "A data de criaçao é menor que a data atual";
            }
            return "A tarefa é válida";
        }
    }
}