using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using practice.Models;

namespace practice.Practice
{
    public class Measure : Test
    {
        private string Cls { get; set; }
        private string Method { get; set; }
        public string Param { get; set; }

        public Measure(string cls, string method, string _params, string testName = "Measure test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
            Cls = cls;
            Method = method;
            Param = _params;
        }


        protected override void RealTestOutPut()
        {
            var obj = (JObject)JsonConvert.DeserializeObject("{\"resultCode\":\"-1\",\"resultValue\":{\"resultMsg\":\"[用户登录失败]\"},\"resultMsg\":\"[用户登录失败]\"}");
            

            //var assm = Assembly.Load("practice");
            var type = Type.GetType(Cls);
            //var types = assm.GetExportedTypes();
            //var type = types.FirstOrDefault(ty => ty.Name == Cls);
            var instance = Activator.CreateInstance(type);
            var method = type.GetMethod(Method);
            var args = Param.Split(',').ToList();
            object[] objs = new object[args.Count];
            for (int i = 0; i < args.Count; i++)
            {
                if (i == 2)
                {


                    var intCls = typeof (int);
                    var arg = Activator.CreateInstance(intCls);
                    arg = Int32.Parse(args[i]);
                    objs[i] = arg;
                }
                else
                {

                    objs[i] = args[i];
                }

            }
            
            watch.Restart();
            var result = method.Invoke(instance, objs) as string;
            watch.Stop();

            println(result);
            println("用时：" + watch.Elapsed.ToString());
        }


        /// <summary>
        /// 返回结果类
        /// </summary>
        /// <typeparam name="T">泛型集合</typeparam>
        public class Result<T>
        {
            //Response's Code
            public string resultCode { get; set; }

            //Response's Value
            public T resultValue { get; set; }

            public string resultMsg { get; set; }

            public static string success_msg = "操作成功";
            //private static Result<T> success_object = new Result<T>(((int)ResultCode.success).ToString(), "[" + success_msg + "]");

            //public static Result<T> success(T data)
            //{
            //    return success_object;
            //}


            public Result(string resultCode, string resultMsg)
            {
                this.resultCode = resultCode;
                this.resultMsg = resultMsg;
            }

            public Result(string resultCode, T resultValue)
            {
                this.resultCode = resultCode;
                this.resultValue = resultValue;
            }
            public Result(string resultCode, T resultValue, string resultMsg)
            {
                this.resultCode = resultCode;
                this.resultValue = resultValue;
                this.resultMsg = resultMsg;
            }
            public Result() { }
        }
    }
}
