using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.MenuRecognition
{   public delegate object Method();

    public class MenuItem
    {
        internal readonly object nameItems;
        
        public object Dictionary { get; }

        public MenuItem(string nameItems, var dictionaryChoose)
        {
            this.MenuItems = nameItems;
            Dictionary = dictionaryChoose;
        }
            internal readonly Method methodItems;
        

        
        public string MenuItems { get; set; }
    }
}
