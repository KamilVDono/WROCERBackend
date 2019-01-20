using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WROCERBackend.Model.DataAccess;
using WROCERBackend.Model.DataModel;

namespace WROCERBackend.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class SkladTypController : BaseController<DataSklad>
	{
		public SkladTypController(IDataAccess dataAccess)
		{
			_DataAccess = dataAccess;
		}
		// GET: api/SkladTyp
		[HttpGet]
		public ActionResult<IEnumerable<DataSklad>> Get()
		{
			return Ok(GetAll());
		}

		// GET: api/SkladTyp/5
		[HttpGet("{id}", Name = "GetSkladTyp")]
		public ActionResult<DataSklad> Get(int id)
		{
			return TryGet(id);
		}

		// POST: api/SkladTyp
		[HttpPost]
		public ActionResult Post([FromBody] DataSklad value)
		{
			return TryPost(value);
		}

		// PUT: api/SkladTyp/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] DataSklad value)
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
