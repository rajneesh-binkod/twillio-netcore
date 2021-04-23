using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace TwillioSmsTaskScheduler
{
    class Program
    {
        private static readonly string FROM = "PHONE NUMBER HERE";
        private static readonly string AccountSID = "ACCOUNT SID HERE";
        private static readonly string AuthTOKEN = "AUTH TOKEN HERE";

        static void Main(string[] args)
        {
            TwilioClient.Init(AccountSID, AuthTOKEN);

            string MessageText = "Hi Rajneesh, sending a test SMS on " + DateTime.Now + " for task scheduler demo from Twillio.";
            string MessageTO = "PHONE NUMBER HERE";

            MessageResource.Create(
                body: MessageText,
                from: new Twilio.Types.PhoneNumber(FROM),
                to: new Twilio.Types.PhoneNumber(MessageTO)
            );
        }
    }
}
