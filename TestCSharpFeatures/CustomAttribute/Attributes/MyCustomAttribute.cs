using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttribute.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class MyCustomAttribute : Attribute
    {
        private bool _myValue;

        public string Name { get; set; }

        public string[] Params { get; set; }

        public MyCustomAttribute(bool myValue)
        {
            _myValue = myValue;
        }

    }
}
