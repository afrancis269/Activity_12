using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Activity_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line;
            string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            int res = 0;

            try
            {
                StreamReader sr = new StreamReader(dir + @"\TestDir\TestFile.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] arr = line.Split(' ');
                    for (int i = 0; i < arr.Length; i++) {
                        int wordLen = arr[i].Length;
                        while (!Regex.IsMatch(arr[i][wordLen-1].ToString(), "[a-z]"))
                        {
                            wordLen--;
                        }
                        if (arr[i][wordLen-1] == 'e' || arr[i][wordLen-1] == 't')
                        {
                            res++;
                        }
                    }
                    line = sr.ReadLine();
                }
                sr.Close();

            }catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.WriteLine("There are " + res.ToString() + " words that end in t or e");
            
            Console.ReadLine();
        }
    }
}
