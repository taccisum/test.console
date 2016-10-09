using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Composition.Visitors
{
    public class PrintNoComposing : IVisitor
    {
        public void ForEach(Component component, int retractLevel = 0)
        {
            if (component.GetType() == typeof (Composite))
            {
                Console.WriteLine("I'm " + component.Name + ", it's my child:");

                foreach (var composite in component.GetAllChild())
                {

                    composite.AcceptForEach(this);
                }
            }
            else
            {
                Console.WriteLine("I'm a leaf." + (component.Name == null ? "" : " name: " + component.Name));
            }
        }
    }
}
