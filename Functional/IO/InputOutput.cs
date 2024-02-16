using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Functional.IO
{
    public class InputOutput
    {
        static string filePath = @"../../../EnglishUkrainian Vocabulary/Dicitonaries/";

        public static Dictionary<string, string> OpenFile(string filename)
        {
            string temp = filePath;
            temp += filename;
            Dictionary<string, string> post = File.ReadAllLines(temp, Encoding.Default)
                .Select(x => Regex.Match(x, @"(\w*)\s*(\w*.*)")).ToDictionary(x => x.Groups[1].Value, x => x.Groups[2].Value);
            return post;
        }

        public static void SaveFile(string filename, Dictionary<string,string> po)
        {
            if(po.Count == 0)
            {
                return;
            }
            string temp = filePath;
            temp += filename;
            using (FileStream fs = new FileStream(temp, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    foreach(var item in po)
                    {
                        sw.WriteLine($"{item.Key} {item.Value}");
                    }
                }
            }

        }

        public static FileInfo[] GetDictionaryName()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(filePath);
            FileInfo[] files = directoryInfo.GetFiles();
            return files;
        }

    }
}
