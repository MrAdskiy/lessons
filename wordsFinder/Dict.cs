﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace wordsFinder
{
    class Dict
    {
        public static Dictionary<string, int> dwords = new Dictionary<string, int>();

        public void AddWordsToDict(List<string> listOfWords)
        {
            for (int i = listOfWords.Count - 1; i >= 0; i--)
            {
                if (dwords.ContainsKey(listOfWords[i]))
                    dwords[listOfWords[i]] ++;
                else
                    dwords.Add(listOfWords[i], 1);
            }
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
            Array.Sort(values);

            for (int i = values.Length-1; i >= values.Length-value; i--)
            {
                foreach (var el in dwords)
                {
                    if (values[i] == el.Value)
                        Console.WriteLine($"{el.Key}\t\t{el.Value}");
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