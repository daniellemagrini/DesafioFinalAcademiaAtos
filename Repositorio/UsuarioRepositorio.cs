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

        public Usuario Atualizar(Usuario usuario)
        {
            Usuario usuarioBD = BuscaEmail(usuario.email);

            if (usuarioBD == null)
            {
                throw new Exception("Houve uma falha na atualização");
            }
            else
            {
                usuarioBD.nome = usuario.nome;
                usuarioBD.cpf = usuario.cpf;
                usuarioBD.email = usuario.email;
                usuarioBD.senha = usuario.senha;
                usuarioBD.cep = usuario.cep;
                usuarioBD.logradouro = usuario.logradouro;
                usuarioBD.numero_endereco = usuario.numero_endereco;
                usuarioBD.complemento = usuario.complemento;
                usuarioBD.bairro = usuario.bairro;
                usuarioBD.cidade = usuario.cidade;
                usuarioBD.estado = usuario.estado;

                _contexto.Usuario.Update(usuarioBD);
                _contexto.SaveChanges();

                return usuarioBD;
            }
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
