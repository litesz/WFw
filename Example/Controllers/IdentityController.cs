using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Example.Core.Account;
using Example.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WFw.Exceptions;

namespace Example.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IAccountService _accountService;
        public IdentityController(IAccountService accountService)
        {

            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInInputDto inputDto)
        {
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
