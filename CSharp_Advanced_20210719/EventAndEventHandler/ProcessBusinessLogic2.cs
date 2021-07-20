using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndEventHandler
{
    public class ProcessBusinessLogic2
    {
        public event EventHandler ProcessCompleted;
        public event EventHandler ProcessCompletedNew;
        public void StartProcess()
        {
            //Mach was




            MyEventArg myEvent = new MyEventArg();
            myEvent.Uhrzeit = DateTime.Now;

            OnProcessCompletedNew(myEvent);
            OnProcessCompleted(EventArgs.Empty);
        }

        protected virtual void OnProcessCompleted(EventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }

        protected virtual void OnProcessCompletedNew(MyEventArg e)
        {
            ProcessCompletedNew?.Invoke(this, e);
        }

    }


    public class MyEventArg : EventArgs
    {
        public DateTime Uhrzeit { get; set; }
    }
}
