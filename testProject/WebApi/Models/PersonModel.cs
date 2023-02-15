namespace WebApi.Models
{
	public class PersonModel
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
