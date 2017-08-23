using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EventDelegate.Interfaces;
using EventDelegate.Services;

namespace EventDelegate.Encoder
{
    public class Encoder : IEncoder
    {
        // 1- Define a delegate
        // 2- Define an event based that that deletage
        // 3- Raise the event

        // Solution 1
        // public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
        // public event VideoEncodedEventHandler VideoEncoded;

        // Solution 2
        public event EventHandler<EventArgs<IFile>> OnEncoded;

        public event EventHandler<EventArgs<IFile>> OnEncoding;

        public void Encode(IFile fileToEncode)
        {
            Console.WriteLine($"Encoding . . .");
            OnVideoEncoding(fileToEncode);
            fileToEncode.Encode();
            Thread.Sleep(3000);
            OnVideoEncoded(fileToEncode);
        }

        protected virtual void OnVideoEncoded(IFile fileToEncode)
        {
            OnEncoded?.Invoke(this, new EventArgs<IFile>() { Data = fileToEncode });
        }

        protected virtual void OnVideoEncoding(IFile fileToEncode)
        {
            OnEncoding?.Invoke(this, new EventArgs<IFile>() { Data = fileToEncode });
        }

    }
}
