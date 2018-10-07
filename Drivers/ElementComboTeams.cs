namespace Drivers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameDefinitions;

    public class ElementComboTeams
    {
        public ElementComboTeams(List<Driver> drivers)
        {
            Drivers = drivers;
            Fill(Drivers[0], Drivers[1], Drivers[2]);
            GetTeamCombos(Drivers[0], Drivers[1], Drivers[2]);
        }

        // map is of first driver, second driver, third driver -> list of combos
        public Dictionary<Element, Dictionary<Element, Dictionary<Element, List<ComboOrder>>>> ElementGraph { get; } = new Dictionary<Element, Dictionary<Element, Dictionary<Element, List<ComboOrder>>>>();

        public List<ElementTeam> ElementTeams { get; set; }

        private List<Driver> Drivers { get; set; }

        public void GroupPrintTeams()
        {
            var max = ElementTeams.Max(x => GetDistinctFinishableElementsCount(x.FinishableElements));
            Console.WriteLine("Combo Count: " + max);

            var maxTeams = ElementTeams.Where(x => GetDistinctFinishableElementsCount(x.FinishableElements) == 4);
            maxTeams = maxTeams.Where(x => x.First.Contains(Element.Light) && x.First.Contains(Element.Fire) && x.Second.Contains(Element.Water));
            var bladeTeams = maxTeams.Select(x => new BladeTeam(x, Drivers)).ToList();
            var reactionTeams = bladeTeams.SelectMany(x => GetReactionTeams(x));

            reactionTeams.OrderByDescending(x => GetDistinctFinishableElements(x.FinishableElements))
                .ThenByDescending(x => x.FinishableElements.Count())
                .ThenByDescending(x => x.ReactionTotal());

            foreach (var team in reactionTeams)
            {
                var distinctEndings = GetDistinctFinishableElements(team.FinishableElements);
                Console.WriteLine(distinctEndings.Count() + " Unique Combo Endings: " + string.Join(", ", distinctEndings));
                Console.WriteLine("Reaction Total: " + team.ReactionTotal());
                Console.WriteLine("Rex: " + team.Print(team.First));
                Console.WriteLine("Nia: " + team.Print(team.Second));
                Console.WriteLine("Tora: " + team.Print(team.Third));
                Console.WriteLine(team.FinishableElements.Count() + " Combo List Entries: \n" + Print(team.FinishableElements));
                Console.WriteLine();
            }
        }

        public void PrintTeams()
        {
            foreach (var team in this.ElementTeams)
            {
                var distinctEndings = this.GetDistinctFinishableElements(team.FinishableElements);
                Console.WriteLine(distinctEndings.Count() + " Unique Combo Endings: " + string.Join(", ", distinctEndings));
                Console.WriteLine("Rex: " + string.Join(", ", team.First.Select(x => x.ToString())));
                Console.WriteLine("Nia: " + string.Join(", ", team.Second.Select(x => x.ToString())));
                Console.WriteLine("Tora: " + string.Join(", ", team.Third.Select(x => x.ToString())));
                Console.WriteLine(team.FinishableElements.Count() + " Total Combos: " + Print(team.FinishableElements));
                Console.WriteLine();
            }
        }

        private string Print(List<ComboOrder> finishableElements)
        {
            var output = string.Empty;
            var max = finishableElements.Count();
            for (var counter = 0; counter < max; counter++)
            {
                var entry = finishableElements[counter];

                output += $"{entry.First.ToString()} -> {entry.Second.ToString()} -> {entry.Third.ToString()}";

                if (counter < max - 1)
                {
                    output += "\n";
                }
            }

            return output;
        }

            private int GetDistinctFinishableElementsCount(List<ComboOrder> combos)
        {
            return this.GetDistinctFinishableElements(combos).Count();
        }

        private List<Element> GetDistinctFinishableElements(List<ComboOrder> combos)
        {
            return combos.Select(x => x.Third).Distinct().ToList();
        }

        private List<Blade> GetUniqueDrivers(List<List<Blade>> blades)
        {
            var newList = new List<Blade>();

            foreach (var group in blades)
            {
                newList.Add(group[0]);
            }

            return newList;
        }

        private List<ReactionTeam> GetReactionTeams(BladeTeam team)
        {
            // get all unique sets of blade combinations, (this is N choose 1 not N choose K)
            var reactionTeams = new List<ReactionTeam>();

            // list {1}, {2, 3}, {4} => {1, 2, 4}, {1, 3, 4}
            var first = this.GetUniqueDrivers(team.First);
            var second = this.GetUniqueDrivers(team.Second);
            var third = this.GetUniqueDrivers(team.Third);

            reactionTeams.Add(new ReactionTeam(first, second, third, team.FinishableElements));

            return reactionTeams;
        }

        private void GetTeamCombos(Driver one, Driver two, Driver three)
        {
            var first = one.Blades.Select(x => x.Element).Distinct().DifferentCombinations(one.MaxBlades);
            var second = two.Blades.Select(x => x.Element).Distinct().DifferentCombinations(two.MaxBlades);
            var third = three.Blades.Select(x => x.Element).Distinct().DifferentCombinations(three.MaxBlades);

            ElementTeams = new List<ElementTeam>();

            foreach (var firstTeam in first)
            {
                var firstTeamList = firstTeam.ToList();
                foreach (var secondTeam in second)
                {
                    var secondTeamList = secondTeam.ToList();
                    foreach (var thirdTeam in third)
                    {
                        var thirdTeamList = thirdTeam.ToList();
                        var finishableElements = this.GetFinishableElements(firstTeamList, secondTeamList, thirdTeamList);
                        this.ElementTeams.Add(new ElementTeam(firstTeamList, secondTeamList, thirdTeamList, finishableElements));
                    }
                }
            }

            this.ElementTeams = this.ElementTeams
                .OrderByDescending(x => this.GetDistinctFinishableElementsCount(x.FinishableElements))
                .ThenByDescending(x => x.FinishableElements.Count()).ToList();
        }

        private List<ComboOrder> GetFinishableElements(IEnumerable<Element> first, IEnumerable<Element> second, IEnumerable<Element> third)
        {
            var finishableElements = new List<ComboOrder>();

            foreach (var a in first)
            {
                foreach (var b in second)
                {
                    foreach (var c in third)
                    {
                        finishableElements.AddRange(this.ElementGraph[a][b][c]);
                    }
                }
            }

            return finishableElements;
        }

        // no value in having multiple blades of the same element type
        private void Fill(Driver one, Driver two, Driver three)
        {
            foreach (var oneBlade in one.Blades)
            {
                foreach (var twoBlade in two.Blades)
                {
                    foreach (var threeBlade in three.Blades)
                    {
                        this.Add(oneBlade, twoBlade, threeBlade);
                    }
                }
            }
        }

        private void Add(Blade one, Blade two, Blade three)
        {
            this.Add(one.Element, two.Element, three.Element);
        }

        private void Add(Element one, Element two, Element three)
        {
            if (!this.ElementGraph.ContainsKey(one))
            {
                this.ElementGraph.Add(one, new Dictionary<Element, Dictionary<Element, List<ComboOrder>>>());
            }

            if (!this.ElementGraph[one].ContainsKey(two))
            {
                this.ElementGraph[one].Add(two, new Dictionary<Element, List<ComboOrder>>());
            }

            if (!this.ElementGraph[one][two].ContainsKey(three))
            {
                // we only need to calculate the number of finishable elements if we haven't seen it before
                this.ElementGraph[one][two].Add(three, this.FinishableElements(one, two, three));
            }
        }

        private List<ComboOrder> FinishableElements(Blade one, Blade two, Blade three)
        {
            return this.FinishableElements(one.Element, two.Element, three.Element);
        }

        // The list of finishable elements
        // note: this doesnt help disambiguate if multiple elements can combine into the same final element in more then one way
        private List<ComboOrder> FinishableElements(Element one, Element two, Element three)
        {
            var combos = this.CanFinish(one, two, three);
            combos.AddRange(this.CanFinish(two, one, three));
            combos.AddRange(this.CanFinish(three, one, two));
            return combos;
        }

        // A combo can be finished if there is a combo entry that can do elements one and two in order for the given target element
        private List<ComboOrder> CanFinish(Element targetElement, Element one, Element two)
        {
            var elements = new List<Element>();
            var comboEntry = GameRules.ComboList.Definition.First(x => x.ComboFinishType == targetElement);
            var combos = comboEntry.ComboOrder.Where(x => (x.First == one && x.Second == two) || (x.First == two && x.Second == one));
            return combos.ToList();
        }
    }
}
