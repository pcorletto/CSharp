using System;

// Peter R. Corletto. May 5, 2017
// CS50XMiami, Cohort 6, C# track. 
// HW # 1, Exercise 3

// Program that has a max function that accepts a variable number of integer parameters (line 22).
// It finds the largest number in the collection (lines 31-51) and then,
// it returns it from my max function (line 51)

namespace max_function
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Create an array that contains the integers
            // I used an array of integers because the program requires a 
            // variable number of integer parameters. We could make our list
            // have any number of integers we want...
            int[] numberList = {17, 10, 5, 6, 2, 11, 6, 20, 3, 1, 12, 5, 4, 10, 9};
            
            // Call my function max. Assign the result to maxNumber
            int maxNumber = myMaxFunction(numberList);
            
            // Print out the max number
            Console.WriteLine("The maximum value is: " + maxNumber);

            // My max function definition...
            int myMaxFunction(int[] values)
            {

                // Start by making the first value in the array the maximum that has been
                // determined yet
                int max = values[0];

                for(int i = 0; i < values.Length; i++)
                {
                    // Compare each value in the array with the value in the next array index,
                    // to the right. If the value on the right is greater than the current
                    // max value, then make that value the new max value

                    if(values[i]>max)
                    {
                        max = values[i];
                    }
                
                }
                
                return max;

            }

        }
    }
}
