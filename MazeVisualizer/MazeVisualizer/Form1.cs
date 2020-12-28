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
        private Grid _grid;
        private BinaryTree _algorithm;
        public Form1()
        {
            InitializeComponent();
            _grid = new Grid(10, 10);
            pbMaze.Image = _grid.ToImg();
            cbAlgorithm.SelectedIndex = 0;
            _algorithm = new BinaryTree(_grid);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pbMaze;
        }
    }
}
