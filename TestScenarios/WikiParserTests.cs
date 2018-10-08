namespace TestScenarios
{
    using Drivers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WikiParser;

    [TestClass]
    public class WikiParserTests
    {
        [TestMethod]
        public void ParseDriversPage()
        {
            //todo: nothing should be by full path
            var checkedInFullPath = @"C:\Users\_\source\repos\XenobladeC2\WikiParser\Contents\Drivers.html";
            var driversPage = new Page(checkedInFullPath);
        }
    }
}
