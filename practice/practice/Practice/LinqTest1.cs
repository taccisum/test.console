using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Practice
{
    public class LinqTest1 : Test
    {

        public LinqTest1(string testName = "Linq test 1", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
        }

        protected override void RealTestOutPut()
        {
            ArrayList al = new ArrayList {"First", "Second", "Third", 1, 2};
            
            //var list = al.Cast<string>();       //报错
            //foreach (var i in list)
            //{
            //    println(i);
            //}

            var list = al.OfType<string>();     //过滤掉非string类型
            foreach (var i in list)
            {
                println(i);
            }

        }

    
        
    }
}
