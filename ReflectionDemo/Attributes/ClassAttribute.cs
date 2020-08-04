using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ClassAttribute : Attribute
    {
        public ClassAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
