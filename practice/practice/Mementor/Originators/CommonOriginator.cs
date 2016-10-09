using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Mementor.CareTakers;
using practice.Mementor.Mementos;

namespace practice.Mementor.Originators
{
    public class CommonOriginator : AbstractOriginator
    {
        public CommonOriginator(int maxMementoNum)
        {
            _careTaker = new CommonCareTaker(maxMementoNum);
        }


        public override void CreateMemento()
        {
            _careTaker.Push(new CommonMemento(State));
        }

        public void ModifyStateAndPrint(object newState)
        {
            State = newState;
            CreateMemento();
            Console.WriteLine("State has been modify, now: " + ToString());
        }

        public void RollBackAndPrint(int back)
        {
            for (int i = 0; i < back; i++)
            {
                RollBack();
            }

            Console.WriteLine("State has been roll-back " + back + " times, now: " + ToString());
        }

        public void ReDoAndPrint(int forward)
        {
            for (int i = 0; i < forward; i++)
            {
                ReDo();
            }

            Console.WriteLine("State has been re-do " + forward + " times, now: " + ToString());
        }
    }
}
