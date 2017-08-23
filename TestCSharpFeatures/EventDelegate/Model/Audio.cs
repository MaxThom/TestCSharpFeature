using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventDelegate.Interfaces;

namespace EventDelegate.Model
{
    public class Audio : IFile
    {
        public string Title { get; set; }
        public void Encode()
        {
            Console.WriteLine("AUDIO : 9999-8888-7777-6666-5555-4444-3333-2222-1111-0000");
        }
    }
}
