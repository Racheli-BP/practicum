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
	public class HealthFundRepository : IEntity<HealthFund>
	{
		IContext _cotext;

		public HealthFundRepository(IContext context)
		{
			_cotext = context;
		}

		public async Task<HealthFund> Add(HealthFund entity)
		{
			EntityEntry<HealthFund> newEntity = _cotext.HealthFunds.Add(entity);
			await _cotext.SaveChangesAsync();
			return newEntity.Entity;
		}

		public async Task Delete(int id)
		{
			_cotext.HealthFunds.Remove(_cotext.HealthFunds.Single(a => a.Id == id));
			await _cotext.SaveChangesAsync();
		}

		public async Task<List<HealthFund>> GetAll()
		{
			return await _cotext.HealthFunds.ToListAsync();
		}

		public async Task<HealthFund> GetById(int id)
		{
			return await _cotext.HealthFunds.SingleAsync(a => a.Id == id);
		}

		public async Task<HealthFund> Update(HealthFund entity)
		{
			await Delete(entity.Id);
			return await Add(entity);
		}
	}
}
