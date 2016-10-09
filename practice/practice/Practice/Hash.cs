using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Models;

namespace practice.Practice
{
    public class Hash : Test
    {
        public Hash(string testName = "Hashtable test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
        }

        protected override void RealTestOutPut()
        {
            Sword shortSword = new Sword(1.08f, "蓝色品质");
            Sword greatSword = new Sword(3.02f, "紫色品质");

            Hashtable hashtable = new Hashtable();
            Console.WriteLine("正在添加100w条数据到hashtable");
            watch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                hashtable.Add(i, shortSword);
            }
            hashtable.Add(greatSword.Quality, greatSword);
            watch.Stop();
            Console.WriteLine("添加完成，用时: " + watch.Elapsed);
            Console.WriteLine("从添加数据后的hashtable中查找Quality为紫色的Sword数据");
            watch.Restart();
            var obj = hashtable[greatSword.Quality] as Sword;
            watch.Stop();
            Console.WriteLine("查找完成：" + obj.ToString() + "，用时: " + watch.Elapsed);



            Console.WriteLine();
            List<Sword> swordList = new List<Sword>();
            Console.WriteLine("正在添加100w条数据到swordList");
            watch.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                swordList.Add(shortSword);
            }
            swordList.Add(greatSword);
            
            watch.Stop();
            Console.WriteLine("添加完成，用时: " + watch.Elapsed);
            Console.WriteLine("从添加数据后的swordList中查找Quality为紫色的Sword数据");
            watch.Restart();
            var obj1 = swordList.Find(s => s.Quality == greatSword.Quality) as Sword;
            watch.Stop();
            Console.WriteLine("查找完成，" + obj1.ToString() + "，用时: " + watch.Elapsed);
            
        }
    }
}
