using AutoMapper;
using Common;
using Common.DTOs;
using DBContext;
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
	public class ChildService : IService<ChildDTO>
	{
		private readonly IMapper _mapper;
		private readonly IEntity<Child> _childRepository;

		public ChildService(IMapper mapper, IEntity<Child> childRepository)
		{
			_mapper = mapper;
			_childRepository = childRepository;
		}

		public async Task<ChildDTO> Add(ChildDTO entity)
		{
			if (await IsChildExists(entity))
				throw new Exception("מספר זהות של הילד " + entity.Name + "קיים במערכת");
			else if (!Validations.IsValidTZ(entity.Tz))
				throw new Exception("מספר זהות של הילד " + entity.Name + "לא תקין");
			return _mapper.Map<ChildDTO>(await _childRepository.Add(_mapper.Map<Child>(entity)));
		}

		public async Task Delete(int id)
		{
			await _childRepository.Delete(id);
		}

		public async Task<List<ChildDTO>> GetAll()
		{
			return _mapper.Map<List<ChildDTO>>(await _childRepository.GetAll());
		}

		public async Task<ChildDTO> GetById(int id)
		{
			return _mapper.Map<ChildDTO>(await _childRepository.GetById(id));
		}

		public async Task<ChildDTO> Update(ChildDTO entity)
		{
			return _mapper.Map<ChildDTO>(await _childRepository.Update(_mapper.Map<Child>(entity)));
		}

		public async Task<bool> IsChildExists(ChildDTO entity)
		{
			return (await _childRepository.GetAll()).FirstOrDefault(a => a.Tz == entity.Tz) is Child;
		}


	}
}
