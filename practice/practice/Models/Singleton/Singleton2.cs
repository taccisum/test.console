using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Registry;

namespace practice.Models.Singleton
{
    public class Singleton2
    {
        protected Singleton2()
        {
            
        }

        public static Singleton2 GetInstance()
        {
            return (Singleton2)SingletonRegistry.REGISTRY.GetInstance(typeof(Singleton2).FullName);
        }

        public override string ToString()
        {
            return "Singleton2 instance";
        }
    }
}
