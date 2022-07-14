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

        public Usuario SenhaRedefinida(Usuario usuario)
        {
            Usuario usuario1 = BuscaEmail(usuario.email);

            if (usuario1 == null)
            {
                throw new System.Exception("Tivemos um erro. Tente novamente mais tarde");
            }

            usuario1.senha = usuario1.senha;
            _contexto.Usuario.Update(usuario1);
            _contexto.SaveChanges();

            return usuario;

        }

        public Usuario SenhaRedefinida(string senha)
        {
            throw new NotImplementedException();
        }
    }
}
