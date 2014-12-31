using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands
{
    public class AddNewVehicle
    {
        public Guid Id;
        public string AddedByUser { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Odometer { get; set; }
    }
}
