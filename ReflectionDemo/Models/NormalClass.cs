using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.Models
{
    [Attributes.Class("class")]
    public class NormalClass
    {
        [Attributes.Field]
        private List<object> Container;
        private Dictionary<string, object> Container2;
        private List<string> Container3;

        private string Field;
        private static string StaticField;

        [Attributes.Event]
        private event Action ChangeEvent;

        [Attributes.Constructor]
        public NormalClass()
        {
            Container = new List<object>();
            Container2 = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            Container3 = new List<string>();
        }

        private NormalClass(string x)
        {
            Console.WriteLine(x);
        }

        [Attributes.Property]
        public object Property { get; set; }

        public IEnumerable<object> this[string key]
        {
            get { return Container3.Where(x => string.IsNullOrWhiteSpace(x) == false && x.Contains(key));  }
        }

        [Attributes.Method]
        [return: Attributes.ReturnValue]
        public int Add([Attributes.Parameter] int x, int y) => x + y;

        public string GenericMethod<T1, T2>(T1 t1, T2 t2)
        {
            return $"typeof(T1): {typeof(T1)}; typeof(T2): {typeof(T2)}; t1: {t1}; t2: {t2}";
        }

        //public object this[int index]
        //{
        //    get
        //    {
        //        return Container[index];
        //    }
        //    set
        //    {
        //        Container[index] = value;
        //    }
        //}

        //public object this[string key]
        //{
        //    get
        //    {
        //        return Container2[key];
        //    }
        //    set
        //    {
        //        Container2[key] = value;
        //    }
        //}


        //public KeyValuePair<string, object> this[string key, object valueObject]
        //{
        //    get
        //    {
        //        var data = Container2.FirstOrDefault(x => x.Key == key && x.Value == valueObject);
        //        return data;
        //    }
        //}

        //public object this[object key]
        //{
        //    get
        //    {
        //        return Container.FirstOrDefault(x => x == key);
        //    }
        //    set
        //    {
        //        Container.Add(value);
        //    }
        //}
    }
}
