using System;
using System.IO;
using System.Threading;
 
namespace BOT
{
    class AI
    {
        public Robot Robot;
        public Maze Maze;
        public Robot2 Robot2;
        public Robot3 Robot3;
        
        public bool MakeStep()
        {
            //достигли выхода?
            if (Maze[Robot.Location] == Cell.Exit) return false;
            
            //получаем значение ячейки слева
            var left2 = Maze[Robot.Location + Robot.Direction.Rotate(1)];
            //если слева нет стены - поворачиваем налево
            if (left2 != Cell.Wall)
                Robot.Direction = Robot.Direction.Rotate(1);
            else
                //пока впереди есть стена - поворачиваем направо
                while (Maze[Robot.Location + Robot.Direction] == Cell.Wall)
                    Robot.Direction = Robot.Direction.Rotate(-1);
            //идем вперед
            Robot.GoForward();
            return true;
        
        }
        
        public bool MakeStep3()
        {
            //достигли выхода?
            if (Maze[Robot3.Location] == Cell.Exit) return false;
            
            //получаем значение ячейки слева
            var righr3 = Maze[Robot3.Location + Robot3.Direction.Rotate(-1)];
            //если слева нет стены - поворачиваем налево
            if (righr3 != Cell.Wall)
                Robot3.Direction = Robot3.Direction.Rotate(-1);
            else
                //пока впереди есть стена - поворачиваем направо
                while (Maze[Robot3.Location + Robot3.Direction] == Cell.Wall)
                    Robot3.Direction = Robot3.Direction.Rotate(1);
            //идем вперед
            Robot3.GoForward();
            return true;
        
        }
        public bool MakeStep2()
        {
            //достигли выхода?
            if (Maze[Robot2.Location] == Cell.Exit) return false;
            //получаем значение ячейки справа
            var left = Maze[Robot2.Location + Robot2.Direction.Rotate(1)];
            //получаем значение ячейки слева
            var right = Maze[Robot2.Location + Robot2.Direction.Rotate(-1)];
            var center = Maze[Robot2.Location + Robot2.Direction];
            // //если справа нет стены - поворачиваем направо                
            // if (left != Cell.Wall)
            //     Robot2.Direction = Robot2.Direction.Rotate(1); 
            // else if (right != Cell.Wall)
            //     Robot2.Direction = Robot2.Direction.Rotate(-1);
            // else
            //     //пока впереди есть стена - поворачиваем налево
            //
            //tdgnsdil;tkgn
            Random rnd = new Random();
            int value = rnd.Next(1, 3);
            Console.WriteLine(value);

            if (right == Cell.Wall && left == Cell.Wall && center == Cell.Wall)
            {
                Robot2.Direction = Robot2.Direction.Rotate(-1);
                Robot2.Direction = Robot2.Direction.Rotate(-1);
            }
                
            else if (right != Cell.Wall && left != Cell.Wall)
            {
                if (value == 1)
                    Robot2.Direction = Robot2.Direction.Rotate(-1);
                else
                    Robot2.Direction = Robot2.Direction.Rotate(1);
            }
            //dbjknjkgnjn;dgdl
            else if (right != Cell.Wall && center != Cell.Wall)
            {
                if (value == 1)
                    Robot2.Direction = Robot2.Direction.Rotate(-1);
            }
            //jl;t;tnjktgnj;stotdnxjlbk
            else if (center != Cell.Wall && left != Cell.Wall)
            {
                if (value == 1)
                    Robot2.Direction = Robot2.Direction.Rotate(1);
            }
            else if (right != Cell.Wall)
                Robot2.Direction = Robot2.Direction.Rotate(-1);
            else if (left  != Cell.Wall)
                Robot2.Direction = Robot2.Direction.Rotate(1);

            // if (Maze[Robot2.Location + Robot2.Direction] != Cell.Wall)
            //     Robot2.GoForward();
            // else if (right == Cell.Wall) 
            //     Robot2.Direction = Robot2.Direction.Rotate(1);
            // else if (left  == Cell.Wall) 
            //     Robot2.Direction = Robot2.Direction.Rotate(-1);
            // else if (center == Cell.Wall) 
            //     Robot2.Direction = Robot2.Direction.Rotate(-1);
            Robot2.GoForward();

            return true;
        
        }

        public void StartBot(AI ai)
        {
            var a = true;
            var b = true;
            var c = true;
            do
            {
                DrawMaze(ai.Maze, ai.Robot, ai.Robot2, ai.Robot3);
                Thread.Sleep(100);
                a = ai.MakeStep();
                b = ai.MakeStep2();
                c = ai.MakeStep3();
            } while (a || b || c);
        }
        public static void DrawMaze(Maze maze, Robot robot, Robot2 robot2, Robot3 robot3)
        {
            Console.Clear();
            for (int row = 0; row < maze.Height; row++)
            {
                for (int col = 0; col < maze.Width; col++)
                    switch (maze[col, row])
                    {
                        case Cell.Wall: Console.Write('#'); break;
                        case Cell.Exit: Console.Write('E'); break;
                        default: Console.Write(' '); break;
                    }
                Console.WriteLine();
            }
            
            Console.SetCursorPosition(robot.Location.X, robot.Location.Y);
            Console.Write("1");
            Console.SetCursorPosition(robot2.Location.X, robot2.Location.Y);
            Console.Write("2");
            Console.SetCursorPosition(robot3.Location.X, robot3.Location.Y);
            Console.Write("3");
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
    class Robot2
    {
        public Point Location = new Point();
        public Point Direction = new Point() { X = 1, Y = 0};
 
        public void GoForward()
        {
            Location.X += Direction.X;
            Location.Y += Direction.Y;
        }
    }
    class Robot3
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