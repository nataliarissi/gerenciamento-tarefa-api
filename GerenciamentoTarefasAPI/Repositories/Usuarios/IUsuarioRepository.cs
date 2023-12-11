using GerenciamentoTarefasAPI.Models;

namespace GerenciamentoTarefasAPI.Repositories.Usuarios
{
    public interface IUsuarioRepository
    {
        bool CadastrarUsuario(Usuario usuario);
        Usuario? ObterUsuario(int id);
        Usuario? ObterUsuarioLoginSenha(string loginUsuario, string senha);
    }
}
