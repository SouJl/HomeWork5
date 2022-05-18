using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    /// <summary>
    /// Статических класс Message
    /// </summary>
    static class Message
    {
        /// <summary>
        /// Выбор слов не превышающих заданную длину
        /// </summary>
        /// <param name="message">исходное сообщение</param>
        /// <param name="n">максимальная длина слова</param>
        /// <returns></returns>
        public static string[] SelectByLength(string message, int n)
        {
            string[] words = GetWords(message);
            return words.Where(w => w.Where(c => char.IsLetter(c)).ToArray().Length <= n).ToArray();
        }

        /// <summary>
        /// Удаление слов заканчивающихся на заданный символ
        /// </summary>
        /// <param name="message">исходное сообщение</param>
        /// <param name="c">символ</param>
        /// <returns></returns>
        public static string ReplaceWordsFromMessage(string message, char c)
        {
            string[] words = GetWords(message);
            return string.Join(" ", words.Where(w => w.Last() != c));
        }

        /// <summary>
        /// Нахождение максимального по длине слова
        /// </summary>
        /// <param name="message">исходное сообщение</param>
        /// <returns></returns>
        public static string Max(string message)
        {
            string[] words = GetWords(message);
            string max = "";
            foreach (var w in words)
            {
                if (w.Length > max.Length) max = w;
            }
            return max;
        }

        /// <summary>
        /// Построение нового сообщения из максимальных по длине слов
        /// </summary>
        /// <param name="message">исходное сообщение</param>
        /// <returns></returns>
        public static string BuildWithMaxWords(string message)
        {
            string[] words = GetWords(message);
            string max = Max(message);
            StringBuilder resut = new StringBuilder();
            foreach (var w in words)
            {
                if (w.Length == max.Length) resut.AppendFormat("{0} ", w);
            }
            return resut.ToString();
        }

        /// <summary>
        /// Частотный анализ сообщения
        /// </summary>
        /// <param name="message">исходное сообщение</param>
        /// <returns></returns>
        public static Dictionary<string, int> WordsFrequency(string message)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            string[] words = GetWords(message);
            foreach (var w in words)
            {
                if (!result.ContainsKey(w)) result.Add(w, 1);
                else result[w]++;
            }
            return result;
        }

        /// <summary>
        /// Разбиение сообщения на массив слов
        /// </summary>
        /// <param name="message">исходное сообщение</param>
        /// <returns></returns>
        private static string[] GetWords(string message)
        {
            return message.Split(' ');
        }
    }
}
