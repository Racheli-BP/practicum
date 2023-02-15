using Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Services;
using WebApi.Models;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenderController : ControllerBase
	{
		private readonly IService<GenderDTO> _gender;
		public GenderController(IService<GenderDTO> gender)
		{
			_gender = gender;
		}


		// GET: api/<ActionController>
		[HttpGet]
		public async Task<List<GenderDTO>> Get()
		{
			return await _gender.GetAll();
		}

		// GET api/<ActionController>/5
		[HttpGet("{id}")]
		public async Task<GenderDTO> Get(int id)
		{
			return await _gender.GetById(id);
		}

		// POST api/<ActionController>
		[HttpPost]
		public async Task<GenderDTO> Post([FromBody] GenderModel postModel)
		{
			GenderDTO newEntity = new GenderDTO();
			newEntity.Name = postModel.Name;
			return await _gender.Add(newEntity);
		}

		// PUT api/<ActionController>/5
		[HttpPut("{id}")]
		public async Task<GenderDTO> Put([FromBody] GenderModel postModel)
		{
			GenderDTO newEntity = new GenderDTO();
			newEntity.Name = postModel.Name;
			return await _gender.Update(newEntity);
		}

		// DELETE api/<ActionController>/5
		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await _gender.Delete(id);
		}
	}
}
