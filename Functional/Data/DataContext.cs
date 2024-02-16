using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Entities;

namespace Functional.Data
{
    public class DataContext
    {
        readonly DataSet dataSet = new DataSet();

        public ICollection<Diction> dictions 
        {
            get { return dataSet.dict; }
        }

    }
}
