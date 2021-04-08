﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Homework_FileManager
{

    class Command
    {
        public string put { get; set; }
        string nextdir;
        string newdir;
        string[] com = { "nd", "atr", "del", "copy","cd" };
       public string[] mas { get; set; }
        string ls = "ls";
        string atr = "atr";
        string del = "del";
        string copy = "copy";
        string nd = "nd";
        string cd = "cd";
        string rd = "rd";//Root Directory
        string bd = "bd";//Back Directory
        string YN = "Y";//Yes/No
        string Q = "Q";//Exit
        public bool exit = true;
       public int nomberposition = 0;// Позиция вывода дерева каталогоа и файлов
        long sumfile = 0;
        int j = 0;
       

        
        public string ParseComand(string com)
        {

            string[] b = com.Split('/');
            for (int i = 0; i < this.com.Length; i++)
            {
                if (b[0].Trim() == this.com[i])
                {
                    
                    nextdir = b[1].Trim();
                    newdir= b[1].Trim();
                    return b[0].Trim();

                }
            }
            
            return b[0].Trim();

        }

        public string Comand(string com)
        {
            if (com == ls)
            {
                List(mas);
                

            }
            else if (com == bd)
            {
                DirectoryInfo backdir = new DirectoryInfo(put);
                put = Convert.ToString(backdir.Parent);
                mas = Directory.GetFileSystemEntries(put);

            }
            else if (com == rd)
            {
                DirectoryInfo rootdir = new DirectoryInfo(put);
                put = Convert.ToString(rootdir.Root);
                mas = Directory.GetFileSystemEntries(put);
                List(mas);

            }
            else if (com == atr)
            {
                List(mas);
                //Console.WriteLine("Введите номер файла");
                //nomberfile = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                string nextput = Path.Combine(put, nextdir);

                FileAttributes attributes = File.GetAttributes(nextput);
                if (attributes == FileAttributes.Directory)
                {
                    InfoDir(nextput);
                    string[] arrayfileput = Directory.GetFiles(nextput);
                    foreach (string s in arrayfileput)
                    {
                        FileInfo file = new FileInfo(s);
                        sumfile += file.Length;
                    }
                    DirectoryInfo dir = new DirectoryInfo(nextput);

                    Console.WriteLine($"Имя Каталога: {dir.Name}\nРазмер:{sumfile} Байт\nДата создания: {dir.CreationTime}\nДата изменения: {dir.LastWriteTime}");
                }
                else
                {
                    InfoFile(nextput);
                }

            }
            else if (com == del)
            {
                List(mas);
                //Console.WriteLine("Введите номер файла");
                //nomberfile = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine($"Удалить обеъкт и все его содержимое: {nextdir}??? Нажмите Y(Да)/N(Нет)");
                YN = Console.ReadLine();
                if (YN == "Y")
                {
                    Console.Clear();
                    Console.WriteLine($"{nextdir} БЫЛ УДАЛЕН!");
                    string nextput = Path.Combine(put, nextdir);
                    FileAttributes attributes = File.GetAttributes(nextput);
                    if (attributes == FileAttributes.Directory)
                    {
                        DelDir(nextput);
                    }
                    else
                    {
                        DelFile(nextput);
                    }
                    mas = Directory.GetFileSystemEntries(put);
                    List(mas);

                }
            }
            else if (com == copy)
            {
                List(mas);
                //Console.WriteLine("Введите номер файла или каталога для копирования");
                //nomberfile = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                string nextput = Path.Combine(put, nextdir);
                CopyFile(nextput, put);
                mas = Directory.GetFileSystemEntries(put);
                List(mas);

            }
            else if (com == nd)
            {
                List(mas);

                string nextput = Path.Combine(put, nextdir);
                if (Directory.Exists(nextput) == true)
                    put = nextput;
                
                    mas = Directory.GetFileSystemEntries(put);
                    Console.Clear();
                    List(mas);
                
            }
            else if (com == cd)
            {
                if (Directory.Exists(newdir) == true)
                    put = nextdir;
                mas = Directory.GetFileSystemEntries(put);
                Console.Clear();
            }
            else if (com == Q)
            {
                Exit();
            }

            else
            {
                Console.Clear();
                TextPosition textPosition = new TextPosition();
                textPosition.ComCurs(60, 10, "Некорректная команда!!!");
                textPosition.ComCurs(60, 11, "Для перехода в меню ввода нажмите любую клавишу");

                //Console.WriteLine("Некорректная команда!!!\nДля перехода в меню ввода нажмите любую клавишу");
            }
            return put;
        }

        public void List(string[] sp)
        {
            TextPosition textPosition = new TextPosition();

            for (int i = 0; i < sp.Length; i++)
            {
                //Console.WriteLine(Path.GetFileName(sp[i]));
                textPosition.ComCurs(100,i+1,Path.GetFileName(sp[i]));
            }

        }
        public void ListDirectory(string put,int lv=0)
        {
            
            TextPosition textPosition = new TextPosition();
            string[] sp = Directory.GetDirectories(put);
            string[] sp1 = Directory.GetFiles(put);
            string indent = "";
            for (int i = 0; i < lv; i++)
            {
                indent += "  ";
            }
            foreach (string s in sp)
            {
                
                //int i = 1;
                DirectoryInfo dir = new DirectoryInfo(s);
                //Console.WriteLine(indent + "│\n"+indent+"└" + dir.Name);
                textPosition.ComCurs(1, nomberposition++, indent + "│");
                textPosition.ComCurs(1, nomberposition, indent + "└" + dir.Name);
                nomberposition++;
                //if (j < 0)
                //{
                //    j++;
                //    ListDirectory(s, lv + 1);
                //}
                ListDirectory(s, lv + 1);
            }
            //foreach(string file in sp1)
            //{

            //    textPosition.ComCurs(1, nomberposition++, indent + "│");
            //    textPosition.ComCurs(1, nomberposition, indent + "└" + Path.GetFileName(file));
            //    nomberposition++;
            //    //Console.WriteLine(indent + "│\n" + indent + "└" + Path.GetFileName(file));
            //}


        }
        public void InfoFile(string sp)
        {
            FileInfo file = new FileInfo(sp);
            TextPosition add = new TextPosition();
            try
            {
                add.ComCurs(15, 20, $"Имя файла: {file.Name}\nРазмер: {file.Length} Байт\nДата создания: {file.CreationTime}\nДата изменения: {file.LastWriteTime}\nРасширение: {file.Extension}");
                add.ComCurs(15, 21, $"Размер:{file.Length} Байт");
                //Console.WriteLine($"Имя файла: {file.Name}\nРазмер: {file.Length} Байт\nДата создания: {file.CreationTime}\nДата изменения: {file.LastWriteTime}\nРасширение: {file.Extension}");
            }
            catch
            {
                Console.Clear();
                add.ComCurs(15, 20, "Ошибка: Неверный путь или файла не существует");
                //Console.WriteLine("Ошибка: Неверный путь или файла не существует");
            }

        }
        public void InfoDir(string sp)
        {
            //string[] arrayfileput = Directory.GetFiles(sp);
         string[] arraydirput = Directory.GetDirectories(sp);
            //foreach(string s in arrayfileput)
            //{
            //    FileInfo file = new FileInfo(s);
            //    sumfile += file.Length;
            //}
            for (int i = 0; i < arraydirput.Length; i++)
            {
                string[] flput = Directory.GetFiles(arraydirput[i]);
                foreach(string s in flput)
                {
                    FileInfo file = new FileInfo(s);
                    sumfile += file.Length;
                }
                InfoDir(arraydirput[i]);
            }

            //DirectoryInfo dir = new DirectoryInfo(sp);
            //Console.WriteLine($"Имя Каталога: {dir.Name}\nРазмер:{sumfile} Байт\nДата создания: {dir.CreationTime}\nДата изменения: {dir.LastWriteTime}");

        } 
        public void DelFile(string sp)
        {
            FileInfo file = new FileInfo(sp);

            file.Delete();
        }
        public void DelDir(string sp)
        {
            DirectoryInfo dir = new DirectoryInfo(sp);

            dir.Delete(true);
        }

        public void CopyFile(string sp, string put)
        {
            FileInfo file = new FileInfo(sp);
            string newfile = Path.Combine(put, Console.ReadLine());
            file.CopyTo(newfile);
        }
        //public void CopyDir(string sp, string put)
        //{
        //    DirectoryInfo dir = new DirectoryInfo(sp);
        //    string newfile = Path.Combine(put, Console.ReadLine());
        //    dir.(newfile);
        //}
        public void Exit()
        {
            exit = false;
        }
    }
}
