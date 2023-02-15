using AutoMapper;
using Common.DTOs;
using Repositories.Entities;
using Repositories.Interfaces;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceEntities
{
	public class HealthFundService : IService<HealthFundDTO>
	{
		private readonly IMapper _mapper;
		private readonly IEntity<HealthFund> _healthFundRepository;

		public HealthFundService(IMapper mapper, IEntity<HealthFund> healthFundRepository)
		{
			_mapper = mapper;
			_healthFundRepository = healthFundRepository;
		}

		public async Task<HealthFundDTO> Add(HealthFundDTO entity)
		{
			return _mapper.Map<HealthFundDTO>(await _healthFundRepository.Add(_mapper.Map<HealthFund>(entity)));
		}

		public async Task Delete(int id)
		{
			await _healthFundRepository.Delete(id);
		}

		public async Task<List<HealthFundDTO>> GetAll()
		{
			return _mapper.Map<List<HealthFundDTO>>(await _healthFundRepository.GetAll());
		}

		public async Task<HealthFundDTO> GetById(int id)
		{
			return _mapper.Map<HealthFundDTO>(await _healthFundRepository.GetById(id));
		}

		public async Task<HealthFundDTO> Update(HealthFundDTO entity)
		{
			return _mapper.Map<HealthFundDTO>(await _healthFundRepository.Update(_mapper.Map<HealthFund>(entity)));
		}
	}
}
