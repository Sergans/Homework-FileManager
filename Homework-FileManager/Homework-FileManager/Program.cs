using System;
using System.IO;
using System.Text.Json;


namespace Homework_FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string com;

            Command command = new Command();
            //Command command = new Command(@"C:\Users\GANS\Desktop\Catalog");//Пробный каталог
            string json = Path.Combine(Directory.GetCurrentDirectory(), "save.json");
            Console.WriteLine("Программа файловый менеджер\nНажмите: (Y) - загрузить сохраненный вариант,(Любую клавишу)-Продолжить");
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

                Console.WriteLine($"Путь:{command.put}");
                Console.WriteLine("Введите команду");
                com = Console.ReadLine();
                Console.Clear();
                command.Comand(command.ParseComand(com));
                if (command.exit == false)
                {
                    Console.WriteLine("Файл сохранен");
                    string saveProg = JsonSerializer.Serialize(command);

                    File.WriteAllText(json, saveProg);

                }
            }   
        }
    }
}
