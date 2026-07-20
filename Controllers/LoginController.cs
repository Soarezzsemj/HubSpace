using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security; 
using System.Threading.Tasks; 
using HubSpace.Web.Models;
using HubSpace.Web.Repositorio;
using BCrypt.Net;
using HubSpace.Web.ViewModels;

namespace HubSpace.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly RepositorioUsuario _repositorioUsuario;

        public LoginController()
        {
            var contexto = new HubSpaceContext(); 
            _repositorioUsuario = new RepositorioUsuario(contexto);
        }

        [HttpGet]
        public ActionResult Login() => View();
        
        // Este método recebe os dados quando o usuário clica em "Entrar"
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var usuario = await _repositorioUsuario.ObterPorEmailAsync(model.Email);

            if (usuario != null)
            {
                bool passwordCheck = BCrypt.Net.BCrypt.Verify(model.Password, usuario.SenhaHash);

                if (passwordCheck && usuario.Status == "Ativo")
                {
                    FormsAuthentication.SetAuthCookie(usuario.Nome, false);
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Incorrect username or password");
            return View(model);
        }
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}