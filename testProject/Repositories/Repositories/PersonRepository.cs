using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repositories.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
	public class PersonRepository : IEntity<Person>	
	{
		IContext _cotext;

		public PersonRepository(IContext context)
		{
			_cotext = context;
		}

		public async Task<Person> Add(Person entity)
		{
			EntityEntry<Person> newEntity = _cotext.People.Add(entity);
			await _cotext.SaveChangesAsync();
			return newEntity.Entity;
		}

		public async Task Delete(int id)
		{
			_cotext.People.Remove(_cotext.People.Single(a => a.Id == id));
			await _cotext.SaveChangesAsync();
		}

		public async Task<List<Person>> GetAll()
		{
			return await _cotext.People.ToListAsync();
		}

		public async Task<Person> GetById(int id)
		{
			return await _cotext.People.SingleAsync(a => a.Id == id);
		}

		public async Task<Person> Update(Person entity)
		{
			await Delete(entity.Id);
			return await Add(entity);
		}
	}
}
