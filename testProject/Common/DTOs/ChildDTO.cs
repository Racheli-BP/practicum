using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
	public class ChildDTO
	{
		public int Id { get; set; }

		public string? Name { get; set; }

		public string? Tz { get; set; }

		public DateTime? BirthDate { get; set; }

		public int? ParentId { get; set; }

	}
}
