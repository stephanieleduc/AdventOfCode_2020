using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Day2
    {

        private static List<String> passwords = new List<string>();
        private static String pattern = @"(?<min>[\d]+)-(?<max>[\d]+) (?<letter>[a-z]): (?<password>[a-z]+)";
        private static int resultCounter = 0;

        public static void Solve(int id)
        {

            ReadInput("assets/input2.txt");

            if (id == 1)
            {

                int letterCounter = 0;
                int min, max;
                char letter;
                char[] pass;

                foreach (String line in passwords)
                {
               
                    Match m = Regex.Match(line, pattern);
                    min = int.Parse(m.Groups["min"].Value);
                    max = int.Parse(m.Groups["max"].Value);
                    letter = Convert.ToChar(m.Groups["letter"].Value);
                    pass = m.Groups["password"].Value.ToCharArray();

                    for (int i = 0; i < pass.Length; i++)
                    {
                        if (pass[i].Equals(letter))
                        {
                            letterCounter++;
                        }
                    }

                    if (min <= letterCounter && letterCounter <= max)
                    {
                        resultCounter++;
                    }

                    letterCounter = 0;
                }

                Console.WriteLine("Result day 2, puzzle 1: " + resultCounter);

            }
            else if (id == 2)
            {
                int pos1, pos2;
                char letter;
                char[] pass;


                foreach (String line in passwords)
                {
                    Match m = Regex.Match(line, pattern);
                    pos1 = int.Parse(m.Groups["min"].Value);
                    pos2 = int.Parse(m.Groups["max"].Value);
                    letter = Convert.ToChar(m.Groups["letter"].Value);
                    pass = m.Groups["password"].Value.ToCharArray();

                    if (pass[pos1-1].Equals(letter) != pass[pos2-1].Equals(letter))
                    {
                        resultCounter++;
                    }
                    
                }

                Console.WriteLine("Result day 2, puzzle 2: " + resultCounter);

            }
          
        }

        public static void ReadInput(String fileName)
        {
            TextReader tr = File.OpenText(fileName);
            String line = tr.ReadLine();
            while (line != null)
            {
                passwords.Add(line);
                line = tr.ReadLine();
            }
        }

    }
}
