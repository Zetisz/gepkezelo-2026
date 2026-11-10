using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetrikGepkezelo
{
    [TestFixture]
    internal class ManagerTest
    {
        [Test]
        void TestLocalHost()
        {
            var ipstring = NetworkDeviceManager.IPv4ToString();
            Assert.That(ipstring);
        }
    }
}
