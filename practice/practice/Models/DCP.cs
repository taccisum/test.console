using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Models
{
    public class DCP : IDefault
    {
        public Guid Id { get; set; }
        public virtual object Default()
        {
            return null;
        }
    }
}
