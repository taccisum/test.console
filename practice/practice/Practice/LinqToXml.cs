using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace practice.Practice
{
    public class LinqToXml : Test
    {
        public LinqToXml(string testName = "Linq to xml test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
        }

        protected override void RealTestOutPut()
        {
            XDocument xd = XDocument.Load( System.AppDomain.CurrentDomain.BaseDirectory + "Xml/Data1.xml");
            var list = from s in xd.Descendants("Sword")
                join w in xd.Descendants("Wand")
                    on (float) s.Attribute("Weight") equals (float) w.Attribute("Weight")
                    let sw = (float) s.Attribute("Weight")
                    orderby sw descending 
                select new
                {
                    SwordWeight = sw,
                    SwordQuality = (string) s.Attribute("Quality"),
                    WandWeight = (float) w.Attribute("Weight"),
                    WandQuality = (string) w.Attribute("Quality")
                };


            println("Query list: ");
            foreach (var item in list)
            {
                println("Sword: " + item.SwordWeight + "，" + item.SwordQuality + "。　　"+"Wand: " + item.WandWeight + "，" + item.WandQuality);
            }
        }
    }

}
