using CleanArchitecture.Core.Application.Models.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task SendEmail(Email email);
    }
}
