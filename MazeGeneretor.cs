using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGeneratorCell
{
    public int X;
    public int Y, Delta;

    public bool WallLeft = true, WallBottom = true, Visited = false;
    
}

public class MazeGenerator {
    public int Width = 27;
    public int Height = 13;

    public MazeGeneratorCell[,] GenerateMaze()
    {
        MazeGeneratorCell[,] maze = new MazeGeneratorCell[Width, Height];
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y] = new MazeGeneratorCell {X = x, Y = y};
            }
        }

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            maze[x, Height - 1].WallLeft = false;
        }

        for (int y = 0; y < maze.GetLength(1); y++)
        {
            maze[Width - 1, y].WallBottom = false;
        }

        RemoveWallWithBacktracking(maze);

        PlaceMazeExit(maze);
        return maze;
    }

    private void PlaceMazeExit(MazeGeneratorCell[,] maze)
    {
        MazeGeneratorCell futher = maze[0,0];
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            if (maze[x, Height - 2].Delta > futher.Delta) futher = maze[x, Height - 2];
            if (maze[x, 0].Delta > futher.Delta) futher = maze[x, 0];
        }

        for (int y = 0; y < maze.GetLength(1); y++)
        {
            if (maze[Width - 2, y].Delta > futher.Delta) futher = maze[Width - 2, y];
            if (maze[0, y].Delta > futher.Delta) futher = maze[0, y];
        }

        if (futher.X == 0) futher.WallLeft = false;
        else if (futher.Y == 0) futher.WallBottom = false;
        else if (futher.X == Width - 2) maze[futher.X + 1, futher.Y].WallLeft = false;
        else if (futher.Y == Height - 2) maze[futher.X, futher.Y + 1].WallBottom = false;
        
    }


    private void RemoveWallWithBacktracking(MazeGeneratorCell[,] maze)
    {
        MazeGeneratorCell current = maze[0, 0];
        current.Visited = true;
        current.Delta = 0;
        Stack<MazeGeneratorCell> stack = new Stack<MazeGeneratorCell>();
        do
        {
            int x = current.X;
            int y = current.Y;
            List<MazeGeneratorCell> unvisitedNeighbours = new List<MazeGeneratorCell>();
            if (x > 0 && !maze[x - 1, y].Visited)
                unvisitedNeighbours.Add(maze[x - 1, y]);
            if (x < Width - 2 && !maze[x + 1, y].Visited)
                unvisitedNeighbours.Add(maze[x + 1, y]);
            if (y > 0 && !maze[x, y - 1].Visited)
                unvisitedNeighbours.Add(maze[x, y - 1]);
            if (y < Height - 2 && !maze[x, y + 1].Visited)
                unvisitedNeighbours.Add(maze[x, y + 1]);


            if (unvisitedNeighbours.Count > 0)
            {
                MazeGeneratorCell chosen = unvisitedNeighbours[Random.Range(0, unvisitedNeighbours.Count)];
                RemoveWall(current,chosen);
                
                chosen.Visited = true;
                stack.Push(chosen);
                current = chosen;
                chosen.Delta = stack.Count;
            }
            else
            {
                current = stack.Pop();
            }
        } while (stack.Count > 0);
    }

    private void RemoveWall(MazeGeneratorCell a, MazeGeneratorCell b)
    {
        if (a.X == b.X)
        {
            if (a.Y > b.Y) a.WallBottom = false;
            else b.WallBottom = false;
        }
        else
        {
            if (a.X > b.X) a.WallLeft = false;
            else b.WallLeft = false;
        }
    }
}
