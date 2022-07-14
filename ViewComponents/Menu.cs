using DesafioFinalAcademiaAtos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DesafioFinalAcademiaAtos.ViewComponents
{  
    public class Menu : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContext;
        public Menu(IHttpContextAccessor httpContext)
        {

            _httpContext = httpContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("UsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return View();
            }

            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);

            return View(); // View Default
        }
    }
}
