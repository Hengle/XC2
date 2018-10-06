using GameDefinitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestScenarios
{
    [TestClass]
    public class Scenarios
    {
        [TestMethod]
        public void GetMaxCombos()
        {
            var drivers = new Drivers.Drivers();
            var graph = new ElementComboTeams(drivers.Team);
            //graph.PrintTeams();
            graph.GroupPrintTeams();
        }
    }
}
