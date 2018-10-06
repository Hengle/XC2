using GameDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestScenarios
{
    public class ElementComboTeams
    {
        //map is of first driver, second driver, third driver -> list of combos
        public Dictionary<Element, Dictionary<Element, Dictionary<Element, List<ComboOrder>>>> ElementGraph { get; }
        public List<ElementTeam> ElementTeams { get; set; }
        private List<Driver> Drivers { get; set; }
        public ElementComboTeams(List<Driver> drivers)
        {
            ElementGraph = new Dictionary<Element, Dictionary<Element, Dictionary<Element, List<ComboOrder>>>>();
            Drivers = drivers;
            Fill(Drivers[0], Drivers[1], Drivers[2]);
            GetTeamCombos(Drivers[0], Drivers[1], Drivers[2]);
        }

        public void PrintTeams()
        {
            foreach (var team in ElementTeams)
            {
                var distinctEndings = GetDistinctFinishableElements(team.FinishableElements);
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
            var output = "";
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
            return GetDistinctFinishableElements(combos).Count();
        }

        private List<Element> GetDistinctFinishableElements(List<ComboOrder> combos)
        {
            return combos.Select(x => x.Third).Distinct().ToList();
        }

        public List<Blade> GetUniqueDrivers(List<List<Blade>> blades)
        {
            var newList = new List<Blade>();

            foreach (var group in blades)
            {
                newList.Add(group[0]);
            }

            return newList;
        }

        public List<ReactionTeam> GetReactionTeams(BladeTeam team)
        {
            // get all unique sets of blade combinations, (this is N choose 1 not N choose K)
            var reactionTeams = new List<ReactionTeam>();

            // list {1}, {2, 3}, {4} => {1, 2, 4}, {1, 3, 4}

            var first = GetUniqueDrivers(team.First);
            var second = GetUniqueDrivers(team.Second);
            var third = GetUniqueDrivers(team.Third);

            reactionTeams.Add(new ReactionTeam(first, second, third, team.FinishableElements));

            return reactionTeams;
        }

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


        public void GetTeamCombos(Driver one, Driver two, Driver three)
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
                        var finishableElements = GetFinishableElements(firstTeamList, secondTeamList, thirdTeamList);
                        ElementTeams.Add(new ElementTeam(firstTeamList, secondTeamList, thirdTeamList, finishableElements));
                    }
                }
            }

            ElementTeams = ElementTeams
                .OrderByDescending(x => GetDistinctFinishableElementsCount(x.FinishableElements))
                .ThenByDescending(x => x.FinishableElements.Count()).ToList();
        }

        public List<ComboOrder> GetFinishableElements(IEnumerable<Element> first, IEnumerable<Element> second, IEnumerable<Element> third)
        {
            var finishableElements = new List<ComboOrder>();

            foreach(var a in first)
            {
                foreach(var b in second)
                {
                    foreach(var c in third)
                    {
                        finishableElements.AddRange(ElementGraph[a][b][c]);
                    }
                }
            }

            return finishableElements;
        }

        //no value in having multiple blades of the same element type
        public void Fill(Driver one, Driver two, Driver three)
        {
            foreach (var oneBlade in one.Blades)
            {
                foreach (var twoBlade in two.Blades)
                {
                    foreach (var threeBlade in three.Blades)
                    {
                        Add(oneBlade, twoBlade, threeBlade);
                    }
                }
            }
        }

        public void Add(Blade one, Blade two, Blade three)
        {
            Add(one.Element, two.Element, three.Element);
        }

        public void Add(Element one, Element two, Element three)
        {
            if (!ElementGraph.ContainsKey(one))
            {
                ElementGraph.Add(one, new Dictionary<Element, Dictionary<Element, List<ComboOrder>>>());
            }

            if (!ElementGraph[one].ContainsKey(two))
            {
                ElementGraph[one].Add(two, new Dictionary<Element, List<ComboOrder>>());
            }

            if (!ElementGraph[one][two].ContainsKey(three))
            {
                //we only need to calculate the number of finishable elements if we haven't seen it before
                ElementGraph[one][two].Add(three, FinishableElements(one, two, three));
            }
        }

        public List<ComboOrder> FinishableElements(Blade one, Blade two, Blade three)
        {
            return FinishableElements(one.Element, two.Element, three.Element);
        }

        //The list of finishable elements
        //note: this doesnt help disambiguate if multiple elements can combine into the same final element in more then one way
        public List<ComboOrder> FinishableElements(Element one, Element two, Element three)
        {
            var combos = CanFinish(one, two, three);
            combos.AddRange(CanFinish(two, one, three));
            combos.AddRange(CanFinish(three, one, two));
            return combos;
        }

        //A combo can be finished if there is a combo entry that can do elements one and two in order for the given target element
        public List<ComboOrder> CanFinish(Element targetElement, Element one, Element two)
        {
            var elements = new List<Element>();
            var comboEntry = GameRules.ComboList.Definition.First(x => x.ComboFinishType == targetElement);
            var combos = comboEntry.ComboOrder.Where(x => (x.First == one && x.Second == two) || (x.First == two && x.Second == one));
            return combos.ToList();
        }
    }
}
