using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace practice.Practice
{
    /// <summary>
    /// Template Pattern
    /// </summary>
    public abstract class Test : ITest
    {
        protected Test()
        {
            ItemNum = current;
            current++;
        }

        protected Test(string testName = "Unnamed Test", bool isShow = true, bool isMeasureTime = true)
        {
            ItemNum = current;
            current++;
            TestName = testName;
            SetVisible(isShow);
            SetMeasureTime(isMeasureTime);
        }



        protected Stopwatch watch = new Stopwatch();

        protected string TestName { get; set; }
        protected bool IsShow { get; set; }
        protected bool IsMeasureTime { get; set; }

        protected Action<object> println = o => Console.WriteLine(o);


        protected int ItemNum;
        private static int current = 1;

        public virtual void DoTest()
        {
            int sum = 79;
            int num = (sum - TestName.Length - ItemNum.ToString().Length - 2) / 2;
            var title = "-".PadRight((sum - TestName.Length)%2 == 1 ? num + 1 : num, '-') + ItemNum + "  " + TestName + "-".PadRight(num, '-');
            println(title);
            if (IsShow)
            {
                if (IsMeasureTime)
                {
                    watch.Restart();

                    RealTestOutPut();

                    watch.Stop();
                    println("");
                    println("method finished! time elapsed: " + watch.Elapsed);
                }
                else
                {
                    RealTestOutPut();
                }
            }
            else
            {
                println("content is hidden");
            }
            println(title);
            println("");
            println("");
            println("");
        }

        public virtual void SetVisible(bool visible)
        {
            IsShow = visible;
        }

        public virtual void SetMeasureTime(bool measure)
        {
            IsMeasureTime = measure;
        }


        protected  abstract void RealTestOutPut();

    }
}
