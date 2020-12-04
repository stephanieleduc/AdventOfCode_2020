using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    class Day1
    {

        private static List<int> numbers = new List<int>();

        public static void Solve(int id)
        {
            ReadFileToArraylist("assets/input1-1.txt");

            if (id == 1)
            {
                foreach (int number in numbers)
                {
                
                    if (numbers.Contains(2020 - number))
                    {
                        int result = (2020 - number) * number;
                        Console.WriteLine("Result for puzzle 1: " + result);
                        break;
                    }
                }

            } else if (id ==2)
            {
                Boolean broken = false;

                foreach (int i in numbers)
                {
                    foreach (int j in numbers)
                    {
                        if (numbers.Contains(2020-i-j))
                        {
                            int result = (2020 - i - j) * i * j;
                            Console.WriteLine("Result for puzzle 2: " + result);
                            broken = true;
                            break;
                        }
                    } 
                    if (broken)
                    {
                        break;
                    }
                }
            } 
        }


        public static void ReadFileToArraylist(String fileName)
        {
            TextReader tr = File.OpenText(fileName);
            
            String line = tr.ReadLine();
            while (line != null)
            {
                int number = int.Parse(line);
                numbers.Add(number);
                line = tr.ReadLine();

            }
        }
    }
}
