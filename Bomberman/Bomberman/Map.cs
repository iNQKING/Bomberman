using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Map
    {
        const int height = 40;      //Rozmiar
        const int width =80;
        private char[,] arrayMap;

        public Map()
        {
            arrayMap = new char[height, width];

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    arrayMap[i, j] = ' ';       //Pusty znak
        }

        public char[,] ArrayMap
        {
            get { return this.arrayMap; }
        }
    }
}
