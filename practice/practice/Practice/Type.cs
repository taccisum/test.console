using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using practice.Models;

namespace practice.Practice
{
    public class _Type : Test
    {
        public _Type(string testName = "Type test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
        }

        protected override void RealTestOutPut()
        {
            println("获取当前应用程序域中所有公共类型");
            Assembly assem= Assembly.GetEntryAssembly();
            var ts = assem.ExportedTypes;
            println("遍历并找出所有实现了ITest接口或继承自Test类的类型");
            foreach (var type in ts)
            {
                var itest = typeof (ITest);
                var test = typeof (Test);
                if (type.GetInterfaces().Contains(itest))
                {
                    println("类型" + type.FullName + "实现了接口" + itest.FullName);
                }
                if (type.BaseType == test)
                {
                    println("类型" + type.FullName + "继承自" + test.FullName);
                }
                
            }

            println("");
            var swordTypeName = "practice.Models.Sword";
            println("从所有公共类中搜索类" + swordTypeName);
            Type st = ts.FirstOrDefault(t => t.FullName == swordTypeName);
            if (st == null)
            {
                println("未找到类型" + swordTypeName);
            }
            else
            {
                println("成功获取类型" + swordTypeName + "，创建一个相应的实例");
                object o = System.Activator.CreateInstance(st, 1.23f, "紫色");//创建实例
                println("创建成功，尝试调用ToString()方法，输出如下：");
                System.Reflection.MethodInfo mi = st.GetMethod("ToString");//获得方法

                println(mi.Invoke(o, new object[] { }).ToString()); //调用方法
            }


            
        }
    }
}
