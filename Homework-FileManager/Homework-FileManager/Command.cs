﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework_FileManager
{
    class Command
    {
        public string put;
        string nextdir;
        string[] com = { "cd", "atr", "del", "copy" };
        string[] mas;
        string ls = "ls";
        string atr = "atr";
        string del = "del";
        string copy = "copy";
        string cd = "cd";
        string dc = "dc";
        string bc = "bc";
        string YN = "Y";
        string Q = "Q";
        public bool exit;
        int nomberfile;

        public Command(string pu_t)
        {
            put = pu_t;
            exit = true;
            mas = Directory.GetFileSystemEntries(put);

        }
        public string ParseComand(string com)
        {

            string[] b = com.Split('/');
            for (int i = 0; i < this.com.Length; i++)
            {
                if (b[0] == this.com[i])
                {
                    nextdir = b[1];
                    return b[0];

                }
            }
            

            return b[0];

        }

        public string Comand(string com)
        {
            if (com == ls)
            {
                List(mas);

            }
            else if (com == bc)
            {
                DirectoryInfo backdir = new DirectoryInfo(put);
                put = Convert.ToString(backdir.Parent);
                mas = Directory.GetFileSystemEntries(put);

            }
            else if (com == dc)
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
                }
                else
                {
                    InfoFile(nextput);
                }

                //InfoFile(nextput);

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
            else if (com == cd)
            {
                List(mas);

                string nextput = Path.Combine(put, nextdir);
                put = nextput;
                mas = Directory.GetFileSystemEntries(put);
                Console.Clear();
                List(mas);
            }
            else if (com == Q)
            {
                Exit();
            }

            else
            {
                Console.WriteLine("Некорректная команда!!!\nДля перехода в меню ввода нажмите любую клавишу");
            }
            return put;
        }

        public void List(string[] sp)
        {

            for (int i = 0; i < sp.Length; i++)
            {
                Console.WriteLine($"{i}: {Path.GetFileName(sp[i])}");
            }

        }
        public void InfoFile(string sp)
        {
            FileInfo file = new FileInfo(sp);
            Console.WriteLine($"Имя файла: {file.Name}\nРазмер: {file.Length} Байт\nДата создания: {file.CreationTime}\nДата изменения: {file.LastWriteTime}\nРасширение: {file.Extension}");
        }
        public void InfoDir(string sp)
        {

            DirectoryInfo dir = new DirectoryInfo(sp);
            Console.WriteLine($"Имя Каталога: {dir.Name}\nРазмер:   Байт\nДата создания: {dir.CreationTime}\nДата изменения: {dir.LastWriteTime}");

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