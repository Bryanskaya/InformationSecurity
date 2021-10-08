using System;
using System.IO;
using System.Collections;


namespace lab03
{
    class Cipher
    {
        private static string _root = @"C:\msys64\home\bryan\InformationSecurity\lab03\lab03\";
        
        private string _fileIP = _root + @"Tables\IP.txt";
        private string _fileIPRev = _root + @"Tables\IP-1.txt";
        private string _fileSi = _root + @"Tables\Si.txt";
        private string _fileB = _root + @"Tables\B.txt";
        private string _fileCP = _root + @"Tables\CP.txt";
        private string _fileE = _root + @"Tables\E.txt";
        private string _fileP = _root + @"Tables\P.txt";
        private string _fileSBlocks = _root + @"Tables\Sblocks.txt";


        private string _in, _out;

        private static BitArray _key;
        private static BitArray[] _keys_arr;

        static int[] prmIP;
        static int[] prmIPRev;
        public static int[] moveSi;
        public static int[] prmCP;
        public static int[] prmB;
        public static int[] prmE;
        public static int[] prmP;
        public static int[][][] sBlocks;

        public Cipher(string inFile, string outFile)
        {
            _in = inFile;
            _out = outFile;
            
            Reader.GetFromFile(_fileIP, out prmIP);
            Reader.GetFromFile(_fileIPRev, out prmIPRev);
            Reader.GetFromFile(_fileSi, out moveSi);
            Reader.GetFromFile(_fileB, out prmB);
            Reader.GetFromFile(_fileCP, out prmCP);
            Reader.GetFromFile(_fileE, out prmE);
            Reader.GetFromFile(_fileP, out prmP);
            sBlocks = Reader.GetSBlocksFromFile(_fileSBlocks);

            KeysProcessing.GetKey(out _key);
            KeysProcessing.GetKeys(_key, out _keys_arr);
        }

        public void Encrypt()
        {
            Reader reader = new Reader(_in);
            Writer writer = new Writer(_out);

            BitArray blk;
            int num = 0;

            while (reader.GetBlock(num, out blk))
            {
                var eblk = DoEcryption(blk);
                writer.SaveInFile(eblk);
                num++;
            }

            Reader.Close();
            Writer.Close();
        }

        private static BitArray DoEcryption(BitArray blk)
        {
            BitArray left, right;
                    
            BitArray prm_blk = EncryptionSteps.Permutate(blk, prmIP);
            EncryptionSteps.GetLeftRightPart(prm_blk, out left, out right);

            for (int i = 0; i < _keys_arr.Length; i++)
            {
                var temp_left = right;
                right = left.Xor(EncryptionSteps.FeistelCipher(right, _keys_arr[i]));
                left = temp_left;
            }

            prm_blk = KeysProcessing.Join(left, right);
            prm_blk = EncryptionSteps.Permutate(prm_blk, prmIPRev);

            return prm_blk;
        }

        public void Decipher()
        {

        }

 
    
    }
}
