using GerenciamentoTarefaAPI.Models;
using GerenciamentoTarefasAPI.Models;
using GerenciamentoTarefasAPI.Repositories.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoTarefasAPI.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository){
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("cadastrarUsuario")]
        //[Authorize] Comentado para permitir cadastrar usuário
        public bool CadastrarUsuario([FromBody] Usuario usuario){
            return _usuarioRepository.CadastrarUsuario(usuario);
        }

        [HttpGet("obterUsuario")]
        [Authorize]
        public Usuario? ObterUsuarioPorId(int id){
            return _usuarioRepository.ObterUsuario(id);
        }

        [HttpPost("Autenticar")]
        public string Autenticar(string usuario, string senha)
        {
            var usuarioEncontrado = _usuarioRepository.ObterUsuarioLoginSenha(usuario, senha);

            if (usuarioEncontrado == null)
                throw new Exception("Usuário não encontrado");

            var geradorToken = new GeradorToken();
            return geradorToken.GerarToken(usuarioEncontrado);
        }
    }
}