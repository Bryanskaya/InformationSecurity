using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.IO;


namespace lab01
{
    public class Installer
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

        static string getKey()
        {
            return getHash(getId());
        }

        public static bool cmpKeys(string key)
        {
            string data = getKey();
            return key.Equals(data);
        }

        static void Main(string[] args)
        {
            string path = @"..\..\..\key2.txt";
            byte[] keyBytes = Encoding.Default.GetBytes(getKey());

            FileStream fstream = new FileStream(path, FileMode.OpenOrCreate);

            fstream.Write(keyBytes, 0, keyBytes.Length);
            fstream.Close();
        }
    }
}
