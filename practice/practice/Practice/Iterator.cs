using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Models;

namespace practice.Practice
{
    public class Iterator : Test
    {
        public Iterator(string testName = "Iterator test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
        }


        protected override void RealTestOutPut()
        {
            Array swords = new Sword[5];
            for (int i = 0; i < 5; i++)
            {
                swords.SetValue(new Sword(i, "tac"), i);
            }

            Swords s = new Swords(swords);

            foreach (var item in s)
            {
                println(item.ToString());
            }
            
        }


        private class Swords : IEnumerable<Sword>
        {
#pragma warning disable 0169
            private Sword _s;
#pragma warning restore 0169
            private List<Sword> _swordsArray = new List<Sword>();

            public Swords(Array swords)
            {
                _swordsArray.AddRange(swords.Cast<Sword>());
            }

            public IEnumerator<Sword> GetEnumerator()
            {
                //foreach (Sword sword in _swordsArray)
                //{
                //    yield return sword;
                //}

                yield return _swordsArray[0];
                yield return _swordsArray[1];
                yield return _swordsArray[2];
                yield break;
#pragma warning disable 0162
                yield return _swordsArray[3];
                yield return _swordsArray[3];
#pragma warning restore 0162
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }


        }
    }
}
