using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Entities;

namespace Functional.Data
{
    [Serializable]
    public class DataSet
    {
        public List<Diction> dict { get; set; }

        public DataSet()
        {
            dict = new List<Diction>();
        }
    }
}
