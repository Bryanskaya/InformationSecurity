using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;


namespace lab01
{
    public class KeyGenerator
    {
        static string getId()
        {
            string query = "SELECT SerialNumber FROM Win32_BIOS";
            string res = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            foreach (ManagementObject info in searcher.Get())
            {
                res = info["SerialNumber"].ToString();
            }

            return res;
        }

        static string getHash(string serialNum)
        {
            UnicodeEncoding ue = new UnicodeEncoding();
            SHA256 shHash = SHA256.Create();

            byte[] hashValue = shHash.ComputeHash(ue.GetBytes(serialNum));

            return Convert.ToBase64String(hashValue);
        }

        public static string getKey()
        {
            return getHash(getId());
        }

        public static bool cmpKeys(string key)
        {
            string data = getKey();
            return key.Equals(data);
        }
    }
}
