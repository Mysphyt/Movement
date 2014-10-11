using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movement
{
    class ReadFile
    {
        string[] lines;
        char[,] level = new char[5, 6];
        int x, y;
        public void Read(int lvl)
        {
            if (lvl == 1)
            {
                lines = System.IO.File.ReadAllLines(@"C:\Users\Aaron\Desktop\CS Projects\Movement\Movement\Level1.txt");
            }
        }

        public char[,] SetPosArray()
        {
            for (x = 0; x < 5; x++)
            {
                for (y = 0; y < 6; y++)
                {
                    
                        level[x, y] = lines[x][y];
                   
                }
            }

                return level;
        }
    }
}
