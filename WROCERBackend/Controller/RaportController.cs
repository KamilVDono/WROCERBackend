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
	public class RaportController : BaseController<DataRaport>
	{
		public RaportController(IDataAccess dataAccess)
		{
			_DataAccess = dataAccess;
		}

		// GET: api/Raport
		[HttpGet]
		public ActionResult<IEnumerable<DataRaport>> Get()
		{
			return Ok(GetAll());
		}

		// GET: api/Raport/sedzia/5
		[HttpGet("sedzia/{idSedzia}", Name = "GetBySedzia")]
		public ActionResult<IEnumerable<DataRaport>> GetBySedzia(int idSedzia)
		{
			return Ok(GetWhere(r => r.Mecz.Sedzia.ID == idSedzia));
		}

		// GET: api/Raport/5
		[HttpGet("{id}", Name = "GetRaport")]
		public ActionResult<DataRaport> Get(int id)
		{
			return TryGet(id);
		}

		// POST: api/Raport/
		[HttpPost("mecz/{idMecz}")]
		public ActionResult Post(int idMecz, [FromBody] DataRaport value)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var mecz = _DataAccess.GetItem<DataMecz>(idMecz);
			if (mecz == null)
			{
				return NotFound();
			}

			value.Mecz = mecz;

			return TryPost(value);
		}

		// PUT: api/Raport/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] DataRaport value)
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
