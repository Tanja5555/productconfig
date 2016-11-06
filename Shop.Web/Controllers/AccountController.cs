using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Shop.Web.Models;
using System.Web;
using System.Web.Mvc;
using TanLeonaShop.Domain.Models;

namespace Shop.Web.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                ViewBag.ReturnUrl = returnUrl;
                var shopContext = new ShopContext();
                var userStore = new UserStore<AppUser>(shopContext);
                var userManager = new UserManager<AppUser>(userStore);
                var authenticationManager =
                HttpContext.GetOwinContext().Authentication;
                var signInManager = new SignInManager<AppUser, string>(userManager, authenticationManager);
                var result = signInManager.PasswordSignIn(model.UserName, model.Password, isPersistent: false, shouldLockout: false);
                switch (result)
                {
                    case SignInStatus.Success:
                        var user = userManager.FindByName(model.UserName);
                        var isAdmin = userManager.IsInRole(user.Id, "admins");
                        if (isAdmin)
                        {
                            return RedirectToAction("Index", "AdminOrders");
                        }
                        else
                        {
                            return RedirectToLocal(returnUrl);
                        }

                    default:
                        ModelState.AddModelError("", "Invalid login attempt.");
                        break;
                }
            }
           
            return View();
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Product");
        }

        public ActionResult LogOff()
        {
            var authenticationManager =
            HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut(
            DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Product");
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.UserName,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    CompanyName = model.CompanyName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address
                };

                var shopContext = new ShopContext();
                var userStore = new UserStore<AppUser>(shopContext);
                var userManager = new UserManager<AppUser>(userStore);
                var result = userManager.Create(user, model.Password);
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
               
                if (result.Succeeded)
                {
                    var signInManager = new SignInManager<AppUser, string>(userManager, authenticationManager);
                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: true);
                    return RedirectToAction("Index", "Product");                    
                }
               
                else
                {
                    AddErrors(result);
                }
               

            }
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

        }

    }
}
