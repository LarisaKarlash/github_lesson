using Microsoft.Extensions.Options;
using ObjectBD.Configurations;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ObjectBD.Services
{
    public class SmsMessageSender : IMessageSender
    {
        //заинжектили конфигурацию, но берем ее через опции, значения приходят из конфигурации (secret.jc например)
        private readonly ObjectBDConfiguration _configuration;
        public SmsMessageSender(IOptions<ObjectBDConfiguration> options)
        {
            _configuration = options.Value;
        }

        public void SendMessage()
        {
            TwilioClient.Init(_configuration.TwilioLevel.TwilioAccountId, _configuration.TwilioLevel.TwilioAuthToken);

            //string aaa = _configuration.TwilioLevel.TwilioNumber;
            //string bbb = _configuration.TwilioLevel.MyNumber;

            var message = MessageResource.Create(
                from: new PhoneNumber(_configuration.TwilioLevel.TwilioNumber),
                to: new PhoneNumber(_configuration.TwilioLevel.MyNumber),
                body: "Sms From ObjectBD");

            Console.WriteLine( message.Status);
        }
    }
}
