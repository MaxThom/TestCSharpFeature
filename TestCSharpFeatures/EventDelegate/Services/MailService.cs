using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventDelegate.Interfaces;

namespace EventDelegate.Services
{
    public class MailService : ICommunicationService
    {
        public void OnCommunicationEncoding(object source, EventArgs<IFile> e)
        {
            Console.WriteLine($"Encoding : Sending mail to client ! {e.Data.Title}");
        }

        public void OnCommunicationEncoded(object source, EventArgs<IFile> e)
        {
            Console.WriteLine($"Encoded : Sending mail to client ! {e.Data.Title}");
        }

    }
}
