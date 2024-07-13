using System;
using System.IO;
using System.Linq;

namespace ForJoinScripts
{
    class Program
    {
        static void Main(string[] args)
        {
            string originPath = @"C:\Users\Udenar\Documents\AFACs_tools\source";
            DirectoryInfo originDirectory = new DirectoryInfo(originPath);

            string towardPath = @"C:\Users\Udenar\Documents\AFACs_tools\combined\join_scripts.sql";
            FileInfo towardFile = new FileInfo(towardPath);
            if (!towardFile.Exists)
            {
                towardFile.Create();
            }

            var directories = originDirectory.GetDirectories();
            var directorios = Directory.GetDirectories(originPath);
            int contador = 0;
            using (StreamWriter writer = new StreamWriter(towardPath, append: true))
            { 
                foreach (var item in directories.OrderBy(x => x.Name))
                {
                    DirectoryInfo insideDirectory = new DirectoryInfo(item.FullName);
                    var insideDirectories = insideDirectory.GetFiles();
                    foreach(var iItem in insideDirectories)
                    {
                        FileInfo insideFile = new FileInfo(iItem.FullName);
                        Console.WriteLine(item.FullName);
                        using (StreamReader reader = insideFile.OpenText())
                        {
                            string fileContent = reader.ReadToEnd();
                            writer.WriteLine(fileContent);
                            writer.WriteLine();
                        }
                    }
                }            
            }

            using (StreamReader reader = towardFile.OpenText())
            {
                string fileContent = reader.ReadToEnd();
                Console.WriteLine(fileContent);
            }
            Console.WriteLine($"Continuar ({contador}):");
            var respuesta = Console.ReadLine();


        }
    }
}
