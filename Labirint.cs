using System;
using System.Collections.Generic;
using System.Text;

namespace Labirint
{
    public class LabirintCell
    {
        public int sizeX, sizeY;
        public bool WallLeft, WallBottom;
    }
    class Labirint
    {
        public int Width = 20, Height = 30;
        public LabirintCell[,] GenerateMaze()
        {
            LabirintCell[,] maze = new LabirintCell[Width, Height];
            //creating labirint
            //.     .       .

            return maze;
        }
    }
}
