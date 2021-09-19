using System;

namespace lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileNameCipher = @"ciphered_version.txt";
            string fileNameUncipher = @"uncipher_version.txt"; //jpg"; //txt"; //mp4";
            string fileNameScr = @"text.txt";                //@"video.mp4"; @"img.jpg"; @"text.txt";
            string stateEnigma = @"stateEnigma.txt";


            Enigma enigma1 = new Enigma();
            enigma1.saveInFile(stateEnigma);
            enigma1.cipherFile(fileNameScr, fileNameCipher);

            Enigma enigma2 = new Enigma();
            enigma2.loadFromFile(stateEnigma);
            enigma2.cipherFile(fileNameCipher, fileNameUncipher);

            Console.WriteLine("Prease, press any key");
            Console.ReadKey();
        }
    }
}