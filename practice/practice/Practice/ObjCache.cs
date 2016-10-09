using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using practice.Models;

namespace practice.Practice
{
    public class ObjCache : Test
    {
        private ObjectCache cache;

        public ObjCache(string testName = "Object cache test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
            cache = new MemoryCache("test1");
        }


        protected override void RealTestOutPut()
        {
            PrintCacheValue("test1");
            PrintCacheValue("test1");
            PrintCacheValue("test1");
            PrintCacheValue("test2");
            PrintCacheValue("test3");
            PrintCacheValue("test4");

        }

        private string GetValue(string key)
        {
            var content = cache[key] as string;
            if (content == null)
            {
                content = Guid.NewGuid().ToString();
                println("item " + KeyToStr(key) + " is not exist, now add " + KeyToStr(key) + " as new item, value " + content);

                var policy = new CacheItemPolicy() {AbsoluteExpiration = DateTime.Now.AddSeconds(3)};
                cache.Set(key, content, policy);
            }

            return content;
        }

        private void PrintCacheValue(string key)
        {
            println("Value of cache " + KeyToStr(key) + " is: " + GetValue(key));
        }

        private string KeyToStr(string key)
        {
            return "\"" + key + "\"";
        }
    }
}
