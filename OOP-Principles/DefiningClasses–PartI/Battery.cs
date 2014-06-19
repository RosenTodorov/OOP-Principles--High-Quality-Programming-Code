using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses_PartI
{
    public enum BatteryType
    {
        LiIon, NiMh, NiCd
    }

    public class Battery
    {
        // Declaring private fields
        private BatteryType batteryTexture;
        private string model;
        private double? hoursIdle;
        private double? hoursTalk;

        // Defining constructors
        public Battery(BatteryType texture, string model, double hoursIdle, double hoursTalk)
        {
            this.batteryTexture = texture;
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
        }

        public Battery(BatteryType texture)
        {
            this.batteryTexture = texture;
            this.model = null;
            this.hoursIdle = null;
            this.hoursTalk = null;
        }

        //Defining properties
        public BatteryType BatteryTexture
        {
            get { return this.batteryTexture; }
            set { this.batteryTexture = value; }
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException();
                else
                    this.model = value;
            }
        }

        public double? HoursIdle
        {
            get { return this.hoursIdle; }
            set
            {
                if (value == null || value >= 0)
                {
                    this.hoursIdle = value;
                }
                else
                    throw new ArgumentException();
            }
        }

        public double? HoursTalk
        {
            get { return this.hoursTalk; }
            set
            {
                if (value == null || value >= 0)
                {
                    this.hoursTalk = value;
                }
                else
                    throw new ArgumentException();
            }
        }
    }
}

