namespace WebApi.Models
{
	public class ChildModel
	{
		public int Id { get; set; }

		public string? Name { get; set; }

		public string? Tz { get; set; }

		public DateTime? BirthDate { get; set; }

		public int? ParentId { get; set; }
	}
}
