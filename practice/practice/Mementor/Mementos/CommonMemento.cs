using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Mementor.Mementos
{
    public class CommonMemento : AbstractMemento
    {
        public CommonMemento(object state)
        {
            State = state;
        }

    }
}
