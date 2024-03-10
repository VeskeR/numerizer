using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Numerizator
{
    class Program
    {
        private static Random _rand = new Random();
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Number from start: ");
            int num = int.Parse(Console.ReadLine());

            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string dir = dlg.SelectedPath;
                List<string> files = Directory.GetFiles(dir).ToList();
                int index = files.FindIndex(f => f.EndsWith("Numerizator.exe"));
                if (index >= 0)
                    files.RemoveAt(index);
                int j = 0;

                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);

                    string name = string.Empty;

                    for (int i = 0; i < 4; i++)
                    {
                        name += (j++).ToString() + (_rand.Next(1000000000)).ToString();
                    }

                    fi.MoveTo(fi.DirectoryName + @"\" + name + fi.Extension);
                }

                files = Directory.GetFiles(dir).ToList();
                index = files.FindIndex(f => f.EndsWith("Numerizator.exe"));
                if (index >= 0)
                    files.RemoveAt(index);
                int count = num;

                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);

                    fi.MoveTo(fi.DirectoryName + @"\" + (count++).ToString() + fi.Extension);
                }
            }
        }
    }
}
