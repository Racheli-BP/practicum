using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
	public class PersonDTO
	{
		public int Id { get; set; }

		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public string? Tz { get; set; }

		public DateTime? BirthDate { get; set; }

		public int? GenderId { get; set; }

		public int? HealthFundId { get; set; }

	}
}
