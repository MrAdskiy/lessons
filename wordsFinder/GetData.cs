using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace wordsFinder
{
    class GetData
    {
        private const string PATH = @".\text.txt";
        
        public void ReadFromFile(string path = PATH)
        {
            string line;
            var tempDict = new Dict(); 
            using (StreamReader sr = new StreamReader(PATH)) 
            {
                while ((line = sr.ReadLine()) != null)
                    tempDict.AddWordsToDict(ParseLine(line));
            }
        }

        private List<string> ParseLine(string line)
        {
            var list = new List<string>();

            foreach (var el in line)
                if (!char.IsLetter(el))
                    line = line.Replace(el, ' ');

            list.AddRange(line.Split(' '));

            for (int i = 0; i < list.Count; i++)
                list[i] = list[i].Trim();
            
            return list;
        }

    }
}