using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoTarefaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GerenciamentoTarefaAPI.Controllers
{
    [ApiController]
    [Route("tarefas")]
    public class TarefasController : Controller
    {
        private readonly ILogger<TarefasController> _logger;

        public TarefasController(ILogger<TarefasController> logger)
        {
            _logger = logger;
        }

        [HttpPost("cadastrarTarefa")]
        public bool CadastrarTarefa(Tarefa tarefa){
            return true;
        }

        [HttpGet("visualizarTarefa")]
        public Tarefa VisualizarTarefa(int id){
            return null;
        }

        [HttpPut("editarTarefa")]
        public bool EditarTarefa(Tarefa tarefa){
            return false;
        }

        [HttpDelete("deletarTarefa")]
        public bool DeletarTarefa(int id){
            return true;
        }

        [HttpGet("visualizarTodasTarefas")]
        public List<Tarefa> VisualizarTodasTarefas(){
            return null;
        }
    }
}  