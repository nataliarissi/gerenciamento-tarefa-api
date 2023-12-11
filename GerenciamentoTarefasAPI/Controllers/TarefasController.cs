using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Dapper;
using GerenciamentoTarefaAPI.Models;
using GerenciamentoTarefaAPI.Repositories;
using GerenciamentoTarefaAPI.Repositories.Tarefas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GerenciamentoTarefaAPI.Controllers
{
    [ApiController]
    [Route("tarefas")]
    public class TarefasController : Controller
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefasController(ITarefaRepository tarefaRepository){
            _tarefaRepository = tarefaRepository;
        }

        [HttpPost("cadastrarTarefa")]
        [Authorize]
        public bool CadastrarTarefa([FromBody]TarefaCadastro tarefaCadastro){
            var mensagem = "A tarefa é válida";
            var validacacoCadastro = tarefaCadastro.CadastroValido();

            if (validacacoCadastro != mensagem){
                throw new Exception(validacacoCadastro);
            }
            return _tarefaRepository.CadastrarTarefa(tarefaCadastro);
        }

        [HttpGet("visualizarTarefa")]
        [Authorize]
        public Tarefa VisualizarTarefa(int id){
            return _tarefaRepository.VisualizarTarefa(id);
        }

        [HttpPut("editarTarefa")]
        [Authorize]
        public bool EditarTarefa([FromBody]Tarefa tarefa){
            var mensagem = "A tarefa é válida";
            var validacaoAlteracao = tarefa.AlteracaoValida();

            if ( validacaoAlteracao != mensagem){
                throw new Exception(validacaoAlteracao);
            }
            return _tarefaRepository.EditarTarefa(tarefa);
        }

        [HttpDelete("deletarTarefa")]
        [Authorize]
        public bool DeletarTarefa([FromBody]int id){
            return _tarefaRepository.DeletarTarefa(id);
        }

        [HttpGet("visualizarTodasTarefas")]
        [Authorize]
        public PaginacaoTarefa<List<Tarefa>> VisualizarTodasTarefas(int numeroPaginaAtual, int tamanhaPagina){
             return _tarefaRepository.VisualizarTodasTarefas(numeroPaginaAtual, tamanhaPagina);
        }

        [HttpGet("pesquisarTituloTarefa")]
        [Authorize]
        public Tarefa? PesquisarTarefaTitulo(string titulo){
            return _tarefaRepository.PesquisarTarefaTitulo(titulo);
        }
    }
}