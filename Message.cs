using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    static class Message
    {
        public static string SelectByLength(string text, int n)
        {
            string[] words = GetWords(text);
            return string.Join(" ", words.Where(w => w.Where(c => char.IsLetter(c)).ToArray().Length <= n));
        }

        public static string Replace(string text, char c)
        {
            string[] words = GetWords(text);
            return string.Join(" ", words.Where(w => w.Last() != c));
        }

        public static string Max(string text)
        {
            string[] words = GetWords(text);
            string max = "";
            foreach (var w in words)
            {
                if (w.Length > max.Length) max = w;
            }
            return max;
        }

        public static string BuildWithMaxWords(string text)
        {
            string[] words = GetWords(text);
            string max = Max(text);
            StringBuilder resut = new StringBuilder();
            foreach (var w in words)
            {
                if (w.Length == max.Length) resut.AppendFormat("{0} ", w);
            }
            return resut.ToString();
        }

        public static Dictionary<string, int> WordsFrequency(string text)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            string[] words = GetWords(text);
            foreach (var w in words)
            {
                if (!result.ContainsKey(w)) result.Add(w, 0);
                else result[w]++;
            }
            return result;
        }

        private static string[] GetWords(string text)
        {
            text = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            return text.Split(' ');
        }
    }
}
