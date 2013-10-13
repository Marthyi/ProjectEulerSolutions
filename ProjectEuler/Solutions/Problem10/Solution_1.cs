using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
namespace Solutions.Problem10
{
    public class Solution_1 : ISolution
    {
        const string PROBLEM_NUMBER = "Problem 10 solution 1";
        const long TARGET = 2000000;

        List<long> primes = new List<long>();
        List<long> primesSQRT = new List<long>();

        public string Execute()
        {                      
            long total = 2;
            int primesSQRTsize = 1;
            primes.Add(2);
            primesSQRT.Add(2);
            int sqrtIndex = 1;

            long numberCandidateToBePrime = 3;

            while (numberCandidateToBePrime < TARGET)
            {
                long sqrt = (long)Math.Sqrt(numberCandidateToBePrime) + 1;

                if (IsPrime(numberCandidateToBePrime))
                {
                    primes.Add(numberCandidateToBePrime);
                    total += numberCandidateToBePrime;
                }

                while (sqrtIndex < sqrt)
                {
                    primesSQRT.Add(primes[sqrtIndex]);
                    primesSQRTsize++;
                    sqrtIndex++;
                }

                if (numberCandidateToBePrime > 10 && numberCandidateToBePrime % 10 == 3)
                {
                    numberCandidateToBePrime += 4;
                }
                else
                {
                    numberCandidateToBePrime += 2;
                }
            }

            return total.ToString();
        }

        public string ProblemId
        {
            get { return PROBLEM_NUMBER; }
        }

        private bool IsPrime(long numberCandidateToBePrime)
        {
            bool isPrime = true;

            Parallel.ForEach(primesSQRT, (prime, state) =>
            {
                {
                    if (IsFactor(numberCandidateToBePrime, prime))
                    {
                        isPrime = false;
                        state.Break();
                    }
                }
            });

            return isPrime;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsFactor(long value, long factor)
        {
            return factor * (value / factor) == value;
        }
    }
}
