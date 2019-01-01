using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dag11_CodeFirst3__Work.Models
{
    public enum CHARACTER_ENUM
    {
        VALUE3MINUS = -3,
        VALUEZERO = 0,
        VALUETWO = 2,
        VALUEFOUR = 4,
        VALUESEVEN = 7,
        VALUETEN = 10,
        VALUETWELVE = 12
    }
    
    public class Character
    {
        private static string[] CharacterStrings = { "-3",
                                                     "0",
                                                     "2",
                                                     "4",
                                                     "7",
                                                     "10",
                                                     "12" };

        //public int CharacterID { get; set; }

        public int CharacterValue { get; set; }

        public string CharacterName { get; set; }


        public static List<Character> GetCharacters()
        {
            List<Character> CharacterList = new List<Character>();

            int[] CharacterValues = EnumHandlingTools.GetEnumValuesInt<CHARACTER_ENUM>();

            var CaracterValuesHere = EnumHandlingTools.GetValues<CHARACTER_ENUM>();

            for (int Counter = 0; Counter < CharacterValues.Length; Counter++)
            {
                Character Character_Object = new Character();
                Character_Object.CharacterValue = CharacterValues[Counter];
                Character_Object.CharacterName = CaracterValuesHere.ElementAt(Counter).ToString();
                CharacterList.Add(Character_Object);
            }

            CharacterList = CharacterList.OrderBy(c => c.CharacterValue).ToList();

            return (CharacterList);
        }

        public static List<Character> GetCharacters1()
        {
            List<Character> CharacterList = new List<Character>();
            int[] CharacterValues = EnumHandlingTools.GetEnumValuesInt<CHARACTER_ENUM>();

            Array.Sort(CharacterValues);
            for (int Counter = 0; Counter < CharacterValues.Length; Counter++)
            {
                Character Character_Object = new Character();
                Character_Object.CharacterValue = CharacterValues[Counter];
                Character_Object.CharacterName = CharacterStrings[Counter];
                CharacterList.Add(Character_Object);
            }
            return (CharacterList);
        }
    }
}