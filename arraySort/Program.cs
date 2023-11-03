using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace arraySort
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] array = {5, 3, 1, 4, 6, 2};
            
            Console.Write("Изначальный массив: ");
            foreach (var el in array)
                Console.Write($"{el} ");
            Console.WriteLine();
            
            // сортировка пузырьком
            
            // var length = array.Length;
            // while (length != 0)
            // {
            //     var maxIndex = 0;
            //     for (int i = 1; i < length; i++)
            //     {
            //         if (array[i-1] > array[i])
            //         {
            //             (array[i - 1], array[i]) = (array[i], array[i - 1]);
            //             maxIndex = i;
            //         }
            //     }
            //     length = maxIndex;
            // }

            //сортировка выбором
            
            // for (int i = 0; i < array.Length; i++)
            // {
            //     var minIndex = i;
            //     for (int j = i+1; j < array.Length; j++)
            //     {
            //         if (array[minIndex] > array[j])
            //             minIndex = j;
            //     }
            //     if (minIndex != i)
            //         (array[i], array[minIndex]) = (array[minIndex], array[i]);
            // }
            
            //сортировка вставками

            // for (int i = 1; i < array.Length; i++)
            // {
            //     var sorted = i - 1;
            //     while (sorted >= 0 && array[sorted] > array[sorted+1])
            //     {
            //         (array[sorted], array[sorted+1]) = (array[sorted+1], array[sorted]);
            //         sorted--;
            //     }
            // }

            Console.Write("Отсротированный массив: ");
            foreach (var el in array)
                Console.Write($"{el} ");
        }
    }
}