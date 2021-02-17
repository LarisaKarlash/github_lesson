using CountryZip.Configurations;
using CountryZip.ViewModels;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CountryZip.Services
{
    public class EmailMessageSender : IMessageSender
    {
        public readonly CountryZipConfiguration _configuration;
        public EmailMessageSender(IOptions<CountryZipConfiguration> options)
        {
            _configuration = options.Value;
        }
        public void SendMessage(AccountRegisterViewModel registerViewModel)
        {
            //Add Header
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(_configuration.EmailLevel.EmailNameFrom, _configuration.EmailLevel.EmailAddressFrom));
            // message.To.Add(new MailboxAddress(_configuration.EmailLevel.EmailNameTo, _configuration.EmailLevel.EmailAddressTo));
            message.To.Add(new MailboxAddress(registerViewModel.FirstName, registerViewModel.Email));

            message.Subject = _configuration.EmailLevel.Subject;

            //Add Body
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = _configuration.EmailLevel.TextBody;
            message.Body = bodyBuilder.ToMessageBody();

            //Send
            using (SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                client.Connect(_configuration.EmailLevel.EmailSmtp, 465, true);
                client.Authenticate(_configuration.EmailLevel.EmailAddressFrom, _configuration.EmailLevel.EmailPasswordFrom);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
