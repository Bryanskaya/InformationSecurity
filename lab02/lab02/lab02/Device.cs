using System;
using System.Linq;
using System.IO;

namespace lab02
{
    public class Device
    {
        public static int num = 256;
        public int amountRot = 0;

        public int[] connectionsArr = new int[num];

        public Device()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < num; i++)
                connectionsArr[i] = i;

            connectionsArr = connectionsArr.OrderBy(x => rnd.Next()).ToArray();
        }

        public int getValue(int index)
        {
            return connectionsArr[index];
        }

        public int getIndex(int value)
        {
            return Array.IndexOf(connectionsArr, value);
        }

        public void saveInFile(FileStream fs)
        {
            for (int i = 0; i < num; i++)
                fs.WriteByte((byte)connectionsArr[i]);
        }

        public void loadFromFile(FileStream fs)
        {
            amountRot = 0;

            for (int i = 0; i < num; i++)
                connectionsArr[i] = fs.ReadByte();
        }

        public void view()
        {
            Console.WriteLine(String.Join(" ", connectionsArr));
            Console.WriteLine();
        }
    }
}