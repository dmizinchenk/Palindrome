using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Palindrome
    {
        const int CORES = 6;
        int part;
        readonly string source;
        ConcurrentStack<string> palindromes;

        public Palindrome(int part, in string source, in ConcurrentStack<string> palindromes)
        {
            this.part = part;
            this.source = source;
            this.palindromes = palindromes;
        }

        public void Find(object? o)
        {
            List<int> discharges = new();
            for (int l = 2; l < source.Length; l++)
            {
                if (l % CORES == part)
                    discharges.Add(l);
            }

            foreach (var discharge in discharges)
            {
                for (int k = 0; k < source.Length - discharge; k++)
                {
                    string substr = source.Substring(k, discharge);
                    bool isPalindrome = true;

                    if (substr[0] == '0')
                        continue;

                    for (int j = 0; j < substr.Length / 2; j++)
                    {
                        if (substr[j] != substr[substr.Length - 1 - j])
                        {
                            isPalindrome = false;
                            break;
                        }
                    }

                    if (isPalindrome)
                    {
                        palindromes.Push(substr);
                    }
                }
            }


        }
    }
}
