using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using MazeGrid;
using MazeDistances;
using MazeCell;

namespace MazeDistancesGrid
{
    public class DistanceGrid : Grid
    {
        public Distances Distances { get; set; }

        public DistanceGrid(int rows, int cols) : base(rows, cols) { }

        protected override string ContentsOf(Cell cell)
        {
            if (Distances != null && Distances[cell] >= 0)
            {
                return Distances[cell].ToBase64();
            }
            return base.ContentsOf(cell);
        }
    }
}
