using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using NUnit.Framework;
using LiterallyFood.CQRS;
using Vehicle;
using Commands;
using Events;

namespace UnitTests
{
    [TestFixture]
    public class VehicleTests : BDDTest<VehicleAggregate>
    {
        Guid Id;
        string User;
        string Make;
        string Model;
        int Year;
        decimal Odo;

        [SetUp]
        public void Setup()
        {
            Id = Guid.NewGuid();
            User = "test:user";
        }

        [Test]
        public void CreateVehicle()
        {
            Test(Given(),
                When(new AddNewVehicle
                {
                    Id = Id,
                    AddedByUser = User,
                    Make = Make,
                    Model = Model,
                    Year = Year,
                    Odometer = Odo
                }),
                Then(new AddedNewVehicle
                {
                    Id = Id,
                    AddedByUser = User,
                    Make = Make,
                    Model = Model,
                    Year = Year,
                    Odometer = Odo
                }));
        }
    }
}
