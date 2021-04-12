using CleanArchitecture.Core.Application.Contracts.Identity;
using CleanArchitecture.Core.Application.Models;
using CleanArchitecture.Core.Application.Models.EmailConfirmation;
using CleanArchitecture.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(EmailConfirmationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new ApplicationException($"User with given email {request.Email} doesn't exist");
            }

            var result = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return result;
        }

        public async Task<AuthenticationResponse> LogInAsync(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new ApplicationException($"User with given email {request.Email} doesn't exist");
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

            if (result == null)
            {
                throw new ApplicationException($"Credentials are invalid for email {request.Email}");
            }

            var isEmailConfimred = await _userManager.IsEmailConfirmedAsync(user);

            if (!isEmailConfimred)
            {
                throw new ApplicationException("Email not confirmed");
            }

            JwtSecurityToken token = await GenerateToken(user);

            var response = new AuthenticationResponse()
            {
                Email = user.Email,
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = user.UserName
            };

            return response;
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            var existingUserName = await _userManager.FindByNameAsync(request.UserName);
            if (existingUserName != null)
            {
                throw new ApplicationException($"User for given name {request.UserName} already exist");
            }

            var applicationUser = new ApplicationUser()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
            };

            var existingMail = await _userManager.FindByEmailAsync(request.Email);

            if (existingMail != null)
            {
                throw new ApplicationException($"User for given email {request.Email} already exist");
            }

            var result = await _userManager.CreateAsync(applicationUser, request.Password);

            if (result.Succeeded)
            {
                var response = new RegistrationResponse()
                {
                    UserId = applicationUser.Id
                };

                return response;
            }
            else
            {
                throw new ApplicationException($"Registration failed: {result.Errors}");
            }
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            var userRolesClaims = new List<Claim>();
            foreach (var role in userRoles)
            {
                userRolesClaims.Add(new Claim("role", role));
            }

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            }

            .Union(userClaims)
            .Union(userRolesClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);


            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationInMinutes),
                signingCredentials: signingCredentials);

            return token;
        }

    }
}
