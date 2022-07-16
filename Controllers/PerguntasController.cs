using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesafioFinalAcademiaAtos.Models;
using DesafioFinalAcademiaAtos.Repositorio;

namespace DesafioFinalAcademiaAtos.Controllers
{
    public class PerguntasController : Controller
    {
        private readonly Contexto _context;
        private readonly IPerguntaRepositorio _perguntaRepositorio;

        public PerguntasController(Contexto context, IPerguntaRepositorio perguntaRepositorio)
        {
            _context = context;
            _perguntaRepositorio = perguntaRepositorio;
        }

        // GET: Perguntas
        public async Task<IActionResult> Index()
        {
              return _context.Pergunta != null ? 
                          View(await _context.Pergunta.ToListAsync()) :
                          Problem("Entity set 'Contexto.Pergunta'  is null.");
        }

        // GET: Perguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pergunta == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Pergunta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pergunta == null)
            {
                return NotFound();
            }

            return View(pergunta);
        }

        // GET: Perguntas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perguntas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,pergunta,resposta,categoria,nivel,solucao,alternativaA,alternativaB,alternativaC,alternativaD,alternativaE")] Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pergunta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pergunta);
        }

        // GET: Perguntas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pergunta == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Pergunta.FindAsync(id);
            if (pergunta == null)
            {
                return NotFound();
            }
            return View(pergunta);
        }

        // POST: Perguntas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,pergunta,resposta,categoria,nivel,solucao,alternativaA,alternativaB,alternativaC,alternativaD,alternativaE")] Pergunta pergunta)
        {
            if (id != pergunta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pergunta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerguntaExists(pergunta.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pergunta);
        }

        // GET: Perguntas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pergunta == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Pergunta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pergunta == null)
            {
                return NotFound();
            }

            return View(pergunta);
        }

        // POST: Perguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pergunta == null)
            {
                return Problem("Entity set 'Contexto.Pergunta'  is null.");
            }
            var pergunta = await _context.Pergunta.FindAsync(id);
            if (pergunta != null)
            {
                _context.Pergunta.Remove(pergunta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerguntaExists(int id)
        {
          return (_context.Pergunta?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult ComecarTeste(Pergunta pergunta)
        {
            try
            {
                Pergunta perguntaBD = _perguntaRepositorio.BuscaPergunta(pergunta.Id);

                if (ModelState.IsValid)
                {
                    perguntaBD = _perguntaRepositorio.EscolhePergunta(pergunta);
                    return View(pergunta);
                }

                return View(pergunta);
            }
            catch(Exception e)
            {
                TempData["MensagemErro"] = $"Detalhe do erro: {e.Message}";
                return RedirectToAction("Index", "Home");
            }
            /*List<Pergunta> perguntaSelecionada = _perguntaRepositorio.ListarPerguntas();
            List<int> idsSelecionados = new List<int>();
            Random random = new Random();
            int idSelecao = random.Next(1, perguntaSelecionada.Count);            
            idsSelecionados.Add(idSelecao);

            while (idsSelecionados.Contains(idSelecao))
            {
                idSelecao = random.Next(1, perguntaSelecionada.Count);
                idsSelecionados.Add(idSelecao);
            }

            return View(perguntaSelecionada);*/
        }
    }
}
