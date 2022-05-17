using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using GeekBrainsLib;

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
            ConsoleUI consoleUI = new ConsoleUI("Мельников Александр", "Практическое задание 5", 4);
            Console.ForegroundColor = ConsoleColor.White;
            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                consoleUI.PrintUserInfo();
                consoleUI.PrintMenu();
                if (int.TryParse(Console.ReadLine(), out int ndx))
                {
                    Console.Clear();
                    switch (ndx)
                    {
                        default:
                            break;
                        case 1:
                            {
                                Exercise1();
                                break;
                            }
                        case 2:
                            {
                                Exercise2();
                                break;
                            }
                        case 3:
                            {
                                Exercise3();
                                break;
                            }
                        case 4:
                            {
                                Exercise4();
                                break;
                            }
                        case 0:
                            {
                                isWork = false;
                                break;
                            }
                    }
                }
                else
                {
                    Console.Clear();
                    ModifiedConsole.Print("Формат ввода неверен!");
                    ModifiedConsole.Pause();
                }
            }
        }

        static void Exercise1()
        {
            Console.WriteLine("Проверка корректности ввода логина");
            Console.Write("Введите корректный логин: ");
            string login = Console.ReadLine();
            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"Проверяемый логин - {login}");
                Console.WriteLine("Выбирете метод проверки логина");
                Console.WriteLine("1) - Проверка без использования регулярных выражений");
                Console.WriteLine("2) - Проверка c использованием регулярных выражений");
                Console.WriteLine("0) - Назад");
                Console.Write("Введите номер пункта: ");
                if (int.TryParse(Console.ReadLine(), out int ndx))
                {
                    Console.Clear();
                    switch (ndx)
                    {
                        default:
                            break;
                        case 1:
                            {
                                Console.WriteLine($"Проверяемый логин - {login}");
                                Console.Write("Результат -> ");
                                if (IsLoginCorrect(login))
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("логин введен корректно!");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("логин введен неверно!");
                                }
                                Console.ResetColor();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine($"Проверяемый логин - {login}");
                                Regex regex = new Regex(@"^[0-9][A-Za-z0-9]{1,9}$");
                                Console.WriteLine($"Регулярное выражение = {regex}");
                                Console.Write("Результат -> ");
                                if (IsLoginCorrect(login, regex))
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("логин введен корректно!");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("логин введен неверно!");
                                }
                                Console.ResetColor();
                                break;
                            }
                        case 0:
                            {
                                isWork = false;
                                break;
                            }
                    }
                    Console.WriteLine("Для продолжение нажмите любую клавишу...");
                    ModifiedConsole.Pause();
                }
            }
        }

        static void Exercise2()
        {
            Console.WriteLine("Проверка работы класса Message");
            Console.Write("Введите сообщение: ");
            string text = Console.ReadLine();
            bool isWork = true;
            while (isWork)
            {
                Console.Clear();
                Console.WriteLine($"Введение сообщение - {text}");
                Console.WriteLine("Выбирете способб обработки введенного сообщения");
                Console.WriteLine("1) - Вывод слов сообщения, которые содержат не более n букв");
                Console.WriteLine("2) - Удалить слова из сообщения, которые заканчиваются на заданный символ");
                Console.WriteLine("3) - Найти самое длинное слово сообщения");
                Console.WriteLine("4) - Формирование строки из самых длинных слов сообщения");
                Console.WriteLine("5) - Частотный анализ сообщения");
                Console.WriteLine("0) - Назад");
                Console.Write("Введите номер пункта: ");
                if (int.TryParse(Console.ReadLine(), out int ndx))
                {
                    Console.Clear();
                    switch (ndx)
                    {
                        case 1:
                            {
                                Console.WriteLine($"Введение сообщение - {text}");
                                Console.Write("Введите максимальную длину слова: ");
                                int n = int.Parse(Console.ReadLine());
                                var words = Message.SelectByLength(text, n);
                                Console.WriteLine($"Слова, которые менььше {n}");
                                for (int i = 0; i < words.Length; i++)
                                {
                                    Console.WriteLine($"{i + 1}) - {words[i]}");
                                }
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine($"Введение сообщение - {text}");
                                Console.Write("Введите символ: ");
                                char c = char.Parse(Console.ReadLine());
                                string resultText = Message.Replace(text, c);
                                Console.WriteLine($"Сообщенеи без слов, которые заканчиваются на {c}:");
                                Console.WriteLine(resultText);
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine($"Введение сообщение - {text}");
                                Console.WriteLine($"Самое длинное слова - {Message.Max(text)}");
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine($"Введение сообщение - {text}");
                                Console.WriteLine($"Сообщенеи из максмальных по длине слов:");
                                Console.WriteLine(Message.BuildWithMaxWords(text));
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine($"Введение сообщение - {text}");
                                Console.WriteLine("Частотный анализ текста:");
                                var wordsFreq = Message.WordsFrequency(text);
                                foreach (var wordFq in wordsFreq)
                                {
                                    Console.WriteLine($"{wordFq.Key} - {wordFq.Value} шт;");
                                }
                                break;
                            }
                        case 0:
                            {
                                isWork = false;
                                break;
                            }
                    }
                    Console.WriteLine("Для продолжение нажмите любую клавишу...");
                    ModifiedConsole.Pause();
                }
            }
        }

        static void Exercise3()
        {
            Console.WriteLine("Проверка перстановки строк");
            Console.Write("Введите первую строку: ");
            string str1 = Console.ReadLine();
            Console.Write("Введите вторую строку: ");
            string str2 = Console.ReadLine();
            if (IsCompare(str1, str2))
            {
                Console.WriteLine($"{str2} является перестановкой {str1}");
            }
            else
            {
                Console.WriteLine($"{str2} не является перестановкой {str1}");
            }
            Console.WriteLine("Для продолжение нажмите любую клавишу...");
            Console.ReadKey();
        }

        static void Exercise4()
        {
            string fileName = Environment.CurrentDirectory + @"\StudentsInfo.txt";
            if (File.Exists(fileName))
            {
                string[] students = File.ReadAllLines(fileName);
                Console.WriteLine("Сведения о сдаче экзаменов учеников 9-х классов");
                int i = 0;
                foreach(var student in students)
                {
                    Console.WriteLine($"{++i}) -> {student}");
                }
                Console.WriteLine();
                Console.WriteLine("Список худших учеников");
                i = 0;
                foreach (var worstStudent in FindWorstStudents(students))
                {
                    Console.WriteLine($"{++i}) -> {worstStudent.FIO}, средний бал - {worstStudent.Grade}");
                }
                Console.WriteLine();
            }
            else 
            {
                Console.WriteLine($"Файл {fileName} не найден!");
            }
            Console.WriteLine("Для продолжение нажмите любую клавишу...");
            ModifiedConsole.Pause();
        }

        static bool IsCompare(string s1, string s2)
        {
            if (s1 == s2) return false;
            if (s1.Length != s2.Length) return false;
            for (int i = 0; i < s1.Length; i++)
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
            for (int i = 1; i < n; i++)
            {
                if (!char.IsLetterOrDigit(login[i])) return false;
                if (char.IsLetter(login[i]) && !(login[i] >= 65 && login[i] <= 122))
                    return false;

            }
            return true;
        }


        static bool IsLoginCorrect(string login, Regex regex) => regex.IsMatch(login);

        static List<StudentInfo> FindWorstStudents(string[] text)
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
