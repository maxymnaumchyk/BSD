using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using MazeGrid;
using MazeCell;
using MazeDistances;
using MazeColorExtensions;

namespace MazeColoredGrid
{
    public class ColoredGrid : Grid
    {
        private Distances _distances;
        private Cell _farthest;
        private int _maximum;

        public ColoredGrid(int rows, int cols) : base(rows, cols)
        {
            BackColor = Color.Green;
        }

        public Color BackColor { get; set; }

        public Distances Distances
        {
            get => _distances;
            set
            {
                _distances = value;
                (_farthest, _maximum) = value.Max;
            }
        }

        protected override Color? BackgroundColorFor(Cell cell)
        {
            if (Distances == null || Distances[cell] < 0)
            {
                return null;
            }
            var distance = Distances[cell];
            var intensity = (_maximum - distance) / (float)_maximum;

            return BackColor.Scale(intensity);
        }
    }
}
