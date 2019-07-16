using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SendGridDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SendMail().Wait();
        }

        public static async Task SendMail()
        {
            try
            {
                var apiKey = "";
                var client = new SendGridClient(apiKey);
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("test@mail.com", "test"),
                    Subject = "Testing the SendGrid C# Library by Deivid Mladenov",
                    PlainTextContent = "Hello, Email!",
                    HtmlContent = "<strong>Hello, Email!</strong>"
                };


                var recipients = new List<EmailAddress>
                {
                    new EmailAddress("7deividmladenov007@gmail.com", "Deivid Mladenov")
                };

                msg.AddTos(recipients);

                for (int i = 0; i < 10; i++)
                {
                    await client.SendEmailAsync(msg);
                }

                var response = await client.SendEmailAsync(msg);

                Console.WriteLine($"Status code from your request is {response.StatusCode}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
