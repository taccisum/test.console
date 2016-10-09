using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using practice.Medium.Mediators;

namespace practice.Medium.Colleagues
{
    public abstract class AbstractColleague
    {
        protected AbstractMediator mediator;

        public object Data { get; set; }

        public virtual void Update(AbstractColleague source)
        {
            Type t = this.GetType();
            var updateMethod = t.GetMethod("UpdateBy" + source.GetType().Name,BindingFlags.Instance | BindingFlags.NonPublic);
            updateMethod.Invoke(this, new object[] { source });
        }

        protected abstract void UpdateByColleagueA(AbstractColleague source);

        protected abstract void UpdateByColleagueB(AbstractColleague source);

        protected abstract void UpdateByColleagueC(AbstractColleague source);


        public virtual void Changed()
        {
            mediator.NotifyChange(this);
        }

    }
}
