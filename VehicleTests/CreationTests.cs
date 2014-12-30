using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using NUnit.Framework;
using LiterallyFood.CQRS;
using Vehicle;

namespace VehicleTests
{
    [TestFixture]
    public class CreationTests : BDDTest<VehicleAggregate>
    {
        Guid Id;

        [SetUp]
        public void Setup()
        {
            Id = Guid.NewGuid();
        }

        [Test]
        public void TestsWork()
        {
            return;
        } 
    }
}
