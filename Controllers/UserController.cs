using CGenius.Data;
using CGenius.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CGenius.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _dataContext;
        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        public IActionResult EfetuarLogin(LoginDTO request) 
        {
            var session = HttpContext.Session.GetInt32("_Id");
            var find = _dataContext.Usuarios.Find(session);
            if (find != null)
            {

                return RedirectToAction("PerfilPage", "User");
            }
            
            var getUser = _dataContext.Usuarios.FirstOrDefault(x => x.UserEmail == request.Email);
            if (getUser == null) 
            {
                //TODO: Retornar um card com a informaç~eo que não há cadastro
                return NotFound();
            }
            if(!BCrypt.Net.BCrypt.Verify(request.Password, getUser.PasswordHash))
            {
                //TODO: Retornar um card com a informaç~eo que não há cadastro
                return NotFound();
            }
            if(getUser.IsActive == false)
            {
                getUser.IsActive = true;
            }

            HttpContext.Session.SetInt32("_Id", getUser.Id);
            HttpContext.Session.SetString("_Email", getUser.UserEmail);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult CadastroPage()
        {
            var session = HttpContext.Session.GetInt32("_Id");
            var find = _dataContext.Usuarios.Find(session);
            if (find != null)
            {

                return RedirectToAction("PerfilPage", "User");
            }


            return View();
        }

        public IActionResult EfetuarCadastro(CadastroDTO request) 
        {
            var findUser = _dataContext.Usuarios.FirstOrDefault(x => x.UserEmail == request.UserEmail);
            if (findUser != null)
            {
                //TODO: Retornar um card com a informaç~eo que há cadastro
                return NotFound();
            }

            Usuario newUser = new Usuario
            {
                UserEmail = request.UserEmail,
                UserName = request.UserName,
                NickName = request.NickName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash),
                DateRegister = DateTime.Now,
            };

            _dataContext.Usuarios.Add(newUser);
            _dataContext.SaveChanges();

            return RedirectToAction("LoginPage", "User");
        }

        public IActionResult PerfilPage() 
        {
            var id = HttpContext.Session.GetInt32("_Id");
            if(id == null)
            {
                return RedirectToAction("Index","Home");
            }
            var getUser = _dataContext.Usuarios.Find(id);

            var getAtualizacao = _dataContext.Atualizacoes.ToList();

            ViewBag.getAtualizacao = getAtualizacao;
            ViewBag.User = getUser;
            ViewBag.isLogged = true;

            return View();
        }

        public IActionResult EditarPerfil(string FotoUrl, CadastroDTO request) 
        {
            var id = HttpContext.Session.GetInt32("_Id");
            var getUser = _dataContext.Usuarios.Find(id);
            
                getUser.UserEmail = request.UserEmail != "" ? request.UserEmail : getUser.UserEmail;
                getUser.UserName = request.UserName != "" ? request.UserName : getUser.UserName; 
                getUser.NickName = request.NickName != "" ? request.NickName : getUser.NickName;   
                getUser.FotoUrl = FotoUrl != "" ? FotoUrl : getUser.FotoUrl;

            _dataContext.Update(getUser);
            _dataContext.SaveChanges();
            
            return RedirectToAction("PerfilPage");
        }

        public IActionResult DeletarPerfil(int id)
        {
            var getUser = _dataContext.Usuarios.Find(id);
            getUser.IsActive = false;

            _dataContext.Update(getUser);
            _dataContext.SaveChanges();

            return RedirectToAction("PerfilPage");
        }
    }
}
