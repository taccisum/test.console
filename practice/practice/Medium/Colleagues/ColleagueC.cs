using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Medium.Mediators;

namespace practice.Medium.Colleagues
{
    public class ColleagueC : AbstractColleague
    {
        public ColleagueC(AbstractMediator mediator)
        {
            this.mediator = mediator;
            this.mediator.AddColleague(this);
        }

        protected override void UpdateByColleagueA(AbstractColleague source)
        {
            Data = ((int) source.Data)/100;
        }

        protected override void UpdateByColleagueB(AbstractColleague source)
        {
            Data = ((int) source.Data)/10000;
        }

        protected override void UpdateByColleagueC(AbstractColleague source)
        {
        }
    }
}
