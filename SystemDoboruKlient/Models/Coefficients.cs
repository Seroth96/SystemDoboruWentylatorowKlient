using System;
using System.Collections.Generic;

namespace SystemDoboruKlient.Models
{
    public partial class Coefficients
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public double Value { get; set; }
        public bool IsArchived { get; set; }
        public int? WentylatorId { get; set; }

        public Wentylators Wentylator { get; set; }
    }
}
