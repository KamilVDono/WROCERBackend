using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using WROCERBackend.Model.DataModel;

    namespace WROCERBackend.Controller
    {
	    [Route("api/[controller]")]
	    [ApiController]
	    public class SytuacjaMeczowaController : BaseController<DataSytuacjaMeczowa>
	    {
		    // GET: api/SytuacjaMeczowa
		    [HttpGet]
		    public ActionResult<IEnumerable<DataSytuacjaMeczowa>> Get()
		    {
			    return Ok(GetAll());
		    }

		    // GET: api/SytuacjaMeczowa/5
		    [HttpGet("{id}", Name = "GetDataSytuacjaMeczowa")]
		    public ActionResult<DataSytuacjaMeczowa> Get(int id)
		    {
			    return TryGet(id);
		    }

		    // POST: api/SytuacjaMeczowa
		    [HttpPost]
		    public ActionResult Post([FromBody] DataSytuacjaMeczowa value)
		    {
			    return TryPost(value);
		    }

		    // PUT: api/SytuacjaMeczowa/5
		    [HttpPut("{id}")]
		    public ActionResult Put(int id, [FromBody] DataSytuacjaMeczowa value)
		    {
			    return TryPut(id, value);
		    }

		    // DELETE: api/SytuacjaMeczowa/5
		    [HttpDelete("{id}")]
		    public ActionResult Delete(int id)
		    {
			    return TryDelete(id);
		    }
	    }
    }
