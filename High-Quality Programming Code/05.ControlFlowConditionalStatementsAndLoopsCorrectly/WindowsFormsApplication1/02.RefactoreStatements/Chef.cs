namespace RefactoreStatements.Potatoes
{
    using System;
    using System.Linq;

    public class Chef
    {
        public void Cook()
        {
            Potato goodRawPotato = new Potato();
            PotatoPeeler(goodRawPotato);

            if (goodRawPotato != null)
            {
                if (!goodRawPotato.HasNotBeenPeeled && !goodRawPotato.IsRotten)
                {
                    CookPotato(goodRawPotato);
                }
            }
        }


        private static void PotatoPeeler(Potato toBePeeled)
        {
            toBePeeled.HasNotBeenPeeled = false;
        }

        private static void CookPotato(Potato toBePeeled)
        {
            toBePeeled.IsCooked = true;
        }
    }
}