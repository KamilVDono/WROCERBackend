﻿using System;
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
	public class MeczController : ControllerBase
	{
		private readonly IDataAccess _DataAccess;

		public MeczController(IDataAccess dataAccess)
		{
			_DataAccess = dataAccess;
		}

		// GET: api/Mecz
		[HttpGet]
		public ActionResult<IEnumerable<DataMecz>> Get()
		{
			return Ok(_DataAccess.GetAll<DataMecz>());
		}

		// GET: api/Mecz/5
		[HttpGet("{id}", Name = "Get")]
		public ActionResult<DataMecz> Get(int id)
		{
			var item = _DataAccess.GetItem<DataMecz>(id);

			if (item == null)
			{
				return NotFound();
			}

			return Ok(item);
		}

		// POST: api/Mecz/sezon/id/sedzia/id/gospodarz
		[HttpPost("sezon/{idSezon}/sedzia/{idSedzia}/gospodarz/{idGospodarz}/gosc/{idGosc}")]
		public ActionResult Post(int idSezon, int idSedzia, int idGospodarz, int idGosc, [FromBody] DataMecz value)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var sezon = _DataAccess.GetItem<DataSezon>(idSezon);
			if (sezon == null)
			{
				return NotFound();
			}

			var sedzia = _DataAccess.GetItem<DataUzytkownik>(idSedzia);
			if (sedzia == null)
			{
				return NotFound();
			}

			var gospodarz = _DataAccess.GetItem<DataDruzyna>(idGospodarz);
			if (gospodarz == null)
			{
				return NotFound();
			}

			var gosc = _DataAccess.GetItem<DataDruzyna>(idGosc);
			if (gosc == null)
			{
				return NotFound();
			}

			value.Sezon = sezon;
			value.Sedzia = sedzia;
			value.Gospodarz = gospodarz;
			value.Gosc = gosc;

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

		// PUT: api/Mecz/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] DataMecz value)
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
			var mecz = _DataAccess.GetItem<DataMecz>(id);

			if (mecz == null)
			{
				return NotFound();
			}

			var success = _DataAccess.RemoveItem(mecz);

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
