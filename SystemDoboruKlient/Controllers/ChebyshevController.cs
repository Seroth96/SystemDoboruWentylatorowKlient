using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemDoboruKlient.Helpers;
using SystemDoboruKlient.Models;
using SystemDoboruKlient.ModelsDTO;

namespace SystemDoboruKlient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChebyshevController : ControllerBase
    {
        private readonly BazaWentylatorowContext _context;

        public ChebyshevController(BazaWentylatorowContext context)
        {
            _context = context;
        }

        // GET: api/Chebyshev
        [HttpGet]
        [HttpGet("[action]")]
        [EnableCors("MyPolicy")]
        public ChebyshevValuesDTO GetApproximationValues(int Id)
        {
            var wentylator = _context.Wentylators.Include(w => w.Coefficients).First(w => w.Id == Id);
            IEnumerable<double> sampledRange = ChebyshevHelper.SampleRange(wentylator.AirMassFlowFrom, wentylator.AirMassFlowTo, 100).Reverse();
            List<double[]> approximationValues = new List<double[]>();
            double[] C = wentylator.Coefficients.Where(notArchived => !notArchived.IsArchived).OrderBy(level => level.Level).Select(c => c.Value).ToArray();
            foreach (var valueX in sampledRange)
            {
                var values = new double[2];
                values[0] = valueX * 1000;
                var U = ChebyshevHelper.Normalize(wentylator.AirMassFlowFrom, wentylator.AirMassFlowTo, valueX);
                var Y = ChebyshevHelper.EvaluateFunctionFromCoefficients(C, U);
                values[1] = Y;
                approximationValues.Add(values);
            }
            ChebyshevValuesDTO DTO = new ChebyshevValuesDTO
            {
                Id = Id,
                Name = wentylator.Name,
                Data = approximationValues
            };
            return DTO;
        }

        // GET: api/Chebyshev/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
