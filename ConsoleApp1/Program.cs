using System;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var guid = Guid.NewGuid().ToString();
            
            Console.WriteLine(guid);

        }
    }
}
