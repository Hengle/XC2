using GameDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Drivers
{
    public class ReactionTeam
    {
        public Dictionary<Reaction, int> ReactionMap { get; set; } = new Dictionary<Reaction, int>();
        public List<ComboOrder> FinishableElements { get; }
        public List<Blade> First { get; }
        public List<Blade> Second { get; }
        public List<Blade> Third { get; }

        public ReactionTeam(List<Blade> first, List<Blade> second, List<Blade> third, List<ComboOrder> finishableElements)
        {
            First = first;
            Second = second;
            Third = third;
            FinishableElements = finishableElements;

            var allBlades = new List<Blade>(first);
            allBlades.AddRange(second);
            allBlades.AddRange(third);

            // we dont care for these
            //ReactionMap.Add(Reaction.Knockback, 0);
            //ReactionMap.Add(Reaction.Blowdown, 0);
            ReactionMap.Add(Reaction.Break, 0);
            ReactionMap.Add(Reaction.Launch, 0);
            ReactionMap.Add(Reaction.Smash, 0);
            ReactionMap.Add(Reaction.Topple, 0);

            foreach (var blade in allBlades)
            {
                foreach (var reaction in blade.Reactions)
                {
                    // we dont care for these
                    if (reaction == Reaction.Blowdown || reaction == Reaction.Knockback)
                    {
                        continue;
                    }

                    ReactionMap[reaction]++;
                }
            }
        }

        public int ReactionTotal()
        {
            var counter = 0;
            foreach(var entry in ReactionMap)
            {
                counter += entry.Value;
            }

            return counter;
        }

        public string Print(List<Blade> bladeList)
        {
            var output = "";
            var max = bladeList.Count();
            for (var counter = 0; counter < max; counter++)
            {
                var entry = bladeList[counter];

                output += entry.Name;

                if (counter < max - 2)
                {
                    output += ", ";
                }
                else if (counter < max - 1)
                {
                    output += " and ";
                }
            }

            return output;
        }
    }
}
