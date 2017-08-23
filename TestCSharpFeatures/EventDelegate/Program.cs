using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EventDelegate.Interfaces;
using EventDelegate.Model;
using EventDelegate.Services;

namespace EventDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Events();
        }

        static void Events()
        {
            IFile video = new Video() { Title = "IP Man" };
            IFile audio = new Audio() { Title = "Sweet Home Alabama" };

            IEncoder videoEncoder = new Encoder.Encoder(); // Publisher
            ICommunicationService mailService = new MailService(); // Subscriber
            ICommunicationService textService = new TextService(); // Subscriber

            videoEncoder.OnEncoding += mailService.OnCommunicationEncoding;
            videoEncoder.OnEncoding += textService.OnCommunicationEncoding;
            videoEncoder.OnEncoded += mailService.OnCommunicationEncoded;
            videoEncoder.OnEncoded += textService.OnCommunicationEncoded;

            videoEncoder.Encode(video);
            videoEncoder.Encode(audio);
        }
    }

}

