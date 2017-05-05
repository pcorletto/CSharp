using System;

// Peter R. Corletto. May 5, 2017
// CS50XMiami, Cohort 6, C# track. 
// HW # 1, Exercise 1

// Program that calculates the area of a rectangle.
// It contains a single function, GetArea, that accepts
// two integer parameters and returns the calculated area as an integer (lines 23-26)

// My Main function or "class Program" calls my function by passing in
// some sample data to test that my function works (line 39).

// My program prints the result of the calculation to the screen (line 42)

namespace rectangle_area
{
    class Rectangle
    {
        public int Length{get; set;}
        public int Width{get; set;}

        public int GetArea(int l, int w)
        {
            return l * w;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Rectangle object. I called it "box"
            Rectangle box = new Rectangle();
         
            // Calculate the area using the GetArea method
            // Pass in 12 units for the length
            // and 5 units for the width (SAMPLE)
            int area = box.GetArea(12, 5);
            
            // Display the area, on the screen, in square units
            Console.WriteLine("The area is " + area + " square units.");

        }
    }
}
