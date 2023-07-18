using System;
using System.IO;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "./File/RandomNumbers.txt";

            int count = 100000;
            int minValue = int.MinValue;
            int maxValue = int.MaxValue;

            GenerateRandomNumbersToFile(filePath, count, minValue, maxValue);

            Console.WriteLine("Random numbers generated and saved to text file.");
            Console.ReadLine();
        }

        /// <summary>
        /// function which read the file path and generate g 100,000 int32 distinct random numbers.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="count"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        static void GenerateRandomNumbersToFile(string filePath, int count, int minValue, int maxValue)
        {
            Random random = new Random();
            HashSet<int> numbers = new HashSet<int>();

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                while (numbers.Count < count)
                {
                    int randomNumber = random.Next(minValue, maxValue);
                    if (numbers.Add(randomNumber))
                    {
                        writer.WriteLine(randomNumber);
                    }
                }
            }
        }
    }
}

