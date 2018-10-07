namespace TestScenarios
{
    using Drivers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Scenarios
    {
        [TestMethod]
        public void GetMaxCombosByBlade()
        {
            var drivers = new Drivers();
            var graph = new ElementComboTeams(drivers.Team);
            graph.GroupPrintTeams();
        }

        [TestMethod]
        public void GetMaxCombosByElement()
        {
            var drivers = new Drivers();
            var graph = new ElementComboTeams(drivers.Team);
            graph.PrintTeams();
        }
    }
}
