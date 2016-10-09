using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Mementor
{
    public class Status
    {
        private int _val;

        public int Val
        {
            get { return _val; }
            set { _val = value; }
        }

        public Status(int val)
        {
            _val = val;
        }


        public override string ToString()
        {
            return "Status: " + _val;
        }

        public object Clone()
        {
            return new Status(_val);
        }
    }
}
