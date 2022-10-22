using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dart_schema.Helper.Tools
{
    public class Benchmark
    {
        private readonly Stopwatch stopwatch;

        public Benchmark()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        public Stopwatch End()
        {
            stopwatch.Stop();
            return stopwatch;
        }

        public void Pause()
        {
            stopwatch.Stop();
        }

        public void Start()
        {
            stopwatch.Start();
        }
    }
}
