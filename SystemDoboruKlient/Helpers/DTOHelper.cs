using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemDoboruKlient.Models;
using SystemDoboruKlient.ModelsDTO;

namespace SystemDoboruKlient.Helpers
{
    public static class DTOHelper
    {
        public static IEnumerable<WentylatorsDTO> PackWentylatorsToDTO(IEnumerable<Wentylators> wentylators)
        {
            var wentylatorsDTO = wentylators.Select(w => new WentylatorsDTO
            {
                AirMassFlowFrom = w.AirMassFlowFrom,
                AirMassFlowTo = w.AirMassFlowTo,
                Coefficients = w.Coefficients.Where(c => !c.IsArchived).Select(c => new CoefficientsDTO
                {
                    Id = c.Id,
                    IsArchived = c.IsArchived,
                    Level = c.Level,
                    Value = c.Value,
                    WentylatorId = c.WentylatorId
                }).ToArray(),
                Id = w.Id,
                Name = w.Name,
                Nature = new NaturesDTO
                {
                    Id = w.Nature.Id,
                    Name = w.Nature.Name
                },
                NatureId = w.NatureId,
                Power = w.Power,
                Revolution = w.Revolution
            }).ToArray();

            return wentylatorsDTO;
        }

        public static WentylatorsDTO PackWentylatorToDTO(Wentylators w)
        {
            var wentylatorDTO = new WentylatorsDTO
            {
                AirMassFlowFrom = w.AirMassFlowFrom,
                AirMassFlowTo = w.AirMassFlowTo,
                Coefficients = w.Coefficients.Where(c => !c.IsArchived).Select(c => new CoefficientsDTO
                {
                    Id = c.Id,
                    IsArchived = c.IsArchived,
                    Level = c.Level,
                    Value = c.Value,
                    WentylatorId = c.WentylatorId
                }).ToArray(),
                Id = w.Id,
                Name = w.Name,
                Nature = new NaturesDTO
                {
                    Id = w.Nature.Id,
                    Name = w.Nature.Name
                },
                NatureId = w.NatureId,
                Power = w.Power,
                Revolution = w.Revolution
            };

            return wentylatorDTO;
        }
    }
}
