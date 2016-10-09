using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using practice.Models;
using practice.Practice;

namespace practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var def = true;
            List<ITest> testList = new List<ITest>();

            testList.Add(new Hash(isShow: false));
            testList.Add(new Compare(isShow: false));
            testList.Add(new LinqToXml(isShow: true));
            testList.Add(new Boxing<Sword>(new Sword(1.00f, "测试实例"), isShow: true, testNum: 999999));
            testList.Add(new Boxing<int>(999, isShow: false, testNum: 88888));
            testList.Add(new Genericity<Sword>(new Sword(2.22f, "紫"), new Sword(2.34f, "蓝"), isShow: false));
            testList.Add(new Genericity<Sword>(isShow: false));
            testList.Add(new UploadFiles("http://localhost:51103//ShopEmployeeUser/UploadPortraitImg", new List<string>()
                    {
                        @"E:\img\logo.png",
                    }, isShow: false, isMeasureTime: true));
            testList.Add(new UploadFiles("http://localhost:51103//ShopEmployeeUser/UploadPortraitImg", new List<string>()
                    {
                        @"E:\img\Google_Chrome_1024px_1175195_easyicon.net.png",
                        @"E:\img\logo.png",
                        @"E:\img\logo.png",
                        @"E:\icon\debug_32px.ico"
                    }, isShow: false, isMeasureTime: true));
            testList.Add(new Iterator(isShow: false, isMeasureTime: true));
            testList.Add(new Lambda());
            testList.Add(new LinqRanking());
            testList.Add(new Measure("practice.Models.Sword", "MeasureTest", "hello,world,2016", isMeasureTime: false));
            testList.Add(new SingletonRegistryTest());
            testList.Add(new CompositePattern());
            testList.Add(new MediatorPattern());
            testList.Add(new MementoPattern());
            testList.Add(new ObjCache());
            testList.Add(new LinqTest1());
            testList.Add(new ObservableTest());
            testList.Add(new InnerClassTest());
            testList.Add(new DataGenerator());
            testList.Add(new IoC());
            testList.Add(new Redis());
            
            foreach (var test in testList)
            {
                test.DoTest();
            }

            Console.ReadKey();

        }

    }

}
