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
	public class SkladController : ControllerBase
	{
		private readonly IDataAccess _DataAccess;

		public SkladController(IDataAccess dataAccess)
		{
			_DataAccess = dataAccess;
		}

		// GET: api/Sklad/5
		[HttpGet("{id}", Name = "Get")]
		public string Get(int id)
		{
			return "value";
		}

		// POST: api/Sklad
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT: api/Sklad/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
