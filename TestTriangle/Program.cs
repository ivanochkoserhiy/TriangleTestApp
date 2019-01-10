using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTriangle
{
    class Program
    {
        /// <summary>
        /// Method that calculate biggest sum in triangle
        /// </summary>
        /// <param name="tri">Inout list, parsed from file</param>
        /// <param name="countRows">Count of rows in the list of elements</param>
        /// <returns>Max sum which we can get from start to end of the triangle</returns>
        static int maxPathSum(List<int[]> tri, int countRows)
        {
            // loop for bottom-up calculation 
            for (int i = countRows - 1; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    // for each element,  
                    // check both elements 
                    // just below the number 
                    // and below right to 
                    // the number add the 
                    // maximum of them to it 
                    if (tri[i + 1][j] >
                           tri[i + 1][j + 1])
                        tri[i][j] +=
                               tri[i + 1][j];
                    else
                        tri[i][j] +=
                           tri[i + 1][j + 1];
                }
            }

            // return the top element 
            // which stores the maximum sum 
            return tri[0][0];
        }

        /// <summary>
        /// Methods that parse input file with numbers
        /// </summary>
        /// <param name="pathToFile">Path to input file</param>
        /// <returns>List of rows with numbers to calculate</returns>
        static List<int[]> parseInputArray(string pathToFile)
        {
            List<int[]> items = new List<int[]>();

            var fileStream = new FileStream(pathToFile, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        items.Add(Array
                            .ConvertAll(line.Split(' '), int.Parse));
                    }
                }
            }
            return items;
        }

        static void Main(string[] args)
        {
            //User to input count of rows in the input file
            int countRows = 0;
            do
            {
                Console.Write("Input count of rows in text document: ");
                if (!Int32.TryParse(Console.ReadLine(), out countRows))
                {
                    Console.WriteLine("Error! Please, enter correct value (only number).");
                }
            }
            while (countRows == 0);

            //Parse input file
            List<int[]> items;

            try
            {
                items = parseInputArray("Input.txt");

                //Start algorithm
                if (items != null)
                {
                    Console.WriteLine("Result = " +
                     maxPathSum(items, countRows - 2));
                }
                else
                {
                    Console.WriteLine("You have some errors in the input file.");
                }
            }
            catch
            {
                Console.WriteLine("You have some problems with input file. Please check and try again.");
            }
            Console.ReadKey();
        }
    }
}
