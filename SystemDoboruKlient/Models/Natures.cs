using System;
using System.Collections.Generic;

namespace SystemDoboruKlient.Models
{
    public partial class Natures
    {
        public Natures()
        {
            Wentylators = new HashSet<Wentylators>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Wentylators> Wentylators { get; set; }
    }
}
