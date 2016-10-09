using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace practice.Registry
{
    public class SingletonRegistry
    {
        public static SingletonRegistry REGISTRY = new SingletonRegistry();
        private SingletonRegistry() { }



        private Dictionary<string, object> _map = new Dictionary<string, object>();


        public object GetInstance(string cls)
        {
            Type t = Type.GetType(cls);
            object instance = null;

            if (_map.ContainsKey(cls))
            {
                return _map[cls];
            }
            else
            {
                try
                {
                    ConstructorInfo[] constructorInfoArray = t.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    ConstructorInfo noParameterConstructorInfo = null;
                    foreach (ConstructorInfo constructorInfo in constructorInfoArray)
                    {
                        ParameterInfo[] parameterInfoArray = constructorInfo.GetParameters();
                        if (0 == parameterInfoArray.Length)
                        {
                            noParameterConstructorInfo = constructorInfo;
                            break;
                        }
                    }
                    instance = noParameterConstructorInfo.Invoke(null);

                }
                catch (ArgumentNullException ane)
                {
                    
                }
                catch (Exception ex)
                {
                    
                    throw;
                }

                _map.Add(cls, instance);
            }


            return instance;


        }

    }
}
