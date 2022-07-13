using DesafioFinalAcademiaAtos.Models;
using DesafioFinalAcademiaAtos.Repositorio;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFinalAcademiaAtos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FazerLogin(Login loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = _usuarioRepositorio.BuscaEmail(loginModel.login);
                    if (usuario != null)
                    {
                        if (usuario.ValidaSenha(loginModel.senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha inválida";
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou Senha inválido(os)";
                }

                return View("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar o Login. Favor conferir seus dados. Detalhe do Erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CadastrarLogin(Login loginModel)
        {
            try
            {
                return RedirectToAction("Create", "Usuarios");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Detalhe do Erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
