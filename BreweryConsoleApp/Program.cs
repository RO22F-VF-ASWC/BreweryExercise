using System;
using System.Diagnostics;
using System.IO;
using BreweryLib.ThreadCollections;

namespace BreweryConsoleApp
{
    class Program
    {
        public static TraceSource TRACE;
        static void Main(string[] args)
        {
            //BoundedBuffer<String> ss = new BoundedBuffer<string>(); // derved default 1.000.000
            //BoundedBuffer<String> ss2 = new BoundedBuffer<string>(100);

            TRACE = new TraceSource("Brewery");
            TRACE.Listeners.Add(
                new TextWriterTraceListener(
                    new StreamWriter(@"c:\Logfiler\Brewery.txt")));
            TRACE.Listeners.Add(new ConsoleTraceListener());


            TRACE.Switch = new SourceSwitch("Brewery", "all");

            BreweryWorker worker = new BreweryWorker();
            worker.Start();

            Console.WriteLine("Simulation finished - look in logfile");
            Console.ReadLine();
        }
    }
}
