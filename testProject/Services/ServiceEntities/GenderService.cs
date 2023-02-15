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
	public class GenderService : IService<GenderDTO>
	{
		private readonly IMapper _mapper;
		private readonly IEntity<Gender> _genderRepository;

		public GenderService(IMapper mapper, IEntity<Gender> genderRepository)
		{
			_mapper = mapper;
			_genderRepository = genderRepository;
		}

		public async Task<GenderDTO> Add(GenderDTO entity)
		{
			return _mapper.Map<GenderDTO>(await _genderRepository.Add(_mapper.Map<Gender>(entity)));
		}

		public async Task Delete(int id)
		{
			await _genderRepository.Delete(id);
		}

		public async Task<List<GenderDTO>> GetAll()
		{
			return _mapper.Map<List<GenderDTO>>(await _genderRepository.GetAll());
		}

		public async Task<GenderDTO> GetById(int id)
		{
			return _mapper.Map<GenderDTO>(await _genderRepository.GetById(id));
		}

		public async Task<GenderDTO> Update(GenderDTO entity)
		{
			return _mapper.Map<GenderDTO>(await _genderRepository.Update(_mapper.Map<Gender>(entity)));
		}
	}
}
