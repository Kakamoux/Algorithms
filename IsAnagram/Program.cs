using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsAnagram
{
    class Program
    {

        static bool isAnagram(String rf, String str)
        {
            if (rf.Length != str.Length) return false;
            int[] cs = new int[256];
            for (int i = 0; i < rf.Length; i++)
            {
                cs[rf[i]] += 1;
                cs[str[i]] -= 1;
            }

            for (int i = 0; i < cs.Length; i++)
            {
                if (cs[i] != 0) return false;
            }
            return true;
            
        }

        static void Main(string[] args)
        {
            String rf = "abcdef";
            List<String> ls = new List<string>()
            {
                "abcdef",
                "abcdefd",
                "abcde",
                "hdbkef",
                "abcder",
                "fedcba",

        };

            foreach(String s in ls )
            {
                Console.WriteLine("{0} is{1} an anagram of {2}", s, (isAnagram(s, rf) ? "":" NOT"), rf );
            }
            

            Console.ReadLine();

        }
    }
}
