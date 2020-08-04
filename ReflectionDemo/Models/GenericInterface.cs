using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.Models
{
    public interface GenericInterface<TEntity> where TEntity : struct
    {
    }

    public interface GenericInterface<TEntity, TEntity2>
    {
    }
}
