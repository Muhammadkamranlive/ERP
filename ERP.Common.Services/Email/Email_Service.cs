using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace ERP.Common.Services
{
    public class Email_Service : IEmail_Service
    {
        public Email_Service()
        {
                
        }
        public async Task SendEmailAsync(string to, string subject, string content, bool isHtml = true)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sapient Medical", "Muhammadkamranntu@gmail.com"));
            message.To.Add(new MailboxAddress("", to));
            message.Subject = subject;

            var emailBody = CreateEmailBody(content);

            var textPart = new TextPart(TextFormat.Html)
            {
                Text = emailBody
            };

            message.Body = textPart;

            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                    await client.AuthenticateAsync("Muhammadkamranntu@gmail.com", "hfyo hcqw nvae dupb");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        public async Task SendBulkEmailAsync(List<string> toList, string subject, string content, bool isHtml = true)
        {
            foreach (var to in toList)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Emtiyaz EDU", "Emtiyaz-devTeam@outlook.com"));
                message.To.Add(new MailboxAddress("", to));
                message.Subject = subject;

                var emailBody = CreateEmailBody(content);

                var textPart = new TextPart(isHtml ? TextFormat.Html : TextFormat.Plain)
                {
                    Text = emailBody
                };

                message.Body = textPart;

                using (var client = new SmtpClient())
                {
                    try
                    {
                        await client.ConnectAsync("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
                        await client.AuthenticateAsync("Emtiyaz-devTeam@outlook.com", "16Feb@1234TK");
                        await client.SendAsync(message);
                        await client.DisconnectAsync(true);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }
                }
            }
        }
        private static string CreateEmailBody(string content)
        {
            string emailTemplate = $@"<!DOCTYPE html>
            <html>
            <head>
                <style>
                    /* Your inline CSS styles */
                    body {{
                        background-color: #f2f2f2;
                        font-family: Arial, sans-serif;
                        font-size: 28px;
                        font-weight:bold;
                    }}
                   
                    .header {{
                        text-align: center;
                        padding: 10px 0;
                    }}
                    .header img {{
                        width: 200px;
                        height: 200px;
                    }}
                    .content {{
                        background-color: #ffffff;
                        padding: 10px 0;
                        text-align: center;
                    }}
                    .footer {{
                        background-color: #5d16ec;
                        padding: 20px 0;
                        color: #ffffff;
                        text-align: center;
                    }}
                    .footer p {{
                        font-size: 14px;
                    }}
                </style>
            </head>
            <body>
               
                <div class='content'>
                    {content}
                </div>
                <div class='footer'>
                    <p>Contact us at: Phone: +1 (123) 456-7890<br>Email: info@example.com<br>Address: 123 Main St, City, Country</p>
                </div>
            </body>
            </html>";

            return emailTemplate;
        }

    }
}
