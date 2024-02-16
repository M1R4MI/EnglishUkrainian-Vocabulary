using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ConsoleIO;
using Functional.Data;
using Functional.MenuUI;




namespace EnglishUkrainian_Vocabulary
{
    class Program
    {
        static MainMenu main;
        static DataContext dataContext;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Settings.SetConsoleParam("English - Ukrainian Dictionary");

            dataContext = new DataContext();

            main = new MainMenu(dataContext);
            main.Launch();

            Console.ReadKey();
        }
    }
}
