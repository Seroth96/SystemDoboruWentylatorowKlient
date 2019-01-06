using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemDoboruKlient.ModelsDTO
{
    public class ChebyshevValuesDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<IEnumerable<double>> Data { get; set; }

    }
}
