using System;

namespace shapes
{
    abstract class Shape
    {

        public int OriginX {get; set;}
        public int OriginY {get; set;}

    }

    class Square : Shape
    {
        public int SideLength {get; set;}
    }

    class Circle : Shape
    {
        public int Radius {get; set;}
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Circle myCircle = new Circle();
            myCircle.Radius = 10;
            myCircle.OriginX = 2;
            myCircle.OriginY = -5;

            Square mySquare = new Square();
            mySquare.SideLength = 5;
            mySquare.OriginX = -3;
            mySquare.OriginY = 0;
            
            Console.WriteLine(myCircle.Radius);
            Console.WriteLine(myCircle.OriginX);
            Console.WriteLine(myCircle.OriginY);
            Console.WriteLine(mySquare.SideLength);
            Console.WriteLine(mySquare.OriginX);
            Console.WriteLine(mySquare.OriginY);
        }
    }
}
