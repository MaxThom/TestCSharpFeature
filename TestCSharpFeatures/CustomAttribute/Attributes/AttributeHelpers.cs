using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttribute.Attributes
{
    public static class AttributeHelpers
    {
        public static T GetClassCustomAttribute<T>(Type memberInfo) where T : Attribute
        {
            T myAttribute = (T)Attribute.GetCustomAttribute(memberInfo, typeof(T));

            return myAttribute;
        }

        public static T[] GetClassCustomAttributes<T>(Type memberInfo) where T : Attribute
        {
            T[] myAttribute = (T[])Attribute.GetCustomAttributes(memberInfo, typeof(T));

            return myAttribute;
        }

        public static T[] GetMethodsCustomAttribute<T>(Type memberInfo) where T : Attribute
        {
            List<T> myMethodsAttribute = new List<T>();

            MethodInfo[] myClassMethods = memberInfo.GetMethods();

            foreach (MethodInfo method in myClassMethods)
            {
                T temp = (T)Attribute.GetCustomAttribute(method, typeof(T));
                if (temp != null)
                    myMethodsAttribute.Add(temp);
            }

            return myMethodsAttribute.ToArray();
        }

        public static T[] GetMethodsCustomAttributes<T>(Type memberInfo) where T : Attribute
        {
            List<T> myMethodsAttribute = new List<T>();

            MethodInfo[] myClassMethods = memberInfo.GetMethods();

            foreach (MethodInfo method in myClassMethods)
            {
                T[] attributes = (T[])Attribute.GetCustomAttributes(method, typeof(T));
                foreach (var attribute in attributes)
                {
                    myMethodsAttribute.Add(attribute);
                }
            }

            return myMethodsAttribute.ToArray();
        }

    }
}
