﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using MazeGrid;
using MazeDistances;


namespace MazeCell
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
    public class Cell
    {
        // Position
        public int Row { get; }
        public int Column { get; }

        // Neighbours
        public Cell North { get; set; }
        public Cell South { get; set; }
        public Cell East { get; set; }
        public Cell West { get; set; }
        public List<Cell> Neighbors
        {
            get { return new[] { North, South, East, West }.Where(c => c != null).ToList(); }
        }

        //Linked cells
        private readonly Dictionary<Cell, bool> _links;
        public List<Cell> Links => _links.Keys.ToList();

        public Cell(int row, int col)
        {
            Row = row;
            Column = col;
            _links = new Dictionary<Cell, bool>();
        }

        //Two cells linking function
        public void Link(Cell cell, bool bidirectional = true)
        {
            _links[cell] = true;
            if (bidirectional)
            {
                cell.Link(this, false);
            }
        }

        //Two cells unlinking function
        public void Unlink(Cell cell, bool bidirectional = true)
        {
            _links.Remove(cell);
            if (bidirectional)
            {
                cell.Unlink(this, false);
            }
        }

        public bool IsLinked(Cell cell)
        {
            if (cell == null)
            {
                return false;
            }
            return _links.ContainsKey(cell);
        }

        //Dijkstra's pathfinding algorithm
        public Distances Distances
        {
            get
            {
                var distances = new Distances(this);
                var frontier = new HashSet<Cell> {
                this
            };

                while (frontier.Any())
                {
                    var newFrontier = new HashSet<Cell>();

                    foreach (var cell in frontier)
                    {
                        foreach (var linked in cell.Links)
                        {
                            if (distances[linked] >= 0)
                            {
                                continue;
                            }
                            distances[linked] = distances[cell] + 1;
                            newFrontier.Add(linked);
                        }
                    }
                    frontier = newFrontier;
                }
                return distances;
            }
        }
    }
}
