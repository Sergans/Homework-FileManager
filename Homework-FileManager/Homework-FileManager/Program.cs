using System;
using System.IO;

namespace Homework_FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string com;

            Command command = new Command();
            Console.WriteLine("Программа файловый менеджер\nНажмите: (Y) - загрузить сохраненный вариант,(Любую клавишу)-Продолжить");
            string entarance = Console.ReadLine();
            Console.Clear();
            //Command command = new Command(@"C:\Users\GANS\Desktop\Catalog");//Пробный каталог
            while (command.exit)
            {

                Console.WriteLine($"Путь:{command.put}");
                Console.WriteLine("Введите команду");
                com = Console.ReadLine();
                Console.Clear();
                command.Comand(command.ParseComand(com));
            }
        }
    }
}
