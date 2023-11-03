using System;
using System.Collections.Generic;

namespace wordsFinder
{
    class Program
    {
        public static void Main(string[] args)
        {
            var dict = new Dict();
            var data = new GetData();
            
            data.ReadFromFile();
            Dict.Print();
        }
    }
}