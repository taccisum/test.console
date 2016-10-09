using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Composition.Visitors
{
    public interface IVisitor
    {
        void ForEach(Component component, int retractLevel = 0);
    }
}
