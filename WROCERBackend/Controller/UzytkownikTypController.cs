using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WROCERBackend.Model.DataModel;

namespace WROCERBackend.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class UzytkownikTypController : BaseController<DataUzytkownikTyp>
	{
		// GET: api/UzytkownikTyp
		[HttpGet]
		public ActionResult<IEnumerable<DataUzytkownikTyp>> Get()
		{
			return Ok(GetAll());
		}

		// GET: api/UzytkownikTyp/5
		[HttpGet("{id}", Name = "GetDataUzytkownikTyp")]
		public ActionResult<DataUzytkownikTyp> Get(int id)
		{
			return TryGet(id);
		}

		// POST: api/UzytkownikTyp
		[HttpPost]
		public ActionResult Post([FromBody] DataUzytkownikTyp value)
		{
			return TryPost(value);
		}

		// PUT: api/UzytkownikTyp/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] DataUzytkownikTyp value)
		{
			return TryPut(id, value);
		}

		// DELETE: api/UzytkownikTyp/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			return TryDelete(id);
		}
	}
}