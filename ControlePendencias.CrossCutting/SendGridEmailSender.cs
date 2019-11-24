using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ControlePendencias.CrossCutting
{
    public class SendGridEmailSender : IEMailSender
    {
        public IList<string> SendToAddress { get; set; }
        public IList<string> CCToAddress { get; set; }
        public string Subject { get; set; }
        public string MessageText { get; set; }

        public bool Send()
        {
            Thread.Sleep(3000);
            Console.WriteLine("SendGrid Sender");
            Console.WriteLine("Sending e-mail to: {0}", String.Join(",", SendToAddress));
            Console.WriteLine("Subject: {0}", Subject);
            Console.WriteLine("Message: {0}", MessageText);
            return true;
        }
    }
}
