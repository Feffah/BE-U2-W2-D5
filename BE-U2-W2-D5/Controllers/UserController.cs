using BE_U2_W2_D5.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BE_U2_W2_D5.Models.Dto;

namespace BE_U2_W2_D5.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //pagina di registrazione
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    ApplicationUser user = new ApplicationUser()
                    {
                        UserName = registerRequest.Email,
                        Email = registerRequest.Email,
                        Name = registerRequest.Nome,
                        Surname = registerRequest.Cognome,
                        PhoneNumber = registerRequest.Telefono,
                        CreatedAt = DateTime.Now,
                        Birthday = registerRequest.DataDiNascita,
                        Gender = registerRequest.Sesso,
                        Id = Guid.NewGuid().ToString(),
                        IsDeleted = false,
                        EmailConfirmed = true,
                        LockoutEnabled = false



                    };
                    IdentityResult result = await _userManager.CreateAsync(user, registerRequest.Password);
                    if (result.Succeeded)
                    {
                        var role = "User";
                        if (registerRequest.Ruolo!= null && registerRequest.Ruolo!= "")
                        {
                            role= registerRequest.Ruolo;
                        }

                        var roleExist = await this._roleManager.RoleExistsAsync(role);
                        if (!roleExist)
                        {
                            await this._roleManager.CreateAsync(new IdentityRole(role));


                        }
                        await this._userManager.AddToRoleAsync(user, role);

                    }


                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Errore durante la registrazione");
                return RedirectToAction("Index", "Home");
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        //pagina di login
        [HttpPost]

        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {

                    var result = await _signInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Password, loginRequest.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
               
                ModelState.AddModelError("", "Credenziali non valide");
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }


        }
        
        //metodo di logout

        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
