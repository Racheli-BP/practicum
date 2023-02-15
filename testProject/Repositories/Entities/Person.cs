using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities;

public partial class Person
{
	public int Id { get; set; }

	public string? FirstName { get; set; }

	public string? LastName { get; set; }

	public string? Tz { get; set; }

	public DateTime? BirthDate { get; set; }

	[ForeignKey("Gender")]
	public int? GenderId { get; set; }

	[ForeignKey("HealthFund")]
	public int? HealthFundId { get; set; }

	public virtual ICollection<Child> Children { get; }

	public virtual Gender? Gender { get; set; }

	public virtual HealthFund? HealthFund { get; set; }
}
