using System;
using System.IO;
using System.Text.Json;


namespace Homework_FileManager
{
    class Program
    {
        Command command = new Command();
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
            Command command = new Command();
            string com;
            string instruction = "(rd)-переход в корневую папку,(bd)-переход на уровень назад,(cd)-переход в следующую папку текущего каталога(cd/Имя папки)";
            string json = Path.Combine(Directory.GetCurrentDirectory(), "save.json");
            string textenter = "Нажмите: (Y) - загрузить сохраненный вариант,(Любую клавишу)-Продолжить";
            //Command command = new Command(@"C:\Users\GANS\Desktop\Catalog");//Пробный каталог

            win.Paint();
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
                command.put1 = command.put;

            }
            else
            command.put = Directory.GetCurrentDirectory();
            command.mas = Directory.GetFileSystemEntries(command.put);
            command.put1 = command.put;
            while (command.exit)
            {
                command.nomberposition = 4;
                win.Paint();
                win.VerticLine(60, 3, Console.BufferHeight - 13);
                textPosition.ComCurs(1, Console.BufferHeight - 9, instruction);
                textPosition.ComCurs(1, 3, Path.GetFileName(command.put));
               // command.ListDirectory(command.put);
                command.List(command.mas);
                textPosition.ComCurs(1, Console.BufferHeight - 3, $"Путь:{command.put1}");
                textPosition.ComCurs(1, 1, $"Путь:{command.put1}");
                textPosition.ComCurs(1, Console.BufferHeight - 2, "Введите команду/");

                com = Console.ReadLine();
                Console.Clear();
                command.Comand(command.ParseComand(com));
                if (command.exit == false)
                {
                    string textout = "Состояние программы сохранено";
                    win.Paint();
                    textPosition.ComCurs(60, 15, textout);
                    win.HorizLine(60, 16, textout.Length);
                    string saveProg = JsonSerializer.Serialize(command);
                    File.WriteAllText(json, saveProg);

                }
            }
        }
        

    }
     
}
