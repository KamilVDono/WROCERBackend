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
	public class PozycjaController : ControllerBase
	{
		private readonly IDataAccess _DataAccess;

		public PozycjaController(IDataAccess dataAccess)
		{
			_DataAccess = dataAccess;
		}

		// GET: api/Pozycja
		[HttpGet]
		public ActionResult<IEnumerable<DataPozycja>> Get()
		{
			return Ok(_DataAccess.GetAll<DataPozycja>());
		}

		// GET: api/Pozycja/5
		[HttpGet("{id}", Name = "Get")]
		public ActionResult<DataPozycja> Get(int id)
		{
			var item = _DataAccess.GetItem<DataPozycja>(id);

			if (item == null)
			{
				return NotFound();
			}

			return Ok(item);
		}

		// POST: api/Pozycja
		[HttpPost]
		public ActionResult Post([FromBody] DataPozycja value)
		{
			var success = _DataAccess.AddItem(value);

			if (success)
			{
				return CreatedAtAction("Get", value);
			}
			else
			{
				return Conflict("Can not add element");
			}
		}

		// PUT: api/Pozycja/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] DataPozycja value)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (value == null || _DataAccess.UpdateItem(value) == false)
			{
				return NotFound();
			}

			return Ok();
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			var pozycja = _DataAccess.GetItem<DataPozycja>(id);

			if (pozycja == null)
			{
				return NotFound();
			}

			var success = _DataAccess.RemoveItem(pozycja);

			if (success)
			{
				return Ok();
			}
			else
			{
				return NotFound();
			}
		}
	}
}
