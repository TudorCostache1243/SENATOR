using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENATOR.Units
{
    public class Soldier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int TotalXP { get; set; }
        public Ranks Rank { get; set; }
        public Dictionary<string, int> Specializations { get; set; }

        public Soldier()
        {
            TotalXP = 0;
            Specializations = new Dictionary<string, int>();
        }

        public int CurrentXP => TotalXP - GetXPThresholdForRank(Rank);

        // Calculate XP needed for next rank
        public int XPNeededForNextRank => GetXPThresholdForRank(Rank + 1) - CurrentXP;

        // Get XP threshold for a given rank
        private int GetXPThresholdForRank(Ranks rank)
        {
            switch (rank)
            {
                case Ranks.Recruit:
                    return 0;
                case Ranks.Private:
                    return 100;
                case Ranks.Corporal:
                    return 300; 
                case Ranks.Sergeant:
                    return 700; 
                case Ranks.Lieutenant:
                    return 1200; 
                case Ranks.Captain:
                    return 2000;
                case Ranks.Major:
                    return 3500;
                case Ranks.Colonel:
                    return 5000; 
                default:
                    return 0; // Default threshold
            }
        }

        public void AddSpecialization(string specializationName, int level, Specialization specialization)
        {
            if (Specializations.ContainsKey(specializationName))
            {
                // If the specialization exists, check if the new level is higher
                if (Specializations[specializationName] < level)
                {
                    // Update the level and award XP
                    Specializations[specializationName] = level;
                    AwardXP(specialization.XPRewards[level]);
                }
            }
            else
            {
                // Add new specialization and award XP
                Specializations.Add(specializationName, level);
                AwardXP(specialization.XPRewards[level]);
            }
        }

        private void AwardXP(int xp)
        {
            TotalXP += xp;
            Console.WriteLine($"{Name} awarded {xp} XP for achieving a new level!");
        }
    }
    
}
