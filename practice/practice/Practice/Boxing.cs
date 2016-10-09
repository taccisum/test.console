using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Practice
{
    public class Boxing<T> : Test
    {
        private uint _testNum;
        private T _testInstance;

        public Boxing(T testInstance, uint testNum = 10000, string testName = "Boxing test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
            _testNum = testNum;
            _testInstance = testInstance;
        }

        protected override void RealTestOutPut()
        {
            println("进行" + _testNum + "次"+typeof(T)+"与object之间的装箱拆箱测试");
            if (_testInstance == null)
            {
                println("测试实例为null值，此次测试被终止。");
                return;
            }

            println("开始测试");
            watch.Start();
            for (int i = 0; i < _testNum; i++)
            {
                object temp = _testInstance;
                T temp1 = (T) temp;
            }
            watch.Stop();
            println("执行完毕，用时" + watch.Elapsed);

        }
    }
}
