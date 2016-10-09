using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Registry;

namespace practice.Models.Singleton
{
    public class Singleton1
    {
        protected Singleton1()
        {

        }

        public static Singleton1 GetInstance()
        {
            return (Singleton1) SingletonRegistry.REGISTRY.GetInstance(typeof (Singleton1).FullName);
        }


        public override string ToString()
        {
            return "Singleton1 instance";
        }
    }
}
