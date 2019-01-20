using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WROCERBackend.Model.DataModel;

namespace WROCERBackend.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class UzytkownikController : BaseController<DataUzytkownik>
	{
		// GET: api/Uzytkownik
		[HttpGet]
		public ActionResult<IEnumerable<DataUzytkownik>> Get()
		{
			return Ok(GetAll());
		}

		// GET: api/Uzytkownik/5
		[HttpGet("{id}", Name = "GetDataUzytkownik")]
		public ActionResult<DataUzytkownik> Get(int id)
		{
			return TryGet(id);
		}

		// POST: api/Uzytkownik
		[HttpPost]
		public ActionResult Post([FromBody] DataUzytkownik value)
		{
			return TryPost(value);
		}

		// PUT: api/Uzytkownik/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] DataUzytkownik value)
		{
			return TryPut(id, value);
		}

		// DELETE: api/Uzytkownik/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			return TryDelete(id);
		}
	}
}