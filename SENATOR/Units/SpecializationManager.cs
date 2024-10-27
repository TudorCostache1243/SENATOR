using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENATOR.Units
{
    public class SpecializationManager
    {
        public List<Specialization> Specializations { get; set; }

        public SpecializationManager()
        {
            Specializations = new List<Specialization>
        {
            new Specialization("Basic Training", Ranks.Private),
            new Specialization("Outdoor Survival Training", Ranks.Private),
            new Specialization("Sniper Training", Ranks.Sergeant)
        };
        }

        public void AddSpecialization(string specializationName, int level, Specialization specialization)
        {
            var existingSpecialization = Specializations.FirstOrDefault(s => s.Name == specializationName);

            if (existingSpecialization != null)
            {
                // If the specialization exists, check if the new level is higher
                if (existingSpecialization.XPRewards.ContainsKey(level))
                {
                    // Update the level and award XP
                    AwardXP(existingSpecialization.XPRewards[level]);
                }
            }
            else
            {
                // Add new specialization and award XP
                Specializations.Add(specialization);
                AwardXP(specialization.XPRewards[level]);
            }
        }

        private void AwardXP(int xp)
        {
            // Logic to award XP goes here
            Console.WriteLine($"Awarded {xp} XP!");
        }
    }
}
