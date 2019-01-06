using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SystemDoboruKlient.Helpers;
using SystemDoboruKlient.Models;
using SystemDoboruKlient.ModelsDTO;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SystemDoboruKlient.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class WentylatorsController : Controller
    {
        private readonly ILogger _logger;
        private BazaWentylatorowContext _context;
        public WentylatorsController(BazaWentylatorowContext myContext, ILogger<WentylatorsController> logger)
        {
            _context = myContext;
            _logger = logger;
        }

        [HttpGet("[action]")]
        [EnableCors("MyPolicy")]
        public IEnumerable<WentylatorsDTO> GetWentylators(IWentylatorParams wentylatorParams)
        {
            _logger.LogInformation("Getting wentylators {0}", wentylatorParams);
            var Wentylators = _context.Wentylators.Include(w => w.Coefficients).Include(w => w.Nature).AsEnumerable();
            Wentylators = QueryHelper.QueryAllWentylators(Wentylators, wentylatorParams);
            var wentylatorsDTO = DTOHelper.PackWentylatorsToDTO(Wentylators);
            
            return wentylatorsDTO;
        }


        [HttpGet("[action]")]
        [EnableCors("MyPolicy")]
        public WentylatorsDTO GetWentylator(IWentylatorParams wentylatorParams)
        {
            _logger.LogInformation("Getting wentylator {0}", wentylatorParams);
            var wentylators = _context.Wentylators.Include(w => w.Coefficients).Include(w => w.Nature).AsEnumerable();            
            var wentylator = QueryHelper.QueryOneWentylator(wentylators, wentylatorParams);
            var wentylatorsDTO = DTOHelper.PackWentylatorToDTO(wentylator);

            return wentylatorsDTO;
        }

    }
}
