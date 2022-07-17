using DesafioFinalAcademiaAtos.Models;

namespace DesafioFinalAcademiaAtos.Repositorio
{
    public interface IPerguntaRepositorio
    {
        Pergunta BuscaPerguntaPortugues(int id);
        Pergunta EscolhePerguntaPortugues(Pergunta pergunta);
        Pergunta BuscaPerguntaIngles(int id);
        Pergunta EscolhePerguntaIngles(Pergunta pergunta);
        Pergunta BuscaPerguntaLogica(int id);
        Pergunta EscolhePerguntaLogica(Pergunta pergunta);
    }
}

