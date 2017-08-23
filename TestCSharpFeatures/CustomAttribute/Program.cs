using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            var someClass = new SomeClass();
            someClass.PrintMyCustomAttribute();
            Console.WriteLine("--------------");
            someClass.PrintMyMethodsCustomAttribute();

            Console.WriteLine("==============");

            var someClass2 = new SomeClass2();
            someClass2.PrintMyClassCustomAttribute();
            Console.WriteLine("--------------");
            someClass2.PrintMethodsCustomAttribute();
        }
    }
}
