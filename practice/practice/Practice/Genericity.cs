using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Practice
{
    public class Genericity<T> : Test where T : IComparable<T>, new()
    {
        private T obj;
        private T obj1;

        public Genericity(string testName = "Genericity test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
        }

        public Genericity(T obj, T obj1, string testName = "Genericity test", bool isShow = true)
        {
            this.obj = obj;
            this.obj1 = obj1;
            TestName = testName;
            IsShow = isShow;
        }

        protected override void RealTestOutPut()
        {
            if (obj == null)
            {
                println("实例化一个" + typeof(T));
                obj = new T();
            }
            println(obj.ToString());

            if (obj1 == null)
            {
                println("实例化一个" + typeof (T));
                obj1 = new T();
            }
            println(obj1.ToString());

            println("比较两个对象，返回值：" + obj.CompareTo(obj1));
        }
    }
}
