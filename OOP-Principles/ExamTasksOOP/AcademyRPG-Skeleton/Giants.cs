using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        private bool isEnhanced;
        private int attackPoints;

        public Giant(string name, Point position)
            : base(name, position, 0) //owner e 0 za6toto vinagi trqbva da e neutralen
        {
            this.attackPoints = 150;
            this.isEnhanced = false;
            this.HitPoints = 200;
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
        }

        public int DefensePoints
        {
            get { return 80; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool TryGather(IResource resource) //gledame ot darvarq
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (!isEnhanced)
                {
                    this.attackPoints += 100;
                    this.isEnhanced = true;
                }
                return true;
            }

            return false;
        }
    }
}
