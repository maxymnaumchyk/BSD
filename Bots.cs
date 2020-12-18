using System;
using System.Collections.Generic;
using System.Text;
using BOT;
namespace BOTS
{
    class Alpha : Bot
    {
        public Alpha(int X, int Y) { x = X; y = Y; }
        public void AlgoSolve(string shift)
        {
            Movement($"Alpha", shift);
        }
    }

    class Beta : Bot
    {
        public Beta(int X, int Y) { x = X; y = Y; }
        public void AlgoSolve(string shift)
        {
            Movement("Beta", shift);
        }
    }

    class Gamma : Bot
    {
        public Gamma(int X, int Y) { x = X; y = Y; }
        public void AlgoSolve(string shift)
        {
            Movement("Gamma", shift);
        }
    }
}