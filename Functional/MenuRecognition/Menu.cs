using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Functional.MenuRecognition
{
    public abstract class Menu
    {
        protected MenuItem[] menuItems;

        public Menu()
        {
            MenuMethods();
        }
       
        protected abstract void MenuMethods();
        protected abstract void Screen();

        public void Launch()
        {
            while (true)
            {
                Method method = ShowMenu();
                if (method == null)
                {
                    return;
                }
                try
                {
                    method.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }

            }
        }
        
        private void MenuArea(int x, int y, int width, int height)
        {
           for(; height > 0;)
           {
             Console.SetCursorPosition(x, y + --height);
             Console.Write(new string(' ', width));
           }
           Console.SetCursorPosition(x, y);
        }

        private Method ShowMenu()
        {
            ConsoleKeyInfo keyInfo;
            int count = 0;
            while(true)
            {
                MenuArea(0, 1, 34, 7);
                Console.SetCursorPosition(0, 0);
                Screen();
                Console.SetCursorPosition(0, 1);
                Console.WriteLine();
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if(count == i)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"{i + 1}{menuItems[i].nameItems} <-");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}{menuItems[i].nameItems}");
                    }

                }
                keyInfo = Console.ReadKey();
                Console.WriteLine("\n\n");
                if(keyInfo.Key == ConsoleKey.UpArrow)
                {
                    count--;
                    if (count == -1) count = menuItems.Length - 1;
                }
                if(keyInfo.Key == ConsoleKey.DownArrow)
                {
                    count++;
                    if (count == menuItems.Length) count = 0;
                }
                if(keyInfo.Key == ConsoleKey.Enter)
                {
                    return menuItems[count].methodItems;
                }
            }
        

            
        }


    }
}
