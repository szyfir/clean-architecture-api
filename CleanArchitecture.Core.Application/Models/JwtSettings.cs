using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Application.Models
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public double ExpirationInMinutes { get; set; }
    }
}
