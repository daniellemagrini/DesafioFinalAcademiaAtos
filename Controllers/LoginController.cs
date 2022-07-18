using DesafioFinalAcademiaAtos.Auxiliar;
using DesafioFinalAcademiaAtos.Models;
using DesafioFinalAcademiaAtos.Repositorio;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFinalAcademiaAtos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmail _email;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao, IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;
        }

        public IActionResult Index()
        {
            //Caso o usuario esteja logado, será redirecionado para a Home, sem passar pela tela login
            if(_sessao.BuscarSessao() != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Logout()
        {
            _sessao.SairSessao();

            return RedirectToAction("Index", "Login");
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
                            _sessao.CriarSessao(usuario);

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

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LinkRedefinirSenha(RedefinirSenha redefinirSenha)
        {
            try
            {
                if (ModelState.IsValid)
                {                   
                    Usuario usuario = _usuarioRepositorio.BuscaEmail(redefinirSenha.login);
                    
                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string assunto = "Redefinição de Senha - RH Treinamentos";
                        string mensagem = $"Nova Senha provisória: {novaSenha}";

                        bool enviado = _email.EnviarEmail(usuario.email, assunto, mensagem);

                        if (enviado)
                        {
                            _usuarioRepositorio.SenhaRedefinida(usuario);
                            TempData["MensagemSucesso"] = $"Foi enviado uma nova senha. Favor verificar seu e-mail";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não foi possível enviar o email de redefinição de senha. Tente novamente mais tarde";
                        }
                        
                        return RedirectToAction("Index", "Login");
                    }

                    TempData["MensagemErro"] = $"E-mail inexistente";
                }

                return View("RedefinirSenha");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível Redefinir sua senha. Favor conferir seu email. Detalhe do Erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
