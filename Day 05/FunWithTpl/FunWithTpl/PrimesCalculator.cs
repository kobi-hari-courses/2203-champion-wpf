using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunWithTpl
{
    public static class PrimesCalculator
    {
        private static bool _isPrime(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0) return false;
            }

            return true;
        }         


        public static IEnumerable<int> GetAllPrimes(int start, int finish, CancellationToken ct, IProgress<double>? progress)
        {
            var total = finish - start;

            for (int i = start; i <= finish; i++)
            {
                var soFar = i - start;
                if (soFar % 1000 == 0)
                {
                    progress?.Report((double)soFar / total);
                }

                //if (ct.IsCancellationRequested) throw new OperationCanceledException();
                ct.ThrowIfCancellationRequested();

                if (_isPrime(i)) yield return i;
            }

            progress?.Report(1);

        }

        public static IEnumerable<int> GetAllPrimesParallel(int start, int finish, CancellationToken ct)
        {
            return Enumerable.Range(start, finish)
                .AsParallel()
                .AsOrdered()                
                .WithCancellation(ct)
                .Where(i => _isPrime(i));
        }



        public static Task<List<int>> GetAllPrimesAsync(int start, int finish,
                CancellationToken? ct = null, IProgress<double>? progress = null)
        {
            var token = ct.HasValue ? ct.Value : CancellationToken.None;

            return Task.Factory.StartNew(() => 
                 GetAllPrimes(start, finish, token, progress).ToList()
                 );
        }

    }
}
