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

        public Pergunta BuscaPergunta(int id)
        {
            Random random = new Random();
            id = random.Next(1,3);

            return _contexto.Pergunta.FirstOrDefault(x => x.Id == id);
        }

        public Pergunta EscolhePergunta(Pergunta pergunta)
        {
            Pergunta perguntaBD = BuscaPergunta(pergunta.Id);

            if (perguntaBD == null)
            {
                throw new Exception("Houve uma falha na atualização");
            }
            else
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
        }

        public List<Pergunta> ListarPerguntas()
        {
            Pergunta pergunta = new Pergunta();
            List<Pergunta> lista = new List<Pergunta>();
            lista = _contexto.Pergunta.ToList();

            if (pergunta.categoria == "Português")
            {               
                List<Pergunta> listaPortugues = new List<Pergunta>();

                foreach (Pergunta itemPergunta in lista)
                {
                    listaPortugues.Add(itemPergunta);                   
                }
                return listaPortugues;
            }

            if (pergunta.categoria == "Inglês")
            {
                List<Pergunta> listaIngles = new List<Pergunta>();

                foreach (Pergunta itemPergunta in lista)
                {
                    listaIngles.Add(itemPergunta);
                }
                return listaIngles;
            }

            if (pergunta.categoria == "Lógica")
            {
                List<Pergunta> listaLogica = new List<Pergunta>();

                foreach (Pergunta itemPergunta in lista)
                {
                    listaLogica.Add(itemPergunta);
                }
                return listaLogica;
            }

            return _contexto.Pergunta.ToList();
        }

        public List<int> SelecionarPergunta()
        {
            List<Pergunta> lista = new List<Pergunta>();
            lista = ListarPerguntas();
            List<int> listaSelecao = new List<int>();
            List<int> listaSelecionados = new List<int>();
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                int idSelecao = r.Next(1, lista.Count);
                listaSelecionados.Add(idSelecao);

                while (listaSelecionados.Contains(idSelecao))
                {
                    idSelecao = r.Next(1, lista.Count);
                    listaSelecionados.Add(idSelecao);
                }

                listaSelecao.Add(idSelecao);
            }
            return listaSelecao;
        }
    }
}
