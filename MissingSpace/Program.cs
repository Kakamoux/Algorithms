using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingSpace
{
    class Program
    {
        static Dictionary<String, String> dic = new Dictionary<string, string>();

     

        static String segmente(String input)
        {
            if (dic.ContainsKey(input)) return input;
            for (int i = 0; i < input.Length; i++)
            {
                String prefix = input.Substring(0, i);
                if (dic.ContainsKey(prefix)) {
                    String sufix = input.Substring(i, input.Length - i);
                    String segSuffix = segmente(sufix);
                    if(segSuffix!=null)
                    {
                        return prefix + " " + segSuffix;
                    }
                 }
            }
            return null;
        }
       
        static void Main(string[] args)
        {
            dic.Add("this", "this");
            dic.Add("is", "is");
            dic.Add("a", "a");
            dic.Add("test", "test");
            dic.Add("to", "to");
            dic.Add("them", "them");
            dic.Add("themthi", "themthi");
            dic.Add("mark", "mark");
            dic.Add("ma", "ma");
            String test = "markthemThisisatesttothem";
            Console.WriteLine(segmente(test.ToLower()));
            Console.ReadLine();
        }
    }
}
