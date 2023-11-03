using System.Collections.Generic;

namespace wordsFinder
{
    class Word
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
    }
}