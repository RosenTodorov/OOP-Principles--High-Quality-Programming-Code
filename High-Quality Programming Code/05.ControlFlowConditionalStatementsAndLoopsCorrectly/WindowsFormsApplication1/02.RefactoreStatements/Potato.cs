namespace RefactoreStatements.Potatoes
{
    using System;
    using System.Linq;

    public class Potato
    {
        public Potato()
        {
            this.HasNotBeenPeeled = true;
            this.IsCooked = false;
            this.IsRotten = false;
        }

        public bool HasNotBeenPeeled { get; set; }

        public bool IsRotten { get; set; }

        public bool IsCooked { get; set; }
    }
}