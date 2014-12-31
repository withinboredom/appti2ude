using System;
using NUnit;
using NUnit.Framework;
using LiterallyFood.CQRS;
using Commands;
using Events;
using Person;
using Exceptions;

namespace UnitTests
{
    [TestFixture]
    public class PersonTests : BDDTest<PersonAggregate>
    {
        Guid Id;
        string name = "Rob Landers";
        string email = "landers.robert@gmail.com";

        [SetUp]
        public void Setup()
        {
            Id = Guid.NewGuid();
        }

        [Test]
        public void TestGiveIdentity()
        {
            Test(Given(), When(new GivePersonIdentity
            {
                Id = Id,
                Name = name,
                Email = email
            }), Then(new PersonGivenIdentity
            {
                Id = Id,
                Name = name,
                Email = email
            }));
        }

        [Test]
        public void TestGiveIdentityTwice()
        {
            Test(Given(new PersonGivenIdentity
            {
                Id = Id,
                Email = email,
                Name = name
            }),
            When(new GivePersonIdentity
            {
                Id = Id,
                Email = email,
                Name = name
            }), ThenFailWith<DuplicateIdentityException>());
        }
    }
}
