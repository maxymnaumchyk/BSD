using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Drawing;


namespace BOT
{
    class AI
    {
        public Robot Robot, Robot2, Robot3;
        public Maze Maze;
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
            else if (left != Cell.Wall)
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

        // public bool MakeStep4()
        // {
        //     if (Maze[Robot4.Location] == Cell.Exit) return false;
        //     Stack<PointBot> stack = new Stack<PointBot>();
        //     List<PointBot> unvisitedNeighbours = new List<PointBot>();
        //
        //     var left = Maze[Robot4.Location + Robot4.Direction.Rotate(1)];
        //     var right = Maze[Robot4.Location + Robot4.Direction.Rotate(-1)];
        //     var center = Maze[Robot4.Location + Robot4.Direction];
        //     if (left != Cell.Wall && !(Robot4.Location + Robot4.Direction.Rotate(1)).Visited) unvisitedNeighbours.Add(Robot4.Location + Robot4.Direction.Rotate(1));
        //     if (right != Cell.Wall && !(Robot4.Location + Robot4.Direction.Rotate(-1)).Visited) unvisitedNeighbours.Add(Robot4.Location + Robot4.Direction.Rotate(-1));
        //     if (center != Cell.Wall && !(Robot4.Location + Robot4.Direction).Visited) unvisitedNeighbours.Add(Robot4.Location + Robot4.Direction);
        //     Robot4.Location.Visited = true;
        //     if (right == Cell.Wall && left == Cell.Wall && center == Cell.Wall)
        //     {
        //         Robot4.Direction = Robot4.Direction.Rotate(-1);
        //         Robot4.Direction = Robot4.Direction.Rotate(-1);
        //     }
        //
        //     if (!(Robot4.Location + Robot4.Direction).Visited||(left != Cell.Wall && !(Robot4.Location + Robot4.Direction.Rotate(1)).Visited ) )
        //     {
        //         Random rnd = new Random();
        //         int value = rnd.Next(1, 3);
        //         stack.Push(Robot4.Location);
        //
        //         if (right != Cell.Wall && left != Cell.Wall)
        //         {
        //             if (value == 1 && !(Robot4.Location + Robot4.Direction.Rotate(-1)).Visited)
        //                 Robot4.Direction = Robot4.Direction.Rotate(-1);
        //             else if (value == 2 && !(Robot4.Location + Robot4.Direction.Rotate(1)).Visited)
        //                 Robot4.Direction = Robot4.Direction.Rotate(1);
        //         }
        //         //dbjknjkgnjn;dgdl
        //         else if (right != Cell.Wall && center != Cell.Wall)
        //         {
        //             if (value == 1 && !(Robot4.Location + Robot4.Direction.Rotate(-1)).Visited)
        //                 Robot4.Direction = Robot4.Direction.Rotate(-1);
        //         }
        //         //jl;t;tnjktgnj;stotdnxjlbk
        //         else if (center != Cell.Wall && left != Cell.Wall)
        //         {
        //             if (value == 1 && !(Robot4.Location + Robot4.Direction.Rotate(1)).Visited)
        //                 Robot4.Direction = Robot4.Direction.Rotate(1);
        //         }
        //         else if (right != Cell.Wall && !(Robot4.Location + Robot4.Direction.Rotate(-1)).Visited)
        //             Robot4.Direction = Robot4.Direction.Rotate(-1);
        //         else if (left != Cell.Wall && !(Robot4.Location + Robot4.Direction.Rotate(1)).Visited)
        //             Robot4.Direction = Robot4.Direction.Rotate(1);
        //
        //         stack.Push(Robot4.Location);
        //         Robot4.GoForward();
        //     }
        //     else 
        //         Robot4.Location = stack.Pop();
        //     return true;
        // }

