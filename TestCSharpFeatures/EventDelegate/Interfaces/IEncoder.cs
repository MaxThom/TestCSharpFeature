using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventDelegate.Services;

namespace EventDelegate.Interfaces
{
    public interface IEncoder
    {
        event EventHandler<EventArgs<IFile>> OnEncoded;

        event EventHandler<EventArgs<IFile>> OnEncoding;

        void Encode(IFile fileToEncode);
    }
}
