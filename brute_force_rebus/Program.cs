using System;
using System.Globalization;

namespace brute_force_rebus
{
    internal class Program
    {
        public static bool Compare(string line1, string line2, string answer, string value1, string value2, string answer2)
        {
            if (line1 == line2 && value1 != value2)
                return false;
            if (line1 != line2 && value1 == value2)
                return false;
            if (line1 != answer && value1 == answer2)
                return false;
            if (line2 != answer && value2 == answer2)
                return false;
            
            for (int i = 0; i < line1.Length; i++)
            {
                for (int j = i+1; j < line1.Length; j++)
                {
                    if (line1[i] == line1[j] && value1[i] != value1[j])
                        return false;
                    if (line1[i] != line1[j] && value1[i] == value1[j])
                        return false;
                }
            }
            
            for (int i = 0; i < line2.Length; i++)
            {
                for (int j = i+1; j < line2.Length; j++)
                {
                    if (line2[i] == line2[j] && value2[i] != value2[j])
                        return false;
                    if (line2[i] != line2[j] && value2[i] == value2[j])
                        return false;
                }
            }
            
            for (int i = 0; i < answer.Length; i++)
            {
                for (int j = i+1; j < answer.Length; j++)
                {
                    if (answer[i] == answer[j] && answer2[i] != answer2[j])
                        return false;
                    if (answer[i] != answer[j] && answer2[i] == answer2[j])
                        return false;
                }
            }

            for (int i = 0; i < line1.Length; i++)
            {
                for (int j = 0; j < line2.Length; j++)
                {
                    if (line1[i] == line2[j] && value1[i] != value2[j])
                        return false;
                    if (line1[i] != line2[j] && value1[i] == value2[j])
                        return false;
                }
            }
            
            for (int i = 0; i < line1.Length; i++)
            {
                for (int j = 0; j < answer.Length; j++)
                {
                    if (line1[i] == answer[j] && value1[i] != answer2[j])
                        return false;
                    if (line1[i] != answer[j] && value1[i] == answer2[j])
                        return false;
                }
            }
            
            for (int i = 0; i < line2.Length; i++)
            {
                for (int j = 0; j < answer.Length; j++)
                {
                    if (line2[i] == answer[j] && value2[i] != answer2[j])
                        return false;
                    if (line2[i] != answer[j] && value2[i] == answer2[j])
                        return false;
                }
            }
            return true;
        }
        
        public static void Main()
        {
            //решение ребуса вида WRONG+WRONG=RIGHT методом перебора
            //кол-во букв может быть любым

            // string line1 = "WRONG";
            // string line2 = "WRONG";
            // string answer = "RIGHT";
            string line1 = "ЛЕТО";
            string line2 = "ЛЕТО";
            string answer = "ПОЛЕТ";
            // string line1 = "ABC";
            // string line2 = "C";
            // string answer = "ABD";

            if (answer.Length < line1.Length || answer.Length < line2.Length)
                Console.WriteLine("Неверное условие!");
            
            var line1Min = (int)Math.Pow(10, line1.Length - 1);
            if (line1.Length == 1)
                line1Min--;
            var line2Min = (int)Math.Pow(10, line2.Length - 1);
            if (line2.Length == 1)
                line2Min--;
            
            var line1Max = (int)Math.Pow(10, line1.Length);
            var line2Max = (int)Math.Pow(10, line2.Length);
            var answerMax = (int)Math.Pow(10, answer.Length);
            var answerMin = (int)Math.Pow(10, answer.Length - 1);

            var find = false;
            
            for (int i = line1Min; i < line1Max; i++)
            {
                for (int j = line2Min; j < line2Max; j++)
                {
                    if (i+j >= answerMax || i+j < answerMin)
                        continue;
                    if (Compare(line1, line2, answer, i.ToString(), j.ToString(), (i+j).ToString()))
                    {
                        Console.WriteLine($"{line1} + {line2} = {answer}\n {i} + {j} = {i+j}\n" );
                        find = true;
                    }
                }
            }
            
            if (!find)
                Console.WriteLine($"{line1} + {line2} = {answer}\nОтвет не найден.");
        }
    }
}