using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Mementor.CareTakers
{
    public class CommonCareTaker : AbstractCareTaker
    {
        public CommonCareTaker(int max)
        {
            _currentIndex = -1;
            _maxItems = max;
        }
    }
}
