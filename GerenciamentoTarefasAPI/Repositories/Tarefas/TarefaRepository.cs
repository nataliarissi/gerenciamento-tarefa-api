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

        public TarefaRepository(IConfiguration configuration){
            _connectionString = configuration.GetConnectionString("GerenciamentoTarefa");
        }

        public bool CadastrarTarefa(TarefaCadastro tarefaCadastro)
        {
            string inserirDados = @"Insert into [GerenciamentoTarefa].[dbo].[TAREFA] ([TITULO], [DESCRICAO], [DATACRIACAO], [STATUS]) 
            values (@Titulo, @Descricao, @DataCriacao, @StatusTarefa)";
            
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                var tarefaResultado = dbConnection.Execute(inserirDados,
                    new
                    {
                        Titulo = tarefaCadastro.Titulo,
                        Descricao = tarefaCadastro.Descricao,
                        DataCriacao = tarefaCadastro.DataCriacao,
                        StatusTarefa = tarefaCadastro.Status
                    });
                
                    return tarefaResultado > 0;
            }
        }  

        public bool DeletarTarefa(int id)
        {
            string inserirDados = "Delete [GerenciamentoTarefa].[dbo].[TAREFA] where [ID] = @Id;";
            using (IDbConnection dbConnection = new SqlConnection(_connectionString)){

                var tarefaResultado = dbConnection.Execute(inserirDados,
                new
                {
                    Id = id
                });
                
                return tarefaResultado > 0;
            }
        }

        public bool EditarTarefa(Tarefa tarefa)
        {
            string inserirDados = @"UPDATE [GerenciamentoTarefa].[dbo].[TAREFA] SET [TITULO] = @Titulo, [DESCRICAO] = @Descricao, [DATACRIACAO] = @DataCriacao, [STATUS] = @StatusTarefa
            WHERE [ID] = @Id;";
            
            using (IDbConnection dbConnection = new SqlConnection(_connectionString)){
            
                var tarefaResultado = dbConnection.Execute(inserirDados,
                new
                {
                    Id = tarefa.Id,
                    Titulo = tarefa.Titulo,
                    Descricao = tarefa.Descricao,
                    DataCriacao = tarefa.DataCriacao,
                    StatusTarefa = tarefa.Status
                });

            return tarefaResultado > 0;
            }
        }

        public Tarefa? VisualizarTarefa(int id)
        {
            string inserirDados = "select * from [GerenciamentoTarefa].[dbo].[TAREFA] where [ID] = @Id;";
            
            using (IDbConnection dbConnection = new SqlConnection(_connectionString)){
            
                var resultado = dbConnection.QueryFirstOrDefault<Tarefa>(inserirDados,
                new{
                    Id = id
                });

                if (resultado != null){
                    return resultado;
                }
                                
                return null;
            }
        }

        public PaginacaoTarefa<List<Tarefa>> VisualizarTodasTarefas(int numeroPaginaAtual, int tamanhoPagina)
        {
            int tamanhoMaxPagina = 50;

            tamanhoPagina = (tamanhoPagina > 0 && tamanhoPagina <= tamanhoMaxPagina) ? tamanhoPagina : tamanhoMaxPagina;

            int pular = (numeroPaginaAtual - 1) * tamanhoPagina;
            int pegar = tamanhoPagina;

            string query = @"SELECT COUNT(*) 
                           FROM TAREFA

                           SELECT * FROM TAREFA
                           ORDER BY ID
                           OFFSET @Pular ROWS FETCH NEXT @Pegar ROWS ONLY"
            ;

            using (var connection = new SqlConnection(_connectionString)){
                var leitura = connection.QueryMultiple(query, new { Pular = pular, Pegar = pegar });
                int count = leitura.Read<int>().FirstOrDefault();
                List<Tarefa> todasTarefas = leitura.Read<Tarefa>().ToList();

                var result = new PaginacaoTarefa<List<Tarefa>>(todasTarefas, count, numeroPaginaAtual, tamanhoPagina);
                return result;
            }
        }

        public List<Tarefa> PesquisarTarefaTitulo(string titulo){
            string pesquisarQuery = "select * from [GerenciamentoTarefa].[dbo].[TAREFA] WHERE [TITULO] LIKE @Titulo;";
            
            using (IDbConnection dbConnection = new SqlConnection(_connectionString)){
                return dbConnection.Query<Tarefa>(pesquisarQuery, new { titulo = "%" + titulo + "%"}).ToList();
            }
        }
    }
}