using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Models.Singleton;

namespace practice.Practice
{
    public class SingletonRegistryTest : Test
    {
        public SingletonRegistryTest(string testName = "Singleton registry test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
        }


        protected override void RealTestOutPut()
        {
            println(Singleton1.GetInstance().ToString());
            println(Singleton2.GetInstance().ToString());

            println(Singleton1.GetInstance().ToString());
            println(Singleton2.GetInstance().ToString());
        }
    }
}
