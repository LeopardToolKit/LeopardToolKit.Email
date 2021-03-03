using System;
using System.Collections.Generic;
using System.Text;

namespace LeopardToolKit.Email
{
    public class EmailModel
    {
        public string EmailBody { get; set; }

        public bool IsHtml { get; set; }

        public string Subject { get; set; }

        public List<string> ToMails { get; set; } = new List<string>();

        public List<string> AttachmentPaths { get; set; } = new List<string>();
    }

    public class SomeClass
    {
        private readonly IEmailSender _emailSender;
        public SomeClass(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void SendEmail(string subject, string html, List<string> toEmailAddress)
        {
            _emailSender.Send(new EmailModel
            {
                Subject = subject,
                EmailBody = html,
                IsHtml = true,
                ToMails = toEmailAddress
            });
        }
    }
}
