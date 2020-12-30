using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MazeGrid;
using MazeBinaryTree;
using MazeSidewinder;
using MazeColoredGrid;
using MazeDistancesGrid;

namespace MazeVisualizer
{
    public partial class Form1 : Form
    {
        private BinaryTree _algorithm;
        public Form1()
        {
            InitializeComponent();
            cbAlgorithm.Items.AddRange(new string[] { "BinaryTree", "Sidewinder" });
            Grid _grid = new Grid(10, 10);
            _grid = BinaryTree.Maze(_grid);
            pB.Image = _grid.ToImg();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbAlgorithm.SelectedItem != null)
            {
                Image img = null;
                var grid = new Grid(10, 10);
                if ((string)cbAlgorithm.SelectedItem == "BinaryTree")
                {
                    img = BinaryTree.Maze(grid, (int)numericUpDown1.Value).ToImg();
                }
                else if ((string)cbAlgorithm.SelectedItem == "Sidewinder")
                {
                    img = Sidewinder.Maze(grid, (int)numericUpDown1.Value).ToImg();
                }
                pB.Image = img;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbAlgorithm.SelectedItem != null)
            {
                var colorGrid = new ColoredGrid(10, 10);
                if ((string)cbAlgorithm.SelectedItem == "BinaryTree")
                {
                    BinaryTree.Maze(colorGrid, (int)numericUpDown1.Value);
                }
                else if ((string)cbAlgorithm.SelectedItem == "Sidewinder")
                {
                    Sidewinder.Maze(colorGrid, (int)numericUpDown1.Value);
                }

                var start = colorGrid[0, 0];
                var distances = start.Distances;
                var (newStart, distance) = distances.Max;
                start = newStart;
                distances = start.Distances;
                var (end, distance2) = distances.Max;

                colorGrid.Distances = start.Distances;
                colorGrid.BackColor = pbColor.BackColor;

                pB.Image = colorGrid.ToPng(start,end);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cbAlgorithm.SelectedItem != null)
            {
                var colorGrid = new ColoredGrid(10, 10);
                if ((string)cbAlgorithm.SelectedItem == "BinaryTree")
                {
                    BinaryTree.Maze(colorGrid, (int)numericUpDown1.Value);
                }
                else if ((string)cbAlgorithm.SelectedItem == "Sidewinder")
                {
                    Sidewinder.Maze(colorGrid, (int)numericUpDown1.Value);
                }

                var start = colorGrid[0, 0];
                var distances = start.Distances;
                var (newStart, distance) = distances.Max;
                start = newStart;
                distances = start.Distances;
                var (end, distance2) = distances.Max;

                colorGrid.Distances = start.Distances;
                colorGrid.BackColor = pbColor.BackColor;

                pB.Image = colorGrid.ToPn(start,end);
            }
        }
    }
}
