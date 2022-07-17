using DesafioFinalAcademiaAtos.Models;

namespace DesafioFinalAcademiaAtos.Repositorio
{
    public class PerguntaRepositorio : IPerguntaRepositorio
    {
        private readonly Contexto _contexto;

        public PerguntaRepositorio(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public Pergunta BuscaPerguntaPortugues(int id)
        {
            List<Pergunta> listaPergunta = new List<Pergunta>();
            listaPergunta = _contexto.Pergunta.ToList();
            id = new Random().Next(1,listaPergunta.Count());

            Pergunta pergunta = listaPergunta[id];

            while (pergunta.categoria != "Português")
            {
                id = new Random().Next(1, listaPergunta.Count());
                pergunta = listaPergunta[id];
            }

            return pergunta;

        }

        public Pergunta EscolhePerguntaPortugues(Pergunta pergunta)
        {
            Pergunta perguntaBD = BuscaPerguntaPortugues(pergunta.Id);

            if (perguntaBD == null)
            {
                throw new Exception("Houve uma falha na atualização");
            }
            else if (pergunta.categoria == "Português")
            {
                perguntaBD.pergunta = pergunta.pergunta;
                perguntaBD.resposta = pergunta.resposta;
                perguntaBD.categoria = pergunta.categoria;
                perguntaBD.nivel = pergunta.nivel;
                perguntaBD.solucao = pergunta.solucao;
                perguntaBD.alternativaA = pergunta.alternativaA;
                perguntaBD.alternativaB = pergunta.alternativaB;
                perguntaBD.alternativaC = pergunta.alternativaC;
                perguntaBD.alternativaD = pergunta.alternativaD;
                perguntaBD.alternativaE = pergunta.alternativaE;

                return perguntaBD;
            }
            return perguntaBD;
        }

        public Pergunta BuscaPerguntaIngles(int id)
        {
            List<Pergunta> listaPergunta = new List<Pergunta>();
            listaPergunta = _contexto.Pergunta.ToList();
            id = new Random().Next(1, listaPergunta.Count());

            Pergunta pergunta = listaPergunta[id];

            while (pergunta.categoria != "Inglês")
            {
                id = new Random().Next(1, listaPergunta.Count());
                pergunta = listaPergunta[id];
            }

            return pergunta;

        }

        public Pergunta EscolhePerguntaIngles(Pergunta pergunta)
        {
            Pergunta perguntaBD = BuscaPerguntaIngles(pergunta.Id);

            if (perguntaBD == null)
            {
                throw new Exception("Houve uma falha na atualização");
            }
            else if (pergunta.categoria == "Inglês")
            {
                perguntaBD.pergunta = pergunta.pergunta;
                perguntaBD.resposta = pergunta.resposta;
                perguntaBD.categoria = pergunta.categoria;
                perguntaBD.nivel = pergunta.nivel;
                perguntaBD.solucao = pergunta.solucao;
                perguntaBD.alternativaA = pergunta.alternativaA;
                perguntaBD.alternativaB = pergunta.alternativaB;
                perguntaBD.alternativaC = pergunta.alternativaC;
                perguntaBD.alternativaD = pergunta.alternativaD;
                perguntaBD.alternativaE = pergunta.alternativaE;

                return perguntaBD;
            }
            return perguntaBD;
        }

        public Pergunta BuscaPerguntaLogica(int id)
        {
            List<Pergunta> listaPergunta = new List<Pergunta>();
            listaPergunta = _contexto.Pergunta.ToList();
            id = new Random().Next(1, listaPergunta.Count());

            Pergunta pergunta = listaPergunta[id];

            while (pergunta.categoria != "Lógica")
            {
                id = new Random().Next(1, listaPergunta.Count());
                pergunta = listaPergunta[id];
            }

            return pergunta;

        }

        public Pergunta EscolhePerguntaLogica(Pergunta pergunta)
        {
            Pergunta perguntaBD = BuscaPerguntaLogica(pergunta.Id);

            if (perguntaBD == null)
            {
                throw new Exception("Houve uma falha na atualização");
            }
            else if (pergunta.categoria == "Lógica")
            {
                perguntaBD.pergunta = pergunta.pergunta;
                perguntaBD.resposta = pergunta.resposta;
                perguntaBD.categoria = pergunta.categoria;
                perguntaBD.nivel = pergunta.nivel;
                perguntaBD.solucao = pergunta.solucao;
                perguntaBD.alternativaA = pergunta.alternativaA;
                perguntaBD.alternativaB = pergunta.alternativaB;
                perguntaBD.alternativaC = pergunta.alternativaC;
                perguntaBD.alternativaD = pergunta.alternativaD;
                perguntaBD.alternativaE = pergunta.alternativaE;

                return perguntaBD;
            }
            return perguntaBD;
        }
    }
}
