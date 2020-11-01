using System;


namespace OOP
{
    class CreateLab
    {
        protected int xLab, yLab, walls;
        protected int[] start, exit;
        protected void CreateLabirint(int x, int y)
        {
            Console.WriteLine($"Labirint with dimension [{x},{y}] is created!");
        }
    }


    abstract class Bot
    {
        protected int x, y;
        protected int[] position
        {
            get { return position; }
            set
            {
                position[0] = x;
                position[1] = y;
            }
        }
        protected void Movenment(int x2, int y2)
        {
            Console.WriteLine($"Moving from [{x},{y}] to [{x2},{y2}]");
        }
    }


    class Bot1 : Bot
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
