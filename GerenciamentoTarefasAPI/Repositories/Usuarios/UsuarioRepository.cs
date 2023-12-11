using GerenciamentoTarefaAPI.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using GerenciamentoTarefasAPI.Models;

namespace GerenciamentoTarefasAPI.Repositories.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string _connectionString { get; set; }

        public UsuarioRepository(){
            _connectionString = "Data Source=.;Initial Catalog=GerenciamentoTarefa;User ID=sa;Password=Natalia@123";
        }
        public bool CadastrarUsuario(Usuario usuario){
            string inserirDados = @"Insert into [GerenciamentoTarefa].[dbo].[USUARIO] ([NOME], [LOGINUSUARIO], [SENHA]) 
            values (@Nome, @LoginUsuario, HASHBYTES('MD5', @SENHA))";

            using (IDbConnection dbConnection = new SqlConnection(_connectionString)){
                var tarefaResultado = dbConnection.Execute(inserirDados,
                    new
                    {
                        Nome = usuario.Nome,
                        LoginUsuario = usuario.LoginUsuario,
                        Senha = usuario.Senha
                    });

                return tarefaResultado > 0;
            }
        }

        public Usuario? ObterUsuario(int id)
        {
            string inserirDados = "select * from [GerenciamentoTarefa].[dbo].[USUARIO] where [ID] = @Id;";

            using (IDbConnection dbConnection = new SqlConnection(_connectionString)){
                var resultado = dbConnection.QueryFirstOrDefault<Usuario>(inserirDados,
                new
                {
                    Id = id
                });

                if (resultado != null)
                {
                    return resultado;
                }

                return null;
            }
        }

        public Usuario? ObterUsuarioLoginSenha(string loginUsuario, string senha)
        {
            string inserirDados = "SELECT * FROM USUARIO WHERE LOGINUSUARIO = @LoginUsuario AND SENHA = HASHBYTES('MD5', @SENHA)";

            using (IDbConnection dbConnection = new SqlConnection(_connectionString)){
                var resultado = dbConnection.QueryFirstOrDefault<Usuario>(inserirDados,
                new
                {
                    LoginUsuario = loginUsuario,
                    Senha = senha
                });

                return resultado;
            }
        }
    }
}
