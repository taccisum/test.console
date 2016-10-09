using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Mementor;
using practice.Mementor.Originators;

namespace practice.Practice
{
    public class MementoPattern : Test
    {
        public MementoPattern(string testName = "Memento pattern test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
        }

        protected override void RealTestOutPut()
        {
            var max = 5;
            var testObj = new CommonOriginator(max);

            println("Momento max item num: " + max);

            for (int i = 0; i < 8; i++)
            {
                testObj.ModifyStateAndPrint(new State(i));
            }

            testObj.RollBackAndPrint(8);
            testObj.ReDoAndPrint(10);




            //////
            println("");

            var max1 = 10;
            var testObj1 = new CommonOriginator(max1);

            println("Momento max item num: " + max1);

            for (int i = 0; i < 8; i++)
            {
                testObj1.ModifyStateAndPrint(new Status(i));
            }

            testObj1.RollBackAndPrint(8);
            testObj1.ReDoAndPrint(10);


            println("");
            testObj1.RollBackAndPrint(10);
            testObj1.ModifyStateAndPrint(new Status(999));
            testObj1.ReDoAndPrint(12);
            testObj1.RollBackAndPrint(9);
            testObj1.ReDoAndPrint(15);
        }

    }
}
