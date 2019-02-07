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
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("7deividmladenov007@gmail.com", "Deivid Mladenov Demo"),
                    Subject = "Testing the SendGrid C# Library by Deivid Mladenov",
                    PlainTextContent = "Hello, Email!",
                    HtmlContent = "<strong>Hello, Email!</strong>"
                };


                var recipients = new List<EmailAddress>
                {
                    new EmailAddress("7deividmladenov007@gmail.com", "Deivid Mladenov")
                };
                msg.AddTos(recipients);

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
