using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Composition;
using practice.Composition.Visitors;

namespace practice.Practice
{
    public class CompositePattern : Test
    {
        public CompositePattern(string testName = "Composite pattern test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
        }

        protected override void RealTestOutPut()
        {
            Composite root = new Composite("root", 0);
            Composite branch1 = new Composite("branch", 1);
            Composite branch2 = new Composite("branch", 1);
            Composite branch11 = new Composite("branch", 2);
            branch1.AddChild(new Leaf("tac", 1));
            branch1.AddChild(new Leaf("anit", 1));

            branch2.AddChild(new Leaf("tac2", 2));
            branch2.AddChild(new Leaf("anit2", 2));

            branch11.AddChild(new Leaf("tac11", 3));
            branch11.AddChild(new Leaf("anit11", 3));

            root.AddChild(branch1);
            root.AddChild(branch2);
            branch1.AddChild(branch11);

            root.AcceptForEach(new PrintAndComposing());

            branch1.RemoveChild(branch11);

            root.AcceptForEach(new PrintAndComposing());

            branch1.Parent.AcceptForEach(new PrintAndComposing());
            branch1.GetChild(1).Parent.AcceptForEach(new PrintAndComposing());
        }
    }
}
