using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events
{
    public class Publisher
    { 
        public event EventHandler<CustomEvent> RaiseCustomEvent; 

        public void DoSomething() 
        { 
            OnRaiseCustomEvent(new CustomEvent("Hello there, stranger!"));
        } 
        protected virtual void OnRaiseCustomEvent(CustomEvent e)
        { 
            EventHandler<CustomEvent> handler = RaiseCustomEvent;
            
            if (handler != null) 
            { 
                e.Message += String.Format(" at {0}", DateTime.Now.ToString()); handler(this, e); 
            }
        }
    }
}