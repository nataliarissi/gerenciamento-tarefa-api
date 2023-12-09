using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GerenciamentoTarefaAPI.Models
{
    public class Tarefa
    {    
        //Id
        [Display(Name = "Id", Description = "Informe um inteiro entre 1 e 99999 para a tarefa")]
        [Range(1, 99999)]
        public int Id { get; set; }

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
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DataCriacao { get; set; }

        //Status
        [Display(Name = "Status")]
        [Required(ErrorMessage = "É obrigatório informar um status")]
        [EnumDataType(typeof(StatusTarefa))]
        public StatusTarefa Status { get; set; }
    
        public bool PossuiSequencia(string titulo){
            for(int n = 1; n < titulo.LastIndexOf(""); n ++){
                var verficarValido = Regex.IsMatch(titulo, @"^\d{9}$");
                return verficarValido;
            }
            return false;
        }
        //criado somente para a implementação de teste unitário
    }
}