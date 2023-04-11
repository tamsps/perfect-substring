using System;

namespace FindPerfectSubString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string s = "1221221121";

            //int t = 3;

            string s = "1233452452";
            int t = 2;

            

            Result.perfectSubstring(s, t);
           
            Console.WriteLine("Original: " + s);
            Console.WriteLine("Times: " + t);
            Console.WriteLine();
            Console.WriteLine("Number of perfect substring: " + Result.subPerfect.Count);
            foreach (var item in Result.subPerfect)
            {
                var start  = s.IndexOf(item);
                var end = start + item.Length-1;
                Console.Write(String.Format("[{0}-{1}]: ",start,end));
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
