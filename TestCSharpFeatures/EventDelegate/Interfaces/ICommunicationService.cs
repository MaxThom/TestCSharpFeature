using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventDelegate.Services;

namespace EventDelegate.Interfaces
{
    public interface ICommunicationService
    {
        void OnCommunicationEncoding(object source, EventArgs<IFile> e);
        void OnCommunicationEncoded(object source, EventArgs<IFile> e);
    }
}
