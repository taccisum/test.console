using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Practice
{
    public class LinqRanking : Test
    {
        private class Levels
        {
            public string ID { get; set; } //编号
            public string Name { get; set; } //名称
            public int No { get; set; } //排名
        }
        private class Data
        {
            public string DID { get; set; } //编号
            public string LID { get; set; } //等级编号(关联Levels中的ID)
            public int Num { get; set; } //次数
        }



        public LinqRanking(string testName = "Linq ranking test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
        }

        protected override void RealTestOutPut()
        {
            List<Levels> li = new List<Levels>
            {
                new Levels {ID = "A", Name = "一般"},
                new Levels {ID = "B", Name = "严重"},
                new Levels {ID = "C", Name = "紧急"},
                new Levels {ID = "D", Name = "危急"},
                                new Levels {ID = "E", Name = "危急"}
            };


            List<Data> dli = new List<Data>
            {
                new Data {DID = "1", LID = "A", Num = 5},
                new Data {DID = "2", LID = "B", Num = 3},
                new Data {DID = "3", LID = "C", Num = 3}
            };
            var levels = li;
            var datas = dli;
            var distinctDatas = datas.Select(n => n.Num).Distinct().OrderByDescending(n => n).ToList();
            var paiming = from c in levels
                          join d in datas on
                          c.ID equals d.LID
                          into temp
                          from tt in temp.DefaultIfEmpty()
                          let no = (tt == null ? distinctDatas.Count + 1 : distinctDatas.IndexOf(tt.Num) + 1)
                          let num = (tt == null ? 0 : tt.Num)
                          select new { no, c.ID, num };

            
        }
    }
}
