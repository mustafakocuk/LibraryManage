using booklib.Entities;
using booklib.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace booklib.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AccountController(DatabaseContext databaseContext, IConfiguration configuration, IMapper mapper = null)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
            _mapper = mapper;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Register(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Users.Any(x => x.UserName.ToLower() == model.UserName.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.UserName), "Kullanıcı adı kullanımda...");
                    return View(model);
                }
                User user = new()
                {
                    UserName = model.UserName,
                    Password = model.Password
                };
                _databaseContext.Users.Add(user);
                int affectedRowCount = _databaseContext.SaveChanges();

                if (affectedRowCount == 0)
                {
                    ModelState.AddModelError("", "Kullanıcı Eklenemedi!!!");
                }
                else
                {
                    return RedirectToAction(nameof(Login));
                }
            }
            return View(model);
            
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _databaseContext.Users.SingleOrDefault(x => x.UserName.ToLower() == model.UserName.ToLower() && x.Password==model.Password);

                if (user != null)
                {
                    if (user.Locked)
                    {
                        ModelState.AddModelError(nameof(model.UserName), "Kullanıcı Kilitli.");
                        return View(model);
                    }

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, user.FullName ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Role, user.Role));
                    claims.Add(new Claim("UserName", user.UserName));
                   


                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı ve ya şifre hatalı!!!");
                }

            }
            return View(model);

        }
        public IActionResult Profile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Profile(UserModel model)
        {
            return View();
        }

        public IActionResult BookListed()
        {
            List<BookModel> books = 
                _databaseContext.Books.ToList().Select(x=> _mapper.Map<BookModel>(x)).ToList();
            return View(books);

        }
        
        public IActionResult BorrowBook(Guid id)
        {
            Book book = _databaseContext.Books.Find(id);
            ClaimsPrincipal principal = HttpContext.User;
            Guid userId = new Guid(principal.FindFirst(ClaimTypes.NameIdentifier).Value);

            User user = _databaseContext.Users.Find(userId);


            Lib entity = new Lib();
            entity.Book = book;
            entity.User = user;
            entity.UserName = user.UserName;
            entity.BookName = book.BookName;
            entity.Book.Stock = book.Stock - 1;

            

            //List<LibViewModel> libs =
            //    _databaseContext.Libs.ToList().Select(x => _mapper.Map<LibViewModel>(x)).xToList();

            //var username = entity.User.UserName;
            //var bookname = entity.Book.BookName;

            _databaseContext.Add(entity);
            
            
            _databaseContext.SaveChanges();
           

            return RedirectToAction(nameof(BookListed));

        }
        
        public IActionResult ListBook()
        {
            ClaimsPrincipal principal = HttpContext.User;
            var userid = new Guid(principal.FindFirst(ClaimTypes.NameIdentifier).Value).ToString();

            ViewBag.userid = userid;
            

            List<LibViewModel> libs =
                 _databaseContext.Libs.ToList().Select(x => _mapper.Map<LibViewModel>(x)).ToList();

            return View(libs);
           

        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

        
        
    }
}
