using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using XL;

namespace XLApi.Controllers
{
    [ApiController]
    public class RowsController : ControllerBase
    {
        private Service _xl;
        public RowsController(Service xl)
        {
            _xl = xl;
        }
        // GET: api/Rows
        [HttpGet]
        [Route("api/Rows")]
        public IEnumerable<Row> Get()
        {
            return _xl.GetRows();
        }

        // GET: api/Rows/5
        [HttpGet("{id}")]
        [Route("api/Rows/{id}")]
        public Row Get(int id)
        {
            return _xl.GetRow(id);
        }
    }
}
