using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Mementor
{
    public class State : ICloneable
    {
        private int _val;

        public int Val
        {
            get { return _val; }
            set { _val = value; }
        }

        public State(int val)
        {
            _val = val;
        }


        public override string ToString()
        {
            return "State: " + _val;
        }

        public object Clone()
        {
            return new State(_val);
        }
    }
}
