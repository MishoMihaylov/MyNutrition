using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MyNutrition.Models;
using System.Collections.Generic;
using MyNutrition.DataModels.Models;
using System.Web.Script.Serialization;

namespace MyNutrition.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new MyNutritionUser { UserName = model.UserName, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);
                    
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.UserName);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Statistics()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetStatistics(int daysBack = 2)
        {
            if (daysBack < 0)
            {
                throw new ArgumentException("This software is not designed to see the future -_-.");
            }

            if (!User.Identity.IsAuthenticated)
            {
                throw new Exception("Authentication problem.");
            }


            MyNutritionDbContext db = new MyNutritionDbContext();

            var user = db.Users.Where(u => u.UserName == User.Identity.Name)
                .Single();

            var userConsumation = user.DayConsumations
                .Where(dc => dc.Date >= DateTime.Now.AddDays(-daysBack))
                .OrderBy(dc => dc.Date)
                .ToList();
            
            if(userConsumation.Count == 0)
            {
                return null;
            }

            var result = userConsumation
                .Select(currDay => new
                {
                    Date = currDay.Date != null ? currDay.Date.ToShortDateString() : "null",
                    Calories = currDay.DayCalories != null ? currDay.DayCalories.Overall : 0,
                    Proteins = currDay.DayProteins != null ? currDay.DayProteins.Overall : 0,
                    Vitamins = currDay.DayVitamins != null ? currDay.DayVitamins : null,
                    Minerals = currDay.DayMinerals != null ? currDay.DayMinerals : null
                })
                .ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AteThis(int id, int servSize, bool isRecipe)
        {
            MyNutritionDbContext db = new MyNutritionDbContext();
            DayConsumation dayConsumption;
            if (db.Users.Where(user => user.UserName == User.Identity.Name).Single().DayConsumations.Where(dc => dc.Date.Date == DateTime.Now.Date).Count() == 0)
            {
                dayConsumption = new DayConsumation()
                {
                    Date = DateTime.Now,
                    DayCalories = new Calories(),
                    //DayCarbohydrates = new Carbohydrates(),
                    //DayFats = new Fats(),
                    //DayMinerals = new Minerals(),
                    DayProteins = new Protein(),
                    DayVitamins = new Vitamins()
                };
                db.Users.Where(user => user.UserName == User.Identity.Name).Single().DayConsumations.Add(dayConsumption);
            }
            else
            {
                dayConsumption = db.Users
                    .Where(user => user.UserName == User.Identity.Name)
                    .Single()
                    .DayConsumations.Where(dc => dc.Date.Date == DateTime.Now.Date)
                    .Single();
            }

            if (isRecipe)
            {
                Recipe recipe = db.Recipes.Where(r => r.Id == id).Single();

                foreach (var item in recipe.Ingredients)
                {
                    dayConsumption.DayCalories.Overall += item.Calories.Overall * (item.BaseServingSize / 100);
                    dayConsumption.DayProteins.Overall += item.Protein.Overall * (item.BaseServingSize / 100);
                    dayConsumption.DayVitamins.A += item.Vitamins.A * (item.BaseServingSize / 100);
                    dayConsumption.DayVitamins.B12 += item.Vitamins.B12 * (item.BaseServingSize / 100);
                    dayConsumption.DayVitamins.B6 += item.Vitamins.B6 * (item.BaseServingSize / 100);
                    dayConsumption.DayVitamins.Betaine += item.Vitamins.Betaine * (item.BaseServingSize / 100);
                    dayConsumption.DayVitamins.C += item.Vitamins.C * (item.BaseServingSize / 100);
                    dayConsumption.DayVitamins.D += item.Vitamins.D * (item.BaseServingSize / 100);
                    dayConsumption.DayVitamins.E += item.Vitamins.E * (item.BaseServingSize / 100);
                    dayConsumption.DayVitamins.Choline += item.Vitamins.Choline * (item.BaseServingSize / 100);
                    dayConsumption.DayVitamins.Folate += item.Vitamins.Folate * (item.BaseServingSize / 100);
                    dayConsumption.DayVitamins.K += item.Vitamins.K * (item.BaseServingSize / 100);
                    dayConsumption.DayVitamins.Niacin += item.Vitamins.Niacin * (item.BaseServingSize / 100);
                    dayConsumption.DayVitamins.PantothenicAcid += item.Vitamins.PantothenicAcid * (item.BaseServingSize / 100);
                    dayConsumption.DayVitamins.Riboflavin += item.Vitamins.Riboflavin * (item.BaseServingSize / 100);
                    dayConsumption.DayVitamins.Thiamin += item.Vitamins.Thiamin * (item.BaseServingSize / 100);
                }
            }
            else
            {
                Ingredient ingredient = db.Ingredients.Where(i => i.Id == id).Single();

                dayConsumption.DayCalories.Overall += ingredient.Calories.Overall * (servSize / 100);
                dayConsumption.DayProteins.Overall += ingredient.Protein.Overall * (servSize / 100);
                dayConsumption.DayVitamins.A += ingredient.Vitamins.A * (servSize / 100);
                dayConsumption.DayVitamins.B12 += ingredient.Vitamins.B12 * (servSize / 100);
                dayConsumption.DayVitamins.B6 += ingredient.Vitamins.B6 * (servSize / 100);
                dayConsumption.DayVitamins.Betaine += ingredient.Vitamins.Betaine * (servSize / 100);
                dayConsumption.DayVitamins.C += ingredient.Vitamins.C * (servSize / 100);
                dayConsumption.DayVitamins.D += ingredient.Vitamins.D * (servSize / 100);
                dayConsumption.DayVitamins.E += ingredient.Vitamins.E * (servSize / 100);
                dayConsumption.DayVitamins.Choline += ingredient.Vitamins.Choline * (servSize / 100);
                dayConsumption.DayVitamins.Folate += ingredient.Vitamins.Folate * (servSize / 100);
                dayConsumption.DayVitamins.K += ingredient.Vitamins.K * (servSize / 100);
                dayConsumption.DayVitamins.Niacin += ingredient.Vitamins.Niacin * (servSize / 100);
                dayConsumption.DayVitamins.PantothenicAcid += ingredient.Vitamins.PantothenicAcid * (servSize / 100);
                dayConsumption.DayVitamins.Riboflavin += ingredient.Vitamins.Riboflavin * (servSize / 100);
                dayConsumption.DayVitamins.Thiamin += ingredient.Vitamins.Thiamin * (servSize / 100);
            }

            db.SaveChanges();

            if (isRecipe)
            {
                return RedirectToAction("Index", "Recipes");
            }

            return RedirectToAction("Index", "Ingredients");

        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}