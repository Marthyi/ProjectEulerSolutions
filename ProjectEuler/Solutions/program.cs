using System;
using System.Diagnostics;
namespace Solutions
{
    public static class Program
    {
        private static void Process(ISolution solution)
        {
            var sw = new Stopwatch();
            
            sw.Start();
            string result = solution.Execute();
            sw.Stop();
            
            Console.WriteLine("Time:{0}min  {1}sec. {2}ms", sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            Console.WriteLine();
            Console.WriteLine("Solution: {0}", result);
        }


        public static void Main()
        {
            ISolution solution = new Problem10.Solution1();

            Process(solution);

            Console.ReadKey();
        }
    }
}
