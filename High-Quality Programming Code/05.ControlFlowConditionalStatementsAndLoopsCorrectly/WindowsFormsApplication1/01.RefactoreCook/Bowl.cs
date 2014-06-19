namespace RefactoreCook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Bowl
    {
        private IList<Vegetable> content;

        public Bowl()
        {
            this.content = new List<Vegetable>();
        }

        public void Add(Vegetable vegetableToPullInBowl)
        {
            this.content.Add(vegetableToPullInBowl);
        }
    }
}
