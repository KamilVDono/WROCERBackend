using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using WROCERBackend.Model.DataModel;

    namespace WROCERBackend.Controller
    {
	    [Route("api/[controller]")]
	    [ApiController]
	    public class ZmianaController : BaseController<DataZmiana>
	    {
		    // GET: api/Zmiana
		    [HttpGet]
		    public ActionResult<IEnumerable<DataZmiana>> Get()
		    {
			    return Ok(GetAll());
		    }

		    // GET: api/Zmiana/5
		    [HttpGet("{id}", Name = "GetDataZmiana")]
		    public ActionResult<DataZmiana> Get(int id)
		    {
			    return TryGet(id);
		    }

		    // POST: api/Zmiana
		    [HttpPost]
		    public ActionResult Post([FromBody] DataZmiana value)
		    {
			    return TryPost(value);
		    }

		    // PUT: api/Zmiana/5
		    [HttpPut("{id}")]
		    public ActionResult Put(int id, [FromBody] DataZmiana value)
		    {
			    return TryPut(id, value);
		    }

		    // DELETE: api/Zmiana/5
		    [HttpDelete("{id}")]
		    public ActionResult Delete(int id)
		    {
			    return TryDelete(id);
		    }
	    }
    }
