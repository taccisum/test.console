using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Composition.Visitors;

namespace practice.Composition
{
    public abstract class Component
    {
        public string Name { get; protected set; }
        public int Level { get; protected set; }

        public Composite Parent { get; set; }

        public abstract Component GetChild(int index);

        public abstract List<Component> GetAllChild();

        public abstract void AddChild(Component component);

        public abstract void RemoveChild(Component component);

        public abstract void ForEach();

        public abstract void AcceptForEach(IVisitor strategy);

    }
}
