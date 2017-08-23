using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventDelegate.Interfaces;

namespace EventDelegate.Services
{
    public class TextService : ICommunicationService
    {
        public void OnCommunicationEncoding(object source, EventArgs<IFile> e)
        {
            Console.WriteLine($"Encoding : Sending text message to client ! {e.Data.Title}");
        }


        public void OnCommunicationEncoded(object source, EventArgs<IFile> e)
        {
            Console.WriteLine($"Encoded : Sending text message to client ! {e.Data.Title}");
        }
    }
}
