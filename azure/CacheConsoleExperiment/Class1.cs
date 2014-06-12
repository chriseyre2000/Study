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

                //cache.Remove("key");
                //cache.Add("key", "Hello");
                DataCacheLockHandle handle;

                //Interesting DataCahe semantics. Lock for 500ms or less and it's an infinate lock.
                //Lock for 501ms and it will time out.
                //However locked items can still be read and removed (which removes the lock).
                
                //These values are based upon the Emulator

                object value = cache.GetAndLock("key", TimeSpan.FromMilliseconds(500), out handle);

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
