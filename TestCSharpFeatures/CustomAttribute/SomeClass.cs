using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomAttribute.Attributes;

namespace CustomAttribute
{
    [MyCustom(false, Name = "Transport", Params = new[] { "Avion", "Helicoptère" })]
    public class SomeClass
    {
        [MyCustom(false, Name = "Écran", Params = new[] { "Rogue Swift", "View Sonic" })]
        public void PrintMyCustomAttribute()
        {
            MyCustomAttribute myAttribute = AttributeHelpers.GetClassCustomAttribute<MyCustomAttribute>(typeof(SomeClass));

            if (myAttribute == null)
                Console.WriteLine("The Attribute was not found");
            else
            {
                Console.WriteLine($"The Name is: {myAttribute.Name}");
                Console.WriteLine($"The Params are: {string.Join(", ", myAttribute.Params)}");
            }
        }

        [MyCustom(false, Name = "Carte Graphique", Params = new[] { "Nvidia", "Amd" })]
        public void PrintMyMethodsCustomAttribute()
        {
            MyCustomAttribute[] myMethodAttributes = AttributeHelpers.GetMethodsCustomAttribute<MyCustomAttribute>(typeof(SomeClass));
            if (myMethodAttributes == null)
                Console.WriteLine("The Attributes were not found");
            else
            {
                foreach (var myCustomAttribute in myMethodAttributes)
                {
                    Console.WriteLine($"The Name is: {myCustomAttribute.Name}");
                    Console.WriteLine($"The Params are: {string.Join(", ", myCustomAttribute.Params)}");
                }
            }
        }
    }

    [MyCustom(false, Name = "Nourriture", Params = new[] { "Pizza", "Poutine" })]
    [MyCustom(false, Name = "Ecole", Params = new[] { "Papier", "Ciseau" })]
    public class SomeClass2
    {
        [MyCustom(false, Name = "Console", Params = new[] { "PS4", "Xbox" })]
        public void PrintMyClassCustomAttribute()
        {

            MyCustomAttribute[] myAttributes = AttributeHelpers.GetClassCustomAttributes<MyCustomAttribute>(typeof(SomeClass2));

            if (myAttributes == null)
                Console.WriteLine("The Attributes were not found");
            else
            {
                foreach (var myCustomAttribute in myAttributes)
                {
                    Console.WriteLine($"The Name is: {myCustomAttribute.Name}");
                    Console.WriteLine($"The Params are: {string.Join(", ", myCustomAttribute.Params)}");
                }
            }
        }

        [MyCustom(false, Name = "Jeux", Params = new[] { "Halo", "WoW" })]
        [MyCustom(false, Name = "Sport", Params = new[] { "Badminton", "Soccer" })]
        public void PrintMethodsCustomAttribute()
        {
            MyCustomAttribute[] myMethodAttributes = AttributeHelpers.GetMethodsCustomAttributes<MyCustomAttribute>(typeof(SomeClass2));
            if (myMethodAttributes == null)
                Console.WriteLine("The Attributes were not found");
            else
            {
                foreach (var myCustomAttribute in myMethodAttributes)
                {
                    Console.WriteLine($"The Name is: {myCustomAttribute.Name}");
                    Console.WriteLine($"The Params are: {string.Join(", ", myCustomAttribute.Params)}");
                }
            }
        }
    }
}
