using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using XL;

namespace XLApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirsController : ControllerBase
    {
        Service _xl;
        public DirsController(Service xl)
        {
            _xl = xl;
        }
        // GET: api/Dirs
        [HttpGet]
        public IEnumerable<Dir> Get()
        {
            return _xl.GetDirs();
        }

        // GET: api/Dirs/5
        [HttpGet("{id}", Name = "Get")]
        public Dir Get(int id)
        {
            return _xl.GetDir(id);
        }

        // POST: api/Dirs
        [HttpPost]
        public void Post(string dir)
        {
            _xl.AddDir(dir);
        }
    }
}
