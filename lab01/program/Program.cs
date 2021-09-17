using System;
using System.IO;

namespace lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            if (testAuthen())
                Console.WriteLine("Hello, {0}! Authentication was successful.", Environment.UserName);
            else
                Console.WriteLine("ERROR: action is forbidden!");

            Console.ReadKey();
        }

        static bool testAuthen()
        {
            string path = "key.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("Please, run the installer first!");
                return false;
            }

            string key = File.ReadAllText(path);

            if (KeyGenerator.cmpKeys(key))
                return true;

            return false;
        }
    }
}
