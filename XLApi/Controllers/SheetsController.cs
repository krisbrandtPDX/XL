using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XL;

namespace XLApi.Controllers
{
    [ApiController]
    public class SheetsController : ControllerBase
    {
        private Service _xl;
        public SheetsController(Service xl)
        {
            _xl = xl;
        }
        // GET: api/Sheets
        [HttpGet]
        [Route("api/Sheets")]
        public IEnumerable<Sheet> Get()
        {
            return _xl.GetSheets();
        }

        // GET: api/Sheets/5
        [HttpGet("{id}")]
        [Route("api/Sheets/{id}")]
        public Sheet Get(int id)
        {
            return _xl.GetSheet(id);
        }

    }
}
