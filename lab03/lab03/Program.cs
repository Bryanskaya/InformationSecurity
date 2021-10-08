using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileNameScr = @"tests/tiny_test.txt";                //@"video.mp4"; @"img.jpg"; @"text.txt";
            string fileNameCipher = @"tests/ciphered_version.txt";
            string fileNameUncipher = @"tests/uncipher_version.txt";

            Cipher cipher = new Cipher(fileNameScr, fileNameCipher);
            
            cipher.Encrypt();


            Console.ReadKey();
        }
    }
}
