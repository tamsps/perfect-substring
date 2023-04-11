using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FindPerfectSubString
{
    internal class Result
    {
        public int start { get; set; }
        public int end { get; set; }
        public static List<string> subPerfect { get; set; }
        public static int findSmallestDivisor(string s, string t)
        {
            var res = -1;

            int time = Regex.Matches(s, t).Count;
            if (time * t.Length == s.Length && s.IndexOf(t) == 0)
            {
                res = t.Length;
            }
            return res;
        }

        public static void perfectSubstring(string s, int k)
        {
            int curCount = 1;
            int mid = 0;
            subPerfect = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                curCount = 1;
                for (int j = i + 1; j < s.Length; j++)
                {

                    if (s[i] == s[j])
                    {
                        curCount += 1;
                        if (curCount == k)
                            mid = j;
                        if (curCount == k + 1)
                        {
                            curCount = 1;
                            int realPos = j;
                            if (CheckSubString(s, k, i, mid, j, ref realPos))
                                subPerfect.Add(s.Substring(i, realPos - i + 1));
                            break;
                        }
                    }
                    if (curCount == k && j == s.Length - 1)
                    {
                        int realPos = j;
                        if (CheckSubString(s, k, i, mid, j, ref realPos))
                            subPerfect.Add(s.Substring(i, realPos - i + 1));
                    }
                }
            }
        }
        public static bool CheckSubString(string s, int k, int i, int mid, int end, ref int realPos)
        {

            var sub = s.Substring(i, mid - i + 1);
            Dictionary<char, int> charCountsSubs = sub.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

            var item = charCountsSubs.Any(a => a.Value != k);
            if (item == true)
            {
                for (int m = mid + 1; m <= end; m++)
                {
                    if (charCountsSubs.ContainsKey(s[m]))
                    {
                        charCountsSubs[s[m]] += 1;
                    }
                    else
                        charCountsSubs.Add(s[m], 1);
                    item = charCountsSubs.Any(a => a.Value != k);
                    if (item == false)
                    {
                        realPos = m;
                        return true;
                    }
                }
            }
            else
            {
                realPos = mid;
                return true;
            }

            return false;
        }
    }
}
