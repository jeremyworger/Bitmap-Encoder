using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Bitmap_Encoder
{
    class Program
    {
        static byte[] header = Encoding.UTF8.GetBytes("\r\n\r\n");
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                var dir = Directory.GetCurrentDirectory();
                var output = dir + "\\encoded\\";
                Directory.CreateDirectory(output);
                foreach (var fileInfo in new DirectoryInfo(Directory.GetCurrentDirectory()).EnumerateFiles())
                {
                    new Encoder().Encode(Path.ChangeExtension(output + (fileInfo.Name), "bmp"), header.Concat(File.ReadAllBytes(fileInfo.FullName)).ToArray());
                }
                return;
            }

            string file = args[0];

            if (!File.Exists(file)) ErrorDontExist();

            if (Path.GetExtension(file) == "bmp")
            {

            }
            else
            {
                new Encoder().Encode(Path.ChangeExtension(file, "bmp"), header.Concat(File.ReadAllBytes(file)).ToArray());
            }

        }


        static void ErrorDontExist()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: File do not exist");
            Environment.Exit(0);
        }

        static void WriteHelp()
        {
            Console.WriteLine("Bitmap Encoder encode file to readable 24 bitmap");
            Console.WriteLine("Args: bitmap-encoder filepath");
        }
    }
}
