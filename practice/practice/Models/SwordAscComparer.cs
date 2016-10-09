using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Models
{
    public class SwordAscComparer : IComparer<Sword>
    {
        public int Compare(Sword x, Sword y)
        {
            return x.CompareTo(y);
        }
    }
}
