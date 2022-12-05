using System;

namespace TestWasm
{
    public class Test
    {
        public static string Hello(string name)
        {
            Console.WriteLine($"Hello {name}!");
            return $"Hello {name}!";
        }
    }
}
