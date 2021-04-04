using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_FileManager
{
    class TextPosition
    {
        int x;
        int y;
        
        public void ComCurs(int x,int y,string text)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.WriteLine(text);
        }
        
    }
}
