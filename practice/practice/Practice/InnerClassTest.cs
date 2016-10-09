using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Practice
{
    public class InnerClassTest : Test
    {
        public InnerClassTest(string testName = "Inner class test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {

        }


        protected override void RealTestOutPut()
        {
            var wi = new WithInnerClass();
            IInnerClass ic1 = new WithInnerClass.InnerClassImp1();
            IInnerClass ic2 = wi.GetInnerClass2();
            println(ic1);
            println(ic2);
        }


        private interface IInnerClass
        {

        }

        private class WithInnerClass
        {
            public class InnerClassImp1 : IInnerClass
            {
                public override string ToString()
                {
                    return "i'm a inner class, name InnerClassImp1";
                }
            }

            private class InnerClassImp2 : IInnerClass
            {
                public override string ToString()
                {
                    return "i'm a inner class, name InnerClassImp2";
                }
            }

            public IInnerClass GetInnerClass2()
            {
                return new InnerClassImp2();
            }


        }
    }



}
