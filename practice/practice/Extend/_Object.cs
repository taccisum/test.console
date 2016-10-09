using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Extend
{
    public static class _Object
    {

        public static void Write(this object obj)
        {
            Console.Write(obj);
        }
        public static void WriteLine(this object obj)
        {
            Console.WriteLine(obj);
        }

        public static void WriteLineEach(this IEnumerable<object> collections)
        {
            foreach (var obj in collections)
            {
                obj.WriteLine();
            }
        }

        public static void WriteEach(this IEnumerable<object> collections)
        {
            foreach (var obj in collections)
            {
                obj.Write();
            }
        }
    }
}
