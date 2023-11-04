using System;
using System.Collections.Generic;
using System.Linq;

namespace wordsFinder
{
    class Dict
    {
        public static Dictionary<string, int> dwords = new Dictionary<string, int>();
        public static int wordsCount = 0;

        public void AddWordsToDict(List<string> listOfWords)
        {
            for (int i = listOfWords.Count - 1; i >= 0; i--)
            {
                if (dwords.ContainsKey(listOfWords[i].ToLower()))
                {
                    dwords[listOfWords[i].ToLower()] ++;
                    wordsCount++;
                }
                else if (isWord(listOfWords[i]))
                {
                    dwords.Add(listOfWords[i].ToLower(), 1);
                    wordsCount++;
                }
            }
        }

        private bool isWord(string str)
        {
            if (str.Length<4)
                return false;
            else
                return true;
        }

        public static void PrintTop(int value)
        {
            var values = new int[dwords.Count];
            int count = 0;
            foreach (var el in dwords)
            {
                values[count] = el.Value;
                count++;
            }
            values = values.Distinct().ToArray();
            Array.Sort(values);

            for (int i = values.Length-1; i >= values.Length-value; i--)
            {
                foreach (var el in dwords)
                {
                    if (values[i] == el.Value)
                    {
                        var percent = Math.Round((double)el.Value * 100 / wordsCount, 2) ;
                        Console.WriteLine("{0,-10}{1,10}{2,10}%", el.Key, el.Value, percent);
                    }
                }
            }
        }


        public static void Print(int value)
        {
            foreach (var el in dwords)
            {
                if (Convert.ToInt32(el.Value)  >= value)
                    Console.WriteLine("{0}\t\t\t{1}", el.Key, el.Value);
            }
        }
    }
}