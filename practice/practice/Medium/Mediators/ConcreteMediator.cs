using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Medium.Colleagues;

namespace practice.Medium.Mediators
{
    public class ConcreteMediator : AbstractMediator
    {
        public override void NotifyChange(AbstractColleague source)
        {
            foreach (var colleague in colleagues)
            {
                if (colleague != source)
                {
                    colleague.Update(source);
                }
            }
        }
    }
}
