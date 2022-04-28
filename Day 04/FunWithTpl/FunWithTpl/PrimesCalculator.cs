using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


        public static IEnumerable<int> GetAllPrimes(int start, int finish)
        {
            for (int i = start; i <= finish; i++)
            {
                if (_isPrime(i)) yield return i;
            }

        }

        public static Task<List<int>> GetAllPrimesAsync(int start, int finish)
        {
            return Task.Factory.StartNew(() => 
                 GetAllPrimes(start, finish).ToList()
                 );
        }

    }
}
