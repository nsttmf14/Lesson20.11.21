using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson20._11._21
{
    public class HashCatalog
    {
        private Dictionary<int, Creation> table;

        public HashCatalog()
        {
            table = new Dictionary<int, Creation>();
        }

        internal void Add(Creation creation)
        {
            table.Add(creation.Index, creation);
        }

        internal void Delete(int index)
        {
            table.Remove(index);
        }
    }
}
