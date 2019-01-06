using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemDoboruKlient.ModelsDTO
{
    public class WentylatorsDTO
    {
        public WentylatorsDTO()
        {
            Coefficients = new HashSet<CoefficientsDTO>();
        }

        public string Name { get; set; }
        public double Power { get; set; }
        public double Revolution { get; set; }
        public int NatureId { get; set; }
        public double AirMassFlowFrom { get; set; }
        public double AirMassFlowTo { get; set; }
        public int Id { get; set; }

        public NaturesDTO Nature { get; set; }
        public ICollection<CoefficientsDTO> Coefficients { get; set; }
    }

    public interface IWentylatorParams
    {
        int Id { get; set; }
        string Name { get; set; }
        string Nature { get; set; }
        double Power { get; set; }
        double Revolution { get; set; }
        double AirMassFlow { get; set; }
        double Pressure { get; set; }
    }
}
