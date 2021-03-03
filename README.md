# LeopardToolKit.Email
A useful library to let you send email easily.

## Build
[![LeopardToolKit Email](https://github.com/LeopardToolKit/LeopardToolKit.Email/actions/workflows/Email%20Sender.yml/badge.svg)](https://github.com/LeopardToolKit/LeopardToolKit.Email/actions/workflows/Email%20Sender.yml)

## Packages

| **Name** | **Nuget** |
|----------|:-------------:|
| **LeopardToolKit.Email** | **[![NuGet](https://buildstats.info/nuget/LeopardToolKit.Email)](https://www.nuget.org/packages/LeopardToolKit.Email)**   |

## Features

In your `appsettings.json` add follow:
```json
{
  "Email": {
    "Port": <your smtp server port>,
    "IsSSL": true/false,
    "Host": "your smtp host",
    "Username": "your smtp sender user name, mostly it is same with [FromAddress]",
    "Password": "your smtp sender password",
    "FromAddress": "your smtp sender email address",
    "FromDisplayName": "Your sender name"
  }
}
```

then in `ConfigureServices`, add following:
```csharp
services.AddEmailSender(Configuration.GetSection("Email"));
```

At last, in any place where you want to send email, just like following:
```csharp
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
```

