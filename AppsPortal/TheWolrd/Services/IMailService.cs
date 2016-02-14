using System;

namespace TheWolrd.Services
{
    public interface IMailService
    {
        bool SendMail(string to, string from, string subject, string body);
    }
}