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
                
                win.Paint();
                textPosition.ComCurs(0, Console.BufferHeight - 5, $"Путь:{command.put}");
                textPosition.ComCurs(0, Console.BufferHeight - 4, "Введите команду");
                //Console.WriteLine($"Путь:{command.put}");
                //Console.WriteLine("Введите команду");
                //textPosition.ComCurs(0, 0, com = Console.ReadLine());
                com = Console.ReadLine();
                Console.Clear();
                command.Comand(command.ParseComand(com));
                if (command.exit == false)
                {
                    textPosition.ComCurs(20, 15, "Файл сохранен");
                    //Console.WriteLine("Файл сохранен");
                    string saveProg = JsonSerializer.Serialize(command);

                    File.WriteAllText(json, saveProg);

                }
            }   
        }
    }
}
