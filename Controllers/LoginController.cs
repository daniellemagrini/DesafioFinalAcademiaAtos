using DesafioFinalAcademiaAtos.Models;
using DesafioFinalAcademiaAtos.Repositorio;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFinalAcademiaAtos.Controllers
{
    public class LoginController : Controller
    {
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

                    if (loginModel.login == "adm@adm.com" && loginModel.senha == "12345678")
                    {
                        return RedirectToAction("Index", "Home");
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
