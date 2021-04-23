using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using twillio_netcore.Helpers;

namespace twillio_netcore.Services
{
    public interface ISendSmsService
    {
        Task<MessageResource> SendSMS(string MessageTo, string MessageText);
        Task<MessageResource> WhatsApp(string MessageTo, string MessageText);
    }

    public class SendSmsService : ISendSmsService
    {
        private readonly TwillioConfig _settings;

        public SendSmsService(IOptions<TwillioConfig> options)
        {
            _settings = options.Value;
        }

        public async Task<MessageResource> SendSMS(string MessageTo, string MessageText)
        {
            TwilioClient.Init(_settings.AccountSid, _settings.AuthToken);

            MessageResource response = await MessageResource.CreateAsync(
                body: MessageText,
                from: new Twilio.Types.PhoneNumber(_settings.PhoneNumber),
                to: new Twilio.Types.PhoneNumber(MessageTo)
            );

            return response;
        }

        public async Task<MessageResource> WhatsApp(string MessageTo, string MessageText)
        {
            TwilioClient.Init(_settings.AccountSid, _settings.AuthToken);

            MessageResource response = await MessageResource.CreateAsync(
                body: MessageText,
                from: new Twilio.Types.PhoneNumber("whatsapp:" + _settings.WhatsApp),
                to: new Twilio.Types.PhoneNumber("whatsapp:" + MessageTo)
            );

            return response;
        }
    }
}
