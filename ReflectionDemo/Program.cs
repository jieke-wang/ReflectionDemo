using System;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Models.NormalClass normalClass = new Models.NormalClass();
            //normalClass[0] = "abcd";
            //Console.WriteLine(normalClass[0]);

            //Console.WriteLine("Hello World!");
            //FlagEnumDemo();

            Samples.Sample1.Demo9();
        }

        static void FlagEnumDemo()
        {
            Models.FlagEnum flagEnum = Models.FlagEnum.Three | Models.FlagEnum.Five;
            Console.WriteLine(flagEnum.HasFlag(Models.FlagEnum.Three));
            Console.WriteLine(flagEnum.HasFlag(Models.FlagEnum.One));

            Models.NormalEnum normalEnum = Models.NormalEnum.One | Models.NormalEnum.Four;
            Console.WriteLine(normalEnum.HasFlag(Models.NormalEnum.Three));
            Console.WriteLine(normalEnum.HasFlag(Models.NormalEnum.One));
        }
    }
}