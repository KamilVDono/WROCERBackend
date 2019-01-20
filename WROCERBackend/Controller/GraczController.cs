using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using WROCERBackend.Model.DataModel;

    namespace WROCERBackend.Controller
    {
	    [Route("api/[controller]")]
	    [ApiController]
	    public class GraczController : BaseController<DataGracz>
	    {
		    // GET: api/Gracz
		    [HttpGet]
		    public ActionResult<IEnumerable<DataGracz>> Get()
		    {
			    return Ok(GetAll());
		    }

		    // GET: api/Gracz/5
		    [HttpGet("{id}", Name = "GetDataGracz")]
		    public ActionResult<DataGracz> Get(int id)
		    {
			    return TryGet(id);
		    }

		    // POST: api/Gracz
		    [HttpPost]
		    public ActionResult Post([FromBody] DataGracz value)
		    {
			    return TryPost(value);
		    }

		    // PUT: api/Gracz/5
		    [HttpPut("{id}")]
		    public ActionResult Put(int id, [FromBody] DataGracz value)
		    {
			    return TryPut(id, value);
		    }

		    // DELETE: api/Gracz/5
		    [HttpDelete("{id}")]
		    public ActionResult Delete(int id)
		    {
			    return TryDelete(id);
		    }
	    }
    }
