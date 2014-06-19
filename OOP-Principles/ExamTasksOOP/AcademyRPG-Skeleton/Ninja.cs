using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyRPG
{
   public class Ninja : Character, IFighter, IGatherer
    {
       public Ninja(string name, Point position, int owner)
           : base(name, position, owner)
       {
           this.HitPoints = 1;
       }
       
       private int attackPoints;

        public int AttackPoints
        {
            get { return this.attackPoints; }
        }

        public int DefensePoints
        {
            get { return int.MaxValue; } //return 0
        }
 //Ninja should always attack the target, which is not neutral, does not belong to the same player, and has the highest HitPoints of all the available targets
        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
           // int maxHitPoints = availableTargets.Max(t => t.HitPoints);  //i kak da namerim maksimuma ot tqh ili nai-golemite to4ki
            WorldObject target = availableTargets
                .OrderByDescending(t => t.HitPoints)
                .FirstOrDefault(t => t.Owner != 0 && t.Owner != this.Owner);
            return availableTargets.IndexOf(target);
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
 // For each lumber resource the Ninja has gathered, its AttackPoints should increase by the resource’s quantity
                this.attackPoints += resource.Quantity;
                return true;
            }
 // For each stone resource the Ninja has gathered, its AttackPoints should increase by the resource’s quantity multiplied by 2. 
            else if (resource.Type == ResourceType.Stone)
            {
                this.attackPoints += resource.Quantity * 2;
                return true;
            }

            return false;
        }
    }
}
