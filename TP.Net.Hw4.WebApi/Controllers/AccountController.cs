﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TP.Net.Hw4.Application.Interfaces.Services;
using TP.Net.Hw4.Application.Dtos.Requests;
using TP.Net.Hw4.Domain.Entity;

namespace TP.Net.Hw4.WebApi.Controllers
{
    [Route("/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(ITokenGenerator tokenGenerator,UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _tokenGenerator = tokenGenerator;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserSignupDto signup)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByEmailAsync(signup.Email);
            if (user is not null)
                throw new Exception("There is a user with this email!");

            var newUser = new User()
            {
                Email = signup.Email,
                PasswordHash = signup.Password,
                UserName = signup.UserName,
                FirstName = signup.FirstName,
                LastName = signup.LastName,
                RegisteredAt = DateTime.Now,
                IsActive = true
            };

            var IsCreated = await _userManager.CreateAsync(newUser, signup.Password);

            if(IsCreated.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim("Email", newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var jwtToken = _tokenGenerator.GetToken(claims);

                return Ok(new {token = jwtToken});
            }

            return BadRequest(IsCreated.Errors);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _userManager.FindByEmailAsync(login.Email);

            if (existingUser == null)
                return BadRequest("User does not exist!");
            if (await _userManager.IsLockedOutAsync(existingUser))
                return BadRequest("User is Locked");
                

            var isCorrect = await _userManager.CheckPasswordAsync(existingUser, login.Password);
            var singInResult = await _signInManager.CheckPasswordSignInAsync(existingUser, login.Password, false);

            if (!isCorrect)
            {
                await _userManager.AccessFailedAsync(existingUser);
                return BadRequest("Access Failed");
            }

            var claims = new List<Claim>
            {
                new Claim("Email", existingUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            await _signInManager.SignInAsync(existingUser, false);

            var jwtToken = _tokenGenerator.GetToken(claims);

            return Ok(new { token = jwtToken });

        }
    }
}
