using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Runtime;
namespace Solutions.Problem10
{
    public class Solution_1 : ISolution
    {
        const long TARGET = 2000000;
        long[] primes = new long[2000000];
        long primesIndex = 0;
        long sqrtIndex = 0;
        long total;

        public string Execute()
        {
            AddPrime(2);
            AddPrime(3);
            AddPrime(5);
            AddPrime(7);

            for (int numberCandidateToBePrime = 10; numberCandidateToBePrime < TARGET; numberCandidateToBePrime += 10)
            {
                IsPrime(numberCandidateToBePrime + 1);
                IsPrime(numberCandidateToBePrime + 3);
                IsPrime(numberCandidateToBePrime + 7);
                IsPrime(numberCandidateToBePrime + 9);
            }

            if (total != 142913828922)
            {
                throw new Exception("invalid result");
            }

            return total.ToString();
        }

        private void AddPrime(long value)
        {
            primes[primesIndex] = value;
            primesIndex++;
            total += value;
        }

        private bool IsPrime(long numberCandidateToBePrime)
        {
            bool isPrime = true;
            int nbProcessor = Environment.ProcessorCount;
            long sqrt = (long)Math.Sqrt((double)numberCandidateToBePrime) + 1;

            while (sqrtIndex < primesIndex && primes[sqrtIndex] < sqrt)
            {
                sqrtIndex++;
            }

            Parallel.For(0, sqrtIndex, (i, state) =>
            {
                if (numberCandidateToBePrime % primes[i] == 0)
                {
                    isPrime = false;
                    state.Break();
                }
            });

            if (isPrime)
            {
                AddPrime(numberCandidateToBePrime);
            }

            return isPrime;
        }
    }
}
