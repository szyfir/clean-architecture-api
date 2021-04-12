using CleanArchitecture.Core.Application.Models;
using CleanArchitecture.Core.Application.Models.EmailConfirmation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> LogInAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
        Task<string> GenerateEmailConfirmationTokenAsync(EmailConfirmationRequest request);
    }
}
