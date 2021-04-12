using CleanArchitecture.Core.Application.Contracts.Identity;
using CleanArchitecture.Core.Application.Models;
using CleanArchitecture.Core.Application.Models.EmailConfirmation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public IdentityController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegistrationRequest registrationRequest)
        {
            var result = await _authenticationService.RegisterAsync(registrationRequest);
            return Ok(result);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticationRequest request)
        {
            var result = await _authenticationService.LogInAsync(request);
            return Ok(result);
        }

        [HttpPost("generate-token")]
        public async Task<IActionResult> GenerateConfirmationEmailTokenAsync([FromBody] EmailConfirmationRequest request)
        {
            //Url.Action("ConfirmEmail", )
            var result = await _authenticationService.GenerateEmailConfirmationTokenAsync(request);
            return Ok(result);
        }
    }
}
