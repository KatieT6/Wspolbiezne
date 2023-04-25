using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DataTests
{
    [TestClass]
    public class DataAbstractAPITest
    {
        [TestMethod]
        public void CreateAPITest()
        {
            DataAbstractAPI api = DataAbstractAPI.CreateDataAPI();
            Assert.IsNotNull(api);
        }
    }
}
