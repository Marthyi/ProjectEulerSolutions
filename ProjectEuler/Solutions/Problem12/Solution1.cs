using System;
using System.Threading;
using System.Threading.Tasks;

namespace Solutions.Problem12
{
    /*
     * Warning: this is not an optimised solution !!!
     * It could take several minutes
     */
    public class Solution1 : ISolution
    {     
        public string Execute()
        {
            int maxFactors = 1;
           

            int iteration = 1;
            int sum = iteration;
            int nbfactors = CalculateNumberFactorsOf(sum);
            while (nbfactors < 500)
            {
                if (nbfactors > maxFactors)
                {
                    Console.WriteLine(sum + ":" + nbfactors);
                    maxFactors = nbfactors;
                }
                iteration++;
                sum += iteration;
                nbfactors = CalculateNumberFactorsOf(sum);
            }

            return sum.ToString();
        }

        private int CalculateNumberFactorsOf(int value)
        {
            int number = 0;

           
            int limitOfFactors = value / 2 + 1;
            Parallel.For(1, limitOfFactors, (i) =>
            {
                if (value % i == 0)
                {
                    Interlocked.Increment(ref number);
                }
            });

            return number+1;
        }
      
    }
}
