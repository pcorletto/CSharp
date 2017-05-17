using System;

namespace shapes
{
    abstract class Shape
    {

        public string Name {get; set;}
        public abstract double Area {get; set;}

    }

    class Square : Shape
    {
        public Square(){

            this.Name = "Square";

        }
        
        public double Side {get; set;}
        public override double Area()
        {
            return Side * Side;
        }
    }

    class Circle : Shape
    {
        
        public Circle(){

            this.Name = "Circle";

        }
        
        public double Radius {get; set;}
        
        public override double Area()
        {

            return Math.PI * Math.Pow(Radius, 2);

        }
        
        
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Circle myCircle = new Circle();
            myCircle.Radius = 5;

            Square mySquare = new Square();
            mySquare.Side = 7;

            double circleArea = myCircle.Area(myCircle.Radius);

            Console.WriteLine("Area of " + myCircle.Name );
            
        }
    }
}
