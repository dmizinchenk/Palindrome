namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string value = "9459914441654073";
            int size = value.Length;
            //object locker = new object();
            List<string> palindromes = new List<string>();

            ParallelLoopResult res = Parallel.For(2, size, (iter) =>
            {
                for (int i = 0; i <= size - iter; i++)
                {
                    string s = value.Substring(i, iter);
                    bool isPalindrome = true;
                    for (int j = 0; j < s.Length / 2; j++)
                    {
                        if (s[j] != s[s.Length - 1 - j])
                        {
                            isPalindrome = false;
                            break;
                        }
                    }
                    if (isPalindrome)
                    {
                        //lock (locker)
                        {
                            palindromes.Add(s);
                        }
                    }
                }
            });
            Console.WriteLine(res.IsCompleted);

            foreach (string s in palindromes)
            {
                Console.WriteLine(s);
            }
        }
    }
}
