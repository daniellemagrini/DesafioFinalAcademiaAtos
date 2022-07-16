using DesafioFinalAcademiaAtos.Models;

namespace DesafioFinalAcademiaAtos.Repositorio
{
    public interface IPerguntaRepositorio
    {
        List<Pergunta> ListarPerguntas();
        List<Pergunta> ListarPerguntasPortugues(string categoria);
        List<Pergunta> ListarPerguntasIngles(string categoria);
        List<Pergunta> ListarPerguntasLogica(string categoria);
        

    }
}
