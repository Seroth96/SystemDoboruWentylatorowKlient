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
        public IEnumerable<WentylatorsDTO> GetWentylators(params KeyValuePair<string, string>[] list)
        {
            _logger.LogInformation("Getting wentylators {0}", list);
            var Wentylators = _context.Wentylators.Include(w => w.Coefficients).Include(w => w.Nature).AsEnumerable();

            Wentylators = QueryHelper.QueryAllWentylators(Wentylators, list);
            var wentylatorsDTO = DTOHelper.PackWentylatorsToDTO(Wentylators);
            
            return wentylatorsDTO;
        }


        [HttpGet("[action]")]
        [EnableCors("MyPolicy")]
        public WentylatorsDTO GetWentylator(params KeyValuePair<string, string>[] list)
        {
            _logger.LogInformation("Getting wentylator {0}", list);
            var Wentylators = _context.Wentylators.Include(w => w.Coefficients).Include(w => w.Nature).AsEnumerable();
            var wentylator = QueryHelper.QueryOneWentylator(Wentylators, list);
            var wentylatorsDTO = DTOHelper.PackWentylatorToDTO(wentylator);

            return wentylatorsDTO;
        }

    }
}
