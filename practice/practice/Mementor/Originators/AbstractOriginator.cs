using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Mementor.CareTakers;

namespace practice.Mementor.Originators
{
    public abstract class AbstractOriginator
    {
        protected AbstractCareTaker _careTaker { get; set; }

        public object State { get; set; }

        public abstract void CreateMemento();

        public virtual void RollBack()
        {
            _careTaker.RollBack(this);
        }

        public virtual void ReDo()
        {
            _careTaker.ReDo(this);
        }

        public override string ToString()
        {
            return State.ToString();
        }
    }
}
