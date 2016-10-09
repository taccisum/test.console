using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Composition.Visitors;

namespace practice.Composition
{
    public class Composite : Component
    {
        private List<Component> _composites = new List<Component>();


        public Composite(string name, int level)
        {
            Name = name;
            Level = level;
        }

        public override Component GetChild(int index)
        {
            return _composites[index];
        }

        public override List<Component> GetAllChild()
        {
            return _composites;
        }

        public override void AddChild(Component component)
        {
            _composites.Add(component);
            component.Parent = this;
        }

        public override void RemoveChild(Component component)
        {
            _composites.Remove(component);
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
