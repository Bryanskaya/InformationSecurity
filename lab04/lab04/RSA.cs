using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    class RSA
    {
        private int _startKey = 1000;
        private int _endKey = 9999;
        private int privateKey;
        public int publicKey;
        
        static Random rnd = new Random();


        public RSA()
        {
            int left = 1;

            int p = GetSimpleKey(_startKey, _endKey);
            int q = GetSimpleKey(_startKey, _endKey);
            int n = p * q;

            publicKey = GetPublicKey(left, MathFuncs.fi(p, q));
            privateKey = GetPrivateKey();
        }

        static int GetSimpleKey(int start, int end)
        {
            int num;

            do
            {
                num = rnd.Next(start, end);
            } while (!MathFuncs.IsSimple(num));

            return num;
        }

        static int GetPublicKey(int fi, int left = 1)
        {
            int e, res;

            do
            {
                e = rnd.Next(left + 1, fi);
                res = MathFuncs.GCD(e, fi);
            } while (res != 1);

            return e;            
        }

        static int GetPrivateKey()
        {
            int res;

            return res;
        }
    }
}
