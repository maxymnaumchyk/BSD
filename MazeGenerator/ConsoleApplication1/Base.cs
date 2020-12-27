using System;
using System.IO;
using System.Threading;

using BOT;
using MazeCell;
using MazeGrid;
using MazeSidewinder;
using MazeBinaryTree;
using MazeDistancesGrid;
using Cell = BOT.Cell;

namespace DefaultNamespace
{
    class Progarm
    {
        public static void Main(string[] args)
        {
            
            var longestGrid = new DistanceGrid(10, 10);
            // BinaryTree.Maze(longestGrid);
            Sidewinder.Maze(longestGrid);
            var start = longestGrid[0, 0];
            var distances = start.Distances;
            var (newStart, distance) = distances.Max;
            var newDistances = newStart.Distances;
            var (goal, distance2) = newDistances.Max;
            longestGrid.Distances = newDistances.PathTo(goal);

            var output = longestGrid.ToUgly(goal);
            Console.WriteLine(output);
            Console.WriteLine("The exit cell(and the farthest from the start) coordinates: x=" + goal.Column + " y=" + goal.Row);
            Thread.Sleep(10000);

            TextWriter ts = new StreamWriter(@"C:\1.txt");
            ts.Write(output);
            ts.Close();
            var robotas = new Robotas {Location = new Point {X = newStart.Column, Y = newStart.Row}};
            var robot = new Robot {Location = new Point {X = newStart.Column, Y = newStart.Row}};
            var maze = Maze.Load(@"C:\1.txt");
            var ai = new AI {Robotas = robotas, Maze = maze,Robot = robot};
            ai.StartBot(ai);
        }
    }
}