using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameDIGDIG
{
    static class Randomizer
    {
        static public void Init()
        {
            myRandomizer = new Random();
        }

        static public int GetRandom(int aMinValue, int aMaxValue)
        {
            return myRandomizer.Next(aMinValue, aMaxValue);
        }

        static public int GetRandom(int aMaxValue)
        {
            return myRandomizer.Next(aMaxValue);
        }

        static Random myRandomizer;
    }
}
