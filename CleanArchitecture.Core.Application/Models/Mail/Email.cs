using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Application.Models.Mail
{
    public class Email
    {
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string Topic { get; set; }
        public string Body { get; set; }
    }
}
