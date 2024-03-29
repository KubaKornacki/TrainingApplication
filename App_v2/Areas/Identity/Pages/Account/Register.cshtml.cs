﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using App_v2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace App_v2.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required (ErrorMessage ="Adres email jest wymagany")]
            [EmailAddress(ErrorMessage ="Adres email jest błędny")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Hasło jest wymagane")]
            [StringLength(100, ErrorMessage = "{0} musi mieć minimum {2} i maksimum {1} znaków długości", MinimumLength = 8)]
            [DataType(DataType.Password)]
            [Display(Name = "Hasło")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "Hasła nie są takie same.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = Input.Email, Email = Input.Email,PlanExample=true };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {   
                    if(error.Code.ToString()== "DuplicateUserName")
                    {
                        ModelState.AddModelError(string.Empty,"Adres email jest już zajęty");
                    }
                    else if (error.Code.ToString()== "PasswordRequiresNonAlphanumeric")
                    {
                        ModelState.AddModelError(string.Empty, "Hasło wymaga co najmniej jednego znaku specjalnego");
                    }
                    else if (error.Code.ToString() == "PasswordRequiresLower")
                    {
                        ModelState.AddModelError(string.Empty, "Hasło wymaga co najmniej jednej małej litery");
                    }
                    else if (error.Code.ToString() == "PasswordRequiresUpper")
                    {
                        ModelState.AddModelError(string.Empty, "Hasło wymaga co najmniej jednej wielkiej litery");
                    }
                    else if(error.Code.ToString()== "PasswordRequiresDigit")
                    {
                        ModelState.AddModelError(string.Empty, "Hasło wymaga co najmniej jednej cyfry");
                    }

                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
