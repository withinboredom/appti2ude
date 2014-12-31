using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiterallyFood.CQRS;

namespace Person
{
    public class PersonAggregate : Aggregate,
        IHandleCommand<Commands.GivePersonIdentity>,
        IApplyEvent<Events.PersonGivenIdentity>
    {
        protected string name;
        protected string email;

        public string Name { get { return this.name; } }
        public string Email { get { return this.email; } }

        public System.Collections.IEnumerable Handle(Commands.GivePersonIdentity c)
        {
            if (name != null)
            {
                throw new Exceptions.DuplicateIdentityException();
            }

            yield return new Events.PersonGivenIdentity
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email
            };
        }

        public void Apply(Events.PersonGivenIdentity e)
        {
            name = e.Name;
            email = e.Email;
        }
    }
}
