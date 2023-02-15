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
	public class GenderRepository : IEntity<Gender>
	{
		IContext _cotext;

		public GenderRepository(IContext context)
		{
			_cotext = context;
		}

		public async Task<Gender> Add(Gender entity)
		{
			EntityEntry<Gender> newEntity = _cotext.Genders.Add(entity);
			await _cotext.SaveChangesAsync();
			return newEntity.Entity;
		}

		public async Task Delete(int id)
		{
			_cotext.Genders.Remove(_cotext.Genders.Single(a => a.Id == id));
			await _cotext.SaveChangesAsync();
		}

		public async Task<List<Gender>> GetAll()
		{
			return await _cotext.Genders.ToListAsync();
		}

		public async Task<Gender> GetById(int id)
		{
			return await _cotext.Genders.SingleAsync(a => a.Id == id);
		}

		public async Task<Gender> Update(Gender entity)
		{
			await Delete(entity.Id);
			return await Add(entity);
		}
	}
}
