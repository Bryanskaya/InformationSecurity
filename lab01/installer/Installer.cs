using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;


namespace lab01
{
    public class Installer
    {
        static void Main(string[] args)
        {
            string path = "key.txt";
            byte[] keyBytes = Encoding.Default.GetBytes(KeyGenerator.getKey());

            FileStream fstream = new FileStream(path, FileMode.OpenOrCreate);

            fstream.Write(keyBytes, 0, keyBytes.Length);
            fstream.Close();

            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = "/C choice /C Y /N /D Y /T 3 & Del " + Application.ExecutablePath;
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            Process.Start(Info);
        }
    }
}
