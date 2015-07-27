using System;
using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConcurrentCollectionExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            
            // thread save
            new Example1().Run();
            new Example2().Run();
            new Example3().Run();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
