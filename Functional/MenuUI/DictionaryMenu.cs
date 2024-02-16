using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Functional.Data;
using Functional.IO;
using Functional.MenuRecognition;
using System.Threading.Tasks;

namespace Functional.MenuUI
{
    public class DictionaryMenu : Menu
    {
        DataContext _dataContext;

        public DictionaryMenu(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        
        protected override void MenuMethods()
        {
            menuItems = new MenuItem[]
            {
                new MenuItem("Search translation", SearchTranslation),
                new MenuItem("Add new word", AddWord),
                new MenuItem("Change word or translation", ChangeWord),
                new MenuItem("Delete word or translation", DeleteWord),
                new MenuItem("To the Main Menu",ToMainMenu),
            };
        }

        

        protected override void Screen()
        {
            Console.WriteLine($"Dictionary Menu {_dataContext.dictions.First().dictname}");
        }

        private void SearchTranslation()
        {
            Dictionary<string, string> valuePairs = new Dictionary<string, string>();
            string stKey = "", stValue = "";
            bool point = true;
            while(point)
            {
                Console.WriteLine("Write word");
                stKey = Console.ReadLine();
                if (_dataContext.dictions.First().keyValues.TryGetValue(stKey, out stValue))
                {
                    Console.WriteLine($"Translation: {stValue}");
                    valuePairs.Add(stKey, stValue);
                }
                else
                {
                    Console.WriteLine("Not Existing word");
                }

            }
            valuePairs.Clear();
            Console.Clear();
        }

        private void AddWord()
        {
            bool point = true, point1 = true;
            string wKey = "", wvalue = "";
            while(point1)
            {
                while(point)
                {
                    Console.WriteLine("Write word");
                    wKey = Console.ReadLine();
                    foreach(var key in _dataContext.dictions.First().keyValues.Keys)
                    {
                        if(key == wKey)
                        {
                            Console.WriteLine("The word is exists in the dictionary");
                            point = true;
                            break;
                        }
                        point = false;
                        if (point == false)
                        {
                            Console.WriteLine("Write translation for te word");
                            wvalue = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Write translation for te word");
                            wvalue = Console.ReadLine();
                            point = false;
                        }
                        _dataContext.dictions.First().keyValues.Add(wKey, wvalue);
                        Console.WriteLine("Word and translation added");
                        Console.WriteLine("Do you want to proceed? y - n");
                        string wansw = Console.ReadLine();
                        if( wansw == "n")
                        {
                            point1 = false;
                        }
                        if(wansw == "y")
                        {
                            point1 = true;
                        }
                    }
                    InputOutput.SaveFile(_dataContext.dictions.First().dictname, _dataContext.dictions.First().keyValues);
                    Console.Clear();
                }
            }
        }

        private void DeleteWord()
        {

        }
        
        
        private void ChangeWord()
        {
            
        }

        private void ToMainMenu()
        {
            //MainMenu mainmenu = new MainMenu(dataContext);
            //mainmenu = Launch();
        }
    }
}
