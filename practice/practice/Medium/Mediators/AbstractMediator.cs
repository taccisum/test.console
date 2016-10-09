using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Medium.Colleagues;

namespace practice.Medium.Mediators
{
    public abstract class AbstractMediator
    {
        protected  List<AbstractColleague> colleagues = new List<AbstractColleague>();


        public virtual void AddColleague(AbstractColleague colleague)
        {
            this.colleagues.Add(colleague);
        }

        public virtual void AddColleague(List<AbstractColleague> colleagues)
        {
            this.colleagues.AddRange(colleagues);
        }


        public abstract void NotifyChange(AbstractColleague source);

    }
}
