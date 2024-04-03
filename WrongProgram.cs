using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        int[] numbers = new int[] { 10, 20, 30, 40 };

        Parallel.ForEach(numbers, async number =>
        {
            long fibResult = CalculateFibonacci(number);
            await Task.Run(() => Console.WriteLine($"Fibonacci({number}) = {fibResult}"));
        });
    }

    static long CalculateFibonacci(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentException("The input must be a positive integer", nameof(n));
        }

        long a = 0;
        long b = 1;
        for (int i = 2; i <= n; i++)
        {
            long temp = a;
            a = b;
            b = temp + b;
        }
        return b;
    }
}
