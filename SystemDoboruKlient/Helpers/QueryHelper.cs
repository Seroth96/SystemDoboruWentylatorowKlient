using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemDoboruKlient.Models;
using SystemDoboruKlient.ModelsDTO;

namespace SystemDoboruKlient.Helpers
{
    public static class QueryHelper
    {
        public static Wentylators QueryOneWentylator(IEnumerable<Wentylators> wentylators, IWentylatorParams DTO)
        {
            wentylators = FilterPerParam(wentylators, DTO);
            return wentylators.Count() > 0 ? wentylators.First() : default(Wentylators);
        }

        public static IEnumerable<Wentylators> QueryAllWentylators(IEnumerable<Wentylators> wentylators, IWentylatorParams DTO)
        {
            wentylators = FilterPerParam(wentylators, DTO);
            return wentylators;
        }

        private static IEnumerable<Wentylators> FilterPerParam(IEnumerable<Wentylators> wentylators, IWentylatorParams DTO)
        {
            if (DTO.Name != String.Empty)
            {
                wentylators = wentylators.Where(w => w.Name.Equals(DTO.Name)).ToList();
            }

            if (DTO.Power != 0)
            {
                wentylators = wentylators.Where(w => w.Power / DTO.Power > 0.8 || w.Power / DTO.Power < 1.2).ToList();
            }

            if (DTO.Pressure != 0 && DTO.AirMassFlow != 0)
            {
                wentylators = wentylators
                    .Where(w =>
                             ChebyshevHelper.EvaluateFunctionFromCoefficients(
                                w.Coefficients.OrderBy(c => c.Level).Select(v => v.Value).ToArray(),
                                ChebyshevHelper.Normalize(w.AirMassFlowFrom, w.AirMassFlowTo, DTO.AirMassFlow))
                            / DTO.Pressure > 0.8 &&
                            ChebyshevHelper.EvaluateFunctionFromCoefficients(
                                w.Coefficients.OrderBy(c => c.Level).Select(v => v.Value).ToArray(),
                                ChebyshevHelper.Normalize(w.AirMassFlowFrom, w.AirMassFlowTo, DTO.AirMassFlow))
                            / DTO.Pressure < 1.2
                        ).ToList();
            }

            if (DTO.Revolution != 0)
            {
                wentylators = wentylators.Where(w => w.Revolution / DTO.Revolution > 0.8 || w.Revolution / DTO.Revolution < 1.2).ToList();
            }

            if (DTO.Nature != String.Empty)
            {
                wentylators = wentylators.Where(w => w.Nature.Name.Equals(DTO.Nature)).ToList();
            }
            return wentylators;
        }
    }
}
