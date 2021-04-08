using System;
using System.IO;
using System.Text.Json;


namespace Homework_FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Console.BufferWidth);//87
            //Console.WriteLine(Console.BufferHeight);//9001
            //Console.WriteLine(Console.WindowWidth);//87
            //Console.WriteLine(Console.WindowHeight);//32
            //Console.WriteLine(Console.WindowTop);//0
            //Console.WriteLine(Console.WindowLeft);//0
          
           Console.SetBufferSize(150, 40);
           Console.SetWindowSize(150, 40);
           
            
            Grafica win = new Grafica();
            TextPosition textPosition = new TextPosition();
            
            string com;
            string instruction="(rd)-переход в корневую папку,(bd)-переход на уровень назад,(cd)-переход в следующую папку текущего каталога(cd/Имя папки)";
                
            Command command = new Command();
            //Command command = new Command(@"C:\Users\GANS\Desktop\Catalog");//Пробный каталог
            string json = Path.Combine(Directory.GetCurrentDirectory(), "save.json");
            win.Paint();
            // win.HorizLine(1,0,148);
            // win.HorizLine(0, 39, 148);
            //win.VerticLine(0, 1, 39);
            string textenter = "Нажмите: (Y) - загрузить сохраненный вариант,(Любую клавишу)-Продолжить";
            textPosition.ComCurs(50, 15, "Программа файловый менеджер");
            textPosition.ComCurs(35, 16, textenter);
            win.HorizLine(35, 17, textenter.Length);
            Console.SetCursorPosition(65, 18);
            string entarance = Console.ReadLine();
            Console.Clear();

            if (entarance == "Y" && File.Exists(json))
            {
                string load = File.ReadAllText(json);
                command = JsonSerializer.Deserialize<Command>(load);
                
            }
            else
                command.put = Directory.GetCurrentDirectory();
               command.mas = Directory.GetFileSystemEntries(command.put);
            while (command.exit)
            {
                command.nomberposition = 0;
                win.Paint();
                win.VerticLine(70, 1, Console.BufferHeight - 11);
                textPosition.ComCurs(1, Console.BufferHeight - 9, instruction);
                command.ListDirectory(command.put);
                textPosition.ComCurs(1, Console.BufferHeight - 3, $"Путь:{command.put}");
                textPosition.ComCurs(1, Console.BufferHeight - 2, "Введите команду/");
                //Console.WriteLine($"Путь:{command.put}");
                //Console.WriteLine("Введите команду");
                //textPosition.ComCurs(1, Console.BufferHeight - 3, com = Console.ReadLine());
                com = Console.ReadLine();
                Console.Clear();
                command.Comand(command.ParseComand(com));
                if (command.exit == false)
                {
                    string textout = "Состояние программы сохранено";
                    win.Paint();
                    textPosition.ComCurs(60, 15, textout);
                    win.HorizLine(60, 16, textout.Length);

                    //Console.WriteLine("Файл сохранен");
                    string saveProg = JsonSerializer.Serialize(command);

                    File.WriteAllText(json, saveProg);

                }
            }   
        }
    }
}
