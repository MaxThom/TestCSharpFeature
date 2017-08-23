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

        static void ThrowExceptions(int i)
        {
            throw new WebException(i.ToString() + " - The remote server returned an error: (408) Request Timeout.");

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



        static void Lambda()
        {
            const int factor = 5;
            Func<int, int> multipler = n => n * factor;

            Func<int, int> square = (number) => number * number;

            Console.WriteLine(Test(square));

            Console.WriteLine(square(5));
            Console.WriteLine(multipler(10));


            List<Book> books = new List<Book>();
            books.Add(new Book
            {
                Title = "Tintin",
                Price = 10.00
            });
            books.Add(new Book
            {
                Title = "Yoko Tsuno",
                Price = 15.00
            });
            books.Add(new Book
            {
                Title = "Harry Potter",
                Price = 40.00
            });

            const int price = 20;

            Func<Book, bool> func2 = (bk) => bk.Price < price;

            List<Book> books2 = books.FindAll(x => func2(x));
            List<Book> books3 = books.FindAll((x) => { return x.Price < price; });
        }

        static int Square(int number)
        {
            return number * number;
        }

        static int Test(Func<int, int> func)
        {

            return func(5);
        }
    }

    class Book
    {
        public string Title { get; set; }
        public double Price { get; set; }

        public bool IsCheaperThan10Dollars()
        {
            return Price < 20;
        }
    }
}

