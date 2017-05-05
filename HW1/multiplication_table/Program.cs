using System;

// Peter R. Corletto. May 5, 2017
// CS50XMiami, Cohort 6, C# track. 
// HW # 1, Exercise 2

// Program that has a function that accepts a single integer, int n (line 20),
// and prints out a n x n multiplication table

namespace multiplication_table
{
    class Program
    {
        static void Main(string[] args)
        {
            
            printMultiplicationTable(5);

            // My function definition next: 
            void printMultiplicationTable(int n)
            {

                // Set up two for loops, one nested inside the other one,
                // to generate a two-dimensional array (table) for my 
                // multiplication table. The indexes I use are i and j
                for(int i = 1; i <= n; i++)
                {

                    for(int j = 1; j <= n; j++)
                    {

                        // Print out the product of i times j
                        // on the screen, followed by a blank space

                        // I use Console.Write and not Console.WriteLine because
                        // after printing each number, I do not want it to go
                        // to a new line
                        Console.Write(i * j + " ");

                    }

                    // When the inner loop, j, is finished, go to a new line
                    // by printing the new line character \n
                    Console.Write("\n");

                    // Then, go to the next value of i, for the next multiple...

                }

            }                     
            
        }
    }
}
