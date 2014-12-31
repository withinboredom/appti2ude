using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiterallyFood.CQRS;
using Commands;
using Events;

namespace Vehicle
{
    public class VehicleAggregate : Aggregate,
        IHandleCommand<AddNewVehicle>,
        IApplyEvent<AddedNewVehicle>
    {
        protected string AddedByUser;
        protected string Make;
        protected string Model;
        protected int Year;
        protected decimal Odometer;

        public VehicleAggregate() : base() { }

        public VehicleAggregate(Guid Id) : base(id: Id) { }

        public System.Collections.IEnumerable Handle(AddNewVehicle c)
        {
            yield return new AddedNewVehicle
            {
                AddedByUser = c.AddedByUser,
                Id = c.Id,
                Make = c.Make,
                Model = c.Model,
                Odometer = c.Odometer,
                Year = c.Year
            };
        }

        public void Apply(AddedNewVehicle e)
        {
            AddedByUser = e.AddedByUser;
            Make = e.Make;
            Model = e.Model;
            Year = e.Year;
            Odometer = e.Odometer;
        }
    }
}
