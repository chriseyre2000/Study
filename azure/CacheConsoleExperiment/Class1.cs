using Microsoft.ApplicationServer.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheConsoleExperiment
{
    public class Class1
    {
        static void Main()
        {
            Console.WriteLine("Hello World");

            try
            {

                DataCache cache = new DataCache();
                cache.Add("key", "Hello");

                object value = cache.Get("key");

                Console.WriteLine(cache.Get("key"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadLine();
        }

    }
}
