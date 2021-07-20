using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndEventHandler
{
    public delegate void Notify();

    public class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted; 

        public void StartProcess()
        {
            //Mach was

            OnProcessCompleted();
        }

        protected virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke();
        }
    }
}
