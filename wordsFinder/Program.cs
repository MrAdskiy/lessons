using System;
using System.Collections.Generic;
using System.IO;

namespace wordsFinder
{
    class Program
    {
        public static Dictionary<string, int> AddWordsToDict(Dictionary<string, int> dict, List<string> listOfWords)
        {
            for (int i = listOfWords.Count - 1; i >= 0; i--)
            {
                if (dict.ContainsKey(listOfWords[i]))
                    dict[listOfWords[i]] ++;
                else
                    dict.Add(listOfWords[i], 1);
            }

            return dict;
        }

        public static void ReadFile(Dictionary<string, int> dict, string path)
        {
            string line;
            var list = new List<string>();
            using (StreamReader sr = new StreamReader(path)) 
            {
                while ((line = sr.ReadLine()) != null)
                {
                    AddWordsToDict(dict, list);
                }
            }
        }

        public static void Main(string[] args)
        {
            Dictionary<string, int> dWords = new Dictionary<string, int>();
            
            // Console.Write("Укажите путь до папки с файлами: ");
            // var path = Console.ReadLine();

            var path = @".\text.txt";
        }
    }
}