using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace practice
{
    public class QuartzDemo
    {
        static void Main(string[] args)
        {
            ISchedulerFactory schf = new StdSchedulerFactory();
            IScheduler sch = schf.GetScheduler();
            sch.Start();
            //IJobDetail job = JobBuilder.Create<TestJob>().Build();
            //ISimpleTrigger st = (ISimpleTrigger)TriggerBuilder.Create().WithSimpleSchedule(x => x.WithIntervalInSeconds(3).WithRepeatCount(int.MaxValue)).Build();
            //sch.ScheduleJob(job, st);
            //sch.Start();
            Debug.WriteLine("job start");
        }
    }

    public class TestJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("tac");
        }
    }
}
