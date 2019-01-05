using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemDoboruKlient.ModelsDTO
{
    public class CoefficientsDTO
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public double Value { get; set; }
        public bool IsArchived { get; set; }
        public int? WentylatorId { get; set; }

    }
}
