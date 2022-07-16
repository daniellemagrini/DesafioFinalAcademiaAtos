using DesafioFinalAcademiaAtos.Models;

namespace DesafioFinalAcademiaAtos.Repositorio
{
    public interface IPerguntaRepositorio
    {
        List<Pergunta> ListarPerguntas();
        List<int> SelecionarPergunta();


    }
}
