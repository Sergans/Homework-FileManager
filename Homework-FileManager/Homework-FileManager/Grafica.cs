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
        public void Ugol(int x,int y,char ugol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ugol);
        }
        public void Paint(int xu,int yu,int dlin,int vis)
        {
            //Ugol(xu,yu,ugUL);
             HorizLine(xu,yu,dlin);
            
            // VerticLine(xu-1, yu+1, vis);
            
           // HorizLine(xu, vis, dlin);
             
           // VerticLine(dlin, yu, vis);
            //Ugol(dlin+1, yu, ugUR);
            // VerticLine(dlin+1, yu + 1,vis);
            //Ugol(xu, vis+1, ugLL);
            // HorizLine(xu + 1, vis+1,dlin);
            //Ugol(dlin+1, vis+1, ugLR);
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
