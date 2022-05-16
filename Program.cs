using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork5
{
    struct StudentInfo
    {
        public string FIO;
        public double Grade;
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

            Console.WriteLine(IsCompare("afghw", "wghaf"));
            
            string str = "Иванов Иван 1 2 3\nМельников Александр 2 3 4\nКирилов Антон 3 1 1\nКринова Мария 4 1 0\nДмитриев Антон 1 1 1" +
               "\nКоваль Михаил 1 2 1\nРазов Егор 5 2 1\nПетров Петр 1 4 0";
            string[] text = str.Split('\n');
            var worstStudents = ClassMatesFilter(text);
            foreach (var student in worstStudents)
            {
                Console.WriteLine($"{student.FIO}, средний бал - {student.Grade}");
            }

            Console.ReadKey();

        }

        static bool IsCompare(string s1, string s2)
        {
            if (s1 == s2) return false;
            if (s1.Length != s2.Length) return false;
            for(int i = 0; i <s1.Length; i++)
            {
                if (!s2.Contains(s1[i])) return false;
            }
            return true;
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

        static List<StudentInfo> ClassMatesFilter(string[] text)
        {
            List<StudentInfo> stdInf = new List<StudentInfo>();
            Regex regex = new Regex(@"^[A-Za-zА-Яа-я]{1,20}\s{1}[A-Za-zА-Яа-я]{1,15}\s{1}[0-9]{1}\s{1}[0-9]{1}\s{1}[0-9]{1}$");
            foreach (var str in text)
            {
                if (regex.IsMatch(str))
                {
                    string[] inf = str.Split(' ');
                    stdInf.Add(new StudentInfo
                    {
                        FIO = $"{inf[0]} {inf[1]}",
                        Grade = Math.Round((int.Parse(inf[2]) + int.Parse(inf[3]) + int.Parse(inf[4])) / 3f, 2)
                    });
                }
            }
            List<StudentInfo> worstStudents = stdInf.OrderBy(s => s.Grade).Take(3).ToList();
            foreach (var student in stdInf)
            {
                if (!worstStudents.Contains(student) && worstStudents.Any(ws => ws.Grade == student.Grade))
                {
                    worstStudents.Add(student);
                }
            }
            return worstStudents.OrderBy(s => s.Grade).ToList();
        }

    }
}
