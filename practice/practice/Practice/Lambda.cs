using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace practice.Practice
{
    public class Lambda : Test
    {
        public Lambda(string testName = "Lambda expression test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
        }

        protected override void RealTestOutPut()
        {
            Func<string, int> f = s => s.Length;
            Expression<Func<string, int>> e = s => s.Length;
            println(e.Compile()("abcde").ToString());
            println(f("abcdefg").ToString());
            
            var e1 = Expression.Constant(2);
            var e2 = Expression.Constant(6);
            var e3 = Expression.Multiply(e1, e2);
            var e4 = Expression.Lambda<Func<int>>(e3).Compile();
            println(e3.ToString() + " = " + e4().ToString());
            
        }
    }
}
