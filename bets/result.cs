using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bets
{
    class result
    {
        public int score1;
        public int score2;
        public string team1;
        public string team2;
        public DateTime data;
        public List<line> lines;
        public result()
        {
            lines = new List<line>();
        }
    }
   
}
