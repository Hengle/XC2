namespace Drivers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameDefinitions;

    public class BladeTeam
    {
        public List<ComboOrder> FinishableElements { get; }
        public List<List<Blade>> First { get; }
        public List<List<Blade>> Second { get; }
        public List<List<Blade>> Third { get; }

        public BladeTeam(ElementTeam oldTeam, List<Driver> drivers)
        {
            First = GetBladesFromElements(oldTeam.First, drivers[0]);
            Second = GetBladesFromElements(oldTeam.Second, drivers[1]);
            Third = GetBladesFromElements(oldTeam.Third, drivers[2]);
            FinishableElements = oldTeam.FinishableElements;
        }

        public string Print(List<List<Blade>> bladeList)
        {
            var output = "";
            var max = bladeList.Count();
            for (var counter = 0; counter < max; counter++ )
            {
                var entry = bladeList[counter];

                if(entry.Count() > 1)
                {
                    output += "(" + string.Join(" or ", entry.Select(x => x.Name)) + ")";
                }
                else
                {
                    output += entry.First().Name;
                }

                if(counter < max - 2)
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

        private List<List<Blade>> GetBladesFromElements(List<Element> elements, Driver driver)
        {
            var team = new List<List<Blade>>();

            foreach(var element in elements)
            {
                team.Add(driver.Blades.Where(x => x.Element == element).ToList());
            }

            return team;
        }
    }
}
