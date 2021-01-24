
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using ObjectBD.Configurations;
using Microsoft.Extensions.Options;
using static ObjectBD.Configurations.ObjectBDConfiguration;

namespace ObjectBD.Services
{
    public class EmailMessageSender :IMessageSender
    {
      // private readonly IConfiguration _configuration;

        //заинжектили конфигурацию, но берем ее через опции, значения приходят из конфигурации (secret.jc например)
        private readonly ObjectBDConfiguration _configuration; 
        public EmailMessageSender(//IConfiguration configuration, 
            IOptions<ObjectBDConfiguration> options)
        {
            //_configuration = configuration;
            _configuration = options.Value;
        }

        public void SendMessage()
        {

            //Add Header
            MimeMessage message = new MimeMessage();
            //message.From.Add(new MailboxAddress("ObjectBD", _configuration.GetSection("ObjectBD")["EmailAddress"]));
            message.From.Add(new MailboxAddress(_configuration.EmailLevel.EmailNameFrom, _configuration.EmailLevel.EmailAddressFrom));
            message.To.Add(new MailboxAddress(_configuration.EmailLevel.EmailNameTo, _configuration.EmailLevel.EmailAddressTo));

            message.Subject = "ObjectBD test";

            //Add Body
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h1>Hello Word My Message <h1>";
            bodyBuilder.TextBody = "Hello Word My Message ";
            message.Body = bodyBuilder.ToMessageBody();

            //Send
            using (SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                client.Connect("smtp.gmail.com", 465, true);
                //client.Authenticate(_configuration.GetSection("ObjectBD")["EmailAddress"], _configuration.GetSection("ObjectBD")["EmailPassword"]);
                client.Authenticate(_configuration.EmailLevel.EmailAddressFrom, _configuration.EmailLevel.EmailPasswordFrom);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
