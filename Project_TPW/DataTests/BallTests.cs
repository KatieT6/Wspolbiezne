using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tests
{
    [TestClass()]
    public class BallTests
    {
        [TestMethod()]
        public void BallTest()
        {
            Ball b = new Ball(1.0, 2.0, 10.0);
            b.updateBall(1.5, -1.0);
            Assert.AreEqual(2.5, b.PositionX);
            Assert.AreEqual(1.0, b.PositionY);
        }
    }
}