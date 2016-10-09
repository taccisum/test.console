using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practice.Mementor.Mementos;
using practice.Mementor.Originators;

namespace practice.Mementor.CareTakers
{
    public abstract class  AbstractCareTaker
    {
        protected List<AbstractMemento> mementoes = new List<AbstractMemento>();
        protected int _currentIndex;
        protected int _maxItems;

        public virtual void Push(AbstractMemento item)
        {
            var oldCount = mementoes.Count;

            if (_currentIndex < oldCount - 1)
            {
                mementoes.RemoveRange(_currentIndex + 1, oldCount - _currentIndex - 1);
            }


            if (mementoes.Count >= _maxItems)
            {
                mementoes.Remove(mementoes[0]);
            }
            else
            {
                _currentIndex++;
            }

            mementoes.Add(item);
            
        }

        protected virtual AbstractMemento GetMemento(int index)
        {
            return mementoes[index];
        }

        public virtual void RollBack(AbstractOriginator obj)
        {
            if (_currentIndex <= 0)
                return;

            obj.State = GetMemento(--_currentIndex).State;
        }

        public virtual void ReDo(AbstractOriginator obj)
        {
            if (_currentIndex >= mementoes.Count - 1)
                return;

            obj.State = GetMemento(++_currentIndex).State;
        }
    }
}
