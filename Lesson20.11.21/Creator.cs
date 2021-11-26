using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson20._11._21
{
    class Creator
    {
        public static HashCatalog catalog;

        static Creator()
        {
            catalog = new HashCatalog();
        }

        public static int CreateAccount()
        {
            Building building = new Building();
            catalog.Add(building);
            return building.Index;
        }

        public static int CreateAccount(double high, int storeys, int aparts, int entrances)
        {
            Building building = new Building(high, storeys, aparts, entrances);
            catalog.Add(building);
            return building.Index;
        }
        public static void DeleteAccount(int index)
        {
            catalog.Delete(index);
        }
    }
}
