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
                listaSelecao.Add(idSelecao);
            }
            return listaSelecao;
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

        public List<int> SelecionarPerguntaIngles()
        {
            string categoria = "Inglês";
            List<Pergunta> lista = new List<Pergunta>();
            lista = ListarPerguntasIngles(categoria);
            List<int> listaSelecao = new List<int>();
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                int idSelecao = r.Next(1, lista.Count);
                listaSelecao.Add(idSelecao);
            }
            return listaSelecao;
        }

        public List<int> SelecionarPerguntaLogica()
        {
            string categoria = "Lógica";
            List<Pergunta> lista = new List<Pergunta>();
            lista = ListarPerguntasIngles(categoria);
            List<int> listaSelecao = new List<int>();
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                int idSelecao = r.Next(1, lista.Count);
                listaSelecao.Add(idSelecao);
            }
            return listaSelecao;
        }

        public List<int> SelecionarPerguntaPortugues()
        {
            string categoria = "Português";
            List<Pergunta> lista = new List<Pergunta>();
            lista = ListarPerguntasIngles(categoria);
            List<int> listaSelecao = new List<int>();
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {

                int idSelecao = r.Next(1, lista.Count);
                listaSelecao.Add(idSelecao);
            }
            return listaSelecao;
        }
    }
}
