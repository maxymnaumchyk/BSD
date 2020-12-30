using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeUtilities
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
}
