using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Exercises
{

    [XmlInclude(typeof(Rectangle)), /* XmlInclude(typeof(Square)), */ XmlInclude(typeof(Circle))]
    /* public abstract class Shape
    {
        protected double height;
        protected double width;
        public string Name { get; set; }
        public virtual double Height { get { return height; } set { height = value; } }
        public virtual double Width { get { return width; } set { width = value; } }

        public string Color { get; set; }
        public abstract double Area { get; }
    } */

    public class Rectangle /* : Shape */
    {
        public string Color { get; set; }
        public virtual double Height { get { return height; } set { height = value; } }
        public virtual double Width { get { return width; } set { height = value; } }
        protected double height;
        protected double width;
        public Rectangle() { }
        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }
        public virtual double Area
        {
            get
            {
                return height * width;
            }
        }
    }

    /* public class Square : Rectangle
    {
        public Square() { }
        public Square(double width) : base(height: width, width: width) { }
        new public double Height
        {
            set
            {
                height = value;
                width = value;
            }
        }
    } */

    public class Circle : Rectangle
    {
        public Circle() { }
        // public Circle(double radius) : base(width: radius * 2) { }
        public double Radius
        {
            get { return height / 2; }
            set { Height = value * 2; }
        }
        public override double Area
        {
            get
            {
                var radius = height / 2;
                return System.Math.PI * radius * radius;
            }
        }
    }
}