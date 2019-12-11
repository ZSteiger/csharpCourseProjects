using System;

namespace Exercises
{
    public abstract class Shape
    {
        protected double height;
        protected double width;
        public virtual decimal Height { get { return height; } set { height = value; } }
        public virtual decimal Width { get { return width; } set { width = value; } }

        public string Color { get; set; }
        public decimal Radius { get; set; }
        public Shape() { }
    }
    public class Rectangle : Shape
    {
        public Rectangle() { }
        public Rectangle(decimal height, decimal width)
        {
            this.height = height;
            this.width = width;
        }
        public override decimal Area
        {
            get
            {
                return height * width;
            }
        }
    }
    public class Square : Rectangle
    {
        public Square() { }
        public Square(decimal width) : base(height: width, width: width) { }
        public override decimal Height
        {
            set
            {
                height = value;
                width = value;
            }
        }
    }
    public class Circle : Square
    {
        public Circle() { }
        public Circle(decimal radius) : base(width: radius * 2) { }
        new public decimal Radius
        {
            get { return height / 2; }
            set { Height = value * 2; }
        }
        public override decimal Area
        {
            get
            {
                var radius = height / 2;
                return System.Math.PI * radius * radius;
            }
        }
    }
}