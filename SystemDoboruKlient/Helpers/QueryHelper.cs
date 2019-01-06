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
        public static Wentylators QueryOneWentylator(IEnumerable<Wentylators> wentylators, WentylatorParams DTO)
        {
            wentylators = FilterPerParam(wentylators, DTO);
            return wentylators.Count() > 0 ? wentylators.First() : default(Wentylators);
        }

        public static IEnumerable<Wentylators> QueryAllWentylators(IEnumerable<Wentylators> wentylators, WentylatorParams DTO)
        {
            wentylators = FilterPerParam(wentylators, DTO);
            return wentylators;
        }

        private static IEnumerable<Wentylators> FilterPerParam(IEnumerable<Wentylators> wentylators, WentylatorParams DTO)
        {
            if (DTO.Id != 0)
            {
                wentylators = wentylators.Where(w => w.Id == DTO.Id).ToList();
            }
            else
            {
                if (DTO.Name != String.Empty)
                {
                    wentylators = wentylators.Where(w => w.Name.Equals(DTO.Name)).ToList();
                }

                if (DTO.Power != String.Empty)
                {
                    var Power = double.Parse(DTO.Power);
                    wentylators = wentylators.Where(w => w.Power / Power > 0.8 || w.Power / Power < 1.2).ToList();
                }

                if (DTO.Pressure != String.Empty && DTO.AirMassFlow != String.Empty)
                {
                    var Pressure = double.Parse(DTO.Pressure);
                    var AirMassFlow = double.Parse(DTO.AirMassFlow);
                    wentylators = wentylators
                        .Where(w =>
                                 ChebyshevHelper.EvaluateFunctionFromCoefficients(
                                    w.Coefficients.OrderBy(c => c.Level).Select(v => v.Value).ToArray(),
                                    ChebyshevHelper.Normalize(w.AirMassFlowFrom, w.AirMassFlowTo, AirMassFlow))
                                / Pressure > 0.8 &&
                                ChebyshevHelper.EvaluateFunctionFromCoefficients(
                                    w.Coefficients.OrderBy(c => c.Level).Select(v => v.Value).ToArray(),
                                    ChebyshevHelper.Normalize(w.AirMassFlowFrom, w.AirMassFlowTo, AirMassFlow))
                                / Pressure < 1.2
                            ).ToList();
                }

                if (DTO.Revolution != String.Empty)
                {
                    var Revolution = double.Parse(DTO.Revolution);
                    wentylators = wentylators.Where(w => w.Revolution / Revolution > 0.8 || w.Revolution / Revolution < 1.2).ToList();
                }

                if (DTO.Nature != String.Empty)
                {
                    wentylators = wentylators.Where(w => w.Nature.Name.Equals(DTO.Nature)).ToList();
                }
            }
            return wentylators;
        }
    }
}
