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
	public class PozycjaController : BaseController<DataPozycja>
	{
		public PozycjaController(IDataAccess dataAccess)
		{
			_DataAccess = dataAccess;
		}

		// GET: api/Pozycja
		[HttpGet]
		public ActionResult<IEnumerable<DataPozycja>> Get()
		{
			return Ok(GetAll());
		}

		// GET: api/Pozycja/5
		[HttpGet("{id}", Name = "GetPozycja")]
		public ActionResult<DataPozycja> Get(int id)
		{
			return TryGet(id);
		}

		// POST: api/Pozycja
		[HttpPost]
		public ActionResult Post([FromBody] DataPozycja value)
		{
			return TryPost(value);
		}

		// PUT: api/Pozycja/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] DataPozycja value)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

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
