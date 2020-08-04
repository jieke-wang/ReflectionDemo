using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.Models
{
    public class GenericClass<[Attributes.GenericParameter] TEntity> : GenericInterface<TEntity> where TEntity : struct
    {
        public string GenericMethod<T1, T2>(T1 t1, T2 t2)
        {
            return $"typeof(T1): {typeof(T1)}; typeof(T2): {typeof(T2)}; t1: {t1}; t2: {t2}";
        }

        public string GenericMethod<T1, T2>(TEntity entity, T1 t1, T2 t2)
        {
            return $"typeof(TEntity): {typeof(TEntity)}; typeof(T1): {typeof(T1)}; typeof(T2): {typeof(T2)}; t1: {t1}; t2: {t2}; entity: {entity}";
        }

        public int NormalMethod(int x, int y) => x + y;
    }
}
