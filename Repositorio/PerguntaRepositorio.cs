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

        public List<Pergunta> ListarPerguntas()
        {
            return _contexto.Pergunta.ToList();
        }

        public List<Pergunta> ListarPerguntasIngles(string categoria)
        {
            categoria = "Inglês";
            List<Pergunta> lista = new List<Pergunta>();
            lista = ListarPerguntas();
            List<Pergunta> listaIngles = new List<Pergunta>();

            foreach (Pergunta pergunta in lista)
            {
                if (categoria.Equals(pergunta.categoria))
                {
                    listaIngles.Add(pergunta);
                }
            }
            return listaIngles;
        }

        public List<Pergunta> ListarPerguntasLogica(string categoria)
        {
            categoria = "Lógica";
            List<Pergunta> lista = new List<Pergunta>();
            lista = ListarPerguntas();
            List<Pergunta> listaLogica = new List<Pergunta>();

            foreach (Pergunta pergunta in lista)
            {
                if (categoria.Equals(pergunta.categoria))
                {
                    listaLogica.Add(pergunta);
                }
            }
            return listaLogica;
        }

        public List<Pergunta> ListarPerguntasPortugues(string categoria)
        {
            categoria = "Português";
            List<Pergunta> lista = new List<Pergunta>();
            lista = ListarPerguntas();
            List<Pergunta> listaPortugues = new List<Pergunta>();

            foreach (Pergunta pergunta in lista)
            {
                if (categoria.Equals(pergunta.categoria))
                {
                    listaPortugues.Add(pergunta);
                }
            }
            return listaPortugues;
        }
    }
}
