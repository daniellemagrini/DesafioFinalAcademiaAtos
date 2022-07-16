using DesafioFinalAcademiaAtos.Models;

namespace DesafioFinalAcademiaAtos.Repositorio
{
    public interface IPerguntaRepositorio
    {
        List<Pergunta> ListarPerguntas();
        List<int> SelecionarPergunta();
        Pergunta BuscaPergunta(int id);
        Pergunta EscolhePergunta(Pergunta pergunta);
    }
}
