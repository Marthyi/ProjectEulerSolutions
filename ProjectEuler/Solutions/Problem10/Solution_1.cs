namespace Solutions.Problem10
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class Solution1 : ISolution
    {        
        private const long Target = 2000000;
        private bool shouldContinue = true;
        readonly List<long> primes = new List<long>();
        readonly ConcurrentQueue<long> primesToAdd = new ConcurrentQueue<long>();
        BlockingCollection<long> numberToEvaluate = new BlockingCollection<long>();
        
        public string Execute()
        {
            primes.Add(2);

            while (shouldContinue)
            {
                long maxPrime = primes.Max(p => p);
                long maxCarre = maxPrime * maxPrime;

                EvaluateRange(maxPrime + 1, maxCarre);
                PrimeAdder();
            }

            long total = primes.Sum();

            if (total != 142913828922)
            {
                Console.WriteLine("Expected: \t142913828922");
                Console.WriteLine("Result  : \t" + total);
            }

            return total.ToString(CultureInfo.InvariantCulture);
        }

        private void NumberEvaluator()
        {
            foreach (var number in numberToEvaluate.GetConsumingEnumerable())
            {
                if (IsPrime(number))
                {
                    this.primesToAdd.Enqueue(number);

                }
            }
        }

        private void PrimeAdder()
        {
            while (!primesToAdd.IsEmpty)
            {
                long prime;
                primesToAdd.TryDequeue(out prime);
                if (prime < Target)
                {
                    primes.Add(prime);
                }
                else
                {
                    shouldContinue = false;
                }
            }
        }

        private void EvaluateRange(long min, long max)
        {
            numberToEvaluate = new BlockingCollection<long>();

            Task[] tasks = { 
                            Task.Factory.StartNew(this.NumberEvaluator),Task.Factory.StartNew(this.NumberEvaluator),
                            Task.Factory.StartNew(this.NumberEvaluator),Task.Factory.StartNew(this.NumberEvaluator)
                            };

            for (long i = min; i < max; i++)
            {
                numberToEvaluate.Add(i);
            }
            numberToEvaluate.CompleteAdding();

            Task.WaitAll(tasks);
        }
        
        private bool IsPrime(long number)
        {
            long squareOfNumberCandidate = (long)Math.Sqrt(number) + 1;

            foreach (var prime in primes.Where(p => p <= squareOfNumberCandidate))
            {
                if (number % prime == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
