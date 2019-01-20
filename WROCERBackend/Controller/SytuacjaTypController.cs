using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WROCERBackend.Model.DataModel;

namespace WROCERBackend.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class SytuacjaTypController : BaseController<DataSytuacjaTyp>
	{
		// GET: api/SytuacjaTyp
		[HttpGet]
		public ActionResult<IEnumerable<DataSytuacjaTyp>> Get()
		{
			return Ok(GetAll());
		}

		// GET: api/SytuacjaTyp/5
		[HttpGet("{id}", Name = "GetSytuacjaTyp")]
		public ActionResult<DataSytuacjaTyp> Get(int id)
		{
			return TryGet(id);
		}

		// POST: api/SytuacjaTyp
		[HttpPost]
		public ActionResult Post([FromBody] DataSytuacjaTyp value)
		{
			return TryPost(value);
		}

		// PUT: api/SytuacjaTyp/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] DataSytuacjaTyp value)
		{
			return TryPut(id, value);
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			return TryDelete(id);
		}
	}
}
