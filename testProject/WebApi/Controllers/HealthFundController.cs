using Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Services;
using WebApi.Models;

namespace WebApi.Controllers
{
	namespace API.Controllers
	{
		[Route("api/[controller]")]
		[ApiController]
		public class HealthFundController : ControllerBase
		{
			private readonly IService<HealthFundDTO> _healthFund;

			public HealthFundController(IService<HealthFundDTO> healthFund)
			{
				_healthFund = healthFund;
			}


			// GET: api/<ActionController>
			[HttpGet]
			public async Task<List<HealthFundDTO>> Get()
			{
				return await _healthFund.GetAll();
			}

			// GET api/<ActionController>/5
			[HttpGet("{id}")]
			public async Task<HealthFundDTO> Get(int id)
			{
				return await _healthFund.GetById(id);
			}

			// POST api/<ActionController>
			[HttpPost]
			public async Task<HealthFundDTO> Post([FromBody] HealthFundModel postModel)
			{
				HealthFundDTO newEntity = new HealthFundDTO();
				newEntity.Name = postModel.Name;
				return await _healthFund.Add(newEntity);
			}

			// PUT api/<ActionController>/5
			[HttpPut("{id}")]
			public async Task<HealthFundDTO> Put([FromBody] HealthFundModel postModel)
			{
				HealthFundDTO newEntity = new HealthFundDTO();
				newEntity.Name = postModel.Name;
				return await _healthFund.Update(newEntity);
			}

			// DELETE api/<ActionController>/5
			[HttpDelete("{id}")]
			public async Task Delete(int id)
			{
				await _healthFund.Delete(id);
			}
		}
	}

}
