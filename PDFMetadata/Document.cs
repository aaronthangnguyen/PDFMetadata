using System;
using System.Globalization;
using PdfSharpCore.Pdf.IO;

namespace PDFMetadata
{
    public class Document
    {
        private string _title;
        private string _author;

        public Document(string filePath)
        {
            using (var document = PdfReader.Open(filePath))
            {
                FilePath = filePath;
                Title = !string.IsNullOrWhiteSpace(document.Info.Title) ? document.Info.Title : "N/A";
                Author = !string.IsNullOrWhiteSpace(document.Info.Author) ? document.Info.Author : "N/A";
            }
        }

        public string FilePath { get; }

        public string Title
        {
            get => _title;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
                }
            }
        }

        public string Author
        {
            get => _author;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _author = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
                }
            }
        }

        public void PrintMetadata(string prompt)
        {
            Console.WriteLine($"\x1b[1m{prompt}\x1b[0m");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
        }

        private bool ValidateMetadata()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Author)) isValid = false;

            return isValid;
        }

        public void SaveMetadata()
        {
            // if (ValidateMetadata())
            // {
            //     using (var document = PdfReader.Open(FilePath))
            //     {
            //         document.Info.Author = Author;
            //         document.Info.Title = Title;
            //         document.Save(FilePath);
            //     }
            // }

            using (var document = PdfReader.Open(FilePath))
            {
                document.Info.Author = Author;
                document.Info.Title = Title;
                document.Save(FilePath);
            }
        }
    }
}