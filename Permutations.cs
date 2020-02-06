using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task1
{
    /// <summary>
    /// Класс - решение задачи получения на вход двух строк и определиния,
    /// является ли первая строка перестановкой второй.
    /// </summary>
    /// <remarks>
    /// Перестановка - любое изменение порядка символов.
    /// Учитывается регистр, пробелы и знаки препинания. 
    /// Ввод: input.txt
    /// Вывод: output.txt
    /// </remarks>
    class Permutations
    {
        /// <summary>
        /// Этот метод проверяет, является ли одна строка перестановкой другой
        /// </summary>
        /// <param name="str1">Первая строка для сравнения</param>
        /// <param name="str2">Вторая строка для сравенния</param>
        /// <returns>true, если первая строка является перемтановкой второй, в противном случае - false</returns>
        static bool checkPermition(String str1, String str2)
        {
            char[] arr1 = str1.ToCharArray();
            char[] arr2 = str2.ToCharArray();
            Array.Sort(arr1); 
            Array.Sort(arr2);
            return Enumerable.SequenceEqual(arr1,arr2) ? true : false;
        }
        /// <summary>
        /// Этот метод записывает данный текст, если может, в указанный файл, если не может, в файл "output.txt" в текущем каталоге
        /// </summary>
        /// <param name="file">Путь к файлу, в который нужно запсывать текст</param>
        /// <param name="text">Текст для записи в файл</param>
        private static void writeOnFile(String file, String text)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(file))
                {
                    streamWriter.WriteLine(text);
                }
            }
            catch(Exception ex)
            {
                using (StreamWriter streamWriter = new StreamWriter("output.txt"))
                {
                    streamWriter.WriteLine(ex.Message+"\n"+text);
                }
            }
        }
        /// <summary>
        /// Этот метод разбивает текст по строкам и возвращает список из первых двух непустых строк.
        /// </summary>
        /// <remarks>
        /// Если в тексте меньше двух непустых строк, метод возвращает список из 1 или 0 строк.
        /// </remarks>
        /// <param name="text">Текст для поиска в нём строк</param>
        /// <returns>Список непустых строк в тексе (максимум две).</returns>
        private static List<String> getTwoNonEmptyLines(String text)
        {
            String[] lines = text.Split('\r','\n');
            List<string> twoStr = new List<string>(2);
            int i = 0;
            while (i < lines.Length)
            {
                if (!String.IsNullOrEmpty(lines[i]))
                {
                    twoStr.Add(lines[i]);
                    if (twoStr.Count == 2) break;
                }
                i++;
            }
            return twoStr;
        }

        /// <summary>
        /// Точка входа для приложения.
        /// </summary>
        /// <param name="args"> Список аргументов командной строки</param>
        static void Main(string[] args)
        {
            String input = @"D:\input.txt";
            String output = @"D:\output.txt";
            String text="";
            try
            {
                using (StreamReader streamReader = new StreamReader(input))
                {
                    text = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                writeOnFile(output, ex.Message);
                return;
            }
            List<string> twoStr = getTwoNonEmptyLines(text);
            if (twoStr.Count == 2)
            {
                if (checkPermition(twoStr[0], twoStr[1]))
                {
                    writeOnFile(output, "Первая строка является перестановкой второй");
                } else
                {
                    writeOnFile(output, "Первая строка не является перестановкой второй");
                }
            } else
            {
                writeOnFile(output, "Не хватает данных для сравнения");
            }
            return;
        }
    }
}
