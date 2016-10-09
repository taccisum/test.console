using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Practice;

namespace practice.Models
{
    public class Sword : DCP, IComparable<Sword>
    {
        public Sword()
        {
            Weight = 1.00f;
            Quality = "白色";
        }

        public Sword(float weight, string quality)
        {
            Weight = weight;
            Quality = quality;
        }
        
        public float Weight { get; set; }
        public string Quality { get; set; }

        public void Attack()
        {
            
        }

        public int CompareTo(Sword other)
        {
            return this.Weight.CompareTo(other.Weight);
        }

        public override string ToString()
        {
            return "重" + this.Weight.ToString("F") + "kg，" + Quality;
        }


        public string MeasureTest(string s1, string s2, int i1)
        {

            return s1 + " " + s2 + " " + i1;
        }

        public override object Default()
        {
            return new Sword(((float) RandonData.RandomInt(0, 1000))/100, RandonData.RandonString(10));
        }
    }
}
