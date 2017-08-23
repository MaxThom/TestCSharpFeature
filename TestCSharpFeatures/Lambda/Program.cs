using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Lambda();
        }

        private static void Lambda()
        {
            const int factor = 5;
            Func<int, int> multipler = n => n * factor;

            Func<int, int> square = (number) => number * number;

            Console.WriteLine((int) Test(square));

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

        private static int Square(int number)
        {
            return number * number;
        }

        private static int Test(Func<int, int> func)
        {

            return func(5);
        }
    }
}
