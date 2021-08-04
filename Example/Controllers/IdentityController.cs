using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Example.Core.Account;
using Example.Core.Account.Dtos;
using Example.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFw.DbContext;
using WFw.Exceptions;
using WFw.IDbContext;

namespace Example.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly SingletonConfigModel _singletonConfigModel;
        private readonly ILogger<IdentityController> _logger;
        public IdentityController(IAccountService accountService, SingletonConfigModel singletonConfigModel, ILogger<IdentityController> logger)
        {
            _accountService = accountService;
            _singletonConfigModel = singletonConfigModel;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            _singletonConfigModel.VisitNum++;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInInputDto inputDto)
        {
            _logger.LogInformation("start SignIn");

            if (ModelState.IsValid)
            {
                try
                {
                    SignInOutputDto result = await _accountService.SignInAsync(inputDto);

                    var claims = new List<Claim>{
                            new Claim(ClaimTypes.Name, result.NickName),
                            new Claim(ClaimTypes.NameIdentifier,result.Id.ToString()),
                            new Claim(ClaimTypes.Role,result.Role),
                        };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                           new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "Home");

                }
                catch (BadRequestException e)
                {
                    ModelState.AddModelError("", e.Message);
                }

            }
            return View(inputDto);
        }
    }
}
