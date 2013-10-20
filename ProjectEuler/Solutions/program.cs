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
            Console.WriteLine("{0}", solution.ProblemId);

            sw.Start();            
            result = solution.Execute();
            sw.Stop();
            
            Console.WriteLine("Time: {0}sec. {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            Console.WriteLine();
            Console.WriteLine("Solution: {0}", result);
        }


        public static void Main()
        {
            ISolution solution = new Problem11.Solution_1();

            Process(solution);

            Console.ReadKey();
        }
    }
}
