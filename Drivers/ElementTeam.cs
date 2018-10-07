using GameDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Drivers
{
    public class ElementTeam
    {
        public List<ComboOrder> FinishableElements { get; }
        public List<Element> First { get; }
        public List<Element> Second { get; }
        public List<Element> Third { get; }

        public ElementTeam(List<Element> first, List<Element> second, List<Element> third, List<ComboOrder> finishableElements)
        {
            First = first;
            Second = second;
            Third = third;
            FinishableElements = finishableElements;
        }
    }
}
