using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemDoboruKlient.Models;

namespace SystemDoboruKlient.Helpers
{
    public static class QueryHelper
    {
        public static Wentylators QueryOneWentylator(IEnumerable<Wentylators> wentylators, KeyValuePair<string, string>[] list)
        {
            foreach (var param in list)
            {
                switch (param.Key)
                {
                    case "id":
                        break;
                    case "name":
                        break;
                    case "power":
                        break;
                    case "revolution":
                        break;
                    case "airMassFlow":
                    case "pressure":
                        break;

                    default:
                        break;
                }
            }

            return wentylators.Count() > 0 ? wentylators.First() : default(Wentylators);
        }

        public static IEnumerable<Wentylators> QueryAllWentylators(IEnumerable<Wentylators> wentylators, KeyValuePair<string, string>[] list)
        {
            return wentylators;
        }
    }
}
