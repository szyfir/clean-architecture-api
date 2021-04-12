using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Application.Models
{
    public class AuthenticationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
