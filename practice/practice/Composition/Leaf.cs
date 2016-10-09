using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Composition.Visitors;

namespace practice.Composition
{
    public class Leaf : Component
    {
        public Leaf() { }

        public Leaf(string name, int level)
        {
            Name = name;
            Level = level;
        }

        public override Component GetChild(int index)
        {
            throw new NotImplementedException();
        }

        public override List<Component> GetAllChild()
        {
            throw new NotImplementedException();
        }

        public override void AddChild(Component component)
        {
            throw new NotImplementedException();
        }

        public override void RemoveChild(Component component)
        {
            throw new NotImplementedException();
        }

        public override void ForEach()
        {
            throw new NotImplementedException();
        }

        public override void AcceptForEach(IVisitor visitor)
        {
            visitor.ForEach(this);
        }

    }
}
