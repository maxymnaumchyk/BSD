using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using MazeCell;
using MazeGrid;
using MazeDistances;
using MazeDistancesGrid;
using MazeBinaryTree;

namespace MazeProgram
{
    public static class IntExtensions
    {
        public static string ToBase36(this int i)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
            return chars[i % 36].ToString();
        }

        public static string ToBase64(this int i)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ%=";
            return chars[i % 64].ToString();
        }
    }

    //Randomly select an element from a List<T> 
    public static class ListExtensions
    {
        public static T Sample<T>(this List<T> list, Random rand = null)
        {
            if (rand == null)
            {
                rand = new Random();
            }
            return list[rand.Next(list.Count)];
        }
    }

    class TestClass
    {
        internal static void Main()
        {
            /*Grid test = new Grid(10, 10);
            test = BinaryTree.Maze(test);
            var output = test.ToString();
            Console.WriteLine(output);*/


            var distGrid = new DistanceGrid(10, 10);
            BinaryTree.Maze(distGrid);
            var start = distGrid[0, 0];
            var distances = start.Distances;
            distGrid.Distances = distances;
            Console.WriteLine(distGrid);

            /*var longestGrid = new DistanceGrid(10, 10);
            BinaryTree.Maze(longestGrid);
            var start = longestGrid[0, 0];
            var distances = start.Distances;
            var (newStart, distance) = distances.Max;
            var newDistances = newStart.Distances;
            var (goal, distance2) = newDistances.Max;
            longestGrid.Distances = newDistances.PathTo(goal);
            Console.WriteLine(longestGrid);
            Console.WriteLine("The exit cell(and the farthest from the start) coordinates: x=" + goal.Column + " y=" + goal.Row);*/
        }
    }
}