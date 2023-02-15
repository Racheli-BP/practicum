using Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Services;
using WebApi.Models;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ChildController : ControllerBase
	{
		private readonly IService<ChildDTO> _child;

		public ChildController(IService<ChildDTO> child)
		{
			_child = child;
		}


		// GET: api/<ActionController>
		[HttpGet]
		public async Task<List<ChildDTO>> Get()
		{
			return await _child.GetAll();
		}

		// GET api/<ActionController>/5
		[HttpGet("{id}")]
		public async Task<ChildDTO> Get(int id)
		{
			return await _child.GetById(id);
		}

		// POST api/<ActionController>
		[HttpPost]
		public async Task<ChildDTO> Post([FromBody] ChildModel postModel)
		{
			ChildDTO newEntity = new ChildDTO();
			newEntity.Id = postModel.Id;
			newEntity.Name = postModel.Name;
			newEntity.Tz= postModel.Tz;
			newEntity.ParentId = postModel.ParentId;
			newEntity.BirthDate = postModel.BirthDate;
			return await _child.Add(newEntity);
		}

		// PUT api/<ActionController>/5
		[HttpPut("{id}")]
		public async Task<ChildDTO> Put([FromBody] ChildModel postModel)
		{
			ChildDTO newEntity = new ChildDTO();
			newEntity.Id = postModel.Id;
			newEntity.Name = postModel.Name;
			newEntity.Tz= postModel.Tz;
			newEntity.ParentId = postModel.ParentId;
			newEntity.BirthDate = postModel.BirthDate;
			return await _child.Update(newEntity);
		}

		// DELETE api/<ActionController>/5
		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await _child.Delete(id);
		}
	}
}


