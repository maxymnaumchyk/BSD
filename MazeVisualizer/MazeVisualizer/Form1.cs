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

namespace MazeVisualizer
{
    public partial class Form1 : Form
    {
        private BinaryTree _algorithm;
        public Form1()
        {
            InitializeComponent();
            Grid _grid = new Grid(10, 10);
            _grid = BinaryTree.Maze(_grid);
            pB.Image = _grid.ToImg();
        }
    }
}
