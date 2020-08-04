using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class AssemblyAttribute : Attribute
    {
    }
}
