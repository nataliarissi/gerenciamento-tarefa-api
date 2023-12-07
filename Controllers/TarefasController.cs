using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoTarefaAPI.Models;
using GerenciamentoTarefaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GerenciamentoTarefaAPI.Controllers
{
    [ApiController]
    [Route("tarefas")]
    public class TarefasController : Controller
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefasController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpPost("cadastrarTarefa")]
        public bool CadastrarTarefa([FromBody]TarefaCadastro tarefaCadastro){
            return _tarefaRepository.CadastrarTarefa(tarefaCadastro);
        }

        [HttpGet("visualizarTarefa")]
        public Tarefa VisualizarTarefa(int id){
            return _tarefaRepository.VisualizarTarefa(id);
        }

        [HttpPut("editarTarefa")]
        public bool EditarTarefa([FromBody]Tarefa tarefa){
            return _tarefaRepository.EditarTarefa(tarefa);
        }

        [HttpDelete("deletarTarefa")]
        public bool DeletarTarefa([FromBody]int id){
            return _tarefaRepository.DeletarTarefa(id);
        }

        [HttpGet("visualizarTodasTarefas")]
        public List<Tarefa> VisualizarTodasTarefas(){
            return _tarefaRepository.VisualizarTodasTarefas();
        }

        [HttpGet("pesquisarTituloTarefa")]
        public Tarefa? PesquisarTarefaTitulo(string titulo){
            return _tarefaRepository.PesquisarTarefaTitulo(titulo);
        }
    }
}