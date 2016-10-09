using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Composition.Visitors
{
    public class PrintAndComposing : IVisitor
    {
        public void ForEach(Component component, int retractLevel = 0)
        {
            if (component.GetType() == typeof (Composite))
            {
                string retract = "";
                string retractChild = "";
                for (int i = 0; i < retractLevel; i++)
                {
                    retract += "  ";
                }
                retractChild = retract + "  ";

                Console.WriteLine("I'm " + component.Name + ", it's my child:");
                Console.WriteLine(retract + "[");
                foreach (var composite in component.GetAllChild())
                {
                    Console.Write(retractChild);
                    ForEach(composite, retractLevel + 1);
                }
                Console.WriteLine(retract + "]");

            }
            else
            {
                Console.WriteLine("I'm a leaf." + (component.Name == null ? "" : " name: " + component.Name));
            }
        }

    }
}
