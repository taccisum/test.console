using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Practice
{
    public class ObservableTest : Test
    {
        public ObservableTest(string testName = "C# IObservable interface test", bool isShow = true, bool isMeasureTime = true)
            : base(testName, isShow, isMeasureTime)
        {
        }

        protected override void RealTestOutPut()
        {
            var tracker = new DataTracker();
            var tracker1 = new DataObserver("tracker1");
            var tracker2 = new DataObserver("tracker2");
            tracker1.Subscribe(tracker);
            tracker2.Subscribe(tracker);

            tracker.Track(new DataSource() {a = 888});
            tracker1.UnSubscribe();
            tracker.Track(new DataSource() { a = 233 });
            tracker.Track(null);
        }


        protected class DataSource
        {
            public int a;


            public override string ToString()
            {
                var result = "";
                result += this.a;
                return result;
            }
        }

        protected class DataTracker: IObservable<DataSource>
        {
            private List<IObserver<DataSource>> _observers;

            public DataTracker()
            {
                _observers = new List<IObserver<DataSource>>();
            }


            public void Track(DataSource data)
            {
                foreach (var observer in _observers)
                {
                    if (data != null)
                    {
                        observer.OnNext(data);
                    }
                    else
                    {
                        observer.OnError(new ArgumentNullException("data"));
                    }
                }
            }



            public IDisposable Subscribe(IObserver<DataSource> observer)
            {
                if (!_observers.Contains(observer))
                {
                    _observers.Add(observer);
                }
                return new UnSubscribe<DataSource>(_observers, observer);
            }
        }

        protected class UnSubscribe<T> : IDisposable
        {
            private List<IObserver<T>> _observers;
            private IObserver<T> _observer;
            public UnSubscribe(List<IObserver<T>> observers, IObserver<T> observer)
            {
                _observers = observers;
                _observer = observer;
            }
            public void Dispose()
            {
                if (_observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                }
            }
        }

        

        protected class DataObserver : IObserver<DataSource>
        {
            private string _name;
            private IDisposable _unsubscriber;

            public DataObserver(string name)
            {
                _name = name;
            }

            public void OnNext(DataSource value)
            {
                Console.WriteLine("DataObserver " + _name + " has received a data, Value: " + value.ToString());
            }

            public void OnError(Exception error)
            {
                Console.WriteLine("DataObserver " + _name + " receive an exception, error info: " + error.Message);
            }

            public void OnCompleted()
            {
                throw new NotImplementedException();
            }

            public void Subscribe(IObservable<DataSource> tracker)
            {
                _unsubscriber = tracker.Subscribe(this);
            }

            public void UnSubscribe()
            {
                _unsubscriber.Dispose();
                Console.WriteLine(">> "+_name + " has been unsubscribed");
            }
        }
    }
}
