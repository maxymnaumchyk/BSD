using System;

namespace BOT
{
    public abstract class Bot
    {
        protected int x, y;
        protected bool wallbottom = false, wallright = false, wallleft = false, wallup = false;
        protected void Movement(string name, string vector)
        {
            Console.Write("Moving " + name + $"\t from:({x},{y})");
            switch (vector)
            {
                case "right":
                    if(!wallright) x++;
                    break;
                case "left":
                    if(!wallleft) x--;
                    break;
                case "up":
                    if(!wallup) y++;
                    break;
                case "down":
                    if(!wallbottom) y--;
                    break;
            }
            Console.WriteLine($"  to:({x},{y})");
        }

    }
}