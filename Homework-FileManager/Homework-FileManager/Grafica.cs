using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_FileManager
{
    class Grafica
    {
        char gorizont = '─';
        char vertical = '│';
        char ugUL = '┌';
        char ugLL = '└';
        char ugUR = '┐';
        char ugLR = '┘';
        public void Ugol(int x,int y, char ugol)
        {
            
            Console.SetCursorPosition(x, y);
            Console.Write(ugol);
        }
        public void Paint()
        {
            Ugol(0,0,ugUL);
            Ugol(0, Console.BufferHeight-1, ugLL);
            Ugol(Console.BufferWidth - 1, 0, ugUR);
            Ugol(Console.BufferWidth - 1, Console.BufferHeight - 1, ugLR);
            HorizLine(1, Console.BufferHeight - 4, Console.BufferWidth - 2);
            HorizLine(1, Console.BufferHeight - 10, Console.BufferWidth - 2);
            HorizLine(1, Console.BufferHeight - 1, Console.BufferWidth - 2);
            HorizLine(1, 0, Console.BufferWidth - 2);
            VerticLine(0, 1, Console.BufferHeight - 2);
            VerticLine(Console.BufferWidth - 1, 1, Console.BufferHeight - 2);

             
        }

        public void HorizLine(int x,int y,int dlin)
        {
            for (int i = 0; i < dlin; i++)
            {
                Console.SetCursorPosition(x+i,y);
                Console.Write(gorizont);
            }
            
        }
        public void VerticLine(int x, int y,int dlin)
        {
            for (int i = 0; i < dlin; i++)
            {
                Console.SetCursorPosition(x, y+i);
                Console.WriteLine(vertical);
            }

        }
    }
}
