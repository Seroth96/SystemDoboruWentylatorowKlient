using System;
using System.Collections.Generic;

namespace SystemDoboruKlient.Models
{
    public partial class Wentylators
    {
        public Wentylators()
        {
            Coefficients = new HashSet<Coefficients>();
        }

        public string Name { get; set; }
        public double Power { get; set; }
        public double Revolution { get; set; }
        public int NatureId { get; set; }
        public double AirMassFlowFrom { get; set; }
        public double AirMassFlowTo { get; set; }
        public int Id { get; set; }

        public Natures Nature { get; set; }
        public ICollection<Coefficients> Coefficients { get; set; }
    }
}
