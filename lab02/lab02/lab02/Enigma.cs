using System;
using System.IO;

namespace lab02
{
    class Enigma
    {
        static int amountRotors = 3;

        public Rotor[] rotorsArr = new Rotor[amountRotors];
        Reflector reflector;

        public Enigma()
        {
            for (int i = 0; i < amountRotors; i++)
                rotorsArr[i] = new Rotor();

            reflector = new Reflector();
        }

        public void cipherFile(string scrName, string destName)
        {
            int temp;

            if (File.Exists(scrName))
            {
                using (FileStream fsR = new FileStream(scrName, FileMode.Open))
                using (FileStream fsW = new FileStream(destName, FileMode.Create))
                {
                    while (fsR.CanRead)
                    {
                        temp = fsR.ReadByte();
                        if (temp == -1)
                            break;
                        fsW.WriteByte((byte)cipherSign(temp));
                    }
                }
            }
        }

        int cipherSign(int s)
        {
            foreach (Rotor rotor in rotorsArr)
                s = rotor.getValue(s);

            s = reflector.getValue(s);

            for (int i = rotorsArr.Length - 1; i >= 0; i--)
                s = rotorsArr[i].getIndex(s);

            if (rotorsArr[0].move() == 0)
                if (rotorsArr[1].move() == 0)
                    rotorsArr[2].move();

            return s;
        }

        public void saveInFile(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                reflector.saveInFile(fs);

                for (int i = 0; i < amountRotors; i++)
                    rotorsArr[i].saveInFile(fs);
            }
        }

        public int loadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    reflector.loadFromFile(fs);

                    for (int i = 0; i < amountRotors; i++)
                        rotorsArr[i].loadFromFile(fs);
                }
            }
            else
            {
                Console.WriteLine("ERROR: file does not exist\n");
                return -1;
            }

            return 0;
        }

        public void view()
        {
            Console.WriteLine("---REFLECTOR---");
            reflector.view();

            Console.WriteLine("---ROTOR 1 ---");
            rotorsArr[0].view();

            Console.WriteLine("---ROTOR 2 ---");
            rotorsArr[1].view();

            Console.WriteLine("---ROTOR 3 ---");
            rotorsArr[2].view();
        }
    }
}
