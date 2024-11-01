﻿using System;
using System.Collections.Generic;

namespace SENATOR.Units
{
    public class Specialization
    {
        public string Name { get; set; }
        public Ranks RequiredRank { get; set; }
        public Dictionary<int, int> XPRewards { get; set; }

        // Constructor that sets XP rewards automatically
        public Specialization(string name, Ranks requiredRank)
        { 
            Name = name;
            RequiredRank = requiredRank;
            XPRewards = new Dictionary<int, int>();
            SetXPRewards();
        }

        // Method to set XP rewards for each level based on specialization
        private void SetXPRewards()
        {
            switch (Name)
            {
                case "Basic Training":
                    XPRewards.Add(0, 50); 
                    XPRewards.Add(1, 100);
                    XPRewards.Add(2, 200);
                    XPRewards.Add(3, 300);
                    break;
                case "Outdoor Survival Training":
                    XPRewards.Add(0, 50);
                    XPRewards.Add(1, 150);
                    XPRewards.Add(2, 250);
                    XPRewards.Add(3, 400);
                    break;
                case "Sniper Training":
                    XPRewards.Add(0, 0);   
                    XPRewards.Add(1, 200); 
                    XPRewards.Add(2, 400); 
                    XPRewards.Add(3, 600); 
                    break;
                default:
                    break;
            }
        }
    }

}
