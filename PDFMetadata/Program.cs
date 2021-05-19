// TODO: Allows users to change file name

using System;

namespace PDFMetadata
{
    internal class Program
    {
        private static void Main()
        {
            var document = InstantiateDocument();
            
            DrawTitle();

            document.PrintMetadata("ORIGINAL: ");
            DrawSeparator();

            document.Title = ReadInput("TITLE: ", $"{document.Title} (leave blank to keep) -> ");
            DrawSeparator();

            document.Author = ReadInput("AUTHOR: ", $"{document.Author} (leave blank to keep) -> ");
            DrawSeparator();

            document.SaveMetadata();

            document.PrintMetadata("NEW: ");

            DrawSeparator();
            Console.Write("Press any key to exit...");
            Console.ReadKey();
        }

        private static void DrawTitle()
        {
            Console.WriteLine(@"
██████╗ ██████╗ ███████╗    ███╗   ███╗███████╗████████╗ █████╗ ██████╗  █████╗ ████████╗ █████╗ 
██╔══██╗██╔══██╗██╔════╝    ████╗ ████║██╔════╝╚══██╔══╝██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗
██████╔╝██║  ██║█████╗      ██╔████╔██║█████╗     ██║   ███████║██║  ██║███████║   ██║   ███████║
██╔═══╝ ██║  ██║██╔══╝      ██║╚██╔╝██║██╔══╝     ██║   ██╔══██║██║  ██║██╔══██║   ██║   ██╔══██║
██║     ██████╔╝██║         ██║ ╚═╝ ██║███████╗   ██║   ██║  ██║██████╔╝██║  ██║   ██║   ██║  ██║
╚═╝     ╚═════╝ ╚═╝         ╚═╝     ╚═╝╚══════╝   ╚═╝   ╚═╝  ╚═╝╚═════╝ ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝
");
        }

        private static Document InstantiateDocument()
        {
            string filePath;
            Document document;
            
            while (true)
            {
                
                try
                {
                    filePath = ReadInput("FILE PATH: ", "Enter file path: ");
                    document = new Document(filePath);
                    break;
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
            
            Console.Clear();

            return document;
        }

        private static void DrawSeparator()
        {
            Console.WriteLine("-------------------------------");
        }

        private static string ReadInput(string prompt, string description)
        {
            Console.Write($"\x1b[1m{prompt}\x1b[0m");
            Console.Write($"{description}");
            var input = Console.ReadLine();

            return input;
        }
    }
}