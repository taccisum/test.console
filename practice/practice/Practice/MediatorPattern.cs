using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Medium.Colleagues;
using practice.Medium.Mediators;

namespace practice.Practice
{
    public class MediatorPattern : Test
    {
        public MediatorPattern(string testName = "Mediator pattern test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
        }

        protected override void RealTestOutPut()
        {
            var mediator = new ConcreteMediator();
            var a = new ColleagueA(mediator);
            var b = new ColleagueB(mediator);
            var c = new ColleagueC(mediator);
            var list = new List<AbstractColleague>() {a, b, c};

            println("Change a to 100 and notify colleagues");
            a.Data = 100;
            a.Changed();
            Print(list);

            println("Change b to 100 and notify colleagues");
            b.Data = 100;
            b.Changed();
            Print(list);

            println("Change c to 100 and notify colleagues");
            c.Data = 100;
            c.Changed();
            Print(list);

        }


        private void Print( List<AbstractColleague > list)
        {
            foreach (var colleague in list)
            {
                println(colleague.Data.ToString());
            }
            println("");
        }
    }
}
