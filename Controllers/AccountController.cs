using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExclusiveContent.Models;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ExclusiveContent.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Login()
		{
			if (!HttpContext.User.Identity.IsAuthenticated)
			{
				return Challenge(OpenIdConnectDefaults.AuthenticationScheme);
			}
			return RedirectToAction("Index", "Home");
		}
		public IActionResult Logout()
		{
			return new SignOutResult(new[]
			{
				OpenIdConnectDefaults.AuthenticationScheme,
				CookieAuthenticationDefaults.AuthenticationScheme
			}); 
		}
	}
}