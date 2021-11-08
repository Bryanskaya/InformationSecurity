using System;

namespace lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileNameScr = @"tests/img.jpg";                //@"test_video.gif"; @"img.jpg"; @"text.txt";
            string fileNameCipher = @"tests/ciphered_version.mp4";
            string fileNameResult = @"tests/uncipher_version.jpg";

            Cipher cipher = new Cipher();

            cipher.Encrypt(fileNameScr, fileNameCipher);
            cipher.Decrypt(fileNameCipher, fileNameResult);

            Console.WriteLine("Press any button");
            Console.ReadKey();
        }
    }
}
