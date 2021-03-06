using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesafioFinalAcademiaAtos.Models;
using DesafioFinalAcademiaAtos.Auxiliar;
using DesafioFinalAcademiaAtos.Repositorio;

namespace DesafioFinalAcademiaAtos.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Contexto _context;
        private readonly ISessao _sessao;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuariosController(Contexto context, ISessao sessao, IUsuarioRepositorio usuarioRepositorio)
        {
            _context = context;
            _sessao = sessao;
            _usuarioRepositorio = usuarioRepositorio;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
              return _context.Usuario != null ? 
                          View(await _context.Usuario.ToListAsync()) :
                          Problem("Entity set 'Contexto.Usuario'  is null.");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome,cpf,email,cep,logradouro,numero_endereco,complemento,bairro,cidade,estado,telefone,senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario usuarioEmail = _usuarioRepositorio.BuscaEmail(usuario.email);

                if (usuarioEmail == null)
                {
                    usuario.SenhaHash();
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
                    TempData["MensagemSucesso"] = $"Usuário cadastrado com sucesso";
                    return RedirectToAction("Index", "Login");
                }

                else
                {
                    TempData["MensagemErro"] = $"E-mail já cadastrado. Tente redefinir sua senha ou cadastre outro e-mail";
                    return RedirectToAction("Index", "Login");
                }
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome,cpf,email,cep,logradouro,numero_endereco,complemento,bairro,cidade,estado,telefone,senha")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'Contexto.Usuario'  is null.");
            }
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuario?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult MeusDados()
        {
            var usuario = _sessao.BuscarSessao();
            return View("Index", usuario);
        }

        public IActionResult EditarDados()
        {
            var usuario = _sessao.BuscarSessao();
            return View("Edit", usuario);
        }

        public IActionResult Editar(UsuarioEdit usuarioEdit)
        {
            try
            {
                Usuario usuario = _usuarioRepositorio.BuscaEmail(usuarioEdit.email);

                usuario.nome = usuarioEdit.nome;
                usuario.cpf = usuarioEdit.cpf;
                usuario.email = usuarioEdit.email;
                usuario.cep = usuarioEdit.cep;
                usuario.logradouro = usuarioEdit.logradouro;
                usuario.numero_endereco = usuarioEdit.numero_endereco;
                usuario.complemento = usuarioEdit.complemento;
                usuario.bairro = usuarioEdit.bairro;
                usuario.cidade = usuarioEdit.cidade;
                usuario.estado = usuarioEdit.estado;
                usuario.telefone = usuarioEdit.telefone;

                if (ModelState.IsValid)
                {
                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Dados alterados com sucesso";
                    return RedirectToAction("Index", "Home");
                }

                return View(usuario);
            }
            catch(Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível atualizar seus dados. Tente novamente mais tarde. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
