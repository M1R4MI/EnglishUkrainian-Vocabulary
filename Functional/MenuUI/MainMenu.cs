using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Functional.Data;
using Functional.MenuRecognition;
using Functional.IO;
using Functional.Entities;

namespace Functional.MenuUI
{
    public class MainMenu : Menu
    {
        DataContext dataContext;

        public MainMenu(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        protected override void MenuMethods()
        {
            menuItems = new MenuItem[]
                {
                    new MenuItem("Choose dictionary", DictionaryChoose),
                    new MenuItem("Create new dictionary", DictionaryCreate),
                    new MenuItem("Exit", Exit)
                };

        }

        protected override void Screen()
        {
            Console.WriteLine("Main Menu");
        }

        private void DictionaryChoose()
        {
            int number = 0;
            FileInfo[] files = InputOutput.GetDictionaryName();
            foreach(var file in files)
            {
                Console.WriteLine($"{++number} {file.Name}");
            }
            Console.WriteLine("Choose dictionary");
            number = int.Parse(Console.ReadLine()) - 1;
            string filename = files[number].Name;

            Diction diction = new Diction
            {
                dictname = filename,
                keyValues = InputOutput.OpenFile(filename)
            };

            dataContext.dictions.Add(diction);
            Console.Clear();
            //dictMenu.Launch();
        }

        private void DictionaryCreate()
        {
            FileInfo[] fileInfos = InputOutput.GetDictionaryName();
            bool point = true;

            while(point)
            {
                Console.WriteLine("Write dictionary name");
                string filename = Console.ReadLine();
                filename += ".txt";

                foreach(var file in fileInfos)
                {
                    if (filename == file.Name)
                    {
                        Console.WriteLine("The dictionary exists");
                        point = true;
                        break;
                    } 
                    point = false;
                }
                if(point == false)
                {
                    Diction diction = new Diction
                    {
                        dictname = filename,
                        keyValues = new Dictionary<string, string>()
                    };
                    dataContext.dictions.Add(diction);
                }
            }
            Console.Clear();
            //dictmenu.Launch();
        }

        private void Exit()
        {
            if(dataContext.dictions.Count == 0)
            {
                Environment.Exit(0);
            }
            string filename = dataContext.dictions.First().dictname;
            Dictionary<string, string> keyValuePairs = dataContext.dictions.First().keyValues;
            InputOutput.SaveFile(filename, keyValuePairs);
            Environment.Exit(0);
        }


    }
}