        public void StartBot(AI ai)
        {
            var a = true;
            var b = true;
            var c = true;
            do
            {
                //DrawMaze(ai.Maze, ai.Robot, ai.Robot2, ai.Robot3);
                //Thread.Sleep(100);
                a = ai.MakeStep();
                b = ai.MakeStep2();
                c = ai.MakeStep3();
            } while (a || b || c);
        }
        public Image ToImg(Maze maze, Robot robot, Robot robot2, Robot robot3, int cellSize = 25)
        {
            var width = cellSize * maze.Width;
            var height = cellSize * maze.Height;

            var img = new Bitmap(width, height);
            using (var g = Graphics.FromImage(img))
            {
                g.Clear(Color.White);
                for (int row = 0; row < maze.Height; row++)
                {
                    for (int col = 0; col < maze.Width; col++)
                    {
                        var x1 = col * cellSize;
                        var y1 = row * cellSize;
                        var cx = col * cellSize + cellSize / 2;
                        var cy = row * cellSize + cellSize / 2;
                        switch (maze[col, row])
                        {
                            case Cell.Wall:
                                var myBruh = new SolidBrush(Color.DarkGray);
                                g.FillRectangle(myBruh, new Rectangle(x1, y1, 25, 25));
                                g.DrawRectangle(Pens.Black, x1, y1, 25, 25);
                                break;
                            case Cell.Exit:
                                g.DrawRectangle(Pens.Black, cx - 2, cy - 2, 10, 10);
                                break;
                            default:
                                break;
                        }
                    }
                }
                g.DrawRectangle(Pens.Green, cellSize * robot.Location.X + cellSize / 2, cellSize * robot.Location.Y + cellSize / 2, 4, 4);
                g.DrawRectangle(Pens.Red, cellSize * robot2.Location.X + cellSize / 2, cellSize * robot2.Location.Y + cellSize / 2, 4, 4);
                g.DrawRectangle(Pens.Blue, cellSize * robot3.Location.X + cellSize / 2, cellSize * robot3.Location.Y + cellSize / 2, 4, 4);
            }
            return img;
        }
        public static void DrawMaze(Maze maze, Robot robot, Robot robot2, Robot robot3)
        {
            Console.Clear();
            for (int row = 0; row < maze.Height; row++)
            {
                for (int col = 0; col < maze.Width; col++)
                    switch (maze[col, row])
                    {
                        case Cell.Wall:
                            Console.Write('#');
                            break;
                        case Cell.Exit:
                            Console.Write('E');
                            break;
                        default:
                            Console.Write(' ');
                            break;
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

    public class PointBot
    {
        public int X;
        public int Y;

        public bool Visited = false;

        public PointBot Rotate(int angle)
        {
            if (angle > 0)
                return new PointBot() {X = Y, Y = -X};
            else
                return new PointBot() {X = -Y, Y = X};
        }

        public static PointBot operator +(PointBot p1, PointBot p2)
        {
            return new PointBot {X = p1.X + p2.X, Y = p1.Y + p2.Y};
        }
    }

    class Robot
    {
        public PointBot Location = new PointBot();
        public PointBot Direction = new PointBot() {X = 1, Y = 0};

        public void GoForward()
        {
            Location.X += Direction.X;
            Location.Y += Direction.Y;
        }
    }

    class Maze
    {
        public Cell[,] Items;

        public static Maze Load(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var res = new Maze();
            res.Items = new Cell[lines[0].Length, lines.Length];

            for (int row = 0; row < lines.Length; row++)
            for (int col = 0; col < lines[row].Length; col++)
                res.Items[col, row] = (Cell) byte.Parse(lines[row][col].ToString());

            return res;
        }

        public Cell this[int col, int row]
        {
            get { return Items[col, row]; }
        }

        public Cell this[PointBot p]
        {
            get { return Items[p.X, p.Y]; }
        }

        public int Height
        {
            get { return Items.GetLength(1); }
        }

        public int Width
        {
            get { return Items.GetLength(0); }
        }
    }

    enum Cell : byte
    {
        Wall = 1,
        Exit = 2
    }
}