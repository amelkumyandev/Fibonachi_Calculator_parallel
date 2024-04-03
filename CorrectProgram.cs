using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FibonacciCalculator
{
    private ConcurrentDictionary<int, long> _cache = new ConcurrentDictionary<int, long>();

    public FibonacciCalculator()
    {
        _cache.TryAdd(0, 0); // Fibonacci(0)
        _cache.TryAdd(1, 1); // Fibonacci(1)
    }

    public long Calculate(int n)
    {
        if (_cache.TryGetValue(n, out long value))
        {
            return value;
        }

        long result = Calculate(n - 1) + Calculate(n - 2);
        _cache.TryAdd(n, result);
        return result;
    }

    public void CalculateInParallel(IEnumerable<int> numbers)
    {
        Parallel.ForEach(numbers, (number) =>
        {
            var result = Calculate(number);
            Console.WriteLine($"Fibonacci({number}) = {result}");
        });
    }
}

class Program
{
    static void Main(string[] args)
    {
        var numbers = new List<int> { 10, 20 , 30 , 40 }; // Example Fibonacci numbers to calculate
        var calculator = new FibonacciCalculator();
        calculator.CalculateInParallel(numbers);
    }
}
