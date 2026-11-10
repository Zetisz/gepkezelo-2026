using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace bankprojekt.Tests
{
    [TestFixture]
    internal class BankTest
    {
        [Test]
        public void InitialBalanceIsZero()
        {
            // Előkészítő lépés
            var b = new Bank();

            // A művelet, amit tesztelünk
            b.NewAccount("1234");

            // Eredmény:
            Assert.That(b.GetBalance("1234"), Is.Zero);
        }

        public void Deposit()
        {
            var b = new Bank();

            b.NewAccount("1234");
            b.Deposit("1234", 50000);

            Assert.That(b.GetBalance, Is.EqualTo(50000);
        }
    }
}
