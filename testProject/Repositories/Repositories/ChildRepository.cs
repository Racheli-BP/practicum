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
	public class ChildRepository : IEntity<Child>
	{
		IContext _cotext;

		public ChildRepository(IContext context)
		{
			_cotext = context;
		}

		public async Task<Child> Add(Child entity)
		{

			EntityEntry<Child> newEntity = _cotext.Children.Add(entity);
			await _cotext.SaveChangesAsync();
			return newEntity.Entity;
		}

		public async Task Delete(int id)
		{
			_cotext.Children.Remove(_cotext.Children.Single(a => a.Id == id));
			await _cotext.SaveChangesAsync();
		}

		public async Task<List<Child>> GetAll()
		{
			return await _cotext.Children.ToListAsync();
		}

		public async Task<Child> GetById(int id)
		{
			return await _cotext.Children.SingleAsync(a => a.Id == id);
		}

		public async Task<Child> Update(Child entity)
		{
			await Delete(entity.Id);
			return await Add(entity);
		}
	}
}
