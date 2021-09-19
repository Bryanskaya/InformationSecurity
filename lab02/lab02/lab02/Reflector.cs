using System;
using System.Collections.Generic;

namespace lab02
{
    class Reflector : Device
    {
        public Reflector()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            List<int> indList = new List<int>();
            int ind, k = 0;

            for (int i = 0; i < num; i++)
            {
                connectionsArr[i] = -1;
                indList.Add(i);
            }

            while (indList.Count > 0)
            {
                ind = rnd.Next(0, indList.Count);

                while (connectionsArr[k] != -1)
                    k++;

                connectionsArr[k] = indList[ind];
                connectionsArr[indList[ind]] = k;

                indList.RemoveAt(ind);
                if (indList.IndexOf(k) >= 0)
                    indList.RemoveAt(indList.IndexOf(k));
                k++;
            }
        }
    }
}
