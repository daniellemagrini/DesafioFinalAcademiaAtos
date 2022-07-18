using DesafioFinalAcademiaAtos.Models;

namespace DesafioFinalAcademiaAtos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscaEmail(string email);
        Usuario SenhaRedefinida(Usuario usuario);
        Usuario Atualizar(Usuario usuario);
    }
}
