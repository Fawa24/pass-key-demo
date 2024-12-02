﻿using FidoDemo.Models.DTO;
using FidoDemo.Models.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FidoDemo.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<BaseUser> _userManager;

		public AccountController(UserManager<BaseUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet("/")]
		public IActionResult Index(RegisterDTO registerDTO)
		{
			return View();
		}

		[HttpPost("/")]
		public async Task<IActionResult> Register(RegisterDTO registerDTO)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Errors = ModelState.Values
					.SelectMany(x => x.Errors)
					.Select(x => x.ErrorMessage);
			}

			var user = new BaseUser
			{
				Id = Guid.NewGuid().ToString(),
				UserName = registerDTO.UserName,
				DisplayName = registerDTO.DisplayName
			};

			var result = await _userManager.CreateAsync(user, registerDTO.Password);

			if (result.Succeeded)
			{
				return RedirectToAction(nameof(Register));
			}
			else
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("Register", error.Description);
				}
			}

			return RedirectToAction(nameof(Register));
		}
	}
}