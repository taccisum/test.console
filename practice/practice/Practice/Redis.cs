using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Extend;
using ServiceStack.Redis;
using ServiceStack.Text;

namespace practice.Practice
{
    public class Redis : Test
    {
        public Redis(string testName = "Redis client test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
        }


        protected override void RealTestOutPut()
        {
            RedisClient client = new RedisClient("localhost", 6379);

            "tac's value is: ".Write();
            client.Get<object>("tac").WriteLine();
            client.Increment("tac", 1);

            "now changed, tac's value is: ".Write();
            client.Get<object>("tac").WriteLine();


            "ltac's value is: ".WriteLine();
            client.GetRangeFromList("ltac", 0, -1).WriteLineEach();
            client.AddItemToList("ltac", "test" + client.Get<object>("tac"));

            "now changed, ltac's value is: ".WriteLine();
            client.GetRangeFromList("ltac", 0, -1).WriteLineEach();



        }
    }
}
