using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events
{
    public class Subscriber
    {
        private string id;
        public Subscriber(string ID, Publisher pub)
        {
            id = ID;
            pub.RaiseCustomEvent += HandleCustomEvent;
        }
        void HandleCustomEvent(object sender, CustomEvent e)
        {
            Console.WriteLine(id + " received this message: {0}", e.Message);
        }
    }
}