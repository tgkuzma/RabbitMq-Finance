using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    public class Poller
    {
        private readonly Action _assertion;

        public Poller(Action assertion)
        {
            _assertion = assertion;
            PollingInterval = 100;
        }

        public int PollingInterval { get; set; }

        public void PollFor(int timeoutInMilliseconds)
        {
            PollFor(new TimeSpan(0, 0, 0, 0, timeoutInMilliseconds));
        }

        public void PollFor(TimeSpan timeout)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (true)
            {
                try
                {
                    _assertion();
                    return;
                }
                catch
                {
                    if (stopwatch.Elapsed > timeout)
                        throw;

                    Thread.Sleep(PollingInterval);
                }
            }
        }
    }
}
