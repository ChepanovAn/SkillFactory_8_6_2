using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory_8_6_2
{
    class Program
    {
        static void Main(string[] args)
        {            
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives.Where(d => d.DriveType == DriveType.Fixed))
            {                
                DirectoryInfo root = drive.RootDirectory;

                var folders = root.GetDirectories();

                WriteFileInfo(root);

                WriteFolderInfo(folders);

                Console.WriteLine();

                Console.ReadKey();
            }            
        }

        public static void WriteDriveInfo(DriveInfo drive)
        {
            Console.WriteLine($"Название: {drive.Name}");

            Console.WriteLine($"Тип: {drive.DriveType}");

            if (drive.IsReady)
            {
                Console.WriteLine($"Объем: {drive.TotalSize}");

                Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");

                Console.WriteLine($"Метка: {drive.VolumeLabel}");
            }
        }

        public static void WriteFolderInfo(DirectoryInfo[] folders)
        {
            Console.WriteLine();

            Console.WriteLine("Папки: ");

            Console.WriteLine();

            foreach (var folder in folders)
            {
                try
                {
                    Console.WriteLine(folder.Name + $" - {DirectoryExtension.DirSize(folder)}байт");
                }
                catch (Exception e)
                {

                    Console.WriteLine(folder.Name + $" - Не удалось рассчитать размер: {e.Message}");
                }
            }
        }

        public static void WriteFileInfo(DirectoryInfo rootFolder)
        {
            Console.WriteLine();

            Console.WriteLine("Файлы: ");

            Console.WriteLine();

            foreach (var file in rootFolder.GetFiles())
            {
                Console.WriteLine(file.Name + $" - {file.Length} байт");
            }

         }  
    }
}
