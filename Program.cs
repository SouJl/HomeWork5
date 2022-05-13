using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork5
{
    class Message
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

    class Program
    {
        static void Main(string[] args)
        {
            bool result;
            result = IsLoginCorrect("1AZaz");
            Regex regex = new Regex(@"^[0-9][A-Za-z0-9]{1,9}$");
            result = IsLoginCorrect("addsda", regex);
            result = IsLoginCorrect("12sAA", regex);

            var result1 = Message.SelectByLength("Ho2w123 are12 you doing today?", 3);
            var max = Message.Max("Ho2w123 are12 you doing today?");
            var replace = Message.Replace("Why my kek split", 'y');
            var build = Message.BuildWithMaxWords("Why my kek");
            var textFreq = Message.WordsFrequency("my my Word kek kek kek epep eppss");

        }

        static bool IsLoginCorrect(string login)
        {
            int n = login.Length;
            if (!(n >= 2 && n <= 10)) return false;
            if (!char.IsDigit(login[0])) return false;
            for(int i = 1; i < n; i++)
            {
                if (!char.IsLetterOrDigit(login[i])) return false;
                if (char.IsLetter(login[i]) && !(login[i] >= 65 && login[i] <= 122))
                    return false;

            }
            return true;
        }

        static bool IsLoginCorrect(string login, Regex regex) => regex.IsMatch(login);
    }
}
