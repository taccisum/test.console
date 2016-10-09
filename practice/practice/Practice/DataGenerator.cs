using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Models;

namespace practice.Practice
{
    public class DataGenerator : Test
    {
        public DataGenerator(string testName = "Data generator test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
        }

        protected override void RealTestOutPut()
        {
            var ge = new Generator<Sword>();
            var sword1 = ge.Create();
            var sword2 = ge.Create();
            println(sword1.ToString());
            println(sword2.ToString());
        }



        private class Generator<T> where T : class, IDefault, new()
        {
            public T Create()
            {
                return new T().Default() as T;
            }


        }

    }

    public static class RandonData
    {
        private static Random _r = new Random();
        private static char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();


        public static int RandomInt(int minValue, int maxValue)
        {
            var val = _r.Next(minValue, maxValue);
            return val;
        }

        public static char RandomChar()
        {
            var val = _r.Next(0, 51);
            return chars[val];
        }

        public static string RandonString(int length)
        {
            if (length <= 0)
            {
                return "";
            }
            else
            {
                StringBuilder sbd = new StringBuilder();
                for (int i = 0; i < length; i++)
                {
                    sbd.Append(RandomChar());
                }
                return sbd.ToString();
            }
        }
    }
}
