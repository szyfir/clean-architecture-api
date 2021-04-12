﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Application.Models
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
