using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WROCERBackend.Model.DataModel;

namespace WROCERBackend.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class ZawodnikController : BaseController<DataZawodnik>
	{
		// GET: api/Zawodnik
		[HttpGet]
		public ActionResult<IEnumerable<DataZawodnik>> Get()
		{
			return Ok(GetAll());
		}

		// GET: api/Zawodnik/5
		[HttpGet("{id}", Name = "GetDataZawodnik")]
		public ActionResult<DataZawodnik> Get(int id)
		{
			return TryGet(id);
		}

		// POST: api/Zawodnik
		[HttpPost]
		public ActionResult Post([FromBody] DataZawodnik value)
		{
			return TryPost(value);
		}

		// PUT: api/Zawodnik/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] DataZawodnik value)
		{
			return TryPut(id, value);
		}

		// DELETE: api/Zawodnik/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			return TryDelete(id);
		}
	}
}