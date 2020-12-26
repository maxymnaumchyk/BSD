using System;
using BOTS;
using MAZE;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] shift = {"left", "right", "up", "down"};
            var Bot1 = new Alpha(0,0);
            Bot1.AlgoSolve(shift[1]);
            var Bot2 = new Beta(9,4);
            Bot2.AlgoSolve(shift[3]);
            Bot2.AlgoSolve(shift[1]);
            var Bot3 = new Gamma(4,6);
            Bot3.AlgoSolve(shift[2]);
        }
    }
}
