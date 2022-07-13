using DesafioFinalAcademiaAtos.Models;

namespace DesafioFinalAcademiaAtos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Contexto _contexto;

        public UsuarioRepositorio(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public Usuario BuscaEmail(string email)
        {
            return _contexto.Usuario.FirstOrDefault(x => x.email == email.ToLower());
        }
    }
}
