using System;
using System.IO;
using System.Collections;

namespace lab03
{
    class Writer
    {
        private static FileStream _fs;

        public Writer(string filename)
        {
            _fs = new FileStream(filename, FileMode.OpenOrCreate);
        }

        public void SaveInFile(BitArray blk)
        {
            byte[] temp = new byte[blk.Length / 8];
            blk.CopyTo(temp, 0);

            for (int i = 0; i < temp.Length; i++)
                _fs.WriteByte(temp[i]);
        }

        public static void Close()
        {
            _fs.Close();
        }

        public static void ViewArray(BitArray arr)
        {
            for (int i = 0; i < arr.Count; i++)
                Console.WriteLine($"{i}, {arr[i]}");

            Console.WriteLine();
            Console.ReadKey();
        }

        public static void ViewArray(int[] arr)
        {
            Console.WriteLine(String.Join(" ", arr));
            Console.WriteLine();
            Console.ReadKey();
        }
    }

}
