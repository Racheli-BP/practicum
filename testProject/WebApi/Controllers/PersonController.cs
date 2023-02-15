using Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.VisualBasic;
using Repositories.Entities;
using Services;
using WebApi.Models;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly IService<PersonDTO> _person;

		public PersonController(IService<PersonDTO> person)
		{
			_person = person;
		}


		// GET: api/<ActionController>
		[HttpGet]
		public async Task<List<PersonDTO>> Get()
		{
			return await _person.GetAll();
		}

		// GET api/<ActionController>/5
		[HttpGet("{id}")]
		public async Task<PersonDTO> Get(int id)
		{
			return await _person.GetById(id);
		}

		// POST api/<ActionController>
		[HttpPost]
		public async Task<PersonDTO> Post([FromBody] PersonModel postModel)
		{
			PersonDTO newEntity = new PersonDTO();
			newEntity.Id = postModel.Id;
			newEntity.FirstName = postModel.FirstName;
			newEntity.LastName = postModel.LastName;
			newEntity.Tz = postModel.Tz;
			newEntity.BirthDate = postModel.BirthDate;
			newEntity.GenderId = postModel.GenderId;
			newEntity.HealthFundId = postModel.HealthFundId;

			return await _person.Add(newEntity);
		}

		// PUT api/<ActionController>/5
		[HttpPut("{id}")]
		public async Task<PersonDTO> Put([FromBody] PersonModel postModel)
		{
			PersonDTO newEntity = new PersonDTO();
			newEntity.Id = postModel.Id;
			newEntity.FirstName = postModel.FirstName;
			newEntity.LastName = postModel.LastName;
			newEntity.Tz = postModel.Tz;
			newEntity.BirthDate = postModel.BirthDate;
			newEntity.GenderId = postModel.GenderId;
			newEntity.HealthFundId = postModel.HealthFundId;
			return await _person.Update(newEntity);
		}

		// DELETE api/<ActionController>/5
		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await _person.Delete(id);
		}
	}
}
