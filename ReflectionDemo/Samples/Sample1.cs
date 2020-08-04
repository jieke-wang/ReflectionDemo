using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.Samples
{
    public class Sample1
    {
        public static void Demo1()
        {
            Assembly assembly = Assembly.Load("ReflectionDemo");
            assembly = Assembly.GetExecutingAssembly();
            assembly = typeof(Sample1).Assembly;
            assembly = Assembly.LoadFrom("ReflectionDemo.dll");
            assembly = Assembly.LoadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ReflectionDemo.dll"));
            Console.WriteLine(assembly.FullName);
        }

        public static void Demo2()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            var exportedTypes = assembly.GetExportedTypes();
            var forwardedTypes = assembly.GetForwardedTypes();
        }

        public static void Demo3()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetType("ReflectionDemo.Models.NormalClass");
        }

        public static void Demo4()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType("ReflectionDemo.Models.GenericInterface`1");
            var type2 = assembly.GetType("ReflectionDemo.Models.GenericInterface`2");

            var genericTypeArguments = type.GenericTypeArguments;
            var genericTypeArguments2 = type2.GenericTypeArguments;

            type = type.MakeGenericType(typeof(string));
            type2 = type2.MakeGenericType(typeof(string), typeof(int));
            genericTypeArguments = type.GenericTypeArguments;
            genericTypeArguments2 = type2.GenericTypeArguments;
        }

        public static void Demo5()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetType("ReflectionDemo.Models.NormalClass");

            var constructors = type.GetConstructors();

            var constructor = type.GetConstructor(Array.Empty<Type>());
            //var constructor2 = type.GetConstructor(new[] { typeof(string) });
            var constructor2 = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(string) }, null);

            var instance = Activator.CreateInstance(type, BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { "bbbb" }, null, null);
            var instance2 = constructor2.Invoke(new[] { "aaaaa" });

            var instance3 = constructor.Invoke(null);
        }

        public static void Demo6()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetType("ReflectionDemo.Models.NormalClass");

            var field = type.GetField("Field", BindingFlags.NonPublic | BindingFlags.Instance);
            var field2 = type.GetMember("StaticField", BindingFlags.NonPublic | BindingFlags.Static);

            var instance = Activator.CreateInstance(type, BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { "bbbb" }, null, null);
            field.SetValue(instance, "aaaa");
            Console.WriteLine(field.GetValue(instance));

            var fieldInfo = field2[0] as FieldInfo;
            fieldInfo.SetValue(null, "cccccc");
            Console.WriteLine(fieldInfo.GetValue(null));
        }

        public static void Demo7()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetType("ReflectionDemo.Models.NormalClass");
            var method1 = type.GetMethod("GenericMethod");

            var instance = Activator.CreateInstance(type, BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { "bbbb" }, null, null);

            var method2 = method1.MakeGenericMethod(typeof(string), typeof(int));

            var result = method2.Invoke(instance, new object[] { "xxxxxxx", int.MaxValue });
            Console.WriteLine(result);

            var genericArguments = method2.GetGenericArguments();
            var genericMethodDefinition = method2.GetGenericMethodDefinition();

            Console.WriteLine(method1 == genericMethodDefinition);
        }

        public static void Demo8()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType("ReflectionDemo.Models.GenericClass`1");

            //var genericParameterConstraints = type.GetGenericParameterConstraints();
            var interfaceType = type.GetInterface("ReflectionDemo.Models.GenericInterface`1").GetGenericTypeDefinition();
            //var genericParameterConstraints2 = interfaceType.GetGenericParameterConstraints();

            var genericTypeArguments = type.GenericTypeArguments;

            type = type.MakeGenericType(typeof(int));
            genericTypeArguments = type.GenericTypeArguments;

            interfaceType = type.GetInterface("ReflectionDemo.Models.GenericInterface`1");

            Type parentType = type.BaseType;

            //var genericParameterConstraints = type.GetGenericParameterConstraints();
            //var genericParameterConstraints2 = interfaceType.GetGenericParameterConstraints();

            var instance = Activator.CreateInstance(type);

            var methods = type.GetMethods();
            //foreach (var method in methods)
            //{
            //    Console.WriteLine(method.Name);
            //}

            //var method1 = type.GetMethod("GenericMethod", 2, new Type[] { typeof(string), typeof(int) });
            var method1 = methods.FirstOrDefault(x => x.Name == "GenericMethod" && x.GetGenericArguments().Length == 2);

            method1 = method1.MakeGenericMethod(typeof(string), typeof(int));
            Console.WriteLine(method1.Invoke(instance, new object[] { "aaaaaaa", 4556456 }));

            //var method2 = type.GetMethod("GenericMethod", 2, new Type[] { typeof(int) });

            //method2 = method2.MakeGenericMethod(typeof(string), typeof(int));
            //Console.WriteLine(method2.Invoke(instance, new object[] { 45654, "aaaaaaa", 4556456 }));

            var method3 = type.GetMethod("NormalMethod");
            var y = method3.Invoke(instance, new object[] { 1, 2 });
        }

        public static void Demo9()
        {
            var assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetType("ReflectionDemo.Models.NormalClass");

            if(type.IsDefined(typeof(Attributes.ClassAttribute)))
            {
                var classAttribute = type.GetCustomAttribute<Attributes.ClassAttribute>();
                Console.WriteLine(classAttribute.Name);
            }
        }
    }
}
