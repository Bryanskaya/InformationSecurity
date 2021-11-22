using System;

namespace lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileNameScr = @"tests/test_video.gif";                //@"test_video.gif"; @"img.jpg"; @"text.txt";
            string fileNameCipher = @"tests/ciphered_version.gif";
            string fileNameResult = @"tests/uncipher_version.gif";

            Cipher cipher = new Cipher();

            cipher.Encrypt(fileNameScr, fileNameCipher);
            cipher.Decrypt(fileNameCipher, fileNameResult);

            Console.WriteLine("Press any button");
            Console.ReadKey();
        }
    }
}
