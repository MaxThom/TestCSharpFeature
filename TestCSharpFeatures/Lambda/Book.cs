using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    public class Book
    {
        public string Title { get; set; }
        public double Price { get; set; }

        public bool IsCheaperThan10Dollars()
        {
            return Price < 20;
        }
    }
}
