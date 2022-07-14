using DesafioFinalAcademiaAtos.Models;
using Newtonsoft.Json;

namespace DesafioFinalAcademiaAtos.Auxiliar
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao (IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public Usuario BuscarSessao()
        {
            string SessaoUsuario = _httpContext.HttpContext.Session.GetString("UsuarioLogado"); //Buscando a string
            
            if (string.IsNullOrEmpty(SessaoUsuario))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Usuario>(SessaoUsuario);
        }

        public void CriarSessao(Usuario usuario)
        {
            string conv = JsonConvert.SerializeObject(usuario); //Transformando para string com um valor serializado
            _httpContext.HttpContext.Session.SetString("UsuarioLogado",conv); // Setando a string
        }

        public void SairSessao()
        {
            _httpContext.HttpContext.Session.Remove("UsuarioLogado");
        }
    }
}
