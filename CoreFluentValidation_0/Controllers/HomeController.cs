using CoreFluentValidation_0.Models;
using CoreFluentValidation_0.Models.Entities;
using CoreFluentValidation_0.Models.ViewModels.AppUsers.RequestModels;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoreFluentValidation_0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly IValidator<UserRegisterRequestModel> _userRegisterRequestValidator;

        public HomeController(ILogger<HomeController> logger, IValidator<UserRegisterRequestModel> userRegisterRequestValidator)
        {
            _logger = logger;
            _userRegisterRequestValidator = userRegisterRequestValidator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterRequestModel model)
        {
            ValidationResult validationResult = _userRegisterRequestValidator.Validate(model);
            if (validationResult.IsValid)
            {
                AppUser appUser = new()
                {
                    UserName = model.UserName,
                    Email = model.Email

                };

                //IdentityResult result = await _userManager.CreateAsync(appUser,model.Password);
            }
            else
            {
                foreach (ValidationFailure item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(model);
        }
    }
}
