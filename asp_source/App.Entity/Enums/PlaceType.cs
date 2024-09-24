using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.Enums
{
    public enum PlaceType
    {
        Gym = 1,
        Home = 2,
        Park = 3


    }
    public class PlaceTypeHelper
    {
        public static Dictionary<string, int> GetEnumValues()
        {
            var values = Enum.GetValues(typeof(PlaceType));
            var enumDictionary = new Dictionary<string, int>();

            foreach (var value in values)
            {
                var name = Enum.GetName(typeof(PlaceType), value);
                enumDictionary[name] = (int)value;
            }

            return enumDictionary;

        }
    }



}
