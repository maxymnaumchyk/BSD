using System;
using System.IO;
using System.Threading;
 
namespace ConsoleApplication205
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Robot's X: ");
            var x = int.Parse(Console.ReadLine());
            Console.Write("Robot's Y: ");
            var y = int.Parse(Console.ReadLine());
 
            var robot = new Robot { Location = new Point { X = x, Y = y } };
            var robotas = new Robotas { Location = new Point { X = x+3, Y = y+2 } };
            var maze = Maze.Load("c:\\1.txt");
            var ai = new AI {Robot = robot, Maze = maze, Robotas = robotas};
            var a = true;
            var b = true;
 
            do
            {   
                DrawMaze(maze, robot, robotas);
                Thread.Sleep(200);
                a = ai.MakeStep();
                b = ai.MakeStepas();
            } while (a || b);
 
            DrawMaze(maze, robot, robotas);
 
            Console.ReadKey();
        }
 
        private static void DrawMaze(Maze maze, Robot robot, Robotas robotas)
        {
            Console.Clear();
            for(int row = 0;row < maze.Height;row++)
            {
                for (int col = 0; col < maze.Width; col++)
                    switch(maze[col, row])
                    {
                        case Cell.Wall: Console.Write('#'); break;
                        case Cell.Exit: Console.Write('E'); break;
                        default: Console.Write(' '); break;
                    }
                Console.WriteLine();
            }
            Console.SetCursorPosition(robot.Location.X, robot.Location.Y);
            Console.Write("*");
            Console.SetCursorPosition(robotas.Location.X, robotas.Location.Y);
            Console.Write("*");
        }
    }
 
    class AI
    {
        public Robot Robot;
        public Maze Maze;
        public Robotas Robotas;
        public bool MakeStep()
        {
            //достигли выхода?
            if (Maze[Robotas.Location] == Cell.Exit) return false;
            //получаем значение ячейки справа
            var left = Maze[Robotas.Location + Robotas.Direction.Rotate(-1)];
            //если справа нет стены - поворачиваем направо                
            if (left != Cell.Wall)
                Robotas.Direction = Robotas.Direction.Rotate(-1);
            else
            //пока впереди есть стена - поворачиваем налево
            while (Maze[Robotas.Location + Robotas.Direction] == Cell.Wall)
                Robotas.Direction = Robotas.Direction.Rotate(1);
            //идем вперед
            Robotas.GoForward();
            return true;

        }
        public bool MakeStepas()
        {
            //достигли выхода?
            if (Maze[Robot.Location] == Cell.Exit) return false;
            
            //получаем значение ячейки слева
            var leftas = Maze[Robot.Location + Robot.Direction.Rotate(1)];
            //если слева нет стены - поворачиваем налево
            if (leftas != Cell.Wall)
                Robot.Direction = Robot.Direction.Rotate(1);
            else
            //пока впереди есть стена - поворачиваем направо
            while (Maze[Robot.Location + Robot.Direction] == Cell.Wall)
                Robot.Direction = Robot.Direction.Rotate(-1);
            //идем вперед
            Robot.GoForward();
            return true;

        }
    }
 
    public class Point
    {
        public int X;
        public int Y;
 
        public Point Rotate(int angle)
        {
            if (angle > 0)
                return new Point() { X = Y, Y = -X };
            else
                return new Point() { X = -Y, Y = X };
        }
 
        public static Point operator +(Point p1, Point p2)
        {
            return new Point {X = p1.X + p2.X, Y = p1.Y + p2.Y};
        }
    }
 
    class Robot
    {
        public Point Location = new Point();
        public Point Direction = new Point() { X = 1, Y = 0};
 
        public void GoForward()
        {
            Location.X += Direction.X;
            Location.Y += Direction.Y;
        }
    }
    class Robotas
    {
        public Point Location = new Point();
        public Point Direction = new Point() { X = 1, Y = 0};
 
        public void GoForward()
        {
            Location.X += Direction.X;
            Location.Y += Direction.Y;
        }
    }
    class Maze
    {
        private Cell[,] Items;
 
        public static Maze Load(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var res = new Maze();
            res.Items = new Cell[lines[0].Length, lines.Length];
 
            for(int row =0;row<lines.Length;row++)
            for(int col =0;col<lines[row].Length;col++)
                res.Items[col, row] = (Cell)byte.Parse(lines[row][col].ToString());
 
            return res;
        }
 
        public Cell this[int col, int row]
        {
            get { return Items[col, row]; }
        }
 
        public Cell this[Point p]
        {
            get { return Items[p.X, p.Y]; }
        }
 
        public int Height{ get { return Items.GetLength(1); } }
        public int Width { get { return Items.GetLength(0); } }
    }
 
    enum Cell : byte
    {
        Empty   = 0,
        Wall    = 1,
        Exit    = 2
    }
}