using System;
using System.Collections.Generic;
using System.IO;

namespace wordsFinder
{
    class Dict
    {
        public Dictionary<string, int> dwords = new Dictionary<string, int>();
        public int wordsCount = 0;
        private const string PATH = @".\text.txt";
        
        public void ReadFromFile(string path = PATH)
        {
            string line;
            using (StreamReader sr = new StreamReader(PATH)) 
            {
                while ((line = sr.ReadLine()) != null)
                    AddWordsToDict(ParseLine(line));
            }
        }
        
        private List<string> ParseLine(string line)
        {
            var list = new List<string>();

            foreach (var el in line)
                if (!char.IsLetter(el) && el != ' ')
                    line = line.Replace(el, ' ');

            list.AddRange(line.Split(' '));
            list.RemoveAll(string.IsNullOrWhiteSpace);

            for (int i = 0; i < list.Count; i++)
                list[i] = list[i].Trim();
            
            return list;
        }

        public void AddWordsToDict(List<string> listOfWords)
        {
            for (int i = listOfWords.Count - 1; i >= 0; i--)
            {
                var wordToLower = listOfWords[i].ToLower();
                if (dwords.ContainsKey(wordToLower))
                {
                    dwords[wordToLower]++;
                    wordsCount++;
                }
                else if (isWord(listOfWords[i]))
                {
                    dwords.Add(wordToLower, 1);
                    wordsCount++;
                }
            }
        }

        private bool isWord(string str)
        {
            if (str.Length<4)
                return false;
            
            return true;
        }

        public void PrintTop(int value)
        {
            List<(string Key, int Value)> listOfWords = new List<(string Key, int Value)>(dwords.Count);
            
            // var listOfWords = dwords.Select(x => (x.Key,x.Value)).ToList();
            foreach (var el in dwords)
                listOfWords.Add((el.Key, el.Value));
            
            listOfWords.Sort((x,y) => - x.Value.CompareTo(y.Value));

            double percent;
            for (int i = 0; i < value; i++)
            {
                percent = Math.Round((double)listOfWords[i].Value * 100 / wordsCount, 2) ;
                Console.WriteLine("{0,-10}{1,10}{2,10}%", listOfWords[i].Key, listOfWords[i].Value, percent);
            }
        }
    }
}