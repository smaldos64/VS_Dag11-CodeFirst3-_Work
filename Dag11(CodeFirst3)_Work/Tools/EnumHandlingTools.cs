using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dag11_CodeFirst3__Work.Models
{
    public class EnumHandlingTools
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static IEnumerable<T> GetValuesList<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        public static int[] GetEnumValuesInt<T>()
        {
            var ThisList = GetValuesList<T>();

            //string[] resultString = ThisList.Cast<string>.ToArray();

            //List<int> ReturnList;

            int[] result = ThisList.Cast<int>().ToArray();

            List<int> resultList = new List<int>(result);

            return result;
        }
    }
}