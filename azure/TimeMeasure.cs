using System;
using System.Diagnostics;

namespace WorkerRole
{
    public class TimeMeasure : IDisposable
    {
        bool isDisposed;
        string message;
        Stopwatch timer;

        private TimeMeasure(string message)
        {
            this.message = message;
            timer = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                isDisposed = true;
                timer.Stop();

               

                Trace.TraceWarning(string.Format("{0} took {1}ms", message, timer.ElapsedMilliseconds));
            }
        }

        public static TimeMeasure Measure(string message)
        {
            return new TimeMeasure(message);
        }
    }
}
