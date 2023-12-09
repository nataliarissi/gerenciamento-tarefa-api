using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using GerenciamentoTarefaAPI.Models;

namespace GerenciamentoTarefaAPI.Repositories.Tarefas
{
    public class TarefaRepository : ITarefaRepository
    {
        private string _connectionString { get; set; }

        public TarefaRepository(){
            _connectionString = "Data Source=.;Initial Catalog=GerenciamentoTarefa;User ID=sa;Password=Natalia@123";
        }

        public bool CadastrarTarefa(TarefaCadastro tarefaCadastro)
        {
            string inserirDados = @"Insert into [GerenciamentoTarefa].[dbo].[TAREFA] ([TITULO], [DESCRICAO], [DATACRIACAO], [STATUS]) 
            values (@Titulo, @Descricao, @DataCriacao, @StatusTarefa)";
            
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();  

                var tarefaResultado = dbConnection.Execute(inserirDados,
                    new
                    {
                        Titulo = tarefaCadastro.Titulo,
                        Descricao = tarefaCadastro.Descricao,
                        DataCriacao = tarefaCadastro.DataCriacao,
                        StatusTarefa = tarefaCadastro.Status
                    });
                
                    dbConnection.Close();

                    return tarefaResultado > 0;
            }
        }  

        public bool DeletarTarefa(int id)
        {
            string inserirDados = "Delete [GerenciamentoTarefa].[dbo].[TAREFA] where [ID] = @Id;";
            using (IDbConnection dbConnection = new SqlConnection(_connectionString)){

                dbConnection.Open();

                var tarefaResultado = dbConnection.Execute(inserirDados,
                new{
                    Id = id
                });
                
                dbConnection.Close();

                return tarefaResultado > 0;
            }
        }

        public bool EditarTarefa(Tarefa tarefa)
        {
            string inserirDados = @"UPDATE [GerenciamentoTarefa].[dbo].[TAREFA] SET [TITULO] = @Titulo, [DESCRICAO] = @Descricao, [DATACRIACAO] = @DataCriacao, [STATUS] = @StatusTarefa
            WHERE [ID] = @Id;";
            
            using (IDbConnection dbConnection = new SqlConnection(_connectionString)){
            
                dbConnection.Open();

                var tarefaResultado = dbConnection.Execute(inserirDados,
                new
                {
                    Id = tarefa.Id,
                    Titulo = tarefa.Titulo,
                    Descricao = tarefa.Descricao,
                    DataCriacao = tarefa.DataCriacao,
                    StatusTarefa = tarefa.Status
                });

            dbConnection.Close();

            return tarefaResultado > 0;
            }
        }

        public Tarefa? VisualizarTarefa(int id)
        {
            string inserirDados = "select * from [GerenciamentoTarefa].[dbo].[TAREFA] where [ID] = @Id;";
            
            using (IDbConnection dbConnection = new SqlConnection(_connectionString)){
            
                dbConnection.Open();
            
                var resultado = dbConnection.QueryFirstOrDefault<Tarefa>(inserirDados,
                new{
                    Id = id
                });

                if (resultado != null){
                    return resultado;
                }
                
                dbConnection.Close();
                
                return null;
            }
        }

        public List<Tarefa> VisualizarTodasTarefas()
        {
            string inserirDados = "select * from [GerenciamentoTarefa].[dbo].[TAREFA]";
            
            List<Tarefa> listaTarefa = new List<Tarefa>();

            using (IDbConnection dbConnection = new SqlConnection(_connectionString)){
            
                dbConnection.Open();
                
                var resultado = dbConnection.Query<Tarefa>(inserirDados);

                dbConnection.Close();

                return resultado.ToList();
            }
        }

        public Tarefa? PesquisarTarefaTitulo(string titulo){
            string pesquisarQuery = "select * from [GerenciamentoTarefa].[dbo].[TAREFA] WHERE [TITULO] = @Titulo;";
            
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                return dbConnection.QueryFirstOrDefault<Tarefa>(pesquisarQuery, new {titulo});
            }
        }
    }
}