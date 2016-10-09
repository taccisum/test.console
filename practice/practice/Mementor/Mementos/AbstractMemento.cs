using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Mementor.Mementos
{
    public abstract class AbstractMemento
    {
        public object State { get; set; }
    }
}
