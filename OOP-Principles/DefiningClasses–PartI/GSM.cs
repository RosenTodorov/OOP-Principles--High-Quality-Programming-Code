using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses_PartI
{
    public class GSM
    {
        private string Model;
        private string Manufacturer;
        private decimal? Price;
        private string Owner;

        private Battery battery;
        private Display display;

        private List<Call> callHistory = new List<Call>();

        //Static field 
        static private GSM IPhone4S = new GSM("4s", "Apple", 900);

        //Defining some constructors
        public GSM(string model, string manufacturer, int price, string owner)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.battery = null;
            this.display = null;
        }

        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = null;
            this.Owner = null;
            this.battery = null;
            this.display = null;
        }

        public GSM(string model, string manufacturer, decimal price)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = null;
            this.battery = null;
            this.display = null;
        }

        public GSM(string model, string manufacturer, int price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.battery = battery;
            this.display = display;
        }

        // Declare properties
        public string model
        {
            get { return this.Model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException();
                else
                    this.Model = value;
            }
        }

        public string manufacturer
        {
            get { return this.Manufacturer; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException();
                else
                    this.Manufacturer = value;
            }
        }

        public decimal? price
        {
            get { return this.Price; }
            set
            {
                if (value == null || value >= 0)
                    this.price = value;
                else
                    throw new ArgumentException();
            }
        }

        public string owner
        {
            get { return this.Owner; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Owner not is correct");
                else
                    this.owner = value;
            }
        }

        // Call history property that holds the call objects        
        public List<Call> CallHistory
        {
            get { return this.callHistory; }
            set { this.callHistory = value; }
        }

        // Property of the static field iPhone        
        public static GSM iPhone
        {
            get { return IPhone4S; }
        }

        // Methods that handle calls in the call history - Add/Remove(via duration ^ number), Clear     
        public void AddCallToHistory(string number, int duration)
        {
            Call newCall = new Call(DateTime.Now, number, duration);
            callHistory.Add(newCall);
        }

        public void ClearCallHistory()
        {
            callHistory.Clear();
        }

        public void RemoveCallsFromHistoryViaNumber(string number)
        {
            for (int i = callHistory.Count - 1; i >= 0; i--)
            {
                if (callHistory[i].PhoneNumber == number)
                {
                    callHistory.RemoveAt(i);
                }
            }
        }

        public void RemoveCallsFromHistoryViaDuration(int duration)
        {
            for (int i = callHistory.Count - 1; i >= 0; i--)
            {
                if (callHistory[i].Duration == duration)
                {
                    callHistory.RemoveAt(i);
                }
            }
        }

        // Method that calculates the total price of the calls in the call history
        public double CalculateTotalPriceOfCalls(double pricePerMinute)
        {
            double totalPrice = 0;
            int totalDuration = 0;

            foreach (var call in callHistory)
            {
                totalDuration += call.Duration;
            }
            totalPrice = ((totalDuration / 60) * pricePerMinute);
            return totalPrice;
        }

        //method in the GSM class for displaying all information about it. Try to override ToString().
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(" Mobile phone device info ");
            sb.AppendLine("Manufacturer: " + this.manufacturer);
            sb.AppendLine("Model: " + this.model);
            if (this.price != null)
                sb.AppendLine("Price: " + this.price);
            if (this.owner != null)
                sb.AppendLine("Owner: " + this.owner);
            if (this.battery != null)
            {
                sb.AppendLine("Battery texture: " + this.battery.BatteryTexture);
                if (this.battery.Model != null) 
                    sb.AppendLine("Battery model: " + this.battery.Model); 
                if (this.battery.HoursIdle != null) 
                    sb.AppendLine("Battery strength in idle hours: " + this.battery.HoursIdle); 
                if (this.battery.HoursTalk != null)
                    sb.AppendLine("Battery strength in talk hours: " + this.battery.HoursTalk);
            } 
            if (this.display != null) 
            { 
                if (this.display.Size != null)                     
                    sb.AppendLine("Display size: " + this.display.Size); 
                if (this.display.NumberOfColors != null)                   
                    sb.AppendLine("Display colors: " + this.display.NumberOfColors); 
            } 
            return sb.ToString();
        }
    }
}
       

		 
			






















       





