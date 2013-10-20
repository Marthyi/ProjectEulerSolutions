using System;
using System.Diagnostics;
namespace Solutions
{
    public class program
    {
        public static void Process(ISolution solution)
        {
            Stopwatch sw = new Stopwatch();
            string result;           

            sw.Start();            
            result = solution.Execute();
            sw.Stop();
            
            Console.WriteLine("Time:{0}min  {1}sec. {2}ms", sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            Console.WriteLine();
            Console.WriteLine("Solution: {0}", result);
        }


        public static void Main()
        {
            ISolution solution = new Problem12.Solution_1();

            Process(solution);

            Console.ReadKey();
        }
    }
}
