using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentCollectionExamples
{
    public class Example2 : IExample
    {
        public void Run()
        {
            Console.WriteLine("Example 2");
            var orders = new Queue<string>();
            Task task1 = Task.Run(() => PlaceOrders(orders, "Mark"));
            Task task2 = Task.Run(() => PlaceOrders(orders, "Ramdevi"));
            Task task3 = Task.Run(() => PlaceOrders(orders, "John"));
            Task.WaitAll(task1, task2, task3);

            // Parallel for each executed on different thread
            // we do not care how it will be assigned between threads
            // If we do we will use partitioner
            Parallel.ForEach(orders, (order) => Console.WriteLine(order));
        }

        private static object _lockObj = new object();

        private static void PlaceOrders(Queue<string> orders, string name)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1);
                string orderName = string.Format("{0} wants t-shirt {1}", name, i);
                lock (_lockObj)
                {
                    orders.Enqueue(orderName);
                }
            }
        }
    }
}