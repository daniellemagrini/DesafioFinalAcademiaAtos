using DesafioFinalAcademiaAtos.Models;

namespace DesafioFinalAcademiaAtos.Auxiliar
{
    public interface ISessao
    {
        void CriarSessao(Usuario usuario);
        void SairSessao();

        Usuario BuscarSessao();
    }
}
