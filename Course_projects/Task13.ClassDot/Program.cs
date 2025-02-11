/*
 * Створити клас Dot для опису точки у двовимірній декартовій системі координат. Створити клас
«Прямокутник», полями якого будуть 2 точки (2 точки, що не лежать на одній прямій, цілком достатні для
однозначного визначення прямокутника). Написати методи для знаходження його периметра та площі.
Створити екземпляр класу «Прямокутник», викликати йому реалізовані методи
 */
using System;
using System.Text;
     
namespace Task13.ClassDot
{
    public class Dot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Dot(int x, int y)        
        { 
            X = x;
            Y = y;
        }
    }

    public class Rectangle
    { 
        public Dot? A { get; set; }
        public Dot? B { get; set; }

        public Rectangle() { } 

    public void Perimetr()
        {
            if (A == null || B == null)
            {
                Console.WriteLine("Точки не встановлені.");
                return;
            }
            int line1 = Math.Abs(B.X-A.X);
            int line2 = Math.Abs(B.Y-A.Y);
            int p = (line1 + line2) *2;
            Console.WriteLine($"Периметр прямокутника = {p}");
        }

    public void Area()
        {
            if (A == null || B == null)
            {
                Console.WriteLine("Точки не встановлені.");
                return;
            }
            int line1 = Math.Abs(B.X - A.X);
            int line2 = Math.Abs(B.Y - A.Y);
            int s = line1 * line2 ;
            Console.WriteLine($"Площа прямокутника = {s}");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            Dot dot1 = new Dot(3, 5);
            Dot dot2 = new Dot(15, 18   );
            Rectangle rectangle = new Rectangle();
            rectangle.A = dot1;
            rectangle.B = dot2;

            rectangle.Perimetr();
            rectangle.Area();

            Console.WriteLine("I'm, here!");
        }
    }
}
