using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bets
{
    class ParseDate
    {
        public static int ParseYear(string a)
        {
            if (a.Contains('-'))
            {
                return Int32.Parse(a.Split('-')[0]);
            }
            else
            {
                return Int32.Parse(a.Split('.')[2].Remove(4));
            }
        }
        public static int ParseMounth(string a)
        {
            if (a.Contains('-'))
            {
                return Int32.Parse(a.Split('-')[1]);
            }
            else
            {
                return Int32.Parse(a.Split('.')[1]);
            }
        }
        public static int ParseDay(string a)
        {
            if (a.Contains('-'))
            {
                return Int32.Parse(a.Split('-')[2].Remove(2));
            }
            else
            {
                return Int32.Parse(a.Remove(2));
            }
        }
        public static int ParseHour(string a)
        {
            return Int32.Parse(a.Split(' ')[1].Split(':')[0]);
        }
        public static int ParseMin(string a)
        {
            string ass = a.Split(' ')[1].Split(' ')[0].Split(':')[1];
            if (ass.Length>2)
            return Int32.Parse(ass.Remove(2));
            else
            return Int32.Parse(ass);
        }
        public static int ParseScore1(string a)
        {
            return (int)Char.GetNumericValue(a.ElementAt(a.LastIndexOf(':') - 1));
        }
        public static int ParseScore2(string a)
        {
            return (int)Char.GetNumericValue(a.ElementAt(a.LastIndexOf(':') + 1));
        }
        public static string CutScore(string a)
        {
            
            return a.Remove(a.LastIndexOf(':')-2);
        }
    }
}
