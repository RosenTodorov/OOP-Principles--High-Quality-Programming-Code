using System;
using System.Linq;

    namespace Minesweeper
    {       
        public class PlayerDetails
        {
            private string name;
            private int score;

            public PlayerDetails()
            {
            }

            public PlayerDetails(string name, int score)
            {
                this.name = name;
                this.score = score;
            }

            public string Name
            {
                get
                {
                    return this.name;
                }

                set
                {
                    this.name = value;
                }
            }

            public int Score
            {
                get
                {
                    return this.score;
                }

                set
                {
                    this.score = value;
                }
            }
        }
    }
}