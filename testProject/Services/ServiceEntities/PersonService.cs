using AutoMapper;
using Common;
using Common.DTOs;
using DBContext.Migrations;
using Microsoft.IdentityModel.Tokens;
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
	public class PersonService : IService<PersonDTO>
	{
		private readonly IMapper _mapper;
		private readonly IEntity<Person> _personRepository;

		public PersonService(IMapper mapper, IEntity<Person> personRepository)
		{
			_mapper = mapper;
			_personRepository = personRepository;
		}

		public async Task<PersonDTO> Add(PersonDTO entity)
		{
			if (await IsPersonExists(entity))
				throw new Exception("מספר זהות קיים במערכת");
			else if (!Validations.IsValidTZ(entity.Tz))
				throw new Exception("מספר זהות לא תקין");
			else return _mapper.Map<PersonDTO>(await _personRepository.Add(_mapper.Map<Person>(entity)));
		}

		public async Task Delete(int id)
		{
			await _personRepository.Delete(id);
		}

		public async Task<List<PersonDTO>> GetAll()
		{
			return _mapper.Map<List<PersonDTO>>(await _personRepository.GetAll());
		}

		public async Task<PersonDTO> GetById(int id)
		{
			return _mapper.Map<PersonDTO>(await _personRepository.GetById(id));
		}

		public async Task<PersonDTO> Update(PersonDTO entity)
		{
			return _mapper.Map<PersonDTO>(await _personRepository.Update(_mapper.Map<Person>(entity)));
		}

		public async Task<bool> IsPersonExists(PersonDTO entity)
		{
			return (await _personRepository.GetAll()).FirstOrDefault(a => a.Tz == entity.Tz) is Person;
		}

	}
}
