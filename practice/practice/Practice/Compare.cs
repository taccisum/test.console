using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Models;

namespace practice.Practice
{
    public class Compare : Test
    {
        private Action<Sword> printSword = Console.WriteLine;
        public Compare(string testName = "IComparer<T> test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {

        }

        protected override void RealTestOutPut()
        {
            List<Sword> swords = new List<Sword>
            {
                new Sword(3.77f, "绿"),
                new Sword(5.27f, "绿"),
                new Sword(1.37f, "蓝"),
                new Sword(4.71f, "绿"),
                new Sword(2.35f, "绿")
            };
            


            println("Data list");
            PirntInfo(swords);
            println("Asc sort by weight using comparer");
            swords.Sort(new SwordAscComparer());
            PirntInfo(swords);

            println("Desc sort by weight using comparer");
            swords.Sort(new SwordDescComparer());
            PirntInfo(swords);

            println("Asc sort by quality using delegate");
            swords.Sort(delegate(Sword x, Sword y) { return x.Quality.CompareTo(y.Quality); });
            PirntInfo(swords);

            println("Desc sort by quality using lambda expression");
            swords.Sort((x,y)=> -x.Quality.CompareTo(y.Quality));
            PirntInfo(swords);
        }

        private void PirntInfo(IEnumerable<Sword> swords)
        {
            foreach (var sword in swords)
            {
                printSword(sword);
            }
        }
    }
}
