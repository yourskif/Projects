using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Shell32;

namespace FileManager
{
    class Program
    {
        public static void F(string nn)
        {
            string[] mas = Directory.GetDirectories(nn);
            foreach (string n in mas)
            {
                Console.WriteLine(n);
                F(n);
            }
        }
        public static int Main()
        {
            string s;
            string dirs, maskf;
            char q = ' ';
            while (q != 'q')
            {
                Console.WriteLine();
                Console.WriteLine("----- File Manager -----");
                Console.WriteLine("1)Choise disk");
                Console.WriteLine("2)View (directory,files)");
                Console.WriteLine("3)Create (directory,files)");
                Console.WriteLine("4)Write dates");
                Console.WriteLine("5)Read dates");
                Console.WriteLine("6)Add dates");
                Console.WriteLine("7)Move directory");
                Console.WriteLine("8)Move file");
                Console.WriteLine("9)Delete directory");
                Console.WriteLine("10)Delete file");
                Console.WriteLine("q-Quit");
                s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        GetLogicalDrives();
                        break;
                    case "2":
                        Console.WriteLine("1-view directory,2-view files");
                        string v2 = Console.ReadLine();
                        switch (v2)
                        {
                            case "1":
                                Console.WriteLine("View directory:");
                                //Shell shell = new Shell();
                                //Folder folder = shell.BrowseForFolder(0, "Choice folder...", 0, ShellSpecialFolderConstants.ssfDESKTOP);
                                //if (folder != null)
                                //{
                                //    foreach (FolderItem fi in folder.Items())
                                //    {
                                //        Console.WriteLine("fi.Name= {0}", fi.Name);
                                //    }
                                //}
                                Console.WriteLine("Input path of directory:");
                                //string dirs = Console.ReadLine();
                                dirs = Console.ReadLine();
                                F(dirs);
                                break;
                            case "2":

                                Console.WriteLine("View fieles:");
                                Console.WriteLine("Input path and mask of fieles:");
                                try
                                {
                                    string[] dirsf = Directory.GetFiles(Console.ReadLine(), Console.ReadLine());
                                    Console.WriteLine("All fieles{0}", dirsf.Length);
                                    foreach (string mas in dirsf)
                                    {
                                        Console.WriteLine("{0}", mas);
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Mistake: {0}", e.ToString());
                                }
                                break;
                        }
                        break;

                    case "3":
                        Console.WriteLine("1-create directory,2-create files");
                        string v3 = Console.ReadLine();
                        switch (v3)
                        {
                            case "1":
                                Console.WriteLine("input path of directory:");
                                string path = Console.ReadLine();
                                DirectoryInfo dirinfo = new DirectoryInfo(path);
                                dirinfo.Create();
                                break;
                            case "2":
                                Console.WriteLine("Create fieles:");
                                try
                                {
                                    Console.WriteLine("Input name of file: ");
                                    string fi = Console.ReadLine();
                                 //   FileStream f = new FileStream(fi, FileMode.Create);
                                 //   StreamWriter sr = File.CreateText(fi);
                                    StreamWriter sw = new StreamWriter(fi,false,System.Text.Encoding.GetEncoding(1251));
                                    sw.Close();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Mistake: {0}", e.ToString());
                                }
                                break;
                        }
                        break;
                    case "4":
                        Console.WriteLine("Write in file:");
                        Console.WriteLine("Input name of file: ");
                        string fiw = Console.ReadLine();
                        FileStream fs = new FileStream(fiw, FileMode.Open, FileAccess.Write);
                        StreamWriter srw = new StreamWriter(fs);
                        string text;
                        text = Console.ReadLine();
                        srw.WriteLine(text);
                        srw.Close();
                        break;
                    case "5":
                        Console.WriteLine("Read file:");
                                    Console.WriteLine("Input name of file: ");
                                    string fir = Console.ReadLine();
                                    FileStream fsr = new FileStream(fir, FileMode.Open, FileAccess.Read);
                                    StreamReader srr = new StreamReader(fsr);
                                    string curLine;
                                    while ((curLine = srr.ReadLine()) != null)
                                        Console.WriteLine(curLine);
                                    srr.Close();
                        break;
                    case "6":
                        Console.WriteLine("Add file:");
                        Console.WriteLine("Input name of file: ");
                        string fira = Console.ReadLine();
                        FileStream fsra = new FileStream(fira, FileMode.Append, FileAccess.Write);
                        StreamWriter srwa = new StreamWriter(fsra);
                        string texta;
                        texta = Console.ReadLine();
                        srwa.WriteLine(texta);
                        srwa.Close();
                        break;
                    case "7":
                        Console.WriteLine("Move directory:");
                        Console.WriteLine("Input name of Directory: ");
                        string firad = Console.ReadLine();
                        Console.WriteLine("Input NewDirectory: ");
                        string NewDirectory = Console.ReadLine();
                        DirectoryInfo dirinfod = new DirectoryInfo(firad);
                        //DirectoryInfo dirinfod = new DirectoryInfo(NewDirectory);
                        dirinfod.MoveTo(NewDirectory);
                        break;
                    case "8":
                        Console.WriteLine("Move file:");
                        Console.WriteLine("Input name of file: ");
                        string firaf = Console.ReadLine();
                        Console.WriteLine("Input NewFileName: ");
                        string NewFileName = Console.ReadLine();
                        FileInfo filef=new FileInfo(firaf);
                        filef.MoveTo(NewFileName);
                        break;
                    case "9":
                        Console.WriteLine("Delete directory:");
                        Console.WriteLine("Input Directory: ");
                        string NewDir = Console.ReadLine();
                        DirectoryInfo dirinfodeld = new DirectoryInfo(NewDir);
                        dirinfodeld.Delete();
                        break;
                    case "10":
                        Console.WriteLine("Delete file:");
                        Console.WriteLine("Input name of file: ");
                        string delf = Console.ReadLine();
                        FileInfo filedelf = new FileInfo(delf);
                        filedelf.Delete();
                        break;
                    case "q":
                        return 1;
                        break;
                }

            }   // q


            return 0;
        }
        static void GetLogicalDrives()
        {
            try
            {
                string[] drives = Directory.GetLogicalDrives();
                foreach (string driver in drives)
                {
                    System.Console.WriteLine(driver);
                }
            }
            catch (System.IO.IOException)
            {
                System.Console.WriteLine("I/O error");
            }
            catch (System.Security.SecurityException)
            {
                System.Console.WriteLine("don't enough rights");
            }
        }

    }
}

