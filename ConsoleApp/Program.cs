using System.Collections.Concurrent;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string value = "989700014441000";
            const int CORES = 6;
            ConcurrentStack<string> palindromes = new();
            WaitHandle[] waitHandles = new WaitHandle[CORES];

            for (int i = 0; i < CORES; i++) 
            {
                waitHandles[i] = new AutoResetEvent(false);
                Palindrome p = new(i, value, palindromes);
                ThreadPool.QueueUserWorkItem(new WaitCallback(p.Find), waitHandles[i]);
            };

            WaitHandle.WaitAll(waitHandles);
            Console.WriteLine($"Palindromes count is: {palindromes.Count}");
            foreach (string s in palindromes)
            {
                Console.WriteLine(s);
            }
        }
    }
}
