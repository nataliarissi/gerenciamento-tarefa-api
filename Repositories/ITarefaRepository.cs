using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoTarefaAPI.Models;
//serviço
namespace GerenciamentoTarefaAPI.Repositories
{
    public interface ITarefaRepository
    {
        bool CadastrarTarefa(TarefaCadastro tarefaCadastro);
        Tarefa? VisualizarTarefa(int id);
        public bool EditarTarefa(Tarefa tarefa);
        bool DeletarTarefa(int id);
        List<Tarefa> VisualizarTodasTarefas();
        Tarefa? PesquisarTarefaTitulo(string titulo);
    }
}        
